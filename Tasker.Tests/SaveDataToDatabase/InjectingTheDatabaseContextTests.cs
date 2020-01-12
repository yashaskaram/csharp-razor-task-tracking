using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace Tasker.Tests.SaveDataToDatabase
{
    public class InjectingTheDatabaseContextTests
    {
        [Fact(DisplayName = "Inject the database context into the CreateTask constructor")]
        public void CreateFormHandlerMethodTests()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
            + Path.DirectorySeparatorChar + "Pages"
            + Path.DirectorySeparatorChar + "CreateTask.cshtml.cs";

            Assert.True(File.Exists(filePath), "CreateTask.cshtml.cs should exist in the Tasker project.");

            var taskModel = TestHelpers.GetClassType("Tasker.Pages.CreateTaskModel");

            Assert.True(taskModel != null, "`CreateTask.cshtml.cs` class was not found.");

            var constructorMethod = taskModel.GetConstructors().FirstOrDefault();

            Assert.True(constructorMethod != null
                && constructorMethod.IsPublic
                && constructorMethod.GetParameters().FirstOrDefault(x => x.ParameterType.Name == "ApplicationDbContext") != null,
                "`CreateTaskModel` class should contain a public constructor that accepts a type of ApplicationDbContext.");

            var field = taskModel.GetField("_context", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.True(field != null 
                && field.FieldType.Name == "ApplicationDbContext"
                && field.IsPrivate,
                "`CreateTaskModel` class should contain a field called `_context` of type ApplicationDbContext.");
        }
    }
}
