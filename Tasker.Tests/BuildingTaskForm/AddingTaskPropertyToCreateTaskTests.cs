using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Tasker.Tests.BuildingTaskForm
{
    public class AddingTaskToCreateTaskTests
    {
        [Fact(DisplayName = "Add the Task property to the CreateTask.cshtml.cs Class")]
        public void AddingTaskPropertyToCreateTaskTests()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
            + Path.DirectorySeparatorChar + "Pages"
            + Path.DirectorySeparatorChar + "CreateTask.cshtml.cs";

            Assert.True(File.Exists(filePath), "CreateTask.cshtml.cs should exist in the pages folder of the Tasker project.");

            var taskModel = TestHelpers.GetClassType("Tasker.Pages.CreateTaskModel");

            Assert.True(taskModel != null, "`CreateTask` class was not found, ensure `CreateTask.cshtml.cs` contains a `public` class `CreateTask`.");

            var idProperty = taskModel.GetProperty("NewTask");
            Assert.True(idProperty != null && idProperty.PropertyType.Name == "Task", "`Task` class did not contain a `public` `Task` property `NewTask`.");
        }
    }
}
