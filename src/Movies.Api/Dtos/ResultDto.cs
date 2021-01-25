using System.Collections.Generic;

namespace Movies.Api.Dtos
{
    public class ResultDto
    {
        public int Page { get; set; }
        public List<MovieSummaryDto> Movies { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}
