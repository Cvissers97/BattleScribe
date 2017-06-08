using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BattleScribe.Classes.Items;

namespace BattleScribe.Classes
{
    public struct Language
    {
        public bool acquired;
        public string name;
        public Language(string name, bool acquired)
        {
            this.name = name;
            this.acquired = acquired;
        }
    }

    public struct Skill
    {
        public bool acquired;
        public string name;
        public Skill(string name, bool acquired)
        {
            this.acquired = acquired;
            this.name = name;
        }
    }

    public class Character
    {
        public int lastBonus;
        public int lastDiceAmount;
        public int lastDiceAmount2;
        public int lastDiceSide;
        public int lastDiceSide2;
        // Custom Attack
        public int lastToHit;

        private byte _int;
        private string age;
        private string alignment;
        private string appearance;
        private List<Armour> armours;
        private string background;
        private string backstory;
        private string bonds;
        private CharacterClass cClass;
        private byte cha;
        private int charClass;
        private List<Feature> classFeatures;
        private byte con;
        private int curHitPoints;
        private DbHandler db;

        private byte dex;
        private int experiencePoints;
        private List<Feat> feats;
        private string flaws;
        private int id;
        private string ideals;
        private byte[] image;
        private bool inspiration;
        private bool isFemale;
        private bool isMale;
        private List<Item> items;
        private List<Spell> knownSpells;
        private List<Language> langs;
        private int level;
        private int maxHitPoints;
        private string miscProfs;
        private string name;
        private string personality;
        private int proficiency;
        private Image profilePic;
        private string race;
        private List<Feature> raceFeatures;
        private string savingThrow1;
        private string savingThrow2;
        private bool setMaxSlots;
        private string size;
        private List<Skill> skills;
        private byte slot1, slot1Max;
        private byte slot2, slot2Max;
        private byte slot3, slot3Max;
        private byte slot4, slot4Max;
        private byte slot5, slot5Max;
        private byte slot6, slot6Max;
        private byte slot7, slot7Max;
        private byte slot8, slot8Max;
        private byte slot9, slot9Max;
        // INT, WIS, CHA (etc.)
        private string spellMod;

        private byte str;
        private int tempHitPoints;
        private string title;
        private List<Weapon> weapons;
        private byte wis;
        public Character()
        {
            str = 8;
            dex = 8;
            con = 8;
            _int = 8;
            wis = 8;
            cha = 8;
            tempHitPoints = 0;
            cClass = new CharacterClass();

            items = new List<Item>();
            weapons = new List<Weapon>();
            armours = new List<Armour>();
        }

        //Id constructor, used for testing the inventory system.
        public Character(int id)
        {
            //Base proficiency
            proficiency = 2;

            this.id = id;

            items = new List<Item>();
            weapons = new List<Weapon>();
            armours = new List<Armour>();
            skills = new List<Skill>();

            foreach (string s in SkillsList())
            {
                skills.Add(new Skill(s, false));
            }

            str = 10;
            _int = 15;
            wis = 20;
            cha = 40;
            dex = 2;

            proficiency = 0;
            maxHitPoints = 37;
            curHitPoints = maxHitPoints;
            SetSpellMod();
        }

        public Character(int id, byte[] image, string name, int charClass, int level)
        {
            this.id = id;
            this.image = image;
            this.name = name;
            this.charClass = charClass;
            this.level = level;
        }

