using MongoDBProject.Controllers;
using MongoDBProject.Models;
using MongoDBProject.Services;
using Moq;
using System;
using Xunit;

namespace MongoDBProject.Unit.Tests
{
    public class StudentControllerShould
    {
        [Trait("Category", "Unit")]
        [Fact(DisplayName = "StudentController - Should call Student Service function once")]
        public void Get_CallOnce_ReturnSuccess()
        {
            //Arrange
            var id = new Guid().ToString();
            var _mockStudentService = new Mock<IStudentService>();
            var _controller = new StudentController(_mockStudentService.Object);
            var studentReturned = new Student();

            _mockStudentService.Setup(x => x.Get(id)).Returns(studentReturned);

            //Act
            var response = _controller.Get(id);

            //Assert
            _mockStudentService.Verify(s => s.Get(id), Times.Once, "Should call one time");
        }
    }
}