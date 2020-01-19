using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Tasker.Tests.BuildingTaskForm
{
    public class CreatingTheFormSubmitTests
    {
        [Fact(DisplayName = "Completing the Form @create-form-submit")]
        public void CreateTheFormSubmitTagsTest()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "CreateTask.cshtml";

            Assert.True(File.Exists(filePath), "CreateTask.cshtml should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var parsedInput = doc.DocumentNode.Descendants("input")
                .FirstOrDefault(x => x.Attributes[@"type"]?.Value == "submit");
            Assert.True(parsedInput != null, $"CreateTask.cshtml should contain an input with the attribute type=\"Text\".");
        }
    }
}
