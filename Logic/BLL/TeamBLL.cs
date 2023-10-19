using Logic.Models;
using PracticaScrumClaro.DataManager;
using PracticaScrumClaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Logic.BLL

{
    public class TeamBLL
    {
        public ResponseData Save(Team data)
        {
            try
            {
                DataManager.SaveData<Team>(data, "Team.txt");
                return new ResponseData { IsSuccess = true, Message = "Guardado Correctamente." };

            }
            catch (Exception ex)
            {
                return new ResponseData { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
