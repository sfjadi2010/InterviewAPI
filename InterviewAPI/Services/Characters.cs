using InterviewAPI.Models;

namespace InterviewAPI.Services
{
    public class Characters : ICharacters
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Characters(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<CharacterResult[]> GetChracter()
        {
            List<CharacterResult> characters = new List<CharacterResult>();

            var httpClient = _httpClientFactory.CreateClient("character_client");

            HttpResponseMessage response = await httpClient.GetAsync("character");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Character>();

                characters.AddRange(result.results);

                if (result.info.count > 0)
                {
                    for (int indx = 2; indx <= result.info.pages; indx++)
                    {

                        response = await httpClient.GetAsync("character?page=" + indx);

                        if (response.IsSuccessStatusCode )
                        {
                            result = await response.Content.ReadFromJsonAsync<Character>();

                            characters.AddRange(result.results);
                        }
                    }
                }

                return characters.ToArray();
            }

            return null;
        }
    }
}
