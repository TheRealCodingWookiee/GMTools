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
        private readonly int _diceCount;

        public DicePool(int diceCount)
        {
            _diceCount = diceCount;
            _dicePool = CreateDicePool(_diceCount);
        }

        public List<Dice> Pool 
        {
            get { return _dicePool; }
            set { _dicePool = value; }
        }

        public int DiceCount
		{
            get { return _diceCount; }
		}

        public List<Dice> RollDicePool()
        {
            foreach (Dice dice in _dicePool)
            {
                dice.Roll();
            }

            return _dicePool;
        }

        public int GetHitsInRolledDicePool(List<Dice> dicePool)
        {
            int successCount = 0;

            foreach (Dice dice in dicePool)
            {
                if (dice.SuccessRoll)
                {
                    successCount += 1;
                }
            }

            return successCount;
        }

        public int Get1sInRolledDicePool(List<Dice> dicePool)
        {
            int missCount = 0;

            foreach (Dice dice in dicePool)
            {
                if (dice.DiceResult == 1)
                {
                    missCount += 1;
                }
            }

            return missCount;
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
