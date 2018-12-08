using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.MinimalMVVM;
using GUI.Model;
using ServiceLayer;

namespace GUI.ViewModel
{
    class CustomerViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> customers;
        private Customer currentCustomer;
        private CustomerModel customerModel;

        public ObservableCollection<Customer> Customers {

            get { return customers; }
            set { customers = value; RaisePropertyEventChanged(); }
        }

        public Customer CurrentCustomer {

            get { return currentCustomer; }
            set { currentCustomer = value; RaisePropertyEventChanged(); }
        }

        public CustomerModel CustomerModel {

            get { return customerModel; }
            set { customerModel = value; Customers = new ObservableCollection<Customer>(value.Customer); }
        }
    }
}
