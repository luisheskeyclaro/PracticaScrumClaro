namespace PracticaScrumClaro.Test
{
	internal class LoginTests
	{

		[Test]
		public void ValidateUser_ValidCredentials_ReturnsTrue()
		{
			//List<User> users = new List<User>();
			//users.Add(new User { Name = "luis", Pass = "12345678", FailPassCount = 0 });
			//Logic.DataManager.DataManager.SaveData(users, "Users.txt");
			var result = new Logic.BLL.LoginBLL().Authenticate(new Logic.Models.Login { Name = "luis", Pass = "12345678" });
			// Assert
			Assert.True(result.IsSuccess);
		}

		[Test]
		public void ValidateUser_InvalidCredentials_ReturnsFalse()
		{
			var result = new Logic.BLL.LoginBLL().Authenticate(new Logic.Models.Login { Name = "luis", Pass = "12345674" });

			// Assert
			Assert.False(result.IsSuccess);
		}

		[Test]
		public void ValidateUser_PasswordLenght_ReturnsFalse()
		{
			var result = new Logic.BLL.LoginBLL().Authenticate(new Logic.Models.Login { Name = "luis", Pass = "123456744" });

			// Assert
			Assert.False(result.IsSuccess);
		}
		[Test]
		public void ValidateUser_FailPasswordCount4_ReturnsFalse()
		{
			var result = new Logic.BLL.LoginBLL().Authenticate(new Logic.Models.Login { Name = "luis", Pass = "12345674" });

			// Assert
			Assert.False(result.IsSuccess, result.Message);
		}
	}
}
