
namespace learnCollection
{
    internal class UserService
    {

        private void ValidateUserData(int id, string name, int age)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id должен быть больше 0");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Поле заполнено неверно");
            }

            if (age <= 0 || age > 120)
            {
                throw new ArgumentOutOfRangeException("Неверный возраст");
            }
        }

        private List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Булат", Age = 22 },
            new User { Id = 2, Name = "Алексей", Age = 25 },
            new User { Id = 3, Name = "Иван", Age = 17 },
            new User { Id = 4, Name = "Анна", Age = 21 },
            new User { Id = 5, Name = "Дмитрий", Age = 16 }
        };
        public List<User> GetAllUsers()
        {
            var allUsers = users.ToList();

            return allUsers;
        }

        public void AddUser(int id, string name, int age)
        {
            ValidateUserData(id, name, age);

            var userExists = users
                .Any(user => user.Id == id);
            if (userExists)
            {
                throw new ArgumentException("Такой id уже существует");
            }
            User newUser = new User { Id = id, Name = name, Age = age };
            users.Add(newUser);
           
        }
        

        public User GetUserById(int id) 
        {
            var user = users.FirstOrDefault(user => user.Id == id);
            if (user == null)
            {
                throw new KeyNotFoundException("Такого пользователя не существует");
            }
            return user;
        }
        
        public List<User> GetAdults()
        {
            List<User> adults = users
                .Where(user => user.Age >= 18)
                .ToList();
            return adults;
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);

            users.Remove(user);
        }

        public void UpdateUser(int id, string name, int age)
        {
            ValidateUserData(id, name, age);

            var user = GetUserById(id);

            user.Age = age;
            user.Name = name;
        }
        
        public List<User> SearchUser(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("поле не должно быть пустым");
            }
            return users
                .Where(user => user.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

        }

        public int GetUserCountByAge(int age)
        {
            var userCount = users.Count(user => user.Age >= age);
            return userCount;
        }
    }
}
