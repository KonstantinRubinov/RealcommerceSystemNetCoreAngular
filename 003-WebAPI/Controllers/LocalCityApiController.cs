using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealcommerceBLL;
using System;
using System.Collections.Generic;

namespace RealcommerceAPI
{
	[Route("api")]
	[ApiController]
	public class LocalCityApiController : ControllerBase
	{
		private ILocalCityRepository localCityRepository;

		public LocalCityApiController(ILocalCityRepository _localCityRepository)
		{
			localCityRepository = _localCityRepository;
		}

		[HttpGet("fromlocal/city")]
		public IActionResult GetAllCities()
		{
			try
			{
				List<City> cities = localCityRepository.GetAllCities();
				return Ok(cities);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("fromlocal/city")]
		public IActionResult AddCity(City city)
		{
			if (city == null)
			{
				return BadRequest("Data is null.");
			}
			try
			{
				City addedCity = localCityRepository.AddCity(city);
				return StatusCode(StatusCodes.Status201Created, addedCity);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("fromlocal/city/{key}")]
		public IActionResult DeleteCity(string key)
		{
			try
			{
				int i = localCityRepository.DeleteCity(key);
				return NoContent();
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}
	}
}
