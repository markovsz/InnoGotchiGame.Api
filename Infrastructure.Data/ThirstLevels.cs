using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class ThirstLevels
    {
        public static readonly List<(string, float)> ThirstLevelsList = new List<(string, float)>{ ("dead", -0.0f),  
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
    }
}
