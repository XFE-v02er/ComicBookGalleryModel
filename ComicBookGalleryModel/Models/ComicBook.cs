using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook //class name becomes Table Name
    {
        // ID, ComicBookId, ComicBookID -- All formats that will associate the property w/ primary key
        public int Id { get; set; } //if "Id" is used, primary key identifier will be set to this
        public Series Series { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }
    }
    
}
