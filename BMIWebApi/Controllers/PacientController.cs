using AutoMapper;
using BMIWebApi.Dto;
using BMIWebApi.Enums;
using BMIWebApi.Interfaces;
using BMIWebApi.Models;
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
            if (!BMIResult.ValidateMeasurements(height, weight))
            {
                return BadRequest("Ошибка: Рост должен быть больше 50 см или меньше 250 см, а также Вес должен быть больше 5 кг или меньше 500 кг.");
            }

            double index = BMIResult.CalculateBMI(height, weight);
            string description = BMIResult.GetBMIDescription(index);

            var result = new BMIResult()
            {
                Index = index,
                Description = description,
            };

            return Ok(result);
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

            if (!BMIResult.ValidateMeasurements(pacientDto.Height, pacientDto.Weight))
                return BadRequest("Ошибка: Рост должен быть больше 50 см или меньше 250 см, а также Вес должен быть больше 5 кг или меньше 500 кг.");

            var curPacient = pacientRepository.GetPacient(pacientDto.NickName);
            if (curPacient != null)
                return BadRequest("Ошибка: Пользователь с таким ником уже существует");

            var pacientMap = mapper.Map<Pacient>(pacientDto);

            var bmiIndex = new BMIIndex
            {
                Index = BMIResult.CalculateBMI(pacientDto.Height, pacientDto.Weight),
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

            if (!BMIResult.ValidateMeasurements(pacientDto.Height, pacientDto.Weight))
                return BadRequest("Ошибка: Рост должен быть больше 50 см или меньше 250 см, а также Вес должен быть больше 5 кг или меньше 500 кг.");

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
    }
}
