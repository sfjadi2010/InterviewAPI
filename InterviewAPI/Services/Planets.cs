using InterviewAPI.Models;

namespace InterviewAPI.Services
{
    public class Planets : IPlanets
    {
        public async Task<Planet> GetPlanets()
        {
            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://swapi.dev/api/")
            })
            {
                HttpResponseMessage response = await httpClient.GetAsync("planets");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Planet>();

                    return result;
                }
            }

            return null;
        }
    }
}
