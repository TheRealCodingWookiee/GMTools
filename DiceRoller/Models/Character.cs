using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class Character
    {
        private string _name;
        private DicePool _dicePool;
        private int _diceCount;

        public Character(string name, int diceCount)
        {
            _name = name;
            _dicePool = new DicePool(diceCount);
        }

        public string Name
        {
            get { return _name; }
        }

        public int DiceCount
        {
            get { return _diceCount; }
            set { _diceCount = value; }
        }

        public DicePool DicePool 
        {        
            get { return _dicePool; }
                   
        }
    }
}