        public Character(string name, string title, string age, string size, string alignment, bool isFemale, bool isMale
            , string bonds, string ideals, string appearance, string flaws, string backstory, byte str, byte dex,
            byte con, byte _int, byte wis, byte cha, int charClass, string personality, string background,
            string charRace, byte[] image, int level)
        {
            //Base proficiency
            proficiency = 2;

            db = new DbHandler();
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
            this.charClass = charClass;
            this.personality = personality;
            this.background = background;
            this.race = charRace;
            this.image = image;
            this.level = level;

            int temp = db.GetMaxHPByClass(charClass);
            maxHitPoints = temp;
            curHitPoints = temp;

            inspiration = false;

            items = new List<Item>();
            weapons = new List<Weapon>();
            armours = new List<Armour>();
            skills = new List<Skill>();

            raceFeatures = db.GetFeaturesByRace(race);
            classFeatures = new List<Feature>();

            foreach (string s in SkillsList())
            {
                skills.Add(new Skill(s, false));
            }

            SetSpellMod();
            setMaxSlots = false;

            // Constructor called for making a character.
        }

        public Character(int id, string name, string title, string age, string size, string alignment, bool isFemale, bool isMale
    , string bonds, string ideals, string appearance, string flaws, string backstory, byte str, byte dex,
    byte con, byte _int, byte wis, byte cha, int charClass, string personality, string background,
    string charRace, int level)
        {
            //Base proficiency
            proficiency = 2;

            db = new DbHandler();
            this.id = id;
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
            this.charClass = charClass;
            this.personality = personality;
            this.background = background;
            this.race = charRace;
            this.level = level;

            int temp = db.GetMaxHPByClass(charClass);
            maxHitPoints = temp;
            curHitPoints = temp;

            inspiration = false;

            raceFeatures = db.GetFeaturesByRace(race);
            classFeatures = new List<Feature>();

            items = new List<Item>();
            weapons = new List<Weapon>();
            armours = new List<Armour>();
            skills = new List<Skill>();

            SetSpellMod();
            setMaxSlots = false;

            // Constructor called after making a character.
        }

        public int CalcCarryWeight()
        {
            int temp = str;
            temp *= 15;
            return temp;
        }

