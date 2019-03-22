using System;
using System.Collections.Generic;

namespace IMDbDomain.Models
{
    public partial class Titlebasics : ITitlebasics<Titlebasics>
    {
        public string Tconst { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool? IsAdult { get; set; }
        public short? StartYear { get; set; }
        public short? EndYear { get; set; }
        public int? RuntimeMinutes { get; set; }
        public string Genres { get; set; }
    }
}
