using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace Tasker.Tests.DisplayingDataOnHomePage
{
    public class InjectingTheDatabaseContextTests
    {
        [Fact(DisplayName = "Inject the database context into the Index constructor")]
        public void CreateFormHandlerMethodTests()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
            + Path.DirectorySeparatorChar + "Pages"
            + Path.DirectorySeparatorChar + "Index.cshtml.cs";

            Assert.True(File.Exists(filePath), "Index.cshtml.cs should exist in the Tasker project.");

            var taskModel = TestHelpers.GetClassType("Tasker.Pages.IndexModel");

            Assert.True(taskModel != null, "`Index.cshtml.cs` class was not found.");

            var constructorMethod = taskModel.GetConstructors().FirstOrDefault();

            Assert.True(constructorMethod != null
                && constructorMethod.IsPublic
                && constructorMethod.GetParameters().FirstOrDefault(x => x.ParameterType.Name == "ApplicationDbContext") != null,
                "`IndexModel` class should contain a public constructor that accepts a type of ApplicationDbContext.");

            var field = taskModel.GetField("_context", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.True(field != null
                && field.FieldType.Name == "ApplicationDbContext"
                && field.IsPrivate,
                "`IndexModel` class should contain a field called `_context` of type ApplicationDbContext.");
        }
    }
}
