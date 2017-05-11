using System;
using WebApiCaller.Core;
using WebApiCaller.UnitTests.Dto;
using Xunit;

namespace WebApiCaller.UnitTests
{
    public class StringParserTests
    {
        [Fact]
        public void StringParser_IsRelation_NotRelationForString()
        {
            ExecuteIsReferenceTypeTest<string>(false);
        }

        [Fact]
        public void StringParser_IsRelation_NotRelationForDatetime()
        {
            ExecuteIsReferenceTypeTest<DateTime>(false);
        }

        [Fact]
        public void StringParser_IsRelation_NotRelationForInt()
        {
            ExecuteIsReferenceTypeTest<int>(false);
        }

        [Fact]
        public void StringParser_IsRelation_NotRelationForFloat()
        {
            ExecuteIsReferenceTypeTest<float>(false);
        }

        [Fact]
        public void StringParser_IsRelation_TrueForTestClassObject()
        {
            ExecuteIsReferenceTypeTest<InputDto>(true);
        }

        private void ExecuteIsReferenceTypeTest<T>(bool expectedResult)
        {
            var isRelation = StringParser.IsSerializable<T>();

            Assert.Equal(expectedResult, isRelation);
        }
    }
}