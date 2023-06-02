using FakeItEasy;
using BMIWebApi.Interfaces;
using AutoMapper;
using BMIWebApi.Models;
using indexWebApi.Controllers;
using BMIWebApi.Dto;
using Microsoft.AspNetCore.Mvc;
using BMIWebApi.Repositories;
using BMIWebApi.Helpers;

namespace BMIWebApi.Test.Controller
{
    public class PacientControllerTest
    {
        [Fact]
        public void GetBMIInfo_ReturnsOkResult_WhenMeasurementsAreValid()
        {
            // Arrange
            double height = 170;
            double weight = 60;
            double expectedBMI = 20.76;
            string expectedDescription = "Нормальная масса тела. Степень ожирения: 2/6.";

            var pacientRepository = A.Fake<IPacientRepository>();
            var mapper = A.Fake<IMapper>();
            var controller = new PacientController(pacientRepository, mapper);

            // Act
            var result = controller.GetBMIInfo(height, weight);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var bmiResult = Assert.IsType<BMIResult>(okResult.Value);

            Assert.Equal(expectedBMI, bmiResult.Index, 2);
            Assert.Equal(expectedDescription, bmiResult.Description);
        }

        [Fact]
        public void GetBMIInfo_ReturnsBadRequest_WhenMeasurementsAreInvalid()
        {
            // Arrange
            double height = 300;
            double weight = 70;
            string expectedErrorMessage = "Ошибка: Рост должен быть больше 50 см или меньше 250 см, а также Вес должен быть больше 5 кг или меньше 500 кг.";

            var pacientRepository = A.Fake<IPacientRepository>();
            var mapper = A.Fake<IMapper>();
            var controller = new PacientController(pacientRepository, mapper);

            // Act
            var result = controller.GetBMIInfo(height, weight);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedErrorMessage, badRequestResult.Value);
        }

        [Fact]
        public void AddPacient_WithValidData_ReturnsOkResult()
        {
            // Arrange
            var pacientRepository = A.Fake<IPacientRepository>(); 
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });
            var mapper = new Mapper(configuration);
            var controller = new PacientController(pacientRepository, mapper);

            var pacient = new PacientDto()
            {
                NickName = "NewTest1",
                Surname = "NewTest",
                FirstName = "NewTest",
                Patronymic = "NewTest",
                Age = 10,
                Height = 170,
                Weight = 77
            };

            // Act
            var result = controller.AddPacient(pacient);
          
            // Assert
            Assert.IsType<OkObjectResult>(result);
            pacientRepository.Delete(pacient.NickName);
        }

        [Fact]
        public void AddPacient_WithInvalidData_ReturnsBadRequestResult()
        {
            // Arrange
            var pacientRepository = A.Fake<IPacientRepository>();
            var mapper = A.Fake<IMapper>();
            var controller = new PacientController(pacientRepository, mapper);

            var pacient = new PacientDto()
            {
                NickName = "NewTest",
                Surname = "NewTest",
                FirstName = "NewTest",
                Patronymic = "NewTest",
                Age = 10,
                Height = 10,
                Weight = 10
            };

            // Act
            var result = controller.AddPacient(pacient);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);

            pacientRepository.Delete(pacient.NickName);

        }

        // Add more test cases as needed for different scenarios
    }
}
