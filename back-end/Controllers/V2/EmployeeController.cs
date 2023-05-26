using api_web.infraestrutura;
using AutoMapper;
using api_web.ViewModel;
using api_web.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api_web.Domain.Model.EmployeeAggregate;

namespace api_web.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/employee")]
    [ApiVersion("2.0")]
    public class EmployeeController : ControllerBase
    {   
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeRepository> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var filepath = Path.Combine("storage", employeeView.Photo.FileName);
            using Stream fileStream = new FileStream(filepath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);
            var employee = new Employee(employeeView.name, employeeView.age, filepath);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            var dataByter = System.IO.File.ReadAllBytes(employee.photo);
            return File(dataByter, "image/png");
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity) 
        {
            var employess = _employeeRepository.Get(pageNumber, pageQuantity);

            return Ok(employess);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            var employess = _employeeRepository.Get(id);

            var employeesDTOS = _mapper.Map<EmployeeDTO>(employess);

            return Ok(employeesDTOS);
        }
    }
}
