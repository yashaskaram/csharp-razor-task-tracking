using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Tasker.Tests.SaveDataToDatabase
{
    public class RegisteringTheDatabaseContextClass
    {
        [Fact(DisplayName = "Register the database conext @registering-dbcontext-startup")]
        public void RegisterTheDatabaseContextTest()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
                    + Path.DirectorySeparatorChar + "startup.cs";

            Assert.True(File.Exists(filePath), "`startup.cs` was not found.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("services.AddDbContext<ApplicationDbContext>"), 
                "`Startup.cs`'s `Configure` did not contain a call to `ApplicationDbContext` with the `ApplicationDbContext` type.");
            Assert.True(file.Contains(@"options => options.UseInMemoryDatabase"), 
                @"`Startup.cs`'s `Configure` called `AddDbContext` but did not provide it the argument `options => options.UseInMemoryDatabase(""Tasker"")`.");
        }
    }
}
