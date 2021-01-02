using DiceRoller.Models;
using System.Collections.Generic;

namespace DiceRoller.Services.Tests
{
    //There are two types of tests: Success Tests and Opposed Tests
    public interface ITest
    {

        bool IsCriticalGlitch(DicePool dicePool);
        bool IsGlitch(DicePool dicePool);     

    }
}
