using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Tasker.Tests.SaveDataToDatabase
{
    public class SavingTheNewTaskTests
    {
        [Fact(DisplayName = "Saving the tasks")]
        public void SavingTheTasks()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "pages"
                + Path.DirectorySeparatorChar + "CreateTask.cshtml.cs";

            Assert.True(File.Exists(filePath), "`CreateTask.cshtml.cs` was not found.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains(@"_context.Tasks.Add(NewTask)"),
                "`OnPost` did not contain a call to _context.Tasks.Add(NewTask).");

            Assert.True(file.Contains("_context.SaveChanges()") || file.Contains("_context.Tasks.Add(NewTask).SaveChanges()"), 
                "`OnPost` did not contain a call to _context.SaveChanges().");
        }
    }
}