        public void ToggleInspiration()
        {
            inspiration = !inspiration;
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

        public int CalcProfBonus()
        {
            if (level < 5)
            {
                proficiency = 2;
            }
            else if (level < 9)
            {
                proficiency = 3;
            }
            else if (level < 13)
            {
                proficiency = 4;
            }
            else if (level < 16)
            {
                proficiency = 5;
            }
            else
            {
                proficiency = 6;
            }

            return proficiency;
        }

        public string GetAge()
        {
            return age;
        }

        public string GetAlignment()
        {
            return alignment;
        }

        public List<Feature> GetAllFeatures()
        {
            List<Feature> features = new List<Feature>();
            raceFeatures = db.GetFeaturesByRaceId(Convert.ToInt32(race));

            foreach (Feature f in raceFeatures)
            {
                f.isRacial = true;
                features.Add(f);
            }

            foreach (Feature f in classFeatures)
            {
                features.Add(f);
            }

            return features;
        }

        public string GetAppearance()
        {
            return appearance;
        }

        public string GetBackGround()
        {
            return background;
        }

        public string GetBackstory()
        {
            return backstory;
        }

        public string GetBonds()
        {
            return bonds;
        }

        public byte GetCha()
        {
            return cha;
        }

        public int GetClass()
        {
            return charClass;
        }

        public string GetClassName()
        {
            return cClass.GetName();
        }

        public byte GetCon()
        {
            return con;
        }

        public int GetCurrentHealth()
        {
            return curHitPoints;
        }

        public byte GetDex()
        {
            return dex;
        }

        public int GetExp()
        {
            return this.experiencePoints;
        }

        public List<Feat> GetFeats()
        {
            return this.feats;
        }

        public string GetFlaws()
        {
            return flaws;
        }

        public int GetID()
        {
            return this.id;
        }

        public string GetIdeals()
        {
            return ideals;
        }

        public byte[] GetImage()
        {
            return image;
        }

        public bool GetInspiration()
        {
            return inspiration;
        }

        public byte GetInt()
        {
            return _int;
        }

        public bool GetIsFemale()
        {
            return isFemale;
        }

        public bool GetIsMale()
        {
            return isMale;
        }

        public List<Spell> GetKnownSpells()
        {
            return this.knownSpells;
        }

        public List<Language> GetLangs()
        {
            return this.langs;
        }

        public int GetLevel()
        {
            return level;
        }

        public int GetMaxHealth()
        {
            return maxHitPoints;
        }

        public string GetMiscProf()
        {
            return this.miscProfs;
        }

        public int GetModifier(string skillName)
        {
            int mod = 0;
            double add = 0;

            switch (skillName)
            {
                default:
                    break;

                case "STR":
                    add = Math.Floor(((double)str - 10) / 2);
                    return mod + (int)add;

                case "DEX":
                    add = Math.Floor(((double)dex - 10) / 2);
                    return mod + (int)add;

                case "CON":
                    add = Math.Floor(((double)con - 10) / 2);
                    return mod + (int)add;

                case "INT":
                    add = Math.Floor(((double)_int - 10) / 2);
                    return mod + (int)add;

                case "WIS":
                    add = Math.Floor(((double)wis - 10) / 2);
                    return mod + (int)add;

                case "CHA":
                    add = Math.Floor(((double)cha - 10) / 2);
                    return mod + (int)add;
            }

            foreach (Skill skill in skills)
            {
                if (skill.name == skillName)
                {
                    switch (skillName)
                    {
                        default:
                            add = 1337;
                            break;

                        case "Athletics":
                            add = Math.Floor(((double)str - 10) / 2);
                            break;

                        case "Acrobatics":
                            add = Math.Floor(((double)dex - 10) / 2);
                            break;

                        case "Sleight of Hand":
                            add = Math.Floor(((double)dex - 10) / 2);
                            break;

                        case "Stealth":
                            add = Math.Floor(((double)dex - 10) / 2);
                            break;

                        case "Arcana":
                            add = Math.Floor(((double)_int - 10) / 2);
                            break;

                        case "History":
                            add = Math.Floor(((double)_int - 10) / 2);
                            break;

                        case "Investigation":
                            add = Math.Floor(((double)_int - 10) / 2);
                            break;

                        case "Nature":
                            add = Math.Floor(((double)_int - 10) / 2);
                            break;

                        case "Religion":
                            add = Math.Floor(((double)_int - 10) / 2);
                            break;

                        case "Animal Handeling":
                            add = Math.Floor(((double)wis - 10) / 2);
                            break;

                        case "Insight":
                            add = Math.Floor(((double)wis - 10) / 2);
                            break;

                        case "Medicine":
                            add = Math.Floor(((double)wis - 10) / 2);
                            break;

                        case "Perception":
                            add = Math.Floor(((double)wis - 10) / 2);
                            break;

                        case "Survival":
                            add = Math.Floor(((double)wis - 10) / 2);
                            break;

                        case "Deception":
                            add = Math.Floor(((double)cha - 10) / 2);
                            break;

                        case "Intimidation":
                            add = Math.Floor(((double)cha - 10) / 2);
                            break;

                        case "Performance":
                            add = Math.Floor(((double)cha - 10) / 2);
                            break;

                        case "Persuasion":
                            add = Math.Floor(((double)cha - 10) / 2);
                            break;
                    }

                    mod += (int)add;

                    if (skill.acquired)
                    {
                        mod += proficiency;
                    }

                    return mod;
                }
            }
            return mod;
        }

        public string GetName()
        {
            return name;
        }

        public string GetPersonality()
        {
            return personality;
        }

        public int GetProfiencyBonus()
        {
            return proficiency;
        }

        public Image GetProfilePic()
        {
            return this.profilePic;
        }

        public string GetRace()
        {
            return this.race;
        }

        public string[] GetSavingThrows()
        {
            string[] throws = new string[2];

            throws[0] = savingThrow1;
            throws[1] = savingThrow2;

            return throws;
        }

        public string GetSize()
        {
            return size;
        }

        public List<Skill> GetSkills()
        {
            return this.skills;
        }

        public byte GetSlot1()
        {
            return this.slot1;
        }

        public byte GetSlot2()
        {
            return this.slot2;
        }

        public byte GetSlot3()
        {
            return this.slot3;
        }

        public byte GetSlot4()
        {
            return this.slot4;
        }

        public byte GetSlot5()
        {
            return this.slot5;
        }

        public byte GetSlot6()
        {
            return this.slot6;
        }

        public byte GetSlot7()
        {
            return this.slot7;
        }

        public byte GetSlot8()
        {
            return this.slot8;
        }

        public byte GetSlot9()
        {
            return this.slot9;
        }

        public string GetSpellMod()
        {
            return this.spellMod;
        }

        public byte GetStr()
        {
            return str;
        }

        public int GetTempHp()
        {
            return this.tempHitPoints;
        }

        public string GetTitle()
        {
            return title;
        }

        public byte GetWis()
        {
            return wis;
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
            temp.Add("Deep Speech");
            temp.Add("Infernal");
            temp.Add("Primordial");
            temp.Add("Sylvan");
            temp.Add("Under Common");

            return temp;
        }

        public void RecoverAllSpellSlots()
        {
            slot1 = slot1Max;
            slot2 = slot2Max;
            slot3 = slot3Max;
            slot4 = slot4Max;
            slot5 = slot5Max;
            slot6 = slot6Max;
            slot7 = slot7Max;
            slot8 = slot8Max;
            slot9 = slot9Max;
        }

        public void SetAge(string age)
        {
            this.age = age;
        }

        public void SetAlignment(string alignment)
        {
            this.alignment = alignment;
        }

        public void SetBackstory(string backstory)
        {
            this.backstory = backstory;
        }

        public void SetBonds(string bonds)
        {
            this.bonds = bonds;
        }

        public void SetCha(byte cha)
        {
            this.cha = cha;
        }

        public void SetCharFeats(List<Feat> input)
        {
            this.feats = input;
        }

        public void SetClassFeatures(List<Feature> input)
        {
            this.classFeatures = input;
        }

        public void SetCon(byte con)
        {
            this.con = con;
        }

        public void SetCurrentHealth(int targetHealth)
        {
            curHitPoints = targetHealth;
        }

        public void SetDex(byte dex)
        {
            this.dex = dex;
        }

        public void SetExp(int exp)
        {
            this.experiencePoints = exp;
        }

        public void SetFlaws(string flaws)
        {
            this.flaws = flaws;
        }

        public void SetIdeals(string ideals)
        {
            this.ideals = ideals;
        }

        public void SetImage(byte[] image)
        {
            this.image = image;
        }

        public void SetImage(Image target)
        {
            this.profilePic = target;
        }

        public void SetInspiration(bool target)
        {
            this.inspiration = target;
        }

        public void SetInt(byte _int)
        {
            this._int = _int;
        }

        public void SetIsFemale(bool isFemale)
        {
            this.isFemale = isFemale;
        }

        public void SetIsMale(bool isMale)
        {
            this.isMale = isMale;
        }

        public void SetItemsInInventory(List<Item> itemsInInventory)
        {
            this.items = itemsInInventory;
        }

        public void SetKnownSpells(List<Spell> spells)
        {
            this.knownSpells = spells;
        }

        public void SetLangList(List<Language> lang)
        {
            this.langs = lang;
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }

        public void SetMaxHealth(int targetHealth)
        {
            maxHitPoints = targetHealth;
        }

        public void SetMiscProf(string target)
        {
            this.miscProfs = target;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPersonality(string personality)
        {
            this.personality = personality;
        }

        public void SetRace(string race)
        {
            this.race = race;
        }

        public void SetSavingThrows(string first, string second)
        {
            savingThrow1 = first;
            savingThrow2 = second;
        }

        public void SetSize(string size)
        {
            this.size = size;
        }

        public void SetSkillList(List<Skill> skills)
        {
            this.skills = skills;
        }

        public void SetSlots(byte slot1, byte slot2, byte slot3, byte slot4,
            byte slot5, byte slot6, byte slot7, byte slot8, byte slot9)
        {
            this.slot1 = slot1;
            this.slot2 = slot2;
            this.slot3 = slot3;
            this.slot4 = slot4;
            this.slot5 = slot5;
            this.slot6 = slot6;
            this.slot7 = slot7;
            this.slot8 = slot8;
            this.slot9 = slot9;

            if (!setMaxSlots)
            {
                slot1Max = slot1;
                slot2Max = slot2;
                slot3Max = slot3;
                slot4Max = slot4;
                slot5Max = slot5;
                slot6Max = slot6;
                slot7Max = slot7;
                slot8Max = slot8;
                slot9Max = slot9;
            }

            setMaxSlots = true;
        }

        public void SetSpellMod()
        {
            switch (charClass)
            {
                default:
                    spellMod = "INT";
                    break;

                case 2:
                    //Bard
                    spellMod = "CHA";
                    break;

                case 3:
                    //Cleric
                    spellMod = "WIS";
                    break;

                case 4:
                    //Druid
                    spellMod = "WIS";

                    break;

                case 5:
                    //Fighter
                    spellMod = "INT";
                    break;

                case 7:
                    //Paladin
                    spellMod = "CHA";

                    break;

                case 8:
                    //Ranger
                    spellMod = "WIS";
                    break;

                case 9:
                    //Rogue
                    spellMod = "INT";
                    break;

                case 10:
                    //Sorcerer
                    spellMod = "CHA";
                    break;

                case 11:
                    //Warlock
                    spellMod = "CHA";
                    break;

                case 12:
                    //Wizard
                    spellMod = "INT";
                    break;
            }
        }
        public void SetStr(byte str)
        {
            this.str = str;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetWis(byte wis)
        {
            this.wis = wis;
        }

        //create a list of all skills in the game
        public List<string> SkillsList()
        {
            List<string> temp = new List<string>();

            temp.Add("Acrobatics");
            temp.Add("Animal Handeling");
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
            temp.Add("Persuasion");
            temp.Add("Religion");
            temp.Add("Sleight of Hand");
            temp.Add("Stealth");
            temp.Add("Survival");

            return temp;
        }
        public bool SpendSlot(byte slotNumber)
        {
            switch (slotNumber)
            {
                default:
                    MessageBox.Show("Invalid slot!");
                    return false;

                case 1:
                    if (slot1 - 1 < 0)
                    {
                        return false;
                    }
                    slot1 -= 1;
                    return true;

                case 2:
                    if (slot2 - 1 < 0)
                    {
                        return false;
                    }
                    slot2 -= 1;
                    return true;

                case 3:
                    if (slot3 - 1 < 0)
                    {
                        return false;
                    }
                    slot3 -= 1;
                    return true;

                case 4:
                    if (slot4 - 1 < 0)
                    {
                        return false;
                    }
                    slot4 -= 1;

                    return true;

                case 5:
                    if (slot5 - 1 < 0)
                    {
                        return false;
                    }
                    slot5 -= 1;

                    return true;

                case 6:
                    if (slot6 - 1 < 0)
                    {
                        return false;
                    }
                    slot6 -= 1;
                    return true;

                case 7:
                    if (slot7 - 1 < 0)
                    {
                        return false;
                    }
                    slot7 -= 1;
                    return true;

                case 8:
                    if (slot8 - 1 < 0)
                    {
                        return false;
                    }
                    slot8 -= 1;
                    return true;

                case 9:
                    if (slot9 - 1 < 0)
                    {
                        return false;
                    }
                    slot9 -= 1;
                    return true;
            }
        }
    }
}