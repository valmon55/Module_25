using EF.Library.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.Model.Repositories
{
    public class UserRepository
    {
        public User SelectById(int id)
        {
            using (var db = new AppContext())
            {
                return (from user in db.Users
                        where user.Id == id
                        select user).FirstOrDefault();
            }
        }
        public IQueryable<User> SelectAll()
        {
            using (var db = new AppContext())
            {
                return from user in db.Users
                       select user;
            }
        }
        public void Remove(User user)
        {
            using (var db = new AppContext())
            {
                db.Remove(user);
                db.SaveChanges();
            }
        }
        public void Add(User user)
        {
            using (var db = new AppContext())
            {
                db.Add(user);
                db.SaveChanges();
            }
        }
        public void UpdateEmailById(int id, string email)
        {
            using (var db = new AppContext())
            {
                User user = SelectById(id);
                user.Email = email;
                db.SaveChanges();
            }
        }
        public int AcceptBook(User user, Book book)
        {
            using (var db = new AppContext())
            {
                // если книгу кто-то взял до нас
                if (book.User is not null)
                    return 0;

                user.books.Add(book);
                db.SaveChanges();
                return 1;
            }
        }
        public int ReturnBook(User user, Book book)
        {
            using (var db = new AppContext())
            {
                // если книга ни кем не взята
                if (book.User is null)
                    return 0;

                user.books.Remove(book);
                db.SaveChanges();
                return 1;
            }
        }
    }
}