using PracticaScrumClaro.DataManager;
using PracticaScrumClaro.Models;

public static class Program
{
	static List<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
	static void Main(string[] args)
	{
		PruebaGuardar();
		PruebaLeer();
	}
	private static void PruebaGuardar()
	{
		Proyectos.Add(new Proyecto { Nombre = "Equipo 1" });
		DataManager.SaveData(Proyectos, "Proyectos.txt");
	}
	private static void PruebaLeer()
	{
		Proyectos.Add(new Proyecto { Nombre = "Equipo 1" });
		var data = DataManager.GetData<List<Proyecto>>("Proyectos.txt");
	}
	private static void CreaMenu()
	{
		Console.Write("Seleccione una opcion");
		Console.Write("1. Crear Proyecto");
		Console.ReadLine();
	}
}

