
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GUI.MinimalMVVM;
using GUI.Model;
using ServiceLayer;
using DataRepositoryLayer;
using System.Windows;
using System.Linq;
using GUI.View;

namespace GUI.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> _customers;
        private Customer _currentCustomer;
        private CustomerModel _customerModel;
        private int _newCustomerID;
        private string _newCustomerName;
        private string _newCustomerSurname;
        private short _newCustomerAge;
        private string _newCustomerEmail;
        private string _newCustomerPhone;


        public CustomerViewModel() {
            FetchCustomerCommand = new DelegateCommand(() => CustomerModel = new CustomerModel());
            AddCustomerCommand = new DelegateCommand(AddCustomer);
            DeleteCustomerCommand = new DelegateCommand(DeleteCustomer);
            UpdateCustomerCommand = new DelegateCommand(UpdateCustomer);
            SaveChangesCommand = new DelegateCommand(SaveChanges);
            ShowPopupCommand = new DelegateCommand(ShowPopup);
        }

        public DelegateCommand FetchCustomerCommand { get; private set; }
        public DelegateCommand AddCustomerCommand { get; private set; }
        public DelegateCommand UpdateCustomerCommand { get; private set; }
        public DelegateCommand DeleteCustomerCommand { get; private set; }
        public DelegateCommand SaveChangesCommand { get; private set; }
        public DelegateCommand ShowPopupCommand { get; private set; }

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

        public int NewCustomerID {

            get { return _newCustomerID; }
            set { _newCustomerID = value; RaisePropertyEventChanged(); }
        }

        public string NewCustomerName {

            get { return _newCustomerName; }
            set { _newCustomerName = value; RaisePropertyEventChanged(); }
        }

        public string NewCustomerSurname
        {

            get { return _newCustomerSurname; }
            set { _newCustomerSurname = value; RaisePropertyEventChanged(); }
        }

        public short NewCustomerAge
        {

            get { return _newCustomerAge; }
            set { _newCustomerAge = value; RaisePropertyEventChanged(); }
        }

        public string NewCustomerEmail
        {

            get { return _newCustomerEmail; }
            set { _newCustomerEmail = value; RaisePropertyEventChanged(); }
        }

        public string NewCustomerPhone
        {

            get { return _newCustomerPhone; }
            set { _newCustomerPhone = value; RaisePropertyEventChanged(); }
        }

        public void AddCustomer() {

            if (DataRepository.CheckIfIDIsUnique(_newCustomerID) && !_newCustomerName.Any(c => char.IsDigit(c) || char.IsWhiteSpace(c)) 
                && !_newCustomerSurname.Any(c => char.IsDigit(c) || char.IsWhiteSpace(c)) 
                && !_newCustomerPhone.Any(c => char.IsLetter(c) || char.IsWhiteSpace(c))) {

                    Customer customer = new Customer()
                    {
                        Id = _newCustomerID,
                        Name = _newCustomerName,
                        Surname = _newCustomerSurname,
                        Age = _newCustomerAge,
                        Phone = _newCustomerPhone,
                        Email = _newCustomerEmail
                    };

                    Task.Run(() => { DataRepository.AddCustomer(customer); });
            }
            else {
                MessageBox.Show("Incorrect data","Error");
            }
        }

        public void DeleteCustomer() {
            Task.Run(() => { DataRepository.DeleteCustomer(_currentCustomer.Id); });
            _customers.Remove(_currentCustomer);
        }

        public void UpdateCustomer() {
            if (!_currentCustomer.Name.Any(c => char.IsDigit(c) || char.IsWhiteSpace(c))
                && !_currentCustomer.Surname.Any(c => char.IsDigit(c) || char.IsWhiteSpace(c))
                && !_currentCustomer.Phone.Any(c => char.IsLetter(c) || char.IsWhiteSpace(c))) {

                    Task.Run(() => { DataRepository.UpdateCustomer(_currentCustomer); });
            }
            else {
                MessageBox.Show("Incorrect data", "Error");
            }
        }

        public void SaveChanges() {
            Task.Run(() => { DataRepository.SaveChanges(); });
        }

        public void ShowPopup() {
            Popup popup = new Popup();
            popup.Show();
        }

    }
}
