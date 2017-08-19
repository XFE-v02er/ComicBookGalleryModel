using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Context context = new Context())
            {
                context.ComicBooks.Add(new ComicBook()
                {
                    SeriesTitle = "The Amazing Spider-Man",
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today

                });
                context.SaveChanges();

                List<ComicBook> comicBooks = context.ComicBooks.ToList();

                foreach (ComicBook c in comicBooks)
                {
                    Console.WriteLine(c.SeriesTitle);
                }

                Console.ReadLine();
            }



    }
    }
}
