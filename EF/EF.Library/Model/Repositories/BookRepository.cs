﻿using EF.Library.Model.Entities;
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
        private AppContext appContext;
        public BookRepository(AppContext db)
        {
            this.appContext = db;
        }

        public Book SelectById(int id)
        {
            return (from book in appContext.Books
                    where book.Id == id
                    select book).FirstOrDefault();
        }
        public IQueryable<Book> SelectAll()
        {
            return from book in appContext.Books
                    select book;
        }
        public void Remove(Book book)
        {
            appContext.Remove(book);
            appContext.SaveChanges();
        }
        public void Add(Book book) 
        {
            appContext.Add(book);
            appContext.SaveChanges();
        }
        public void UpdateYearById(int id, string year) 
        {
            Book book = SelectById(id);
            book.PublishYear = year;
            appContext.SaveChanges();
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
                return appContext.Books.Include(g => g.Genre)
                                    .Where(b => Int32.Parse(b.PublishYear) >= yearFrom &&
                                                Int32.Parse(b.PublishYear) <= yearTo).ToList().AsQueryable();
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
            return appContext.Books.Include(g => g.Genre).Count();
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
            return appContext.Books.OrderBy(n => n.Name);
        }
        /// <summary>
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Book> SelectAllOrderedDescByPublishYear()
        {
            return appContext.Books.OrderByDescending(n => Int32.Parse(n.PublishYear));
        }


    }
}
