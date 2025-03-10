﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNavigation_Kravtcov.mvvm.Model
{
    //Модель сотрудников
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return FirstName; // Возвращаем название отдела
        }
    }
}
