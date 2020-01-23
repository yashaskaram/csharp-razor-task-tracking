using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Tasker.Tests.AddingValidationToCreateForm
{
    public class DisplayingTheValidationErrorsTests
    {
        [Fact(DisplayName = "Displaying the Validation Errors. @display-validation-errors")]
        public void DisplayingTheValidationErrors()
        {
            // Get appropriate path to file for the current operating system
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "CreateTask.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`CreateTask.cshtml` should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var divTags = doc.DocumentNode.Descendants("div");
            var validationSummary = divTags.FirstOrDefault(x => x.Attributes["asp-validation-summary"]?.Value == "All");

            Assert.True(validationSummary != null,
                "`CreateTask.cshtml` should contain a `div` with the `asp-validation-summary` tag helper with a value of `All`.");
        }
    }
}
