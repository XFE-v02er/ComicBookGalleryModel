using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook //class name becomes Table Name
    {

        public ComicBook()
        {
            Artists = new List<Artist>();
        }

        // ID, ComicBookId, ComicBookID -- All formats that will associate the property w/ primary key
        public int Id { get; set; } //if "Id" is used, primary key identifier will be set to this
        public int SeriesId { get; set; } //ClassNameId == interprets as a foreign key property // can also use [ForeignKey="keyName"] if the var name must differ
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        public Series Series { get; set; }
        public ICollection<Artist> Artists { get; set; }

        public string DisplayText => $"{Series?.Title} #{IssueNumber}";
    }
    
}
