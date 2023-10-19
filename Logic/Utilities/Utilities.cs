using Logic.Models;

namespace Logic.Utilities
{
	public class Utilities
	{
		public static void ResponseManager(ResponseData response)
		{
			if (response.IsSuccess)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(response.Message);
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(response.Message);
			}
			Console.ResetColor();
		}
	}
}
