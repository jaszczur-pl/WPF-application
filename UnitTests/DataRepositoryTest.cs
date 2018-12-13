using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;
using DataRepositoryLayer;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class DataRepositoryTest
    {

        [TestMethod]
        public void AddCustomerTest() {

            int oldCustomersNumber = DataRepository.SelectAllCustomers().Count;

            Customer cust = new Customer() {
                Id = 1000,
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

            Customer cust = new Customer() {
                Id = 10,
                Name = "Jan",
                Surname = "Kowalski",
                Age = 30,
                Email = "jkowalski@gmail.com",
                Phone = "600100200",
            };

            DataRepository.AddCustomer(cust);
            int oldCustomersNumber = DataRepository.SelectAllCustomers().Count;

            DataRepository.DeleteCustomer(10);
            int newCustomersNumber = DataRepository.SelectAllCustomers().Count;

            //check if number of records is different
            Assert.AreNotEqual(oldCustomersNumber, newCustomersNumber);
        }

        [TestMethod]
        public void UpdateCustomerTest() {

            Customer cust = new Customer() {
                Id = 1000,
                Name = "Jan",
                Surname = "Kowalski",
                Age = 30,
                Email = "jkowalski@gmail.com",
                Phone = "600100200",
            };

            DataRepository.AddCustomer(cust);
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

            Customer updatedCustomer = DataRepository.SelectAllCustomers().Where(c => c.Id == cust.Id).First();
            int newCustomersNumber = DataRepository.SelectAllCustomers().Count;

            Assert.AreEqual(oldCustomersNumber, newCustomersNumber);
            Assert.AreEqual("Nowak", updatedCustomer.Surname);
            Assert.AreEqual("Marcin", updatedCustomer.Name);
        }
    }
}
