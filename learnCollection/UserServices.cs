using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using learnCollection;

namespace learnCollection
{
    internal class UserServices
    {
        private List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Булат", Age = 22 },
            new User { Id = 2, Name = "Алексей", Age = 25 },
            new User { Id = 3, Name = "Иван", Age = 17 },
            new User { Id = 4, Name = "Анна", Age = 21 },
            new User { Id = 5, Name = "Дмитрий", Age = 16 }
        };
        public void GetAllUser()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} - {user.Name} - {user.Age}");
            }
        }

        public void AddUser(int id, string name, int age)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id должен быть больше 0");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Поле заполнено неверно");
            }

            if (age <= 0 || age > 120)
            {
                throw new ArgumentOutOfRangeException("Неверный возраст");
            }
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                        throw new ArgumentException("Такой id уже существует");
                }
            }
            User newUser = new User { Id = id, Name = name, Age = age };
            users.Add(newUser);
           
        }
        

        public User GetUserById(int id) 
        {
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }          
            }
            throw new ArgumentOutOfRangeException("такого пользователя не существует");
        }
        
        public List<User> GetAdults()
        {
            List<User> adults = new List<User>();

            foreach (var user in users)
            {
                if (user.Age >= 18)
                {
                    adults.Add(user);
                }
            }
            return adults;
        }

        public void DeleteUser(int id)
        {
            int forDeleteUser = -1;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    forDeleteUser = i;
                    break;
                }
                    
            }
            if (forDeleteUser >= 0)
            {
                users.RemoveAt(forDeleteUser);
            }
            else
            {
                throw new ArgumentNullException("Такой пользователь не найден");
            }


        }

        public void UpdateUser(int id, string name, int age)
        {
            bool IsAdd = false;

            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException("Некорректно введен id");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Некорректно введено имя");
            }
            if(age <= 0 || age > 120)
            {
                throw new ArgumentOutOfRangeException("Некорректно введен возраст");
            }
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Id == id)
                    {
                        users[i].Name = name;
                        users[i].Age = age;
                        IsAdd = true;
                        break;
                    }

                }
            if(IsAdd == false)
            {
                throw new ArgumentException("Такого пользователя нет");
            }
            
            
        }
    }
}
