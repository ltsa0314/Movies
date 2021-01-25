using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Domain.Entities
{
    public class BelongsToCollectionEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Poster_Path { get; set; }
        public string Backdrop_Path { get; set; }
    }
}
