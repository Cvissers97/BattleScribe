using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleScribe.Classes
{
   static class DiceThrower
    {
       static Random r;

       public static int ThrowDice(int amount, int sides, int mod)
       {
           int result = 0;
           int _throw = 0;
           r = new Random();

           int rolls = r.Next(0, 20);
           

           for (int i = 0; i <= amount; i++)
           {
               for (int j = 0; j < (rolls + amount); j++)
               {
                   _throw = r.Next(0, sides);
               }
               result += _throw;
           }

           result += mod;

           return result;
       }

       public static int ThrowDieAdvantage(int sides, int mod, bool advantage)
       {
           int first = 0;
           int second = 0;

           r = new Random();

           int temp = r.Next(0, 20);

           r = new Random();

           for (int i = 0; i < temp; i++)
           {
               first = r.Next(1, sides);
           }

           r = new Random();

           for (int i = 0; i < (temp * 2); i++)
           {
               second = r.Next(1, sides);
           }

           // Roll with advantage if true, disadvantage if false
           if (advantage)
           {
               if (first > second)
               {
                   return first + mod;
               }
               else
               {
                   return second + mod;
               }
           }
           else
           {
               if (first > second)
               {
                   return second + mod;
               }
               else
               {
                   return first + mod;
               }
           }
       }
    }
}
