using EF.Library.Model.Entities;
using EF.Library.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.PLL
{
    public class BookInfoView
    {
        public void ShowMenu()
        {
            bool exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("Выберете действие:");
                Console.WriteLine("1. Все книги.");
                Console.WriteLine("2. Поиск книги по Id");
                Console.WriteLine("3. Список книг определенного жанра и вышедших между определенными годами.");
                Console.WriteLine("4. Количество книг определенного автора в библиотеке.");
                Console.WriteLine("5. Количество книг определенного жанра в библиотеке.");
                Console.WriteLine("6. Проверка наличия книги определенного автора и с определенным названием в библиотеке.");
                Console.WriteLine("7. Проверка наличия книги на руках у пользователя.");
                Console.WriteLine("8. Количество книг на руках у пользователя.");
                Console.WriteLine("9. Последняя вышедшая книга.");
                Console.WriteLine("10. Список всех книг, отсортированного в алфавитном порядке по названию.");
                Console.WriteLine("11. Список всех книг, отсортированного в порядке убывания года их выхода.");
                Console.WriteLine("0. Выйти из меню.");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Program.bookInfoView.Show();
                            break;
                        }
                    case "2":
                        {
                            Program.bookInfoView.ShowBook();
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
                    case "5":
                        {
                            //Program.genreInfoView.Show();
                            break;
                        }
                    case "6":
                        {
                            //Program.genreInfoView.Show();
                            break;
                        }
                    case "7":
                        {
                            //Program.genreInfoView.Show();
                            break;
                        }
                    case "8":
                        {
                            //Program.genreInfoView.Show();
                            break;
                        }
                    case "9":
                        {
                            //Program.genreInfoView.Show();
                            break;
                        }
                    case "10":
                        {
                            Program.bookInfoView.SelectAllOrderedByName();
                            break;
                        }
                    case "11":
                        {
                            Program.bookInfoView.SelectAllOrderedDescByPublishYear();
                            break;
                        }
                    case "0":
                        {
                            exitMenu = true;
                            break;
                        }
                }
            }
        }

        public void Show()
        {
            Console.WriteLine("Список всех книг:");

            using (var db = new AppContext())
            {
                BookRepository bookRepository = new BookRepository(db);
                var books = bookRepository.SelectAll();

                foreach (var book in books)
                {
                    Console.Write($"ID: {book.Id} ");
                    Console.Write($"Имя: {book.Name} ");
                    Console.Write($"PublishYear: {book.PublishYear} ");
                    Console.WriteLine();
                }
            }
        }
        public void ShowBook()
        {
            int bookId;
            Console.Write("Введите Id книги:");
            while (!int.TryParse(Console.ReadLine(), out bookId))
            {
                Console.WriteLine("Ошибка! Введите целое число!");
            }
            using (var db = new AppContext())
            {
                BookRepository bookRepository = new BookRepository(db);

                var book = bookRepository.SelectById(bookId);
                if (book is not null)
                {
                    Console.Write($"ID: {book.Id} ");
                    Console.Write($"Имя: {book.Name} ");
                    Console.Write($"PublishYear: {book.PublishYear} ");
                    Console.WriteLine();
                }
            }
        }

        public void SelectById()
        {
            Console.WriteLine("Введите Id книги:");

            using (var db = new AppContext())
            {
                BookRepository bookRepository = new BookRepository(db);
                var books = bookRepository.SelectAll();

                foreach (var book in books)
                {
                    Console.Write($"ID: {book.Id} ");
                    Console.Write($"Имя: {book.Name} ");
                    Console.Write($"PublishYear: {book.PublishYear} ");
                    Console.WriteLine();
                }
            }

        }

        public void SelectAllOrderedByName()
        {
            Console.WriteLine("Список всех книг в алфавитном порядке:");

            using (var db = new AppContext())
            {
                BookRepository bookRepository = new BookRepository(db);
                var books = bookRepository.SelectAllOrderedByName();

                foreach (var book in books)
                {
                    Console.Write($"ID: {book.Id} ");
                    Console.Write($"Имя: {book.Name} ");
                    Console.Write($"PublishYear: {book.PublishYear} ");
                    Console.WriteLine();
                }
            }

        }
        public void SelectAllOrderedDescByPublishYear()
        {
            Console.WriteLine("Список всех книг в обратном порядке по году выпуска:");

            using (var db = new AppContext())
            {
                BookRepository bookRepository = new BookRepository(db);
                try
                {
                    var books = bookRepository.SelectAllOrderedDescByPublishYear();

                    foreach (var book in books)
                    {
                        Console.Write($"ID: {book.Id} ");
                        Console.Write($"Имя: {book.Name} ");
                        Console.Write($"PublishYear: {book.PublishYear} ");
                        Console.WriteLine();
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
