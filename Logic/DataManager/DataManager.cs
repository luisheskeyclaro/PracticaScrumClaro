using Newtonsoft.Json;

namespace Logic.DataManager
{
	public class DataManager
	{
		// Método genérico para guardar un objeto desde un archivo JSON
		public static void SaveData<T>(T data, string fileName)
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\" + fileName;
			string json = JsonConvert.SerializeObject(data);
			File.WriteAllText(baseDirectory, json);
		}
		// Método genérico para leer un objeto desde un archivo JSON
		public static T GetData<T>(string fileName)
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\" + fileName;

			if (File.Exists(baseDirectory))
			{
				string json = File.ReadAllText(baseDirectory);
				var d = JsonConvert.DeserializeObject<T>(json);
				return d;
			}
			else
			{
				throw new FileNotFoundException("El archivo no existe.");
			}
		}
	}
}
