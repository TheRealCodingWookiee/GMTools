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

        public void RollDicePool()
        {
            foreach (Dice dice in _dicePool)
            {
                dice.Roll();
            }
        }

        public List<Dice> ReRollMisses(List<Dice> dicePool)
        {

            foreach (Dice dice in dicePool)
            {
                bool isSuccess = dice.IsSuccessRoll(dice.DiceResult);
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
