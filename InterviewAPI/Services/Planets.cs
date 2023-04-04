using InterviewAPI.Models;

namespace InterviewAPI.Services
{
    public class Planets : IPlanets
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Planets(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PLanetResult[]> GetPlanets()
        {
            List<PLanetResult> planets = new List<PLanetResult>();

            var httpClient = _httpClientFactory.CreateClient("planets_client");

            HttpResponseMessage response = await httpClient.GetAsync("planets");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Planet>();

                planets.AddRange(result?.results);

                if (result.count > 0)
                {
                    for (int indx = 2; indx <= result.count / 10; indx++)
                    {
                        response = await httpClient.GetAsync("planets/?page=" + indx);

                        if (response.IsSuccessStatusCode)
                        {
                            result = await response.Content.ReadFromJsonAsync<Planet>();

                            planets.AddRange(result?.results);
                        }
                    }

                }

                return planets.ToArray();
            }

            return null;
        }
    }
}
