using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
namespace _10zachto
{
     internal class Admin: CRUD
     {
        private string pudge;

        public Admin(string pudge)
        {
            this.pudge = pudge;
        }

        public class admin : CRUD
        {
            private bool dsa = false; 
            private string name;
            private int mesto;

            public admin(string imya)
            {
                name = imya;
                menushka();
            }
            public void poisk(string found)
            {
                Console.Clear();
                List<polzovatel> users1 = Soxran.Deserializer<List<polzovatel>>("D:\\practos.json");
                List<polzovatel> sorted_users = new List<polzovatel>();
                foreach (polzovatel user in users1)
                {
                    if (found.Equals(user.ID) || found.Equals(user.rol) || found.Equals(user.pudge))
                    //Определяет, равен ли указанный объект текущему объекту
                    {
                        sorted_users.Add(user);
                    }
                }
                int y = 0;
                foreach (var item in sorted_users)
                {
                    Console.SetCursorPosition(3, y);
                    Console.Write(item.pudge);
                    Console.SetCursorPosition(20, y);
                    Console.Write(item.rol);
                    Console.SetCursorPosition(40, y);
                    Console.Write(item.ID);
                    y += 1;
                }
                y = 0;
                Console.SetCursorPosition(70, 0);
                Console.Write("f1 - Добавить пользователя");
                Console.SetCursorPosition(70, 1);
                Console.Write("f2 - Удалить пользователя");
                Console.SetCursorPosition(70, 3);
                Console.Write("f3 - поиск");
                Console.SetCursorPosition(70, 7);
                Console.Write("Вы вошли " + name);
                Console.SetCursorPosition(3, sorted_users.Count + 3);
                Console.Write("Логин");
                Console.SetCursorPosition(20, sorted_users.Count + 3);
                Console.Write("Роль");
                Console.SetCursorPosition(40, sorted_users.Count + 3);
                Console.Write("id");
                int position = 0;
                Console.SetCursorPosition(0, position);
                Console.Write("->");
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        Console.SetCursorPosition(0, position);
                        Console.Write("  ");
                        position -= 1;
                        if (position > sorted_users.Count - 1) { position = sorted_users.Count - 1; }
                        if (position < 0) { position = 0; }
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        Console.SetCursorPosition(0, position);
                        Console.Write("  ");
                        position += 1;
                        if (position > sorted_users.Count - 1) { position = sorted_users.Count - 1; }
                        if (position < 0) { position = 0; }
                    }
                    else if (key.Key == ConsoleKey.F1)
                    {
                        Console.Clear();
                        create();
                        Console.Clear();
                        menushka();
                    }
                    else if (key.Key == ConsoleKey.F2)
                    {
                        mesto = users1.IndexOf(sorted_users[position]);
                        delete();
                        break;
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        mesto = users1.IndexOf(sorted_users[position]);
                        update();
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        menushka();
                        break;
                    }
                    Console.SetCursorPosition(0, position);
                    Console.Write("->");
                }
            }
            public void create()
            {
                List<polzovatel > users = Soxran.Deserializer<List<polzovatel>>("D:\\practos.json");
                Console.Clear();
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();
                Console.Write("Введите id: ");
                string id = Console.ReadLine();
                Console.Write("Введите роль: ");
                string role = Console.ReadLine();
                polzovatel new_user = new polzovatel(name, password, role, id);
                users.Add(new_user);
                Soxran.Serializer("D:\\practos.json", users);
                Console.Clear();
                menushka();
            }
            public void delete()
            {
                List<polzovatel> users = Soxran.Deserializer<List<polzovatel>>("D:\\practos.json");
                if (users[mesto].pudge != name)
                {
                    users.Remove(users[mesto]);
                    Soxran.Serializer("D:\\practos.json", users);
                    menushka();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.ReadLine();
                    Console.Clear();
                    menushka();
                }
            }
            public void read()
            {
                int y = 0;
                List<polzovatel> users = Soxran.Deserializer<List<polzovatel>>("D:\\practos.json");
                foreach (var item in users)
                {
                    Console.SetCursorPosition(3, y);
                    Console.Write(item.pudge);
                    Console.SetCursorPosition(20, y);
                    Console.Write(item.rol);
                    Console.SetCursorPosition(40, y);
                    Console.Write(item.ID);
                    y += 1;
                }
            }
            public void update()
            {
                Console.Clear();
                List<polzovatel> users = Soxran.Deserializer<List<polzovatel>>("D:\\practos.json");
                Console.WriteLine($"   id: {users[mesto].ID}\n   login: {users[mesto].pudge}\n   password: {users[mesto].porolchik}\n   role: {users[mesto].rol}");
               //Vыражения интерполированных строк, которые предоставляют удобный синтаксис для создания форматированных строк:
                int pos = 0;
                Console.SetCursorPosition(0, pos);
                Console.Write("->");
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        Console.SetCursorPosition(0, pos);
                        Console.Write("  ");
                        pos -= 1;
                        if (pos > 3) { pos = 3; }
                        if (pos < 0) { pos = 0; }
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        Console.SetCursorPosition(0, pos);
                        Console.Write("  ");
                        pos += 1;
                        if (pos > 3) { pos = 3; }
                        if (pos < 0) { pos = 0; }
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (pos == 0)
                        {
                            Console.SetCursorPosition(7, 0);
                            Console.Write("                             ");
                            Console.SetCursorPosition(7, 0);
                            string new_id = Console.ReadLine();
                            users[mesto].ID = new_id;
                        }
                        else if (pos == 1)
                        {
                            Console.SetCursorPosition(10, 1);
                            Console.Write("                             ");
                            Console.SetCursorPosition(10, 1);
                            string new_login = Console.ReadLine();
                            users[mesto].pudge = new_login;
                        }
                        else if (pos == 2)
                        {
                            Console.SetCursorPosition(13, 2);
                            Console.Write("                             ");
                            Console.SetCursorPosition(13, 2);
                            string new_password = Console.ReadLine();
                            users[mesto].porolchik = new_password;
                        }
                        else if (pos == 3)
                        {
                            Console.SetCursorPosition(9, 3);
                            Console.Write("                             ");
                            Console.SetCursorPosition(9, 3);
                            string new_role = Console.ReadLine();
                            users[mesto].rol = new_role;
                        }
                        Console.Clear();
                        Console.WriteLine($"   id: {users[mesto].ID}\n   login: {users[mesto].pudge}\n   password: {users[mesto].porolchik}\n   role: {users[mesto].rol}");
                    }
                    else if (key.Key == ConsoleKey.Escape) { Soxran.Serializer("D:\\practos.json", users); menushka(); break; }
                    Console.SetCursorPosition(0, pos);
                    Console.Write("->");
                }
            }
            public void menushka()
            {
                Console.Clear();
                List<polzovatel> users = Soxran.Deserializer<List<polzovatel>>("D:\\practos.json");
                int pos = 0;
                read();
                Console.SetCursorPosition(60, 0);
                Console.Write("f1 - Добавить пользователя");
                Console.SetCursorPosition(60, 1);
                Console.Write("f2 - Удалить пользователя");
                Console.SetCursorPosition(60, 5);
                Console.Write("Вы вошли. " + name);
                Console.SetCursorPosition(60, 2);
                Console.Write("f3 - поиск пользователя");
                Console.SetCursorPosition(3, users.Count + 2);
                Console.Write("Логин");
                Console.SetCursorPosition(20, users.Count + 2);
                Console.Write("Роль");
                Console.SetCursorPosition(40, users.Count + 2);
                Console.Write("id");
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        Console.SetCursorPosition(0, pos);
                        Console.Write("   ");
                        pos += 1;
                        if (pos > users.Count - 1) { pos = users.Count - 1; }
                        if (pos < 0) { pos = 0; }
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        Console.SetCursorPosition(0, pos);
                        Console.Write("   ");
                        pos -= 1;
                        if (pos > users.Count - 1) { pos = users.Count - 1; }
                        if (pos < 0) { pos = 0; }
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Soxran.Serializer("D:\\practos.json", users);
                        Console.Clear();
                        Autorize log = new Autorize();
                        break;
                    }
                    else if (key.Key == ConsoleKey.F1)
                    {
                        create();
                        break;
                    }
                    else if (key.Key == ConsoleKey.F2)
                    {
                        mesto = pos;
                        delete();
                        break;
                    }
                    else if (key.Key == ConsoleKey.F3)
                    {
                        Console.Clear();
                        Console.WriteLine("Поиск пользователей: ");
                        string edc = Console.ReadLine();
                        poisk(edc);
                        break;
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        mesto = pos;
                        update();
                        break;
                    }
                    Console.SetCursorPosition(0, pos);
                    Console.Write("->");
                }
            }
        }


    }
}
