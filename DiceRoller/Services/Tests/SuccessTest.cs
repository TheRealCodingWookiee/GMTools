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
    public class SuccessTest : BaseTest
    {

        public SuccessTest()
        {
        }

        public string GetTestResult(DicePool dicePool, int threshold)
        {
            string thresholdResult = "";

            bool criticalGlitch = IsCriticalGlitch(dicePool);
            bool isGlitch = IsGlitch(dicePool);
            bool thresholdPassed = IsThresholdPassed(dicePool.Pool, threshold);

            if (criticalGlitch)
            {
                thresholdResult = "Critical Glitch!";
            }
            else if (isGlitch && !thresholdPassed)
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
            else if (!thresholdPassed)
            {
                thresholdResult = "Not passed!";
            }

            return thresholdResult;
        }

        private bool IsThresholdPassed(List<Dice> dicePool, int threshold)
        {
            bool passed = false;
            int hitsCount = dicePool.Where(d => d.SuccessRoll == true).ToList().Count();
            if (hitsCount >= threshold)
            {
                passed = true;
            }

            return passed;
        }
    }
}
