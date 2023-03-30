using InterviewAPI.Models;

namespace InterviewAPI.Services
{
    public class Characters : ICharacters
    {
        public async Task<Character> GetChracter()
        {
            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://rickandmortyapi.com/api/")
            }) {
                HttpResponseMessage response = await httpClient.GetAsync("character");

                if (response.IsSuccessStatusCode)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    var result = await response.Content.ReadFromJsonAsync<Character>();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                    return result;
                }
            };

            return null;
        }
    }
}
