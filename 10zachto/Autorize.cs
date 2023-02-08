using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using System.Security.Permissions;
using _10zachto;

namespace _10zachto
{
    internal class polzovatel
    {
        public string pudge;
        public string ID;
        public string porolchik;
        public string rol;
        public polzovatel(string pud, string path, string roli, string id)
        {
            pudge = pud;
            porolchik = path;
            rol = roli;
            ID = id;

        }
    }

    internal class Autorize
    {
        private string path = "D:\\practos.json";
        public Autorize() { hleb(); }
        public void hleb()
        {
            Console.Clear();
            bool prikol = true;
            Console.SetCursorPosition(3, 0);
            Console.Write("Введите логин: ");
            Console.SetCursorPosition(3, 1);
            Console.Write("Введите пороль: ");
            Console.SetCursorPosition(3, 2);
            Console.Write("Вход в аккаунт");
            Console.SetCursorPosition(3, 3);
            Console.Write("Выход из программы");
            int put = 0;
            Console.SetCursorPosition(0, put);
            Console.WriteLine("->");
            string password = "";
            string login = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, put);
                    Console.Write(" ");
                    put -= 1;
                    if (put < 0)
                    {
                        put = 0;
                    }
                    if (put > 3)
                    {
                        put = 3;
                    }

                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, put);
                    Console.Write(" ");
                    put += 1;
                    if (put < 0)
                    {
                        put = 0;
                    }
                    if (put > 3)
                    {
                        put = 3;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (put == 0)
                    {
                        Console.SetCursorPosition(9, 0);
                        login = Console.ReadLine();
                    }
                    else if (put == 1)
                    {
                        Console.SetCursorPosition(10, 1);
                        password = Console.ReadLine();
                    }
                    else if (put == 2)
                    {
                        string text = File.ReadAllText(path);
                        List<polzovatel> sf = JsonConvert.DeserializeObject<List<polzovatel>>(text);
                        foreach (polzovatel pud in sf)
                        {
                            if ((login == pud.pudge) && (password == pud.porolchik))
                            {
                                if (pud.rol == "admin")
                                {
                                    prikol = false; Admin admin = new Admin(pud.pudge);
                                }

                            }
                            if (prikol == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Не правильные данные, попробуёте ещё раз");
                                Console.WriteLine("Чтобы попробовать нажмите R");
                                string bra = Console.ReadLine();
                                if (bra == "r")
                                {
                                    hleb();
                                    break;

                                }
                                else
                                {
                                    break;

                                }

                            }

                        }
                    }
                    else if (put == 3)
                    {
                        Console.Clear();
                        break;

                    }
                }
                Console.SetCursorPosition(0, put);
                Console.WriteLine("->");
            }


        }
    }
}  

