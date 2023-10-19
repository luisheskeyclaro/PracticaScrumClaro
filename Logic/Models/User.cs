namespace Logic.Models
{
	public class User
	{
		public string Name { get; set; }
		public string Pass { get; set; }
		public int FailPassCount { get; set; }
		public Role Role { get; set; }
	}
}
