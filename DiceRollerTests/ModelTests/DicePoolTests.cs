using DiceRoller.Models;
using NUnit.Framework;
using System.Collections.Generic;


namespace DiceRollerTests.ModelTests
{
    public class DicePoolTests
    {

        public DicePool sixDicePool;
        public int sixDice;
        [OneTimeSetUp]
        public void Setup()
        {
            sixDice = 6;
            sixDicePool = new DicePool(sixDice);           
        }

        [Test]
        public void CreateDicePoolWith6Test()
        {
            int actual;            

            actual = sixDicePool.GetDicePool.Count;

            Assert.IsTrue(actual == 6);
        }

        [Test]
        public void RollDicePoolWith6Test()
        {
            sixDicePool.RollDicePool();

            int actual = sixDicePool.GetDicePool.FindAll(d => d.DiceResult != 0).Count;

            Assert.IsTrue(actual == 6);
        }

        [Test]
        public void ReRollMissedDicePoolTest()
        {
            Dice missDice = CreateTestDice(1);
            Dice missDice2 = CreateTestDice(4);

            List<Dice> dicePool = new List<Dice> { missDice, missDice2 };

            sixDicePool.ReRollMisses(dicePool);

            Assert.IsTrue(missDice.IsDieReRolled && missDice2.IsDieReRolled);
        }

        [Test]
        public void ReRollSuccessfullDicePoolTest()
        {
            Dice successDice = CreateTestDice(6);
            Dice successDice2 = CreateTestDice(5);

            List<Dice> dicePool = new List<Dice> { successDice, successDice2 };

            sixDicePool.ReRollMisses(dicePool);

            Assert.IsFalse(successDice.IsDieReRolled && successDice2.IsDieReRolled);
        }

        [Test]
        public void GetSuccesesFromDicePoolTest()
        {
            Dice successDice = CreateTestDice(6);
            Dice successDice2 = CreateTestDice(5);
            Dice successDice3 = CreateTestDice(3);
            Dice successDice4 = CreateTestDice(1);
            List<Dice> dicePool = new List<Dice> { successDice, successDice2, successDice3, successDice4 };

            int actual = sixDicePool.GetSuccessesInRolledDicePool(dicePool);


            Assert.IsTrue(actual == 2);

        }

        [Test]
        public void Get1sFromDicePoolTest()
        {
            Dice successDice = CreateTestDice(6);
            Dice successDice2 = CreateTestDice(5);
            Dice successDice3 = CreateTestDice(3);
            Dice successDice4 = CreateTestDice(1);
            List<Dice> dicePool = new List<Dice> { successDice, successDice2, successDice3, successDice4 };

            int actual = sixDicePool.Get1sInRolledDicePool(dicePool);


            Assert.IsTrue(actual == 1);

        }

        private Dice CreateTestDice(int diceResult)
        {
            Dice dice = new Dice();
            dice.DiceResult = diceResult;
            return dice;
        }

    }
}
