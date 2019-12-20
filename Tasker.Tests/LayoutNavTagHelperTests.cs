using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Tasker.Tests
{
    public class LayoutNavTagHelperTests
    {
        [Fact(DisplayName = "Updating the Navigation Links")]
        public void IndexPageTagHelperTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = TestHelpers.GetRootString() + "Tasker" 
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Shared"
                + Path.DirectorySeparatorChar + "_Layout.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`_Layout.cshtml` should exist in the Pages/Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var aTags = doc.DocumentNode.Descendants("a");
            var indexLink = aTags.FirstOrDefault(x => x.Attributes["asp-page"]?.Value == "Index");
            var createLink = aTags.FirstOrDefault(x => x.Attributes["asp-page"]?.Value == "CreateTask");

            Assert.True(indexLink != null && createLink != null, 
                "_Layout.cshtml should contain navigation <a> tags with tag helpers pointing to the Index and CreateTask pages.");
        }
    }
}
