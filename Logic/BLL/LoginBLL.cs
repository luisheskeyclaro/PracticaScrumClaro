using Logic.Models;

namespace Logic.BLL
{
	public class LoginBLL
	{
		List<User> _Users = new List<User>();
		public ResponseData Authenticate(Login login)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			var data = Logic.DataManager.DataManager.GetData<List<User>>("Users.txt");
			IEnumerable<User> users = new List<User>();
			User user = new User();
			try
			{
				if (login.Pass.Length < 5) return new ResponseData { IsSuccess = false, Message = "Cantidad de caracteres de contraseña invalidos." };
				users = data.Where(m => m.Name == login.Name);
				if (users.Count() <= 0) return new ResponseData { IsSuccess = false, Message = "El usuario no existe." };
				user = users.FirstOrDefault();
				if (user.FailPassCount > 3) return new ResponseData { IsSuccess = false, Message = "Usuario bloqueado temporalmente, contactar al administrador." };
				//Usuario y contraseña validos.
				if (user.Pass == login.Pass)
				{
					foreach (var item in data)
					{
						if (item.Name == login.Name)
						{
							item.FailPassCount = 0;
						}
					}
					Logic.DataManager.DataManager.SaveData(data, "Users.txt");
					return new ResponseData { IsSuccess = true, Message = "Logueado Correctamente.", Data = user };
				};
				//Contraseña invalida.

				foreach (var item in data)
				{
					if (item.Name == login.Name)
					{
						item.FailPassCount++;
					}
				}
				Logic.DataManager.DataManager.SaveData(data, "Users.txt");
				return new ResponseData { IsSuccess = false, Message = "Contraseña invalida." };
			}
			catch (Exception ex)
			{
				return new ResponseData { IsSuccess = false, Message = ex.Message };
			}
		}
	}
}
