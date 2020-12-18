using NUnit.Framework;
using DiceRoller.Models;
using System.Linq;

namespace DiceRollerTests.ModelTests
{
    public class DiceTests
    {
        
        public Dice dice;
        [SetUp]
        public void Setup()
        {
            dice = new Dice();
        }

        [Test]
        public void RollDiceTest()
        {
            int diceResult = dice.Roll();
            bool shouldBeBetween = Enumerable.Range(1, 6).Contains(diceResult);
   
            Assert.IsTrue(shouldBeBetween);
        }

        [Test]
        public void IsSuccessRollSuccessTest()
        {
            int isSuccess = 5;
            bool actual = dice.IsSuccessRoll(isSuccess);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsSuccessRollFailTest()
        {
            int isSuccess = 1;
            bool actual = dice.IsSuccessRoll(isSuccess);

            Assert.IsFalse(actual);
        }

        [Test]
        public void ReRollFailTest()
        {
            dice.DiceResult = 5;
            bool actual = dice.ReRoll(dice);

            Assert.IsFalse(actual);
        }

        [Test]
        public void ReRollSuccessTest()
        {
            dice.DiceResult = 1;
            bool actual = dice.ReRoll(dice);

            Assert.IsTrue(actual);
        }
    }
}