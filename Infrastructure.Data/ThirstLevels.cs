using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class ThirstLevels
    {
        private static readonly List<(string, float)> ThirstLevelsList = new List<(string, float)>{ ("dead", -0.0f),  
                                                                                                   ("thirsty", 25.0f),
                                                                                                   ("normal", 50.0f),
                                                                                                   ("full", 75.0f) };

        public static readonly string Dead = ThirstLevelsList[0].Item1;
        public static readonly string Thirsty = ThirstLevelsList[1].Item1;
        public static readonly string Normal = ThirstLevelsList[2].Item1;
        public static readonly string Full = ThirstLevelsList[3].Item1;

        public static readonly float DeadMinThirstValue = ThirstLevelsList[0].Item2;
        public static readonly float ThirstyMinThirstValue = ThirstLevelsList[1].Item2;
        public static readonly float NormalMinThirstValue = ThirstLevelsList[2].Item2;
        public static readonly float FullMinThirstValue = ThirstLevelsList[3].Item2;
        public static readonly float FullMaxThirstValue = 100.0f;

        public static string GetThirstLevelName(float thirstValue)
        {
            var minHungerLevel = ThirstLevelsList.FirstOrDefault();
            string thirstLevelName = minHungerLevel.Item1;
            foreach (var thirstLevel in ThirstLevelsList)
            {
                if (thirstLevel.Item2 <= thirstValue)
                    thirstLevelName = thirstLevel.Item1;
            }
            return thirstLevelName.ToLower();
        }
    }
}
