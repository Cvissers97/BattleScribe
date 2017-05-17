using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
   static class DiceThrower
    {
       static Random r;

       public static int ThrowDice(int amount, int sides, int mod)
       {
           int result = 0;
           r = new Random();
           

           for (int i = 0; i <= amount; i++)
           {
               result += r.Next(0, sides);
           }

           result += mod;

           return result;
       }

       public static int ThrowDieAdvantage(int sides, int mod, bool advantage)
       {
           int first = 0;
           int second = 0;

           r = new Random();

           first = r.Next(1, sides);
           second = r.Next(1, sides);

           // Roll with advantage if true, disadvantage if false
           if (advantage)
           {
               if (first > second)
               {
                   return first;
               }
               else
               {
                   return second;
               }
           }
           else
           {
               if (first > second)
               {
                   return second;
               }
               else
               {
                   return first;
               }
           }
       }
    }
}
