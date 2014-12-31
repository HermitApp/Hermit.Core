using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Hermit.Plugin;

namespace Hermit.Plugin.Tests
{
    public class AppearanceSettingsTest
    {
        public class AccentColorDataTest
        {
            [Fact]
            public void CreateObject()
            {
                AccentColorData accent = new AccentColorData();

                accent.Name = "Red";

                Assert.Equal("Red", accent.Name);
            }
        }
    }
}
