using System.Collections.Generic;

namespace Movies.Domain.Entities
{
    public class MovieEntity
    {
        public bool Adult { get; set; }
        public string Backdrop_Path { get; set; }
        public BelongsToCollectionEntity Belongs_To_Collection { get; set; }
        public int Budget { get; set; }
        public List<GenreEntity> Genres { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string Imdb_Id { get; set; }
        public string Original_Language { get; set; }
        public string Original_Title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public object Poster_Path { get; set; }
        public List<ProductionCompanyEntity> Production_Companies { get; set; }
        public List<ProductionCountryEntity> Production_Countries { get; set; }
        public string Release_Date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public List<SpokenLanguageEntity> Spoken_Languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_Average { get; set; }
        public int Vote_Count { get; set; }
    }
}
