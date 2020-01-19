using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Tasker.Tests.AddingValidationToCreateForm
{
    public class MakingTaskPropertiesRequiredTests
    {
        [Fact(DisplayName = "Making the Task Class properties required. @add-required-validation")]
        public void MakingTaskPropertiesRequired()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Task.cs";

            Assert.True(File.Exists(filePath), "Task.cs should exist in the Tasker project.");

            var taskModel = TestHelpers.GetClassType("Tasker.Task");

            Assert.True(taskModel != null, "`Task` class was not found, ensure `Task.cs` contains a `public` class `Task`.");

            var idAttributes = taskModel.GetProperty("Title")?.GetCustomAttributesData();
            Assert.True(idAttributes != null, "The `Task` class should contain a `string` property called `Title`");
            var idRequired = idAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            Assert.True(idRequired != null, "The `Title` property of the `Task` class should be marked with the `[Required]` attribute.");

            var descriptionAttributes = taskModel.GetProperty("Description")?.GetCustomAttributesData();
            Assert.True(descriptionAttributes != null, "The `Task` class should contain a `string` property called `Description`");
            var descriptionRequired = descriptionAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            Assert.True(descriptionRequired != null, "The `Description` property of the `Task` class should be marked with the `[Required]` attribute.");

            var priorityAttributes = taskModel.GetProperty("Priority")?.GetCustomAttributesData();
            Assert.True(priorityAttributes != null, "The `Task` class should contain an `int` property called `Priority`");
            var priorityRequired = priorityAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            Assert.True(priorityRequired != null, "The `Priority` property of the `Task` class should be marked with the `[Required]` attribute.");
        }
    }
}
