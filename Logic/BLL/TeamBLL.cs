using Logic.Models;
using PracticaScrumClaro.DataManager;
using PracticaScrumClaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace Logic.BLL
{
    public class TeamBLL
    {
        public ResponseData Save(Team data, Role creatorRole)
        {
            try
            {
                if (IsValidCreatorRole(creatorRole))
                {
                    DataManager.SaveData<Team>(data, "Team.txt");
                    return new ResponseData { IsSuccess = true, Message = "Guardado Correctamente." };
                }
                else
                {
                    return new ResponseData { IsSuccess = false, Message = "No tienes permiso para crear un equipo." };
                }
            }
            catch (Exception ex)
            {
                return new ResponseData { IsSuccess = false, Message = ex.Message };
            }
        }

        private bool IsValidCreatorRole(Role creatorRole)
        {
            // Validar si el creador tiene el rol de "ProductOwner" o "ScrumMaster"
            return creatorRole == Role.ProductOwner || creatorRole == Role.ScrumMaster;
        }

    }
}

