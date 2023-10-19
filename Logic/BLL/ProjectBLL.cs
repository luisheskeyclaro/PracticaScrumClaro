﻿using Logic.Models;
using Logic.Utilities;
using PracticaScrumClaro.Models;
using System;
using System.Collections.Generic;

namespace Logic.BLL
{
	public class ProjectBLL
	{
		public static ResponseData Save(string nombre, string descripcion, string empresa, DateTime fechaInicio = DateTime.Now, string equipo = "")
		{
			try
			{
				Proyect data = ValidateFields(nombre, descripcion, empresa, fechaInicio, equipo);
				List<Proyect> proyects = Logic.DataManager.DataManager.GetData<List<Proyect>>("Proyectos.txt");
				proyects.Add(data);
				Logic.DataManager.DataManager.SaveData<Proyect>(proyects, "Proyectos.txt");
				return new ResponseData { IsSuccess = true, Message = "Guardado Correctamente." };

			}
			catch (Exception ex)
			{
				return new ResponseData { IsSuccess = false, Message = ex.Message };
			}
		}
		private static Proyect ValidateFields(string nombre, string descripcion, string empresa, DateTime fechaInicio, string equipo)
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
			return new Proyect { Name = nombre, Description = descripcion, Company = empresa, InitialDate = fechaInicio };
		}
	}

}
