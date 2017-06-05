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
       static Random rand = new Random();

       public static string RollToHit(int modifier)
       {
           // For to hit rolls, you add the modifier to every attack. The modifier also
           // contains the proficiency bonus

           string message = string.Empty;
           int roll = 0;

           roll = rand.Next(1, 21);

           if (roll == 20 || roll == 1)
           {
               message += "Critical ";
           }

           roll += modifier;

           message += Convert.ToString(roll);

           return message;
       }

       public static int RollDamage(int amount, int sides, int modifier)
       {
           // Only add the modifier once to the result.
           
           int result = 0;

           for (int i = 0; i < amount; i++)
           {
               result += rand.Next(1, sides + 1);
           }

           result += modifier;

           return result;
       }

       public static string ThrowDie(int sides, int mod)
       {
           string message = string.Empty;

           int result = rand.Next(1, sides + 1);

           if (result == 20 || result == 1)
	       {
               message += "Critical ";
	       }

           result += mod;
           message += result;

           return message;
       }

       public static int ThrowDieNumb(int sides, int mod)
       {
           int result = 0;

           result = rand.Next(1, sides + 1);

           result += mod;

           return result;
       }


       public static string ThrowDieAdvantage(int sides, int mod, bool advantage)
       {
           string message = string.Empty;

           int first = 0;
           int second = 0;

           first = rand.Next(1, sides + 1);
           second = rand.Next(1, sides + 1);


           // Roll with advantage if true, disadvantage if false
           if (advantage)
           {
               if (first > second)
               {
                   if (first == 20 || first == 1)
                       message += "Critical ";

                   return message += (first + mod);
               }
               else
               {
                   if (second == 20 || second == 1)
                       message += "Critical ";

                   return message += (second + mod);
               }
           }
           else
           {
               if (first > second)
               {
                   if (second == 20 || second == 1)
                       message += "Critical ";

                   return message += (second + mod);
               }
               else

                   if (first == 20 || first == 1)
                       message += "Critical ";

                   return message += (first + mod);
               }
           }
       }
    }