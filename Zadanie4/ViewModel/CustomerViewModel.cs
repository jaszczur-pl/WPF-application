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
        private ObservableCollection<Customer> _customers;
        private Customer _currentCustomer;
        private CustomerModel _customerModel;

        public ObservableCollection<Customer> Customers {

            get { return _customers; }
            set { _customers = value; RaisePropertyEventChanged(); }
        }

        public Customer CurrentCustomer {

            get { return _currentCustomer; }
            set { _currentCustomer = value; RaisePropertyEventChanged(); }
        }

        public CustomerModel CustomerModel {

            get { return _customerModel; }
            set { _customerModel = value; Customers = new ObservableCollection<Customer>(value.Customer); }
        }
    }
}
