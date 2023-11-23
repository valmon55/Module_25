using EF.Library.Model.Entities;
using EF.Library.Model.Repositories;

namespace EF.Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            { 
                UserRepository userRepository = new UserRepository();   

                User jane = new User() { Name = "Jane" };
                User neo = new User() { Name = "Neo" };

                db.Users.AddRange(jane,neo);
                db.SaveChanges();

                Book tennis = new Book() { Name = "Rollan Garros 23" };
                Book fantasy = new Book() { Name = "Kassiopear" };
                Book cs_docs = new Book() { Name = ".Net 7.0" };
                Book oracle = new Book() { Name = "Orackle 23c docs" };

                //db.Books.AddRange(tennis, fantasy, cs_docs);

                userRepository.AcceptBook(jane, tennis);
                userRepository.AcceptBook(jane, cs_docs);
                userRepository.AcceptBook(jane, oracle);
                userRepository.AcceptBook(neo, fantasy);
                userRepository.AcceptBook(neo, tennis);
                userRepository.AcceptBook(neo, fantasy);

                ////jane.books.AddRange(tennis, cs_docs);
                //jane.books.Add(cs_docs);
                //jane.books.Add(tennis);
                ////tennis.User = jane;

                ////neo.books.AddRange(fantasy, oracle);
                //neo.books.Add(fantasy);
                //neo.books.Add(oracle);

                db.SaveChanges();
            }
        }
    }
}