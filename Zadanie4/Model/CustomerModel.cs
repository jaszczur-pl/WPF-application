using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;
using DataRepositoryLayer;

namespace GUI.Model
{
    public class CustomerModel
    {
        public IEnumerable<Customer> Customer { 
            get { return DataRepository.SelectAllCustomers(); }
        }
    }
}
