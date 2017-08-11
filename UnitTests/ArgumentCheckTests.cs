using System;
using FileIt.Common;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class ArgumentCheckTests
    {
        private readonly SingleArgumentPathChecker _checker;
        private readonly ArgumentCheckLibrary _checkLibrary;
        public ArgumentCheckTests()
        {
            _checker = new SingleArgumentPathChecker();
            _checkLibrary = new ArgumentCheckLibrary();
        }

        [Test]
        public void SingleArgumentPathCheck_WithCorrectPath_NoExceptions()
        {
            //Arrange
            string[] args = {"user_option", @"c:\windows"};

            //Act
            _checker.CheckArgument(args);

            //Assert
            // (no exceptions)
        }

        [Test]
        public void SingleArgumentPathCheck_LackingArgument_ArgumentException()
        {
            //Arrange
            string[] args = {"user_option"};

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => _checker.CheckArgument(args));
        }

        [Test]
        public void SingleArgumentPathCheck_InvalidPath_ArgumentException()
        {
            //Arrange
            string[] args = {"user_option", "c:/asdfasdfasdf"};

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => _checker.CheckArgument(args));
        }

        [Test]
        public void CheckIsPattern_CorrectArgument_NoException()
        {
            //Arrange
            //Act
            //Assert
            _checkLibrary.CheckIsPattern("*.txt");
        }

        [Test]
        public void CheckIsPattern_ArgumentIsNotAPattern_ArgumentException()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => _checkLibrary.CheckIsPattern("txt"));

        }

        [Test]
        public void CheckAtLeastNumberOfArguments_1argProvided_NoException()
        {
            //Arrange
            string[] args = {"user-option", "arg1"};
            //Act
            //Assert
            _checkLibrary.CheckHasAtLeastNumberOfArguments(args, 1);
        }

        [Test]
        public void CheckAtleastNumberOfArguments_NoArgumentsGiven_ExceptionCast()
        {
            //Arrange
            string[] args = {"user-option"};
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => _checkLibrary.CheckHasAtLeastNumberOfArguments(args, 1));

        }
    }
}
