using Logic.Models;
using Logic.Utilities;
using PracticaScrumClaro.Models;
using System;
using System.Collections.Generic;

namespace Logic.BLL
{
	public class ProjectBLL
	{
		public static ResponseData Save(string nombre, string descripcion, string empresa, DateTime fechaInicio, string equipo = "")
		{
			try
			{
				Project data = ValidateFields(nombre, descripcion, empresa, fechaInicio, equipo);
				List<Project> proyects = Logic.DataManager.DataManager.GetData<List<Project>>("Proyectos.txt");
				proyects.Add(data);
				Logic.DataManager.DataManager.SaveData<List<Project>>(proyects, "Proyectos.txt");
				return new ResponseData { IsSuccess = true, Message = "Guardado Correctamente." };

			}
			catch (Exception ex)
			{
				return new ResponseData { IsSuccess = false, Message = ex.Message };
			}
		}
		public static ResponseData AsignTeam (string projectName, string teamname)
		{
			try
			{
				List<Project> proyects = Logic.DataManager.DataManager.GetData<List<Project>>("Proyectos.txt");
				var searchproyect = proyects.Where(p=> p.Name == projectName).FirstOrDefault();
				if (searchproyect == null)
					throw new Exception("No se encontro un proyecto con ese nombre");
				
				List<Team> teams = Logic.DataManager.DataManager.GetData<List<Team>>("Team.txt");
				var searchteam = teams.Where(t=> t.Name == teamname).FirstOrDefault();
				if(searchteam == null)
					throw new Exception("No se encontro un equipo con ese nombre");

				if(String.IsNullOrEmpty(searchproyect.TeamName))
					throw new Exception("Ya tiene un equipo asignado");
				
				searchproyect.TeamName = searchteam.Name;

				Logic.DataManager.DataManager.SaveData<List<Project>>(proyects, "Proyectos.txt");
				return new ResponseData { IsSuccess = true, Message = "Guardado Correctamente." };

			}
			catch (Exception ex)
			{
				
				return new ResponseData { IsSuccess = false, Message = ex.Message };;
			}
		}
		private static Project ValidateFields(string nombre, string descripcion, string empresa, DateTime fechaInicio, string equipo)
		{
			if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(descripcion) || String.IsNullOrEmpty(empresa))
			{
				throw new Exception("Faltan campos por llenar");
			}
			if (!String.IsNullOrEmpty(equipo))
			{
				List<Team> equipos = DataManager.DataManager.GetData<List<Team>>("Team.txt");
				var validar = equipos.Where(m => m.Name == equipo);
				if (validar.FirstOrDefault() == null)
					throw new NullReferenceException("Equipo no existe");
			}
			return new Project { Name = nombre, Description = descripcion, Company = empresa, InitialDate = fechaInicio };
		}
	}

}
