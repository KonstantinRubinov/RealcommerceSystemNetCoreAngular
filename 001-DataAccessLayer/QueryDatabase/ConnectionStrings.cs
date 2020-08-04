namespace RealcommerceDAL
{
	static public class ConnectionStrings
	{
		static private string connectionString = "Data Source=.;Initial Catalog=RealcommerceSystem;Integrated Security=True";
		static public string GetConnection()
		{
			return connectionString;
		}
		
		static private string ApiKey1 = "qiLiilQeNDyI0JIQukEn8VY3IcNuA8QR";
		static private string ApiKey2 = "DQkCwsqZyA7Y5BBOFsTJegZzBC2e3m3G";

		static public string GetApiKey()
		{
			return ApiKey1;
		}
	}
}