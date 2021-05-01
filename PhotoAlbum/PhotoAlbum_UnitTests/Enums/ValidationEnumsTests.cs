using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Enums;

namespace PhotoAlbum_UnitTests.Enums
{
    /// <summary>
    /// Summary description for ValidationEnums
    /// </summary>
    [TestClass]
    public class ValidationEnumsTests
    {
        [TestMethod]
        public void ValidationEnums_WhenGetNamesCalled_ReturnsCorrectEnums()
        {
            List<string> expectedEnums = new List<string>()
            {
                "NullOrEmptyValidator",
                "CanBeConvertedToIntValidator"
            };

            List<string> actualEnums = Enum.GetNames(typeof(ValidationEnums)).ToList();

            Assert.AreEqual(expectedEnums.Count, actualEnums.Count);
            for (int i = 0; i < actualEnums.Count; i++)
            {
                Assert.AreEqual(expectedEnums[i], actualEnums[i]);
            }
        }
    }
}
