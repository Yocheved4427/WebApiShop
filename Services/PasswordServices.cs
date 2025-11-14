using Zxcvbn;
namespace Services
{
    public class PasswordServices
    {
        public int PasswordScore(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}
