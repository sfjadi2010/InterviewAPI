namespace InterviewAPI.Models
{
    public interface ICharacters
    {
        public Task<Character> GetChracter();
    }
}
