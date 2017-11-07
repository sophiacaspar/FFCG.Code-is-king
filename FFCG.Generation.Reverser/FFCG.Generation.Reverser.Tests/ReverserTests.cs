using Microsoft.VisualStudio.TestTools.UnitTesting;

/**
 * Vända på bokstäverna i ett ord
 * Vända på bokstäverna i varje ord i en mening, men orden ska behålla sin ursprungliga plats
 * Båda ovan, men behålla positionerna på stor/liten bokstav, dvs börjar ett ord med stor bokstav ska det fortfarande göra det när det är vänt
 * 
 * */

namespace FFCG.Generation.Reverser.Tests
{
    [TestClass]
    public class ReverserTests
    {
        private Reverser _reverser;

        [TestInitialize]
        public void SetUp()
        {
            _reverser = new Reverser();
        }

        [TestMethod]
        public void Should_reverse_one_word()
        {
            string result = _reverser.Reverse("hello");
            Assert.AreEqual("olleh", result);
        }

        [TestMethod]
        public void Should_reverse_words_in_sentence_and_keep_them_in_place()
        {
            string result = _reverser.Reverse("hello world");
            Assert.AreEqual("olleh dlrow", result);
        }

        [TestMethod]
        public void Should_keep_uppercase_positions()
        {
            string result = _reverser.Reverse("For the Win");
            Assert.AreEqual("Rof eht Niw", result);
        }

        [TestMethod]
        public void Should_keep_uppercase_positions_on_every_positions()
        {
            string result = _reverser.Reverse("hEllo WorLd");
            Assert.AreEqual("oLleh DlrOw", result);
        }
    }
}