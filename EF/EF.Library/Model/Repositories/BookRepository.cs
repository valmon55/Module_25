using EF.Library.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.Model.Repositories
{
    public class BookRepository
    {
        public Book SelectById(int id)
        {
            using (var db = new AppContext())
            {
                return (from book in db.Books
                        where book.Id == id
                        select book).FirstOrDefault();
            }
        }
        public IQueryable<Book> SelectAll()
        {
            using (var db = new AppContext())
            {
                return from book in db.Books
                       select book;
            } 
        }
        public void Remove(Book book)
        {
            using (var db = new AppContext()) 
            { 
                db.Remove(book);
                db.SaveChanges();
            }
        }
        public void Add(Book book) 
        {
            using (var db = new AppContext())
            {
                db.Add(book);
                db.SaveChanges();
            }
        }
        public void UpdateYearById(int id, string year) 
        {
            using (var db = new AppContext())
            {
                Book book = SelectById(id);
                book.PublishYear = year;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Получать список книг определенного жанра и вышедших между определенными годами.
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="yearFrom"></param>
        /// <param name="yearTo"></param>
        /// <returns></returns>
        public IQueryable<Book> GetBooksByGenreYears(Genre genre, int yearFrom, int yearTo)
        {
            using (var db = new AppContext())
            {
                var books = db.Books.Include(g => g.Genre)
                                    .Where(b => Int32.Parse(b.PublishYear) >= yearFrom &&
                                                Int32.Parse(b.PublishYear) <= yearTo).ToList().AsQueryable();
                    return books;
            }
        }
        /// <summary>
        /// Получать количество книг определенного жанра в библиотеке.
        /// Нужно учесть что книга в библиотеке == книга ни у кого на руках
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="yearFrom"></param>
        /// <param name="yearTo"></param>
        /// <returns></returns>
        public int GetBooksByGenreInLibrary(Genre genre)
        {
            using (var db = new AppContext())
            {
                var booksByGenre = db.Books.Include(g => g.Genre).Count();
                //var z = from user in db.Users
                //        from book in db.Books.Include(g => g.Genre)
                //        where book in user.
                return 0;
            }
        }
        /// <summary>
        /// Получать количество книг определенного автора в библиотеке.
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="yearFrom"></param>
        /// <param name="yearTo"></param>
        /// <returns></returns>
        public int GetBooksByAuthorInLibrary(Author author)
        {
            using (var db = new AppContext())
            {
                return 0;
            }
        }
        /// <summary>
        /// Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        /// </summary>
        /// <param name="author"></param>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public bool BookByAuthorIsInLibrary(Author author, string bookName)
        {
            using (var db = new AppContext())
            {
                return false;
            }
        }
        /// <summary>
        /// Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public bool BookIsOnUser(string bookName)
        {
            using (var db = new AppContext())
            {
                return false;
            }
        }
        /// <summary>
        /// Получение последней вышедшей книги.
        /// </summary>
        /// <returns></returns>
        public Book LastPublishedBook()
        {
            using (var db = new AppContext())
            {
                return null;
            }
        }
        /// <summary>
        /// Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Book> SelectAllOrderedByName()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderBy(n => n.Name);
            }
        }
        /// <summary>
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Book> SelectAllOrderedDescByPublishYear()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderByDescending(n => Int32.Parse(n.PublishYear));
            }
        }


    }
}
