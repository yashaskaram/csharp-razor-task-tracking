using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Tasker.Tests
{
    public class CreateIndexViewTests
    {
        [Fact(DisplayName = "Create the Index Page")]
        public void CreateIndexViewTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = TestHelpers.GetRootString() + "Tasker" + Path.DirectorySeparatorChar + "Pages" + Path.DirectorySeparatorChar + "Index.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`Index.cshtml` was not found in the Pages folder.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }
            var pattern = "<h1>All Tasks</h1>";
            Assert.True(file.Contains(pattern), "`Index.cshtml` was found, but does not appear to contain both an opening and closing `h1` tag.");
        }
    }
}
