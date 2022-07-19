using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace List_T
{
    class FileDriver
    {
        private DateTime CurrentTime = DateTime.Now;
        public void Save(ref string MyName)
        {
            File.AppendAllText("dump_file.txt", CurrentTime.ToString() + " " + MyName + "\r\n");
        }
    }
    class WriteInFile
    {
        public List<string> NameIn = new List<string>() { };
        public List<string> NameOut = new List<string>() { };
        public string INorOUT = "", GuestName = "";
        public bool isCorrect = false;
        public void LIST()
        {
            do
            {
                Console.WriteLine("0 - вход, 1 - выход, 2 - завершение работы программы.\nВвод ->");
                INorOUT = Console.ReadLine();
                if (INorOUT == "0")
                {
                    Console.WriteLine("Кто вошёл:");
                    GuestName = Console.ReadLine();
                    NameIn.Add(GuestName);
                    GuestName += " ВХод";
                    FileDriver myFile = new FileDriver();
                    myFile.Save(ref GuestName);
                }
                else
                {
                    if (INorOUT == "1")
                    {
                        Console.WriteLine("Кто вышёл:");
                        GuestName = Console.ReadLine();
                        for (int i = 0; i < NameIn.Count(); i++)
                        {
                            if (NameIn[i] == GuestName)
                            {
                                isCorrect = true;
                                break;
                            }
                            else
                            {
                                isCorrect = false;
                            }
                        }
                        if (isCorrect == true)
                        {
                            NameOut.Add(GuestName);
                            GuestName += " Выход";
                            FileDriver myFile = new FileDriver();
                            myFile.Save(ref GuestName);
                        }
                        else
                        {
                            if (isCorrect == false)
                            {
                                Console.WriteLine("Такого имени нет в списке посетителей.");
                            }
                        }

                    }
                    else
                    {
                        if (INorOUT == "2")
                        {
                            Console.WriteLine("Завершение работы!");
                        }
                        else
                        {
                            Console.WriteLine("Такого варианта нет.Попробуйте ещё раз:");
                        }
                    }
                }
            } while (INorOUT != "2");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteInFile myList = new WriteInFile();
            myList.LIST();
        }
    }
}