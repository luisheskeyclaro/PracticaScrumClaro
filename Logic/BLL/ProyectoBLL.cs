using Logic.Models;
using PracticaScrumClaro.DataManager;
using PracticaScrumClaro.Models;

namespace Logic.BLL
{
	public class ProyectoBLL
	{
		public ResponseData Save(Proyecto data)
		{
			try
			{
				DataManager.SaveData<Proyecto>(data, "Proyectos.txt");
				return new ResponseData { IsSuccess = true, Message = "Guardado Correctamente." };

			}
			catch (Exception ex)
			{
				return new ResponseData { IsSuccess = false, Message = ex.Message };
			}
		}
	}
}
