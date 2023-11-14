using EF.Library.Model.Entities;
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
    }
}
