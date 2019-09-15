using GenFu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SolsticeContactAPI.Controllers;
using SolsticeContactAPI.Entities;
using SolsticeContactAPI.Models;
using SolsticeContactAPI.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SolsticeContactAPItest
{
    public class ContactControllerTests
    {
        private ContactController _contactController;
        private Mock<IContactRepository> _contactRepository;

        public ContactControllerTests()
        {            
            _contactRepository = new Mock<IContactRepository>();

            _contactController = new ContactController(_contactRepository.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
        }

        [Fact]
        public async Task Get_All_Contacts()
        {
            //Arrange
            A.Configure<Contact>().Fill<Address>(c => c.Address);
            var contacts = A.ListOf<Contact>(10).ToList();
            _contactRepository.Setup(x => x.GetAll(It.IsAny<ContactQueryModel>())).ReturnsAsync(contacts);

            //Act
            var result = await _contactController.GetAllContactAsync(new ContactQueryModel());

            //Assert
            Assert.NotNull(result);
        }
    }
}
