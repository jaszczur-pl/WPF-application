using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.MinimalMVVM;
using GUI.Model;
using ServiceLayer;
using DataRepositoryLayer;

namespace GUI.ViewModel
{
    class CustomerViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> _customers;
        private Customer _currentCustomer;
        private CustomerModel _customerModel;

        public CustomerViewModel() {
            FetchCustomerCommand = new DelegateCommand(() => CustomerModel = new CustomerModel());
            AddCustomerCommand = new DelegateCommand(AddCustomer);
            DeleteCustomerCommand = new DelegateCommand(DeleteCustomer);
            UpdateCustomerCommand = new DelegateCommand(UpdateCustomer);
        }

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

        public DelegateCommand FetchCustomerCommand { get; private set; }
        public DelegateCommand AddCustomerCommand { get; private set; }
        public DelegateCommand UpdateCustomerCommand { get; private set; }
        public DelegateCommand DeleteCustomerCommand { get; private set; }

        public void AddCustomer() {
            Task.Run(() => { DataRepository.AddCustomer(_currentCustomer); });
        }

        public void DeleteCustomer() {
            Task.Run(() => { DataRepository.DeleteCustomer(_currentCustomer.Id); });
        }

        public void UpdateCustomer() {
            Task.Run(() => { DataRepository.UpdateCustomer(_currentCustomer); });
        }
    }
}
