using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Context context = new Context())

            {

                Series series2 = new Series()
                {
                    Title = "The Amazing Spider-Man"
                };

                Series series3 = new Series()
                {
                    Title = "The Invincible Iron Man"
                };

                Artist artist1 = new Artist()
                {
                    Name = "Stan Lee"
                };

                Artist artist2 = new Artist()
                {
                    Name = "Steve Ditko"
                };

                Artist artist3 = new Artist()
                {
                    Name = "Jack Kirby"
                };

                ComicBook comicBook1 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today

                };

                comicBook1.Artists.Add(artist1);
                comicBook1.Artists.Add(artist2);

                ComicBook comicBook2 = new ComicBook()
                {
                    Series = series3,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today

                };

                comicBook2.Artists.Add(artist1);
                comicBook2.Artists.Add(artist2);

                ComicBook comicBook3 = new ComicBook()
                {
                    Series = series3,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today

                };

                comicBook3.Artists.Add(artist2);
                comicBook3.Artists.Add(artist3);

                context.ComicBooks.Add(comicBook1);
                context.ComicBooks.Add(comicBook2);
                context.ComicBooks.Add(comicBook3);

                context.SaveChanges();

                List<ComicBook> comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists)
                    .ToList();

                foreach (ComicBook c in comicBooks)
                {
                    List<string> artistNames = c.Artists.Select(a => a.Name).ToList();
                    var artistsDisplayText = string.Join(", ", artistNames);
                    Console.WriteLine(c.DisplayText);
                    Console.WriteLine(artistsDisplayText);
                }

                Console.ReadLine();
            }



    }
    }
}
