using Logic.Models;
using PracticaScrumClaro.DataManager;
using PracticaScrumClaro.Models;

namespace Logic.BLL
{
	public class ProyectoBLL
	{
		public static ResponseData Save(string nombre, string descripcion, string empresa, DateTime fechaInicio, string equipo)
		{
			try
			{
				Proyecto data = ValidateFields(nombre, descripcion, empresa, fechaInicio, equipo);
                DataManager.SaveData<Proyecto>(data, "Proyectos.txt");
				return new ResponseData { IsSuccess = true, Message = "Guardado Correctamente." };

			}
			catch (Exception ex)
			{
				return new ResponseData { IsSuccess = false, Message = ex.Message };
			}
		}
		private Proyecto ValidateFields (string nombre, string descripcion, string empresa, DateTime fechaInicio, string equipo)
		{
            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(descripcion) || String.IsNullOrEmpty(empresa) || DateTime.IsNullOrEmpty(fechaInicio))
            {
                throw new Exception {"Faltan campos por llenar"};
            }
			if (!String.IsNullOrEmpty(equipo)
			{
				List<Team> equipos=DataManager.GetData<Team>("Team.txt");
				var validar = equipos.Where(m => m.Name == equipo);
				if (validar.FirstOrDefault() == null)
					throw new NullReferenceException("Equipo no existe");
			}
			return new Proyecto { Nombre = nombre, Descripcion = descripcion, Empresa = empresa, FechaInicio = fechaInicio};
        }
	}
	 
}
