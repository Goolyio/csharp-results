using System;
using Xunit;
using FluentAssertions;

namespace CSharpResults.UnitTests
{
    public class ResultTests
    {
        [Fact]
        public void GivenAValidSuccessObject_WhenSuccessIsInvoked_ThenIsSuccessPropertyIsTrue()
        {
            var testData = new TestSuccessClass();
            var result = Result<TestSuccessClass, TestErrorClass>.Success(testData);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void GivenAValidSuccessObject_WhenSuccessIsInvoked_ThenValueIsTheSameAsSuccessObject()
        {
            var testData = new TestSuccessClass();
            var result = Result<TestSuccessClass, TestErrorClass>.Success(testData);
            result.Value.Should().Be(testData);
        }

        [Fact]
        public void GivenAValidSuccessObject_WhenSuccessIsInvoked_ThenAttemptingToAccessTheErrorPropertyThrows()
        {
            var testData = new TestSuccessClass();
            var result = Result<TestSuccessClass, TestErrorClass>.Success(testData);
            Assert.Throws<InvalidOperationException>(() => result.Error);
        }

        [Fact]
        public void GivenANullSuccessObject_WhenSuccessIsInvoked_ThenAnExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => Result<TestSuccessClass, TestErrorClass>.Success(null));
        }

        [Fact]
        public void GivenAValidErrorObject_WhenFailureIsInvoked_ThenIsSuccessPropertyIsFalse()
        {
            var testData = new TestErrorClass();
            var result = Result<TestSuccessClass, TestErrorClass>.Failure(testData);
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void GivenAValidErrorObject_WhenFailureIsInvoked_ThenErrorIsTheSameAsErrorObject()
        {
            var testData = new TestErrorClass();
            var result = Result<TestSuccessClass, TestErrorClass>.Failure(testData);
            result.Error.Should().Be(testData);
        }

        [Fact]
        public void GivenAValidErrorObject_WhenFailureIsInvoked_ThenAttemptingToAccessTheValuePropertyThrows()
        {
            var testData = new TestErrorClass();
            var result = Result<TestSuccessClass, TestErrorClass>.Failure(testData);
            Assert.Throws<InvalidOperationException>(() => result.Value);
        }

        [Fact]
        public void GivenANullErrorObject_WhenFailureIsInvoked_ThenAnExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => Result<TestSuccessClass, TestErrorClass>.Failure(null));
        }

        private class TestSuccessClass { }
        private class TestErrorClass { }
    }
}
