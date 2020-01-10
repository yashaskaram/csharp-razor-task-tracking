using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Tasker.Tests.BuildingTaskForm
{
    public class CreatingTheTaskClassTests
    {
        [Fact(DisplayName = "Create the Task Class")]
        public void CreateIndexPageTest()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Task.cs";

            Assert.True(File.Exists(filePath), "Task.cs should exist in the Tasker project.");

            var taskModel = TestHelpers.GetClassType("Tasker.Task");

            Assert.True(taskModel != null, "`Task` class was not found, ensure `Task.cs` contains a `public` class `Task`.");
            
            var idProperty = taskModel.GetProperty("Id");
            Assert.True(idProperty != null && idProperty.PropertyType == typeof(int), "`Task` class did not contain a `public` `int` property `Id`.");

            var titleProperty = taskModel.GetProperty("Title");
            Assert.True(titleProperty != null && titleProperty.PropertyType == typeof(string), "`Task` class did not contain a `public` `string` property `Title`.");

            var descriptionProperty = taskModel.GetProperty("Description");
            Assert.True(descriptionProperty != null && descriptionProperty.PropertyType == typeof(string), "`Description` class did not contain a `public` `string` property `Description`.");

            var priorityProperty = taskModel.GetProperty("Priority");
            Assert.True(priorityProperty != null && priorityProperty.PropertyType == typeof(int), "`Task` class did not contain a `public` `int` property `Priority`.");
        }
    }
}
