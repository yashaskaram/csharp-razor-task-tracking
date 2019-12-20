using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Tasker.Tests
{
    public class CreateCreateTaskPageTests
    {
        [Fact(DisplayName = "Create the CreateTask Page")]
        public void CreateCreateTaskPageTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "CreateTask.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`CreateTask.cshtml` was not found in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var h1Tag = doc.DocumentNode.Element("h1");

            Assert.True(h1Tag != null && h1Tag.InnerText.Contains("New Task"), 
                "CreateTask.cshtml does not contain an <h1> tag with the text 'New Task'");
        }
    }
}
