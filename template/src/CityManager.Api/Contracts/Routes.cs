namespace CityManager.Api.Contracts;

public static class Routes
{
    public static class V1
    {
        private const string Version = "v1";
        private const string Base = $"/{Version}";

        public static class Cities
        {
            public const string CitiesRoute = Base + "/cities";
            public const string CityRoute = CitiesRoute + "/{id}";
        }
        
        public static class Activities
        {
            public const string ActivitiesRoute = Base + "/activities";
            public const string RandomActivityRoute = ActivitiesRoute + "/random";
        }
    }
}