using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Tasker.Tests.BuildingTaskForm
{
    public class CreatingTheFormInputsTests
    {
        [Fact(DisplayName = "Create the Form Inputs")]
        public void CreateTheFormInputTagsTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "CreateTask.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "CreateTask.cshtml should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var labels = new[] { "Title", "Description", "Priority" };

            foreach(var label in labels)
            {
                var parsedLabel = doc.DocumentNode.Descendants("label").FirstOrDefault(x => x.InnerText.Contains(label));
                Assert.True(parsedLabel != null, $"CreateTask.cshtml should contain a label with the text of '{label}'");

                Assert.True(parsedLabel.Attributes.Contains(@"asp-for"),
                    $"CreateTask.cshtml should contain a `label` tag with an asp-for=\"NewTask.{label}\" tag helper.");

                Assert.True(parsedLabel.Attributes[@"asp-for"].Value == $"NewTask.{label}",
                    $"CreateTask.cshtml should contain a `label` tag with an asp-for tag helper with a value of NewTask.{label}.");

                var parsedInput = doc.DocumentNode.Descendants("input")
                    .FirstOrDefault(x => x.Attributes[@"asp-for"]?.Value == $"NewTask.{label}" && x.Attributes[@"type"]?.Value == "text");
                Assert.True(parsedInput != null, $"CreateTask.cshtml should contain an input with attributes asp-for=\"NewTask.{label}\" and type=\"text\"");
            }
        }
    }
}
