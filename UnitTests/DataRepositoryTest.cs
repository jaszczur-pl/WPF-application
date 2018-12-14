using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;
using DataRepositoryLayer;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class DataRepositoryTest
    {

        [TestInitialize]
        public void TestInitialization() {


            Customer cust1 = new Customer() {
                Id = 1000,
                Name = "Jan",
                Surname = "Kowalski",
                Age = 30,
                Email = "jkowalski@gmail.com",
                Phone = "600100200",
            };

            Customer cust2 = new Customer() {
                Id = 2000,
                Name = "Mateusz",
                Surname = "Nowak",
                Age = 45,
                Email = "mn@gmail.com",
                Phone = "600100200",
            };

            Customer cust3 = new Customer() {
                Id = 3000,
                Name = "Ilona",
                Surname = "Grabarczyk",
                Age = 34,
                Email = "ig@gmail.com",
                Phone = "600100200",
            };

            DataRepository.AddCustomer(cust1);
            DataRepository.AddCustomer(cust2);
            DataRepository.AddCustomer(cust3);
        }

        [TestCleanup]
        public void TestCleanup() {
            DataRepository.DeleteCustomer(1000);
            DataRepository.DeleteCustomer(2000);
            DataRepository.DeleteCustomer(3000);
        }

        [TestMethod]
        public void AddCustomerTest() {

            int oldCustomersNumber = DataRepository.SelectAllCustomers().Count;

            Customer cust = new Customer() {
                Id = 5000,
                Name = "Jan",
                Surname = "Kowalski",
                Age = 30,
                Email = "jkowalski@gmail.com",
                Phone = "600100200",
            };

            DataRepository.AddCustomer(cust);
            int newCustomersNumber = DataRepository.SelectAllCustomers().Count;

            //check if number of records is greater than 0
            Assert.IsTrue(oldCustomersNumber < newCustomersNumber);
        }

        [TestMethod]
        public void DeleteCustomerTest() {

            int oldCustomersNumber = DataRepository.SelectAllCustomers().Count;

            DataRepository.DeleteCustomer(1000);
            int newCustomersNumber = DataRepository.SelectAllCustomers().Count;

            //check if number of records is different
            Assert.AreNotEqual(oldCustomersNumber, newCustomersNumber);
        }

        [TestMethod]
        public void UpdateCustomerTest() {


            int oldCustomersNumber = DataRepository.SelectAllCustomers().Count;

            Customer newCust = new Customer() {
                Id = 1000,
                Name = "Marcin",
                Surname = "Nowak",
                Age = 30,
                Email = "jkowalski@gmail.com",
                Phone = "600100200",
            };
            
            DataRepository.UpdateCustomer(newCust);

            Customer updatedCustomer = DataRepository.SelectAllCustomers().Where(c => c.Id == newCust.Id).First();
            int newCustomersNumber = DataRepository.SelectAllCustomers().Count;

            Assert.AreEqual(oldCustomersNumber, newCustomersNumber);
            Assert.AreEqual("Nowak", updatedCustomer.Surname);
            Assert.AreEqual("Marcin", updatedCustomer.Name);
        }
    }
}
