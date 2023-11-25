using EF.Library.Model.Entities;
using EF.Library.Model.Repositories;
using EF.Library.PLL;

namespace EF.Library
{
    internal class Program
    {
        public static MainView mainView;
        public static UserInfoView userInfoView;
        public static BookInfoView bookInfoView;
        public static GenreInfoView genreInfoView;
        public static AuthorInfoView authorInfoView;

        static void Main(string[] args)
        {
            //mainView = new MainView();
            //userInfoView= new UserInfoView();
            //bookInfoView= new BookInfoView();
            //genreInfoView= new GenreInfoView();
            //authorInfoView= new AuthorInfoView();

            //while(true)
            //{
            //    mainView.Show();
            //}

            ////////////////////////////////
            //return;
            PrepareData();
        }
        public static void PrepareData()
        {
            using (var db = new AppContext())
            {
                User jane = new User() { Name = "Jane" };
                User neo = new User() { Name = "Neo" };

                db.Users.AddRange(jane, neo);
                db.SaveChanges();

                Author dilts = new Author() { Name = "Robert Dilts" };
                Author ginzburg = new Author() { Name = "Ginzburg M.R." };
                Author toelsen = new Author() { Name = "Toelsen" };
                Author bakirov = new Author() { Name = "Anvar Bakirov" };

                db.Authors.AddRange(dilts, ginzburg, toelsen, bakirov);
                db.SaveChanges();

                Genre hlp = new Genre() { Name = "nlp practic" };
                Genre hipnosys = new Genre() { Name = "hipnos" };
                Genre programming = new Genre() { Name = "programming" };
                db.Genres.AddRange(hlp, hipnosys, programming);
                db.SaveChanges();


                Book hipnosysCourse = new Book() { Name = "Hipnosys Course", Author = ginzburg, Genre = hipnosys };
                Book nlpCourse = new Book() { Name = "Language Tricks", Author = dilts, Genre = hlp };
                Book cs_docs = new Book() { Name = ".Net 7.0", Author = toelsen, Genre = programming };
                Book manipulation = new Book() { Name = "Conversational Hypnosys", Author = bakirov, Genre = hlp };

                db.Books.AddRange(hipnosysCourse, nlpCourse, cs_docs, manipulation);
                db.SaveChanges();

                jane.books.Add(nlpCourse);
                jane.books.Add(hipnosysCourse);
                neo.books.Add(cs_docs);
                neo.books.Add(manipulation);

                db.SaveChanges();
            }
        }

    }
}