using learnCollection;

//1. Добавление пользователя
    UserServices users = new UserServices();

    Console.Write("Напишите свой id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Напишите свое имя: ");
    string name = Console.ReadLine();
    Console.Write("Напишите свой возраст: ");
    int age = Convert.ToInt32(Console.ReadLine());
    users.AddUser(id, name, age);

//2. Поиск пользователя по id
    Console.Write("Напишите id, который нужно найти: ");
    int Findid = Convert.ToInt32(Console.ReadLine());
    User foundUser = users.GetUserById(Findid);

    Console.WriteLine($"{foundUser.Id} - {foundUser.Name} - {foundUser.Age}");

//3. Поиск пользователей 18+
    Console.WriteLine("Лица, которым больше 18 лет");
    List<User> adults = users.GetAdults();
    foreach (User adult in adults)
    {
        Console.WriteLine(adult.Name);
    }

//4. Удаление пользователя
    Console.Write("Введите id для удаления: ");
    int DeleteId = Convert.ToInt32(Console.ReadLine());
    users.DeleteUser(DeleteId);

//5. Вывод остальных пользователей
    users.GetAllUser();

//6. Изменение данных о пользователе

    Console.Write("Напишите свой id: ");
    int ChangeId = Convert.ToInt32(Console.ReadLine());
    Console.Write("Напишите свое имя: ");
    string ChangeName = Console.ReadLine();
    Console.Write("Напишите свой возраст: ");
    int ChangeAge = Convert.ToInt32(Console.ReadLine());
    users.UpdateUser(ChangeId, ChangeName, ChangeAge);

    users.GetAllUser();