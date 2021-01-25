using System.Collections.Generic;

namespace Movies.Domain.Entities
{
    public class ResultEntity
    {
        public int Page { get; set; }
        public List<MovieSummaryEntity> Results { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}
