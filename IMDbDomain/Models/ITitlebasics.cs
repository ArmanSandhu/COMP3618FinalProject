using System;
using System.Collections.Generic;
using System.Text;

namespace IMDbDomain.Models
{
    public interface ITitlebasics<T>
    {
        string Tconst { get; set; }
        string TitleType { get; set; }
        string PrimaryTitle { get; set; }
        string OriginalTitle { get; set; }
        bool? IsAdult { get; set; }
        short? StartYear { get; set; }
        short? EndYear { get; set; }
        int? RuntimeMinutes { get; set; }
        string Genres { get; set; }
    }
}
