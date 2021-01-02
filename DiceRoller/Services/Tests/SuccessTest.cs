using DiceRoller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller.Services.Tests
{
    //A  Success  Test  is  the  standard  test  to  see  if  a  character
    //can accomplish a given task, and how well. 
    //The rolled dice pool must meet or exceed the threshold to be successfull
    public class SuccessTest : ITest
    {

        public SuccessTest()
        {
        }

        public string GetSuccessTestResult(DicePool dicePool, int threshold)
        {
            string thresholdResult = "";

            bool criticalGlitch = IsCriticalGlitch(dicePool);
            bool isGlitch = IsGlitch(dicePool);
            bool thresholdPassed = IsThresholdPassed(dicePool.Pool, threshold);

            if (criticalGlitch)
            {
                thresholdResult = "Critical Glitch!";
            }
            else if(isGlitch && !thresholdPassed)
            {
                thresholdResult = "Not passed and Glitch!";
            }
            else if (thresholdPassed && isGlitch)
            {
                thresholdResult = "Passed with Glitch!";
            }
            else if (thresholdPassed)
            {
                thresholdResult = "Passed!";
            }
            else if(!thresholdPassed)
            {
                thresholdResult = "Not passed!";
            }

            return thresholdResult;
        }

        public bool IsThresholdPassed(List<Dice> dicePool, int threshold)
        {
            bool passed = false;
            int hitsCount = dicePool.Where(d => d.SuccessRoll == true).ToList().Count();
            if (hitsCount >= threshold)
            {
                passed = true;
            }

            return passed;           
        }
        //Critical Glitch when Glitch + no hits on the dice pool
        public bool IsCriticalGlitch(DicePool dicePool)
        {
            bool isCriticalGlitch = false;
            bool isGlitch = IsGlitch(dicePool);

            int hits = dicePool.Pool.Where(d => d.SuccessRoll == true).ToList().Count;

            isCriticalGlitch = (isGlitch && hits == 0) ? true : false; 

            return isCriticalGlitch;
        }
        //Glitch when half or more of the dice pool are 1s
        public bool IsGlitch(DicePool dicePool)
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
            dividedDicePool = (int) Math.Round((decimal)(dicePool.DiceCount/2), MidpointRounding.AwayFromZero);
            return dividedDicePool;
		}
    }
}
