using Logic.BLL;
using Logic.Models;
using PracticaScrumClaro.Models;
using System;

public sealed class ProyectoBLL_Facts
{
	[TestCase("Proyecto1.txt")]
	public void SaveData_WithFileNotCreated(string fileName)
	{
		Proyect testProject = new Proyect
		{
			Name = "Proyecto1",
			TeamName = "Eq01",
			Description = "El proyecto",
			Company = "Claro",
			InitialDate = DateTime.Now
		};
		ResponseData response = ProjectBLL.Save(testProject.Name, testProject.Description, testProject.Company,
			testProject.InitialDate, testProject.TeamName);
		Assert.That(response.IsSuccess, Is.EqualTo(false));
	}
}
