using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class Test_PlatformNotSupported
    {
        [Fact]
        public void WhenPlatformIsSupported_ShouldNotThrow()
        {
            Should.NotThrow(() =>
            {
                OSPlatform supportedPlatform;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    supportedPlatform = OSPlatform.Windows;
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    supportedPlatform = OSPlatform.Linux;
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    supportedPlatform = OSPlatform.OSX;
                }

                GuardAgainst.PlatformNotSupported(supportedPlatform, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenPlatformNotSupported_ShouldNotThrow()
        {
            var ex = Should.Throw<PlatformNotSupportedException>(() =>
            {
                OSPlatform supportedPlatform;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    supportedPlatform = OSPlatform.Linux;
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    supportedPlatform = OSPlatform.OSX;
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    supportedPlatform = OSPlatform.Windows;
                }

                GuardAgainst.PlatformNotSupported(supportedPlatform, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}