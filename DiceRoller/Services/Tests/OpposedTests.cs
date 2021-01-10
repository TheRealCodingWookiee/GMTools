using DiceRoller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Services.Tests
{
    //An Opposed Test occurs when two characters are in direct conflict  with one another.
    //The winner is the one with the more net hits (successes).
    public class OpposedTests : BaseTest
    {

        public OpposedTests()
        {
        }
        public string GetOpposedTestResult(Character attacker, Character defender)
        {
            string result = "";
            int attackerHits = attacker.DicePool.GetHitsInRolledDicePool(attacker.DicePool.Pool);
            int defenderHits = defender.DicePool.GetHitsInRolledDicePool(defender.DicePool.Pool);
            int netHits = Math.Abs(attackerHits - defenderHits);
            bool isDraw = attackerHits == defenderHits ? true : false;
            Character winner = attackerHits > defenderHits ? attacker : defender;
            bool didWinnerGlitched = IsGlitch(winner.DicePool);

            if (isDraw)
            {
                return "Draw!";
            }

            if (didWinnerGlitched)
            {
                result = $"{winner.Name} wins but glitched {netHits} net hits!";
            }
            else
            {
                result = $"{winner.Name} wins with {netHits} net hits!";
            }        

            return result;
        }

    }
}
