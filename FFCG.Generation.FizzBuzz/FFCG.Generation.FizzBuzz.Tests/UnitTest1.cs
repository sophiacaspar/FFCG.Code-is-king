using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.Generation.FizzBuzz.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Should_Be_FizzBuzz()
        {
            int testValue = 15;
            var fizzbuzz = new FizzBuzz();
            bool isFizzBuzz = fizzbuzz.IsFizzBuzz(testValue);
            Assert.IsTrue(isFizzBuzz);
        }

        [TestMethod]
        public void Should_Not_Be_FizzBuzz()
        {
            int testValue = 20;
            var fizzbuzz = new FizzBuzz();
            bool isFizzBuzz = fizzbuzz.IsFizzBuzz(testValue);
            Assert.IsFalse(isFizzBuzz);
        }

        [TestMethod]
        public void Should_Be_Fizz()
        {
            int testValue = 9;
            var fizzbuzz = new FizzBuzz();
            bool isFizz = fizzbuzz.IsFizz(testValue);
            Assert.IsTrue(isFizz);
        }

        [TestMethod]
        public void Should_Not_Be_Fizz()
        {
            int testValue = 15;
            var fizzbuzz = new FizzBuzz();
            bool isFizz = fizzbuzz.IsFizz(testValue);
            Assert.IsFalse(isFizz);
        }

        [TestMethod]
        public void Should_Be_Buzz()
        {
            int testValue = 20;
            var fizzbuzz = new FizzBuzz();
            bool isBuzz = fizzbuzz.IsBuzz(testValue);
            Assert.IsTrue(isBuzz);
        }

        [TestMethod]
        public void Should_Not_Be_Buzz()
        {
            int testValue = 15;
            var fizzbuzz = new FizzBuzz();
            bool isBuzz = fizzbuzz.IsBuzz(testValue);
            Assert.IsFalse(isBuzz);
        }
    }
}
