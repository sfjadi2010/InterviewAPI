namespace InterviewAPI.Models
{
    public interface IPlanets
    {
        public Task<Planet> GetPlanets();
    }
}
