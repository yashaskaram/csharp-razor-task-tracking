using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Tasker.Tests.DisplayingDataOnHomePage
{
    public class CreatingTheTasksPropertyTests
    {
        [Fact(DisplayName = "Create the Tasks property on the Index.cshtml.cs class @task-property-index")]
        public void CreateTheTasksProperty()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
            + Path.DirectorySeparatorChar + "Pages"
            + Path.DirectorySeparatorChar + "Index.cshtml.cs";

            Assert.True(File.Exists(filePath), "Index.cshtml.cs should exist in the Tasker project.");

            var indexModel = TestHelpers.GetClassType("Tasker.Pages.IndexModel");

            Assert.True(indexModel != null, "`Index.cshtml.cs` class was not found.");

            var tasksProperty = indexModel.GetProperty("Tasks");

            Assert.True(tasksProperty != null
                && tasksProperty.Name== "Tasks"
                && tasksProperty.PropertyType.IsPublic
                && tasksProperty.PropertyType.Name == "IEnumerable`1",
                "`IndexModel` class should contain a property called `Tasks` of type IEnumerable<Task>.");
        }
    }
}
