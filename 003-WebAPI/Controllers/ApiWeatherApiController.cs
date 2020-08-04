using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealcommerceBLL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealcommerceAPI
{
	[Route("api")]
	[ApiController]
	public class ApiWeatherApiController : ControllerBase
	{
		private IApiWeatherRepository apiWeatherRepository;

		public ApiWeatherApiController(IApiWeatherRepository _apiWeatherRepository)
		{
			apiWeatherRepository = _apiWeatherRepository;
		}

		[HttpGet("fromsite/city/{city}/")]
		public async Task<IActionResult> GetCityCode(string city)
		{
			try
			{
				List<City> cities = await apiWeatherRepository.GetCityCode(city);
				return Ok(cities);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("fromsite/Weather/{key}/")]
		public async Task<IActionResult> GetCityWeather(string key)
		{
			try
			{
				Weather weather = await apiWeatherRepository.GetCityWeather(key);
				return Ok(weather);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}
	}
}
