using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SolsticeContactAPI.Controllers;
using SolsticeContactAPI.Repositories;
using System;
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
        public void Test1()
        {

        }
    }
}
