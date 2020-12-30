using DiceRoller.Models;
using DiceRoller.Services.Tests;
using NUnit.Framework;
using System.Collections.Generic;

namespace DiceRollerTests.ServiceTests
{
    public class SuccessTestTests
    {

        public DicePool dicePool;
        public SuccessTest successTest;

        [OneTimeSetUp]
        public void Setup()
        {
            dicePool = new DicePool(6);
            successTest = new SuccessTest(dicePool);
        }

        [Test]
        public void PassThresholdTest()
        {
            int threshold = 3;
            successTest.Threshold = threshold;
            List<int> results = new List<int> { 2, 5, 6, 5, 5 };
            List<Dice> dicePool = CreateDicePool(results);

            bool passed = successTest.IsThresholdPassed(dicePool);


            Assert.IsTrue(passed);
        }

        [Test]
        public void FailThresholdTest()
        {
            int threshold = 3;
            successTest.Threshold = threshold;
            List<int> results = new List<int> { 2, 5, 5, 2, 3, 4 };
            List<Dice> dicePool = CreateDicePool(results);

            bool passed = successTest.IsThresholdPassed(dicePool);


            Assert.IsFalse(passed);
        }

        [Test]
        public void GlitchOnRolledDicePoolTest()
		{
            
            successTest.IsGlitch();
            Assert.Pass();

        }


        private Dice CreateTestDice(int diceResult)
        {
            Dice dice = new Dice();
            dice.DiceResult = diceResult;
            return dice;
        }

        private List<Dice> CreateDicePool(List<int> results)
        {
            List<Dice> dicePool = new List<Dice>();

            foreach (int result in results)
            {
                dicePool.Add(CreateTestDice(result));
            }

            return dicePool;
        }

    }
}
