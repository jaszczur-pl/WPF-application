using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DataRepository
    {
        private CustomersDataContext context = new CustomersDataContext();

        public void AddCustomer(Customers customer) {

            context.Customers.InsertOnSubmit(customer);

            try {
                context.SubmitChanges();
            }
            catch (Exception e) { }
        }

        public void DeleteCustomer(int customerID) {

            var matchedCustomers =
                from customers in context.Customers
                where customers.Id == customerID
                select customers;

            foreach (Customers customer in matchedCustomers) {
                context.Customers.DeleteOnSubmit(customer);
            }

            try {
                context.SubmitChanges();
            }
            catch (Exception e) { }
        }

        public void UpdateCustomer(Customers cust) {

            var matchedCustomers =
                from customers in context.Customers
                where customers.Id == cust.Id
                select customers;

            foreach (Customers customer in matchedCustomers) {
                customer.Name = cust.Name;
                customer.Surname = cust.Surname;
                customer.Age = cust.Age;
                customer.Email = cust.Email;
            }

            try {
                context.SubmitChanges();
            }
            catch { }
        }

        public List<Customers> SelectAllCustomers() {

            List<Customers> allCustomers =
                 (from customers in context.Customers
                  select customers).ToList();

            return allCustomers;
        }
    }
}
