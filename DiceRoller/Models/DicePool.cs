using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class DicePool
    {
        private List<Dice> _dicePool;
        private List<int> _rolledDicePool;
        private int _diceCount;

        public DicePool(int diceCount)
        {
            _diceCount = diceCount;
            _dicePool = CreateDicePool(_diceCount);
        }

        public List<Dice> GetDicePool 
        {
            get { return _dicePool; } 
        }

        public List<int> RolledDicePool 
        { 
            get { return _rolledDicePool; }
            set { _rolledDicePool = ReturnDiceResultsAsInt(_dicePool); }
        }

        public List<int> RollDicePool()
        {
            foreach (Dice dice in _dicePool)
            {
                dice.Roll();
            }

            return ReturnDiceResultsAsInt(_dicePool);
        }

        private List<int> ReturnDiceResultsAsInt(List<Dice> dicePool)
        {
            List<int> converted = new List<int>();
            foreach (Dice dice in dicePool)
            {
                converted.Add(dice.DiceResult);
            }

            return converted;
        }

        public List<Dice> ReRollMisses(List<Dice> dicePool)
        {

            foreach (Dice dice in dicePool)
            {
                bool isSuccess = dice.SuccessRoll;
                if (!isSuccess)
                {
                    dice.ReRoll(dice);
                }
            }

            return dicePool;
        }

        private List<Dice> CreateDicePool(int diceCount)
        {
            List<Dice> pool = new List<Dice>();

            while (diceCount > 0)
            {
                pool.Add(new Dice());
                --diceCount;
            }

            return pool;
        }
    }
}
