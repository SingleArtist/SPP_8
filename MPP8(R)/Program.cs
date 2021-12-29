using System;
using System.Linq;
using System.Reflection;
using ExportAtr;

//Задание 8
/*Создать на языке C# пользовательский атрибут с именем
ExportClass, применимый только к классам, и реализовать
консольную программу, которая:
-принимает в параметре командной строки путь к сборке .
(EXE- или DLL-файлу);
-загружает указанную сборку в память;
-выводит на экран полные имена всех public -типов данных этой
сборки, помеченные атрибутом ExportClass.*/

namespace EighthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(
                Assembly.GetExecutingAssembly().Location
            );

            var types = assembly.GetTypes().Where(t => t.IsPublic).OrderBy(type => type.Namespace + type.FullName);
            foreach (var type in types)
            {
                if (Attribute.GetCustomAttribute(type, typeof(ExportClass)) != null)
                {
                    Console.WriteLine(type.FullName);
                }
            }

        }
    }
}

namespace Animals
{
    [ExportClass]
    public class Lion
    { }

    [ExportClass]
    class Rhinoceros
    { }
}

namespace Devices
{
    [ExportClass]
    public class SmartPhone
    { }

}

namespace Fish
{
    [ExportClass]
    public class Shark
    { }

    public class Piranhas
    { }
}
