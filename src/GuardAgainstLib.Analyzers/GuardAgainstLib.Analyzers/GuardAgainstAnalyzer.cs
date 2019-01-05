using System;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace GuardAgainstLib.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class GuardAgainstAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "GuardAgainst01";

        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(DiagnosticId,
                                                                                      "Consider using GuardAgainst equivalent.",
                                                                                      "Consider using GuardAgainst equivalent to throw an {0}",
                                                                                      "Refactoring",
                                                                                      DiagnosticSeverity.Info,
                                                                                      isEnabledByDefault: true,
                                                                                      description: "Reduce code size and increase guard clause readability by using GuardAgainst.");

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(_rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterOperationAction(AnalyzeOperation, OperationKind.Throw);
        }

        private static void AnalyzeOperation(OperationAnalysisContext context)
        {
            try
            {
                if (!(context.Operation is IThrowOperation o))
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(o.Exception?.Type?.MetadataName))
                {
                    return;
                }

                if (o.Syntax.Kind() != SyntaxKind.ThrowStatement)
                {
                    return;
                }

                if (o.Parent?.Parent?.Kind == OperationKind.CatchClause)
                {
                    return;
                }

                var exceptionType = o.Exception?.Type?.MetadataName;

                if (string.IsNullOrWhiteSpace(exceptionType) || (exceptionType != typeof(ArgumentException).Name && exceptionType != typeof(ArgumentNullException).Name &&
                                                                 exceptionType != typeof(InvalidOperationException).Name &&
                                                                 exceptionType != typeof(ArgumentOutOfRangeException).Name))
                {
                    return;
                }

                if (o.Parent?.Parent?.Syntax.Kind() != SyntaxKind.IfStatement && o.Parent?.Parent?.Syntax.Kind() != SyntaxKind.ElseClause)
                {
                    return;
                }

                var diagnostic = Diagnostic.Create(_rule, o.Syntax.GetLocation(), o.Exception?.Type?.MetadataName);

                context.ReportDiagnostic(diagnostic);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
