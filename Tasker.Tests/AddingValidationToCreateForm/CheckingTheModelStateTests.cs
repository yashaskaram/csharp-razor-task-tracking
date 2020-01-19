using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace Tasker.Tests.AddingValidationToCreateForm
{
    public class CheckingTheModelStateTests
    {
        [Fact(DisplayName = "The CreateTask should check the form Model State. @check-model-state")]
        public void CheckingTheModelState()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
            + Path.DirectorySeparatorChar + "Pages"
            + Path.DirectorySeparatorChar + "CreateTask.cshtml.cs";

            Assert.True(File.Exists(filePath), "CreateTask.cshtml.cs should exist in the Tasker project.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            var pattern = @"\s*?if\s*?\(\s*?!ModelState.IsValid\s*?\)\s*?{\s*?return\s*?Page\(\);\s*?}";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`CreateTask.cshtmlcs` does not appear to contain a conditional to check if the ModelState is valid.");
        }
    }
}
