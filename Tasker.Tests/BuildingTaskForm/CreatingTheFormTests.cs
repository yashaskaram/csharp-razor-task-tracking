using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Tasker.Tests.BuildingTaskForm
{
    public class CreatingTheFormTests
    {
        [Fact(DisplayName = "Create the Form")]
        public void CreateTheFormTagTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "CreateTask.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "CreateTask.cshtml should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var formTag = doc.DocumentNode.Element("form");
            Assert.True(formTag != null, "CreateTask.cshtml should contain an `<form>` tag.");

            Assert.True(formTag.Attributes.Contains(@"asp-page"),
                "CreateTask.cshtml should contain a `<form>` tag with an asp-for tag helper");

            Assert.True(formTag.Attributes[@"asp-page"].Value == "CreateTask",
                "CreateTask.cshtml should contain a `<form>` tag with an asp-for tag helper with a value of CreateTask.");

            Assert.True(formTag.Attributes.Contains(@"method"),
                "CreateTask.cshtml should contain a `<form>` tag wth the method attribute");

            Assert.True(formTag.Attributes[@"method"].Value == "post",
                "CreateTask.cshtml should contain a `<form>` tag wth a method attribute with a value of post.");
        }
    }
}
