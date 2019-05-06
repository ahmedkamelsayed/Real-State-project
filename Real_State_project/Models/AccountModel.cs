using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Real_State_project.Models
{
    public class AccountModel
    {
        private List<account> listAccounts = new List<account>();

        public AccountModel()
        {
            IAEntities1 db = new IAEntities1();
            foreach (var item in db.users)
            {
                string role = "none";

                if (item.usertypeId == 1)
                {
                    role = "Customer";
                }
                else if (item.usertypeId == 2)
                {
                    role = "ProjectManager";
                }
                else if (item.usertypeId == 3)
                {
                    role = "TeamLeader";
                }
                else if (item.usertypeId == 4)
                {
                    role = "JuniorEngineer";
                }
                listAccounts.Add(new account { username = item.email, password = item.phone, roles = new string[] { role } });
            }
            listAccounts.Add(new account { username = "admin", password = "admin", roles = new string[] { "Admin" } });

        }

        public account find(string username)
        {
            return listAccounts.Where(acc => acc.username.Equals(username)).FirstOrDefault();
        }

        public account login(string username, string password)
        {
            return listAccounts.Where(acc => acc.username.Equals(username) && acc.password.Equals(password)).FirstOrDefault();
        }
    }

}