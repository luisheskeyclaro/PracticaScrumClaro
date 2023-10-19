using Logic.BLL;
using Logic.Models;
using Logic.Utilities;
using System.Runtime.CompilerServices;

public static class Program
{
	private static Logic.BLL.LoginBLL loginBLL { get; set; } = new Logic.BLL.LoginBLL();


	static void Main(string[] args)
	{
		//Colocamos el Login
		List<User> users = new List<User>();
		users.Add(new User { Name = "luis", Pass = "12345678", FailPassCount = 0, Role = Role.Developer });
		Logic.DataManager.DataManager.SaveData(users, "Users.txt");
		var response = loginBLL.Authenticate(new Logic.Models.Login { Name = "luis", Pass = "12345678" });

        if (response.IsSuccess)
		{
			showMenu();
		}
		else
		{
			Utilities.ResponseManager(response);
		}

		Console.ReadKey();
	}


	static void createTeam()
	{
		TeamBLL teamBLL = new TeamBLL();
		teamBLL.CreateScrumTeam(user);

    }



	static void showMenu()
	{
		bool exit = false;
		while (!exit)
		{
			Console.Clear();
			Console.WriteLine("Scrum Team Management Console App\n");
			Console.WriteLine("1. Create Project");
			Console.WriteLine("2. View Projects");
			Console.WriteLine("3. Crear Team");
			Console.WriteLine("0. Exit");

			Console.Write("Select an option: ");

			if (int.TryParse(Console.ReadLine(), out int choice))
			{
				switch (choice)
				{
					case 1:
						// CreateProject();
						break;
					case 2:
						//  ViewProjects();
						break;
					case 3:
						createTeam();
                        break;
					case 0:
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Invalid option. Please try again.");
						break;
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid option.");
			}
		}
	}
}

