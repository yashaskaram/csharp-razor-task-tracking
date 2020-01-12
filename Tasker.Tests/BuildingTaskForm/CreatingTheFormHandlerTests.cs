using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Tasker.Tests.BuildingTaskForm
{
    public class CreatingTheFormHandlerTests
    {
        [Fact(DisplayName = "Create the Form Handler Method")]
        public void CreateFormHandlerMethodTests()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
            + Path.DirectorySeparatorChar + "Pages"
            + Path.DirectorySeparatorChar + "CreateTask.cshtml.cs";

            Assert.True(File.Exists(filePath), "CreateTask.cshtml.cs should exist in the Tasker project.");

            var taskModel = TestHelpers.GetClassType("Tasker.Pages.CreateTaskModel");

            Assert.True(taskModel != null, "`CreateTask.cshtml.cs` class was not found.");
            
            var onPostMethod = taskModel.GetMethod("OnPost");

            Assert.True(onPostMethod != null
                && onPostMethod.ReturnType.Name == "IActionResult"
                && onPostMethod.IsPublic,
                "`Task` class should contain a `public method called OnPost that returns an IActionResult and accepts a Task parameter. The method body should state \"return RedirectToPage(\"Index\")\".");
        }
    }
}
