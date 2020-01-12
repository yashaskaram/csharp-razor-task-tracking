using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Tasker.Tests.DisplayingDataOnHomePage
{
    public class FilteringTheTasksTests
    {
        [Fact(DisplayName = "Inject the database context into the Index constructor")]
        public void RetrievingTheTasks()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
            + Path.DirectorySeparatorChar + "Pages"
            + Path.DirectorySeparatorChar + "Index.cshtml.cs";

            Assert.True(File.Exists(filePath), "Index.cshtml.cs should exist in the Tasker project.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("Tasks = _context.Tasks.OrderBy(x => x.Priority)"),
                "`Index.cshtml.cs` did not contain a call to `Tasks` on the `ApplicationDbContext` type.");
        }
    }
}
