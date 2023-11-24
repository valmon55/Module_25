using EF.Library.Model.Entities;
using EF.Library.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.PLL
{
    public class UserInfoView
    {
        public void Show()
        {
            Console.WriteLine("Пользавтели:");
            
            //UserRepository userRepository = new UserRepository();
            using (var db = new AppContext())
            {
                var users = from user in db.Users
                        select user;

                //var users = userRepository.SelectAll();
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.Id}");
                    Console.WriteLine($"Имя: {user.Name}");
                    Console.WriteLine($"eMail: {user.Email}");
                    Console.WriteLine();
                }
            }
        }
    }
}
