using System.Data.SqlClient;

namespace RealcommerceBLL
{
	static public class CityStringsSql
	{
		static private string queryCitesString = "SELECT cityKey, cityLocalizedName, cityCountryLocalizedName, cityAdministrativeAreaLocalizedName from Cities";
		static private string queryCitesByIdString = "SELECT cityKey, cityLocalizedName, cityCountryLocalizedName, cityAdministrativeAreaLocalizedName from Cities where cityKey=@cityKey";
		static private string queryCitesPost = "INSERT INTO Cities (cityKey, cityLocalizedName, cityCountryLocalizedName, cityAdministrativeAreaLocalizedName) VALUES (@cityKey, @cityLocalizedName, @cityCountryLocalizedName, @cityAdministrativeAreaLocalizedName); SELECT cityKey, cityLocalizedName, cityCountryLocalizedName, cityAdministrativeAreaLocalizedName FROM Cities WHERE cityKey = @cityKey;";
		static private string queryCitesDelete = "DELETE FROM Weather WHERE weatherKey=@weatherKey; DELETE FROM Cities WHERE cityKey=@weatherKey;";

		static public SqlCommand GetAllCities()
		{
			return CreateSqlCommand(queryCitesString);
		}

		static public SqlCommand GetCity(string key)
		{
			return CreateSqlCommand(key, queryCitesByIdString);
		}

		static public SqlCommand AddCity(City city)
		{
			return CreateSqlCommand(city, queryCitesPost);
		}

		static public SqlCommand DeleteCity(string Key)
		{
			return CreateSqlCommand(Key, queryCitesDelete);
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);
			return command;
		}

		static private SqlCommand CreateSqlCommand(City city, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);
			command.Parameters.AddWithValue("@cityKey", city.cityKey);
			command.Parameters.AddWithValue("@cityLocalizedName", city.cityLocalizedName);
			command.Parameters.AddWithValue("@cityCountryLocalizedName", city.cityCountryLocalizedName);
			command.Parameters.AddWithValue("@cityAdministrativeAreaLocalizedName", city.cityAdministrativeAreaLocalizedName);
			return command;
		}

		static private SqlCommand CreateSqlCommand(string Key, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);
			command.Parameters.AddWithValue("@cityKey", Key);
			command.Parameters.AddWithValue("@weatherKey", Key);
			return command;
		}
	}
}