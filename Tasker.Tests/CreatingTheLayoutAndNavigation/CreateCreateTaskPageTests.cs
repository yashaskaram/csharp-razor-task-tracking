using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Tasker.Tests.CreatingTheLayoutAndNavigation
{
    public class CreateCreateTaskPageTests
    {
        [Fact(DisplayName = "Create the CreateTask Page @create-createtask-page")]
        public void CreateCreateTaskPageTest()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "CreateTask.cshtml";

            Assert.True(File.Exists(filePath), "CreateTask.cshtml should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var h1Tag = doc.DocumentNode.Element("h1");

            Assert.True(h1Tag != null && h1Tag.InnerText.Contains("New Task"), 
                "CreateTask.cshtml should contain an <h1> tag with the text 'New Task'");
        }
    }
}
