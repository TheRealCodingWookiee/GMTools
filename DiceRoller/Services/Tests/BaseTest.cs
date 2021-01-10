using DiceRoller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Services.Tests
{

    public abstract class BaseTest
    {
        //Critical Glitch when Glitch + no hits on the dice pool
        protected bool IsCriticalGlitch(DicePool dicePool)
        {
            bool isCriticalGlitch = false;
            bool isGlitch = IsGlitch(dicePool);

            int hits = dicePool.Pool.Where(d => d.SuccessRoll == true).ToList().Count;

            isCriticalGlitch = (isGlitch && hits == 0) ? true : false;

            return isCriticalGlitch;
        }


        //Glitch when half or more of the dice pool are 1s
        protected bool IsGlitch(DicePool dicePool)
        {
            bool isGlitch = false;
            List<Dice> glitchPool = dicePool.Pool.Where(d => d.DiceResult == 1).ToList();
            int dividedDicePool = DivideDicePoolByTwoAndRoundUp(dicePool);

            isGlitch = glitchPool.Count >= dividedDicePool ? true : false;

            return isGlitch;
        }

        private int DivideDicePoolByTwoAndRoundUp(DicePool dicePool)
        {
            int dividedDicePool = 0;
            dividedDicePool = (int)Math.Round((decimal)(dicePool.DiceCount / 2), MidpointRounding.AwayFromZero);
            return dividedDicePool;
        }
    }
}
