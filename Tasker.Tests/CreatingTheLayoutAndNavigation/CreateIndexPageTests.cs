using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Tasker.Tests.CreatingTheLayoutAndNavigation
{
    public class CreateIndexPageTests
    {
        [Fact(DisplayName = "Create the Index Page")]
        public void CreateIndexPageTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Index.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "Index.cshtml should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var h1Tag = doc.DocumentNode.Element("h1");

            Assert.True(h1Tag != null && h1Tag.InnerText.Contains("All Tasks"), 
                "_Layout.cshtml shoud contain an <h1> tag with the text 'All Tasks'.");
        }
    }
}
