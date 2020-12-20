using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{

    enum DiceSides
    {
        D6 = 6,
        D12 = 12
    }

    public class Dice
    {
        private int _diceSides;
        private int _diceResult;
        private bool _isDieReRolled;

        public Dice()
        {
            _diceSides = (int)DiceSides.D6;
        }
        public int DiceResult 
        { 
            get
            { 
                return _diceResult; 
            }
            set 
            {
                _diceResult = value;
            } 
        }

        public bool IsDieReRolled
        {
            get { return _isDieReRolled; } 
            set { _isDieReRolled = value;  }
        }

        public bool SuccessRoll
        {
            get { return IsSuccessRoll(_diceResult); }         
        }

        public int Roll()
        {
            Random random = new Random();
            int rollResult = random.Next(1, _diceSides);

            _diceResult = rollResult;
            IsSuccessRoll(rollResult);

            return rollResult;
        }

        public bool ReRoll(Dice dice)
        {
            bool reRolled = false;
            if (dice.DiceResult < 5)
            {
                dice.DiceResult = Roll();
                reRolled = true;
                dice.IsDieReRolled = reRolled;                
            }

            return reRolled;
        }

        private bool IsSuccessRoll(int result)
        {
            bool isSuccess = false;
            if (result >= 5)
            {
                isSuccess = true;
            }

            return isSuccess;
        }

    }
}
