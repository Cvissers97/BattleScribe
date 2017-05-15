using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public class Character
    {
        private string name;
        private string title;
        private string age;
        private string size;
        private string alignment;
        private string race;
        private bool isFemale;
        private bool isMale;
        private string bonds;
        private string ideals;
        private string appearance;
        private string flaws;
        private string backstory;
        private byte str;
        private byte dex;
        private byte con;
        private byte _int;
        private byte wis;
        private byte cha;


        public Character()
        {
            str = 8;
            dex = 8;
            con = 8;
            _int = 8;
            wis = 8;
            cha = 8;
        }

        

        public Character(string name, string title, string age, string size, string alignment, bool isFemale, bool isMale
            , string bonds, string ideals, string appearance, string flaws, string backstory, byte str, byte dex,
            byte con, byte _int, byte wis, byte cha)
        {
            this.name = name;
            this.title = title;
            this.age = age;
            this.size = size;
            this.alignment = alignment;
            this.isFemale = isFemale;
            this.isMale = isMale;
            this.bonds = bonds;
            this.ideals = ideals;
            this.appearance = appearance;
            this.flaws = flaws;
            this.backstory = backstory;
            this.str = str;
            this.dex = dex;
            this.con = con;
            this._int = _int;
            this.wis = wis;
            this.cha = cha;
        }

        //Calc the modifier for skills
        public string CalcMod(string stat, double raceMod)
        {
            double temp;
            switch (stat)
            {
                case "STR":
                    temp = str;
                    break;
                case "DEX":
                    temp = dex;
                    break;
                case "CON":
                    temp = con;
                    break;
                case "INT":
                    temp = _int;
                    break;
                case "WIS":
                    temp = wis;
                    break;
                case "CHA":
                    temp = cha;
                    break;
                default:
                    temp = 200;
                    break;
            }

            temp = Math.Floor((((temp + raceMod) - 10) / 2));

            if (temp >= 0)
            {
                return "+" + temp.ToString();
            }
            else if (temp < 0)
            {
                return temp.ToString();
            }

            return null;
        }
        

        //create a list of all skills in the game
        public List<string> SkillsList()
        {
            List<string> temp = new List<string>();

            temp.Add("Acrobatics");
            temp.Add("AnimalHandeling");
            temp.Add("Arcana");
            temp.Add("Athletics");
            temp.Add("Deception");
            temp.Add("History");
            temp.Add("Insight");
            temp.Add("Intimidation");
            temp.Add("Investigation");
            temp.Add("Medicine");
            temp.Add("Nature");
            temp.Add("Perception");
            temp.Add("Performance");
            temp.Add("Religion");
            temp.Add("SleightofHand");
            temp.Add("Stealth");
            temp.Add("Survival");

            return temp;
        }

        //Creates a list of all langs in the game
        public List<string> LangList()
        {
            List<string> temp = new List<string>();

            temp.Add("Common");
            temp.Add("Dwarvish");
            temp.Add("Elvish");
            temp.Add("Giant");
            temp.Add("Gnomish");
            temp.Add("Goblin");
            temp.Add("Halfling");
            temp.Add("Orc");
            temp.Add("Abyssal");
            temp.Add("Celestial");
            temp.Add("Draconic");
            temp.Add("DeepSpeech");
            temp.Add("Infernal");
            temp.Add("Primordial");
            temp.Add("Sylvan");
            temp.Add("Undercommon");

            return temp;
        }

        public string GetName()
        {
            return name;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetAge()
        {
            return age;
        }

        public string GetSize()
        {
            return size;
        }

        public string GetAlignment()
        {
            return alignment;
        }

        public bool GetIsFemale()
        {
            return isFemale;
        }

        public bool GetIsMale()
        {
            return isMale;
        }

        public string GetBonds()
        {
            return bonds;
        }

        public string GetIdeals()
        {
            return ideals;
        }

        public string GetAppearance()
        {
            return appearance;
        }

        public string GetFlaws()
        {
            return flaws;
        }

        public string GetBackstory()
        {
            return backstory;
        }

        public byte GetStr()
        {
            return str;
        }

        public byte GetDex()
        {
            return dex;
        }

        public byte GetCon()
        {
            return con;
        }

        public byte GetInt()
        {
            return _int;
        }

        public byte GetWis()
        {
            return wis;
        }

        public byte GetCha()
        {
            return cha;
        }

        public void SetStr(byte str)
        {
            this.str = str;
        }

        public void SetDex(byte dex)
        {
            this.dex = dex;
        }

        public void SetCon(byte con)
        {
            this.con = con;
        }

        public void SetInt(byte _int)
        {
            this._int = _int;
        }

        public void SetWis(byte wis)
        {
            this.wis = wis;
        }

        public void SetCha(byte cha)
        {
            this.cha = cha;
        }

        public string GetRace()
        {
            return this.race;
        }

        public void SetRace(string race)
        {
            this.race = race;
        }

    }
}
