using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Tasker.Tests.CreatingTheLayoutAndNavigation
{
    public class LayoutRenderBodyTests
    {
        [Fact(DisplayName = "Rendering Content in the Layout File @render-body-content")]
        public void LayoutRenderBodyTest()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker" 
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Shared"
                + Path.DirectorySeparatorChar + "_Layout.cshtml";

            Assert.True(File.Exists(filePath), "`_Layout.cshtml` should exist in the the Pages/Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var mainTag = doc.DocumentNode.Descendants("main").FirstOrDefault();

            Assert.True(mainTag.InnerText.Contains("@RenderBody()"),
                "The `main` tag inside `_Layout.cshtml` should contain the `@RenderBody()` directive to render the current page.");
        }
    }
}
