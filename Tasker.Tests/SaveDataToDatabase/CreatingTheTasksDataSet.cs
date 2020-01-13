using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Tasker.Tests.SaveDataToDatabase
{
    public class CreatingTheTasksDataSet
    {
        [Fact(DisplayName = "Add tasks DbSet to ApplictionDbContext")]
        public void AddConstructorToApplicationDbContextTest()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "ApplicationDbContext.cs";

            Assert.True(File.Exists(filePath), "`ApplicationDbContext.cs` was not found.");

            var applicationDbContext = TestHelpers.GetClassType("Tasker.ApplicationDbContext");

            Assert.True(applicationDbContext != null, "`ApplicationDbContext` class was not found, ensure `ApplicationDbContext.cs` contains a `public` class `ApplicationDbContext`.");
            Assert.True(applicationDbContext.GetProperty("Tasks")?.PropertyType.Name.Contains("DbSet"), "`ApplicationDbContext` was found, but did contain a `property` Tasks of type `DbSet<Task>`.");
        }
    }
}
