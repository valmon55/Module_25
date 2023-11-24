using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.PLL
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Выберете с какими данными будете работать:");
            Console.WriteLine("1. Пользователи библиотеки");
            Console.WriteLine("2. Книги");
            Console.WriteLine("3. Авторы");
            Console.WriteLine("4. Жанры");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.userInfoView.Show();
                        break;
                    }
                case "2":
                    {
                        //Program.bookInfoView.Show();
                        break;
                    }
                case "3":
                    {
                        //Program.authorInfoView.Show();
                        break;
                    }
                case "4":
                    {
                        //Program.genreInfoView.Show();
                        break;
                    }
            }
        }
    }
}
