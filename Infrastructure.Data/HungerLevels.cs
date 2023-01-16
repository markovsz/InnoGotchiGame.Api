using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class HungerLevels
    {
        private static readonly List<(string, float)> HungerLevelsList = new List<(string, float)>{ ("dead", -0.0f),  
                                                                                                   ("hunger", 25.0f),
                                                                                                   ("normal", 50.0f),
                                                                                                   ("full", 75.0f) };

        public static readonly string Dead = HungerLevelsList[0].Item1;
        public static readonly string Hunger = HungerLevelsList[1].Item1;
        public static readonly string Normal = HungerLevelsList[2].Item1;
        public static readonly string Full = HungerLevelsList[3].Item1;

        public static readonly float DeadMinHungerValue = HungerLevelsList[0].Item2;
        public static readonly float HungerMinHungerValue = HungerLevelsList[1].Item2;
        public static readonly float NormalMinHungerValue = HungerLevelsList[2].Item2;
        public static readonly float FullMinHungerValue = HungerLevelsList[3].Item2;
        public static readonly float FullMaxHungerValue = 100.0f;

        public static string GetHungerLevelName(float hungerValue)
        {
            var minHungerLevel = HungerLevelsList.FirstOrDefault();
            string hungerLevelName = minHungerLevel.Item1;
            foreach (var hungerLevel in HungerLevelsList)
            {
                if (hungerLevel.Item2 <= hungerValue)
                    hungerLevelName = hungerLevel.Item1;
            }
            return hungerLevelName.ToLower();
        }
    }
}
