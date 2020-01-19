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
    public class ControllingTheDescriptionLengthTests
    {
        [Fact(DisplayName = "Controlling the Description Length @add-length-validation")]
        public void DescriptionLengthTests()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "Task.cs";

            Assert.True(File.Exists(filePath), "Task.cs should exist in the Tasker project.");

            var taskModel = TestHelpers.GetClassType("Tasker.Task");

            Assert.True(taskModel != null, "`Task` class was not found, ensure `Task.cs` contains a `public` class `Task`.");

            var descriptionAttributes = taskModel.GetProperty("Description")?.GetCustomAttributesData();
            Assert.True(descriptionAttributes != null, "The `Task` class should contain a `string` property called `Description`");
            
            var descriptionMinLength = descriptionAttributes.FirstOrDefault(x => x.AttributeType == typeof(MinLengthAttribute));
            Assert.True(descriptionMinLength != null, "The `Description` property of the `Task` class should be marked with the `[MinLength]` attribute.");

            var arg = descriptionMinLength.ConstructorArguments.FirstOrDefault();
            Assert.True(descriptionMinLength != null && (int)arg.Value == 10, "The `Description` property of the `Task` class should be marked with the `[MinLength]` attribute.");
        }
    }
}
