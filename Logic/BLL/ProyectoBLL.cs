using Logic.Models;
using PracticaScrumClaro.Models;

namespace Logic.BLL
{
	public class ProyectoBLL
	{
		public ResponseData Save(Proyecto data)
		{
			try
			{
				Logic.DataManager.DataManager.SaveData<Proyecto>(data, "Proyectos.txt");
				return new ResponseData { IsSuccess = true, Message = "Guardado Correctamente." };

			}
			catch (Exception ex)
			{
				return new ResponseData { IsSuccess = false, Message = ex.Message };
			}
		}
	}
}
