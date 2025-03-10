﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNavigation_Kravtcov.mvvm.Model
{
    //Модель отдела
    public class Department
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notice { get; set; }

        public override string ToString()
        {
            return Name; // Возвращаем название отдела
        }
    }
}
