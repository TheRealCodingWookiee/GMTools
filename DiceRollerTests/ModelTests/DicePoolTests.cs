using DiceRoller.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void ReRollDicePoolWith6Test()
        {
            Assert.Pass();
        }

    }
}
