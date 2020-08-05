using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_L_Bojana_Backo
{
    class Service
    {
        // Method that add user to database
        public tblUser AddUser(tblUser user)
        {
            try
            {
                using (AudioPlayerDBEntities context = new AudioPlayerDBEntities())
                {
                    tblUser newUser = new tblUser();
                    newUser.Username = user.Username;
                    newUser.Password = user.Password;
                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    //userId = newUser.UserID;
                    return newUser;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
