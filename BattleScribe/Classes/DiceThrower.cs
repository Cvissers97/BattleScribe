using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
   static class DiceThrower
    {
       public static int ThrowDice(int amount, int sides, int mod)
       {
           int result = 0;
           Random r = new Random();

           for (int i = 0; i <= amount; i++)
           {
               result += r.Next(0, sides);
           }

           result += mod;

           return result;
       }
    }
}
