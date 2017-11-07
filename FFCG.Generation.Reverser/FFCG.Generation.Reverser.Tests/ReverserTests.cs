using Microsoft.VisualStudio.TestTools.UnitTesting;

/**
 * V�nda p� bokst�verna i ett ord
 * V�nda p� bokst�verna i varje ord i en mening, men orden ska beh�lla sin ursprungliga plats
 * B�da ovan, men beh�lla positionerna p� stor/liten bokstav, dvs b�rjar ett ord med stor bokstav ska det fortfarande g�ra det n�r det �r v�nt
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