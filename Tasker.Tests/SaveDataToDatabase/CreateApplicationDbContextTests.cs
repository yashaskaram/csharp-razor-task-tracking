using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tasker.Tests;
using Xunit;

namespace Tasker.Tests.SaveDataToDatabase
{
    public class CreateApplicationDbContextTests
    {
        [Fact(DisplayName = "Create ApplicationDbContext class @create-context-class")]
        public void CreateApplicationDbContextTest()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
                + Path.DirectorySeparatorChar + "ApplicationDbContext.cs";

            Assert.True(File.Exists(filePath), "`ApplicationDbContext.cs` was not found.");

            var applicationDbContext = TestHelpers.GetClassType("Tasker.ApplicationDbContext");

            Assert.True(applicationDbContext != null, "`ApplicationDbContext` class was not found, ensure `ApplicationDbContext.cs` contains a `public` class `ApplicationDbContext`.");
            Assert.True(applicationDbContext.BaseType == typeof(DbContext), "`ApplicationDbContext` was found, but did not inherit the `DbContext` class. (this will require a using directive for the `Microsoft.EntityFrameWorkCore` namespace)");

            var constructor = applicationDbContext.GetConstructor(new Type[] { typeof(DbContextOptions) });
            Assert.True(constructor != null, "`ApplicationDbContext` does not appear to contain a constructor accepting a parameter of type `DbContextOptions<ApplicationDbContext>`");
        }
    }
}
