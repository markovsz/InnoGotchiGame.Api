namespace Infrastructure.Data
{
    public static class PetSettings
    {
        public static readonly float PetsTimeConstant = 365.0f / 7.0f;
        public static readonly float HungerUnitsPerPetsHour = 0.01f;
        public static readonly float FeedingUnit = 5.0f;
        public static readonly float ThirstUnitsPerPetsHour = 0.01f;
        public static readonly float ThirstQuenchingUnit = 5.0f;
    }
}
