namespace InterviewAPI.Models
{
    public interface ICharacters
    {
        public Task<CharacterResult[]> GetChracter();
    }
}
