using System;
using TNine.Processor.TNineAlphabet;
using TNine.Processor.TNineStringProcessor;
using Xunit;

namespace TNine.Tests
{
    public class TNineStringProcessorTests
    {
        private readonly TNineStringProcessor _nineStringProcessor;

        public TNineStringProcessorTests()
        {
            _nineStringProcessor = new TNineStringProcessor(TNineAlhabetMapType.Latin);
        }

        [Fact]
        public void Process_Foo_CorrectT9Result()
        {
            //Arrange
            string word = "foo";
            bool isLargeDataSet = false;
            string expectedNumbers = "333666 666";

            //Act
            var result = _nineStringProcessor.Process(word, isLargeDataSet);

            //Assert
            Assert.Equal(expectedNumbers, result);
        }

        [Fact]
        public void Process_YesNo_CorrectT9Result()
        {
            //Arrange
            string word = "yes no";
            bool isLargeDataSet = false;
            string expectedNumbers = "999337777066 666";

            //Act
            var result = _nineStringProcessor.Process(word, isLargeDataSet);

            //Assert
            Assert.Equal(expectedNumbers, result);
        }

        [Fact]
        public void Process_HelloWorld_CorrectT9Result()
        {
            //Arrange
            string word = "hello world";
            bool isLargeDataSet = false;
            string expectedNumbers = "4433555 555666096667775553";

            //Act
            var result = _nineStringProcessor.Process(word, isLargeDataSet);

            //Assert
            Assert.Equal(expectedNumbers, result);
        }

        [Fact]
        public void Process_WorldFromLargeDataset_CorrectT9Result()
        {
            //Arrange
            string word = "hddqnetqpduyzoejlmymlfvlkdg";
            bool isLargeDataSet = true;
            string expectedNumbers = "443 3776633877 7388999 9999666335 55569996555333888555 5534";

            //Act
            var result = _nineStringProcessor.Process(word, isLargeDataSet);

            //Assert
            Assert.Equal(expectedNumbers, result);
        }

        [Fact]
        public void Process_Bracket_ArgumentNullException()
        {
            //Arrange
            string word = "[]";
            bool isLargeDataSet = false;

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => _nineStringProcessor.Process(word, isLargeDataSet));
        }

        [Fact]
        public void Process_UpperCase_ArgumentNullException()
        {
            //Arrange
            string word = "WORLD";
            bool isLargeDataSet = false;

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => _nineStringProcessor.Process(word, isLargeDataSet));
        }

        [Fact]
        public void Process_WordFromLargeDataSetOutOfRange_ArgumentOutOfRangeException()
        {
            //Arrange
            string word = "hddqnetqpduyzoejlmymlfvlkdg";
            bool isLargeDataSet = false;

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _nineStringProcessor.Process(word, isLargeDataSet));
        }
    }
}
