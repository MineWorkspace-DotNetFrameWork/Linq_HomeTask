using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_HomeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание сотрудников
            List<Employee> employees = new List<Employee>()
            { 
                new Employee()
                {Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee()
                {Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee()
                {Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee()
                {Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee()
                {Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee()
                {Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee()
                {Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 },
            };
            // Создание департаментов
            List<Department> departments = new List<Department>()
            {
                new Department()
                {Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department()
                {Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department()
                {Id = 3, Country = "France", City = "Paris" },
                new Department()
                {Id = 4, Country = "Russia", City = "Moscow" },
            };

            // 1 -> Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке
            var res1 = from employee in employees
                       join department in departments
                       on employee.DepId equals department.Id
                       where department.Country == "Ukraine"
                       where department.City != "Donetsk"
                       select new
                       {
                           employee.Id,
                           employee.DepId,
                           employee.FirstName,
                           employee.LastName,
                           department.City
                       };

            foreach (var result in res1)
                Console.WriteLine(result);
            Console.WriteLine("\n");
            // 2 -> Вывести список стран без повторений
            var res2 = departments.Select(dep => dep.Country).Distinct();

            foreach (var result in res2)
                Console.WriteLine(result);
            Console.WriteLine("\n");
            // 3 -> Выбрать 3-х первых сотрудников, возраст которых превышает 25 лет
            var res3 = employees.SkipWhile(emp => emp.Age > 25);

            foreach (var result in res3)
                Console.WriteLine(result);
            Console.WriteLine("\n");
            // 4 -> Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года
            var res4 = from employee in employees
                       join department in departments
                       on employee.DepId equals department.Id
                       where department.City == "Kyiv"
                       where employee.Age > 23
                       select new
                       {
                           employee.FirstName,
                           employee.LastName,
                           employee.Age,
                       };
            foreach (var result in res4)
                Console.WriteLine(result); // Таких студентов нету!
            Console.WriteLine("\n Таких студентов не существует! ");
            Console.WriteLine("\n");
            // Finish ->
            Console.WriteLine("\n> Программа завершена (0_0)");
        }
    }
}
