using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_HomeTask
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
        public override string ToString()
        {
            return $"{FirstName, 10} {LastName,8}    Age: {Age}";
        }
    }
}
