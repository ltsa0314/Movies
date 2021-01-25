using System.Collections.Generic;

namespace Movies.Api.Dtos
{
    public class MovieSummaryDto
    {
        public MovieSummaryDto()
        {
            Genres = new List<string>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Original_Title { get; set; }
        public string Original_Language { get; set; }
        public string Overview { get; set; }
        public List<string> Genres { get; set; }
        public bool Adult { get; set; }
        public string Backdrop_Path { get; set; }
        public double Popularity { get; set; }
        public string Poster_Path { get; set; }
        public string Release_Date { get; set; }
        public bool Video { get; set; }
        public decimal Vote_Average { get; set; }
        public int Vote_Count { get; set; }
    }
}
