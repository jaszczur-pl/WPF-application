﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace GUI.Model
{
    public class CustomerView
    {
        public IEnumerable<Customer> Customer {
            get { return DataRepository.SelectAllCustomers(); }
        }
    }
}