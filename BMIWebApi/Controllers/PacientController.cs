using AutoMapper;
using BMIWebApi.Dto;
using BMIWebApi.Enums;
using BMIWebApi.Exceptions;
using BMIWebApi.Helpers;
using BMIWebApi.Interfaces;
using BMIWebApi.Models;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace indexWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientController : ControllerBase
    {
        private readonly IPacientRepository pacientRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Минимальное значение для значения роста (в сантиметрах).
        /// </summary>
        private const int MinHeightValue = 50;
        /// <summary>
        /// Максимальное значение для значения роста (в сантиметрах).
        /// </summary>
        private const int MaxHeightValue = 250;
        /// <summary>
        /// Минимальное значение для значения веса (в килограммах).
        /// </summary>
        private const int MinWeightValue = 5;
        /// <summary>
        /// Максимальное значение для значения веса (в килограммах).
        /// </summary>
        private const int MaxWeightValue = 500;

        public PacientController(IPacientRepository pacientRepository, IMapper mapper)
        {
            this.pacientRepository = pacientRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(BMIResult))]
        /// <summary>
        /// Получает информацию о BMI на основе роста и веса.
        /// </summary>
        /// <param name="height">Рост в сантиметрах.</param>
        /// <param name="weight">Вес в килограммах.</param>
        /// <returns>Объект BMIResult с индексом и описанием BMI.</returns>
        public IActionResult GetBMIInfo(double height, double weight)
        {
            try
            {
                Validator.ValidateMeasurement(height, MinHeightValue, MaxHeightValue, $"Рост должен быть от {MinHeightValue} до {MaxHeightValue}");
                Validator.ValidateMeasurement(weight, MinWeightValue, MaxWeightValue, $"Вес должен быть от {MinWeightValue} до {MaxWeightValue}");
                
                double index = BMIResult.CalculateBMI(height, weight);

                string description = BMIResult.GetBMIDescription(index);

                var result = new BMIResult()
                {
                    Index = index,
                    Description = description,
                };

                return Ok(result);
            }
            catch (NotValidMeasurementsException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        /// <summary>
        /// Добавляет нового пациента.
        /// </summary>
        /// <param name="pacientDto">DTO пациента.</param>
        /// <returns>Результат операции.</returns>
        public IActionResult AddPacient([FromForm] PacientDto pacientDto)
        {
            if (pacientDto == null)
                return BadRequest(ModelState);

            try
            {
                Validator.ValidateMeasurement(pacientDto.Height, MinHeightValue, MaxHeightValue, $"Рост должен быть от {MinHeightValue} до {MaxHeightValue}");
                Validator.ValidateMeasurement(pacientDto.Weight, MinWeightValue, MaxWeightValue, $"Вес должен быть от {MinWeightValue} до {MaxWeightValue}");
                
                var curPacient = pacientRepository.GetPacient(pacientDto.NickName);
                if (curPacient != null)
                    return BadRequest("Ошибка: Пользователь с таким ником уже существует");

                var pacientMap = mapper.Map<Pacient>(pacientDto);

                var bmiIndex = new BMIIndex
                {
                    Index = BMIResult.CalculateBMI
                    (pacientDto.Height, pacientDto.Weight),
                    Pacient = pacientMap
                };

                pacientMap.BMIIndex = bmiIndex;

                if (!pacientRepository.Add(pacientMap))
                {
                    ModelState.AddModelError("", "Что-то пошло не так. Попробуйте еще раз.");
                    return StatusCode(500, ModelState);
                }

                return Ok("Пользователь успешно добавлен!");
            }
            catch (NotValidMeasurementsException ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpPatch("update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        /// <summary>
        /// Обновляет информацию об пользователе
        /// </summary>
        /// <param name="pacientDto">DTO пациента.</param>
        /// <returns>Результат операции.</returns>
        public IActionResult UpdatePacient([FromForm] PacientDto pacientDto)
        {
            if (pacientDto == null)
                return BadRequest(ModelState);
            try
            {
                Validator.ValidateMeasurement(pacientDto.Height, MinHeightValue, MaxHeightValue, $"Рост должен быть от {MinHeightValue} до {MaxHeightValue}");
                Validator.ValidateMeasurement(pacientDto.Weight, MinWeightValue, MaxWeightValue, $"Вес должен быть от {MinWeightValue} до {MaxWeightValue}");

                var curPacient = pacientRepository.GetPacient(pacientDto.NickName);
                if (curPacient == null)
                    return BadRequest("Ошибка: Пациента с таким ником не существует.");

                var pacientMap = mapper.Map<Pacient>(pacientDto);

                pacientMap.BMIIndex = curPacient.BMIIndex;
                pacientMap.BMIIndex.Index = BMIResult.CalculateBMI(pacientDto.Height, pacientDto.Weight);

                if (!pacientRepository.Update(pacientMap))
                {
                    ModelState.AddModelError("", "Что-то пошло не так. Попробуйте еще раз.");
                    return StatusCode(500, ModelState);
                }

                return Ok("Пользователь успешно обновлен!");
            }
            catch (NotValidMeasurementsException ex)
            {
                return BadRequest(ex.Message);
            }

           
        }

        [HttpGet("FakePacient")]
        public IActionResult AddFakePacients()
        {
            for (int i = 0; i < 100; i++)
            {
                var fakeAge = new Random().Next(5, 60);
                var fakeHeight = new Random().Next(51, 200);
                var fakeWeight = new Random().Next(5, 100);

                var fakePacient = new Faker<Pacient>()
                    .RuleFor(x => x.NickName, x => x.Person.UserName)
                    .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                    .RuleFor(x => x.Surname, x => x.Person.LastName)
                    .RuleFor(x => x.Patronymic, x => x.Person.FullName)
                    .RuleFor(x => x.Age, fakeAge)
                    .RuleFor(x => x.Height, fakeHeight)
                    .RuleFor(x => x.Weight, fakeWeight);

                var bmiIndex = new BMIIndex
                {
                    Index = BMIResult.CalculateBMI(fakeHeight, fakeWeight),
                    Pacient = fakePacient
                };

                fakePacient.RuleFor(x => x.BMIIndex, bmiIndex);
                pacientRepository.Add(fakePacient);
            }

            return Ok("Успех!");
        }


    }
}
