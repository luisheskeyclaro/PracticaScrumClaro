using Logic.Models;

namespace Logic.BLL
{
    public class TeamBLL
    {
        private bool IsValidCreatorRole(User user)
        {
            return user.Role == Role.ProductOwner || user.Role == Role.ScrumMaster;
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

            bool continueAddingMembers = true;

            while (continueAddingMembers)
            {
                Console.Write("Enter Member Name (or type 'done' to finish): ");
                string name = Console.ReadLine();

                if (name.ToLower() == "done")
                {
                    continueAddingMembers = false;
                }
                else
                {
                    Console.Write("Enter Member Role (Developer, ProductOwner, ScrumMaster, QA, Designer, etc): ");
                    if (Enum.TryParse<Role>(Console.ReadLine(), out Role role))
                    {
                        Member member = new Member(name, role);
                        scrumTeam.AddMember(member);
                    }
                    else
                    {
                        Console.WriteLine("Invalid role. Please enter a valid role.");
                    }
                }
            }

            Logic.DataManager.DataManager.SaveData<Team>(scrumTeam, "Team.txt");
            return new ResponseData { IsSuccess = true, Message = "Team created successfully." };
        }
    }
}
