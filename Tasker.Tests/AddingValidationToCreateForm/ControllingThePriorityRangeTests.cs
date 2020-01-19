using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace Tasker.Tests.AddingValidationToCreateForm
{
    public class ControllingThePriorityRangeTests
    {
        [Fact(DisplayName = "Controlling the Priority Range Tests @add-priority-validation")]
        public void PriorityRangeTests()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Task.cs";

            Assert.True(File.Exists(filePath), "Task.cs should exist in the Tasker project.");

            var taskModel = TestHelpers.GetClassType("Tasker.Task");

            Assert.True(taskModel != null, "`Task` class was not found, ensure `Task.cs` contains a `public` class `Task`.");

            var descriptionAttributes = taskModel.GetProperty("Priority").GetCustomAttributesData();
            var descriptionMinLength = descriptionAttributes.FirstOrDefault(x => x.AttributeType == typeof(RangeAttribute));

            var arg1 = descriptionMinLength.ConstructorArguments.FirstOrDefault();
            var arg2 = descriptionMinLength.ConstructorArguments.ElementAt(1);
            Assert.True(descriptionMinLength != null && (int)arg1.Value == 1 && (int)arg2.Value == 5, 
                "The `Range` property of the `Task` class should be marked with the `[Range]` attribute with a min value of 1 and a max of value of 5.");
        }
    }
}
