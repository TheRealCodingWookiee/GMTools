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

        private int _threshold;
        private bool _isTestSuccessfull;
        private DicePool _dicePool;

        public SuccessTest(DicePool dicePool)
        {
            _dicePool = dicePool;
        }

        public int Threshold 
        { 
            get { return _threshold; } 
            set { _threshold = value; } 
        }


        public bool IsThresholdPassed(List<Dice> dicePool)
        {
            bool passed = false;

            if (_dicePool.GetHitsInRolledDicePool(dicePool) >= _threshold)
            {
                passed = true;
            }

            return passed;           
        }

        public bool IsCriticalGlitch()
        {
            throw new NotImplementedException();
        }

        public bool IsGlitch()
        {
            throw new NotImplementedException();
        }
    }
}
