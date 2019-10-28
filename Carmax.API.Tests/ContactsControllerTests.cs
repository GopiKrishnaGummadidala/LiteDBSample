using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Carmax.API.Data;
using System.Linq;
using Carmax.API.Models;
using Carmax.API.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Carmax.API.Tests
{
    [TestClass]
    public class ContactsControllerTests
    {
        [TestMethod]
        public void GetAllContacts_ShouldReturnAllContacts()
        {
            var dbContextMock = new Mock<IDbContext>();
            dbContextMock.Setup(db => db.GetContacts())
                        .Returns(getContactsMockData);

            var controller = new ContactsController(dbContextMock.Object);
            var result = controller.Get() as OkNegotiatedContentResult<IEnumerable<Contact>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Count());
        }

        [TestMethod]
        public void GetContact_ShouldReturnContact()
        {
            var dbContextMock = new Mock<IDbContext>();
            dbContextMock.Setup(db => db.GetContactById(It.IsAny<int>()))
                        .Returns(getContactByIdMockData);

            var controller = new ContactsController(dbContextMock.Object);
            var result = controller.Get(1) as OkNegotiatedContentResult<Contact>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
        }

        [TestMethod]
        public void GetContact_ShouldNotReturnContact()
        {
            var dbContextMock = new Mock<IDbContext>();
            dbContextMock.Setup(db => db.GetContactById(It.IsAny<int>()))
                        .Returns(getContactByIdMockData);

            var controller = new ContactsController(dbContextMock.Object);
            var result = controller.Get(2) as OkNegotiatedContentResult<Contact>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
        }


        private IList<Contact> getContactsMockData()
        {
            IList<Contact> mockData = new List<Contact>();
            mockData.Add(new Contact
            {
                Id = 1,
                Name = new Name
                {
                    First = "Test F",
                    Middle = "Test M",
                    Last = "Test L"
                },
                Email = "Test@gmail.com",
                Address = new Address
                {
                    City = "Test City",
                    State = "Test State",
                    Street = "Test Street",
                    Zip = "Test Zip"
                },
                Phone = new List<Phone>
                     {
                         new Phone
                         {
                              Number = "123123123",
                               Type = "Home"
                         },
                         new Phone
                         {
                              Number = "789789789",
                              Type = "Office"
                         }
                     }
            });
            return mockData;
        }

        private Contact getContactByIdMockData()
        {
            Contact mockData = new Contact
            {
                Id = 1,
                Name = new Name
                {
                    First = "Test F",
                    Middle = "Test M",
                    Last = "Test L"
                },
                Email = "Test@gmail.com",
                Address = new Address
                {
                    City = "Test City",
                    State = "Test State",
                    Street = "Test Street",
                    Zip = "Test Zip"
                },
                Phone = new List<Phone>
                     {
                         new Phone
                         {
                              Number = "123123123",
                               Type = "Home"
                         },
                         new Phone
                         {
                              Number = "789789789",
                              Type = "Office"
                         }
                     }
            };
            return mockData;
        }

    }
}
