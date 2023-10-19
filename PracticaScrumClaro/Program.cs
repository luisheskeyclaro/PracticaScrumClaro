using System.Runtime.CompilerServices;
using Logic.BLL;
using Logic.Utilities;

public static class Program
{
	private static Logic.BLL.LoginBLL loginBLL { get; set; } = new Logic.BLL.LoginBLL();
	static void Main(string[] args)
	{
		//Colocamos el Login
		//List<User> users = new List<User>();
		//users.Add(new User { Name = "luis", Pass = "12345678", FailPassCount = 0 });
		//DataManager.SaveData(users, "Users.txt");
		var response = loginBLL.Authenticate(new Logic.Models.Login { Name = "luis", Pass = "12345678" });
		Utilities.ResponseManager(response);
		Console.ReadKey();

		var response1 = ProyectoBLL.Save(new PracticaScrumClaro.Models.Proyecto{Nombre = "Proyecto 1", CodigoEquipo = "Eq01"});
		Utilities.ResponseManager(response1);
		Console.ReadKey();
	}
}

