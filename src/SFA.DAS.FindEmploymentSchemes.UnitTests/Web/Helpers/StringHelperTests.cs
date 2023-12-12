﻿using SFA.DAS.FindEmploymentSchemes.Web.Helpers;
using Xunit;

namespace SFA.DAS.FindEmploymentSchemes.UnitTests.Web.Helpers
{

    public class StringHelperTests
    {

        [Theory]
        [InlineData("item1,item2,item3", ',', new[] { "item1", "item2", "item3" })]
        [InlineData("123,456,789", ',', new[] { "123", "456", "789" })]
        [InlineData("", ',', new string[] { })]
        [InlineData(null, ',', new string[] { })]
        [InlineData("item1", ',', new[] { "item1" })]
        public void SplitAndReturnList_ShouldReturnCorrectArray(string input, char separator, string[] expected)
        {

            var result = StringHelper.SplitAndReturnList(input, separator);

            Assert.Equal(expected, result);

        }

    }

}
