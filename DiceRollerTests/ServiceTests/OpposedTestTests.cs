using DiceRoller.Models;
using DiceRoller.Services.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRollerTests.ServiceTests
{
    public class OpposedTestTests
    {
        public DicePool attackerPool;
        public DicePool defenderPool;
        public Character attacker;
        public Character defender;
        public OpposedTests opposedTest;

        [OneTimeSetUp]
        public void Setup()
        {
            opposedTest = new OpposedTests();   
        }

        [Test]
        public void AttackerWinsTest()
        {
            List<int> fourHitsPool = new List<int> { 4, 2, 6, 5, 5, 6 };
            List<int> threeHitsPool = new List<int> { 4, 2, 3, 5, 5, 6 };

            attacker = CreateCharacterWithPool("Marlin the Mage" ,fourHitsPool);
            defender = CreateCharacterWithPool("Enemy", threeHitsPool);

            string result = opposedTest.GetOpposedTestResult(attacker, defender);
            Assert.IsTrue(result == "Marlin the Mage wins with 1 net hits!");
        }

        [Test]
        public void AttackerWinsWithGlitchTest()
        {
            List<int> fourHitsPool = new List<int> { 1, 1, 1, 5, 5, 6 };
            List<int> threeHitsPool = new List<int> { 4, 2, 6, 6, 5, 6 };

            attacker = CreateCharacterWithPool("Marlin the Mage", fourHitsPool);
            defender = CreateCharacterWithPool("Enemy", threeHitsPool);

            string result = opposedTest.GetOpposedTestResult(attacker, defender);
            Assert.IsTrue(result == "Enemy wins with 1 net hits!");
        }

        [Test]
        public void DefenderWinsTest()
        {
            List<int> fourHitsPool = new List<int> { 1, 1, 4, 4, 5, 6 };
            List<int> threeHitsPool = new List<int> { 4, 2, 5, 6, 6, 6 };

            attacker = CreateCharacterWithPool("Marlin the Mage", fourHitsPool);
            defender = CreateCharacterWithPool("Enemy", threeHitsPool);

            string result = opposedTest.GetOpposedTestResult(attacker, defender);
            Assert.IsTrue(result == "Enemy wins with 2 net hits!");
        }

        [Test]
        public void DrawTest()
        {
            List<int> fourHitsPool = new List<int> { 1, 1, 4, 4, 5, 6 };
            List<int> threeHitsPool = new List<int> { 4, 2, 5, 4, 2, 6 };

            attacker = CreateCharacterWithPool("Marlin the Mage", fourHitsPool);
            defender = CreateCharacterWithPool("Enemy", threeHitsPool);

            string result = opposedTest.GetOpposedTestResult(attacker, defender);
            Assert.IsTrue(result == "Draw!");
        }




        private Character CreateCharacterWithPool(string name, List<int> pool)
        {
            Character character = new Character(name, 6);
            character.DicePool.Pool = CreateDicePool(pool);
            return character;
        }

        private Dice CreateTestDice(int diceResult)
        {
            Dice dice = new Dice();
            dice.DiceResult = diceResult;
            return dice;
        }

        private List<Dice> CreateDicePool(List<int> results)
        {
            List<Dice> pool = new List<Dice>();

            foreach (int result in results)
            {
                pool.Add(CreateTestDice(result));
            }

            return pool;
        }

    }
}
