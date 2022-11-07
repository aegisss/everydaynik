using System.Globalization;
using System.Xml.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int n = 0;
            int up = 2;
            int left = 0;
            string Arrow = "->";

            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape)
            {

                if (key.Key == ConsoleKey.DownArrow)
                {
                    up++;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    up--;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    while (key.Key != ConsoleKey.Backspace)
                    {
                        Console.Clear();
                        drew_note_all(n,up-2);
                        key = Console.ReadKey();
                    }
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    --n;
                    n = n_arr(n);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    ++n;
                    n = n_arr(n);
                }
                Console.Clear();

                int lenght_List = drew_note(n);
                if (lenght_List != 0)
                {
                    if (up < 2)
                    {
                        up = lenght_List + 2;
                    }
                    if (up > lenght_List + 2)
                    {
                        up = 2;
                    }
                    if (up > (lenght_List + 1))
                    {
                        left = 17;
                        Arrow = "<-";
                        if (key.Key == ConsoleKey.F)
                        {
                            Console.Clear();
                            add_new_note(key);
                        }
                    }
                    else
                    {
                        left = 0;
                        Arrow = "->";
                    }

                    Console.SetCursorPosition(left, up);
                    Console.WriteLine(Arrow);
                }
                key = Console.ReadKey();
            }
        }
        static int drew_note(int n)
        {
            Console.WriteLine("Ежедневник");
            var all_list = List_note();
            int Lenght_arr = all_list.Count;
            var list = all_list[n];
            if (list[0].name == " ")
            {
                Console.WriteLine("Нету никаких записей . ");
                return (0);
            }
            else
            {
                Console.WriteLine(list[1].date);
                foreach (note decription in list)
                {
                    Console.WriteLine(decription.name);
                }
                Console.WriteLine("Добавить заметку  ");
                return (list.Count);
            }
        }
        static int n_arr(int n)
        {
            var lenght_List_all = List_note().Count;
            if (n == lenght_List_all)
            {
                n = 0;
                return (n);
            }
            else if (n < 0)
            {
                n = lenght_List_all - 1;
                return (n);
            }
            else
            {
                return (n);
            }
        }
        static void add_new_note(ConsoleKeyInfo key)
        {
            var list = new List<note> { };
            DateTime nowTime = DateTime.Now;
            ConsoleKeyInfo key_end = key;
            while (key_end.Key != ConsoleKey.Backspace)
            {
                var note_arr = new note()
                {
                    name = "",
                    date = " ",
                    time = " ",
                    description = " ",
                    deadline = " "
                };
                Console.WriteLine("Введите название заметки : ");
                note_arr.name = Console.ReadLine();
                note_arr.date = nowTime.ToString();
                note_arr.time = nowTime.ToLongTimeString();
                Console.WriteLine("Введите описание заметки : ");
                note_arr.description = Console.ReadLine();
                Console.WriteLine("Введите дедлайн : ");
                note_arr.deadline = Console.ReadLine();

                key_end = Console.ReadKey();
                list.Add(note_arr);
                Console.Clear();
            }
            List_note().Add(list);
        }
        static void drew_note_all(int n, int up)
        {
            var arr = List_note();
            var element = arr[n];
            var elem = element[up];
            Console.WriteLine("Название заметки : " + elem.name);
            Console.WriteLine("Дата добавления заметки : " + elem.date);
            Console.WriteLine("Время добавления  заметки : " + elem.time);
            Console.WriteLine("Описание заметки : " + elem.description);
            Console.WriteLine("Дедлайн : " + elem.deadline);
        }
        static List<List<note>> List_note()
        {
            List<List<note>> List_note = new List<List<note>>
            {
                new List<note>
                {
                    new note
                    {
                        name = "  Сдать праки по C#",
                        date = "05.11.22",
                        time = "13:20",
                        description = "Я их не сделаю но пофик.",
                        deadline = "12.12.22"
                    },
                    new note()
                    {
                        name = "  Пойти на митинг",
                        date = "12.13.24",
                        time = "15:34",
                        description = "Навальный Лёха э Навальный Лёха у",
                        deadline = "16.12.29"
                    }
                },
                new List<note>
                {
                    new note()
                    {
                        name = " халява",
                        date = "08.08.23" ,
                        time = " ",
                        description = " седня ничо не делем",
                        deadline = " "
                    }
                },
                new List<note>
                {
                    new note()
                    {
                       name = "  Практическая по ничего",
                       date = "09.07.22",
                       time = "16:16",
                       description = "можно ниче не делать впринципе",
                       deadline = "18.12.22"
                    },
                    new note()
                    {
                        name = "  Сделать ремикс на дорудуру",
                        date = "21.11.20",
                        time = "15:30",
                        description = "патамушта дорадура супердурадорадура",
                        deadline = "20.11.22"
                    },
                },
            };
            return (List_note);
        }
    }
}