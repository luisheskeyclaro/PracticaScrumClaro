using Logic.Models;
using PracticaScrumClaro.DataManager;
using PracticaScrumClaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics.Metrics;


namespace Logic.BLL
{
    public class TeamBLL
    {

        private bool IsValidCreatorRole(User user)
        {
            return user.Role == Role.ProductOwner || user.Role == Role.ScrumMaster;
        }

        private int CountDevelopers(Team team)
        {
            return team.Members.Count(member => member.Role == Role.Developer);
        }


        public ResponseData CreateScrumTeam(User user)
        {

            if (!IsValidCreatorRole(user))
            {
                return new ResponseData { IsSuccess = false, Message = "You do not have permission to create a team." };
            }


        Console.Write("Enter Team Name: ");
            string teamName = Console.ReadLine();
            Team scrumTeam = new Team(teamName);

            while (true)
            {
                Console.Write("Enter Member Name (or type 'done' to finish): ");
                string name = Console.ReadLine();

                if (name.ToLower() == "done")
                {
                    break;
                }

                

                Console.Write("Enter Member Role (Developer, ProductOwner, ScrumMaster, QA, Designer, etc): ");
                if (Enum.TryParse<Role>(Console.ReadLine(), out Role role))
                {
                    
                    Member member = new Member(name, role);

                    if (member.Role == Role.Developer && CountDevelopers(scrumTeam) > 7)
                    {
                        Console.Write("No more than 7 Developers are allowed. ");
                        continue;
                    }else
                    {
                        scrumTeam.AddMember(member);
                    }

                   
                }
                else
                {
                    Console.WriteLine("Invalid role. Please enter a valid role.");
                }
            }
            DataManager.SaveData<Team>(scrumTeam, "Team.txt");
            return new ResponseData { IsSuccess = true, Message = "Saved Successfully." };
           
        }


    }
}

