namespace InterviewAPI.Models
{
    public interface IPlanets
    {
        public Task<PLanetResult[]> GetPlanets();
    }
}
