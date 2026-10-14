using Microsoft.AspNetCore.Mvc;
using UnitConversionAPI.Contracts;
using UnitConversionAPI.Service;

namespace UnitConversionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitConversionController : ControllerBase
    {
        private readonly ILogger<UnitConversionController> _logger;
        private readonly UnitConversionService _unitConversionService;
        private readonly ValidationService _validationService;

        public UnitConversionController(ILogger<UnitConversionController> logger, 
            UnitConversionService unitConversionService, ValidationService validationService)
        {
            _logger = logger;
            _unitConversionService = unitConversionService;
            _validationService = validationService;
        }

        [HttpPost(Name = "Convert")]
        public async Task<ActionResult<UnitConversionResponse>> Convert(UnitConversionRequest request)
        {
            var errors = _validationService.Validate(request);
            if (errors.Count >0)
            {
                return BadRequest(new UnitConversionResponse { Errors = errors });
            }

            var conversion = _unitConversionService.Convert(request.MeasurementType, request.From, request.To, request.Value);
            if (conversion.Errors.Count >0)
            {
                return BadRequest(new UnitConversionResponse { Errors = conversion.Errors });
            }

            return new UnitConversionResponse { Value = conversion.Value ?? 0 };
        }
    }
}
