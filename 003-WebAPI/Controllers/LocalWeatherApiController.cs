using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealcommerceBLL;
using System;
using System.Threading.Tasks;

namespace RealcommerceAPI
{
	[Route("api")]
	[ApiController]
	public class LocalWeatherApiController : ControllerBase
	{
		private ILocalWeatherRepository localWeatherRepository;
		private IApiWeatherRepository apiWeatherRepository;
		private ILocalCityRepository localCityRepository;

		public LocalWeatherApiController(ILocalWeatherRepository _localWeatherRepository, IApiWeatherRepository _apiWeatherRepository, ILocalCityRepository _localCityRepository)
		{
			localWeatherRepository = _localWeatherRepository;
			apiWeatherRepository = _apiWeatherRepository;
			localCityRepository = _localCityRepository;
		}

		[HttpGet("fromlocal/weather/{key}")]
		public async Task<IActionResult> GetWeather(string key)
		{
			try
			{
				Weather weather = localWeatherRepository.GetWeather(key);

				if (weather == null || weather.weatherKey == null)
				{
					weather = await apiWeatherRepository.GetCityWeather(key);
					weather = localWeatherRepository.AddWeather(weather);
				}
				else
				{
					DateTime nowTime = DateTime.Now;
					DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
					long second = weather.weatherEpochTime + 11250;
					DateTime weatherTime = epoch.AddSeconds(second);

					if ((nowTime - weatherTime).TotalMinutes > 180)
					{
						weather = await apiWeatherRepository.GetCityWeather(key);
						weather = localWeatherRepository.UpdateWeather(weather);
					}
				}
				return Ok(weather);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("fromlocal/weather")]
		public IActionResult AddWeather(Weather weather)
		{
			try
			{
				if (weather == null)
				{
					return BadRequest("Data is null.");
				}

				Weather addedWeather = localWeatherRepository.AddWeather(weather);
				return StatusCode(StatusCodes.Status201Created, addedWeather);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}
	}
}
