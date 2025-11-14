using Entities;
using System.Text.Json;
namespace Repository


{

    public class UserRepository
    {
        public User? GetUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText("text.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User? user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user?.id == id)
                        return user;
                }
            }

            return null;
        }
        public User? Login(ExistingUser existingUser)
        {
            using (StreamReader reader = System.IO.File.OpenText("text.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User? user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user?.Email == existingUser.Email && user?.Password == existingUser.Password)
                        return user;
                }
            }
            return null;

        }
        public User Register(User user)
        {

            int numberOfUsers = System.IO.File.ReadLines("text.txt").Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("text.txt", userJson + Environment.NewLine);
            return user;
        }
        public void Upadate(int id, User updateUser)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("text.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User? user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user?.id == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("text.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updateUser));
                System.IO.File.WriteAllText("text.txt", text);
            }


        }
        public void Delete(int id)
        {
        }
    }
}
