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

                Role role1 = new Role()
                {
                    Name = "Script"
                };

                Role role2 = new Role()
                {
                    Name = "Pencils"
                };




                ComicBook comicBook1 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today

                };

                comicBook1.AddArtists(artist1, role1);
                comicBook1.AddArtists(artist2, role2);

                ComicBook comicBook2 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today

                };

                comicBook2.AddArtists(artist1, role1);
                comicBook2.AddArtists(artist2, role2);

                ComicBook comicBook3 = new ComicBook()
                {
                    Series = series3,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today

                };

                comicBook2.AddArtists(artist2, role1);
                comicBook2.AddArtists(artist3, role2);

                context.ComicBooks.Add(comicBook1);
                context.ComicBooks.Add(comicBook2);
                context.ComicBooks.Add(comicBook3);

                context.SaveChanges();

                List<ComicBook> comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList();

                foreach (ComicBook c in comicBooks)
                {
                    List<string> artistRoleNames = c.Artists
                        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                    var artistRolesDisplayText = string.Join(", ", artistRoleNames);
                    Console.WriteLine(c.DisplayText);
                    Console.WriteLine(artistRolesDisplayText);
                }

                Console.ReadLine();
            }



    }
    }
}
