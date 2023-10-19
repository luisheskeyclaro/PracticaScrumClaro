using System;
using Logic.BLL;
using Logic.Models;
using PracticaScrumClaro.Models;

public sealed class ProyectoBLL_Facts
{
	[TestCase("Proyecto1.txt")]
	public void SaveData_WithFileNotCreated (string fileName)
	{
		Proyecto testProyecto = new Proyecto{Nombre = "Proyecto1", CodigoEquipo = "Eq01"};
		ResponseData response = ProyectoBLL.Save(testProyecto);
        Assert.That(response.IsSuccess, Is.EqualTo(false));
	}
}
