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
            successTest = new SuccessTest();
        }

        [Test]
        public void GetSuccesTestResultCriticalGlitch()
        {
            List<int> criticalGlitch = new List<int> { 1, 1, 1, 1, 4, 3 };
            List<Dice> dices = CreateDicePool(criticalGlitch);
            DicePool pool = new DicePool(6);
            pool.Pool = dices;


            string expected = "Critical Glitch!";

            string actual = successTest.GetTestResult(pool, 3);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void GetSuccesTestResultGlitch()
        {
            List<int> glitch = new List<int> { 1, 1, 1, 1, 6, 6 };
            List<Dice> dices = CreateDicePool(glitch);
            DicePool pool = new DicePool(6);
            pool.Pool = dices;


            string expected = "Not passed and Glitch!";

            string actual = successTest.GetTestResult(pool, 3);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void GetSuccesTestResultPassedAndGlitch()
        {
            List<int> glitch = new List<int> { 1, 1, 1, 6, 6, 6 };
            List<Dice> dices = CreateDicePool(glitch);
            DicePool pool = new DicePool(6);
            pool.Pool = dices;


            string expected = "Passed with Glitch!";

            string actual = successTest.GetTestResult(pool, 3);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void GetSuccesTestResultPassed()
        {
            List<int> glitch = new List<int> { 1, 1, 4, 6, 6, 6 };
            List<Dice> dices = CreateDicePool(glitch);
            DicePool pool = new DicePool(6);
            pool.Pool = dices;


            string expected = "Passed!";

            string actual = successTest.GetTestResult(pool, 3);

            Assert.IsTrue(expected == actual);
        }
        [Test]
        public void GetSuccesTestResultNotPassed()
        {
            List<int> glitch = new List<int> { 1, 1, 4, 4, 2, 6 };
            List<Dice> dices = CreateDicePool(glitch);
            DicePool pool = new DicePool(6);
            pool.Pool = dices;


            string expected = "Not passed!";

            string actual = successTest.GetTestResult(pool, 3);

            Assert.IsTrue(expected == actual);
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
