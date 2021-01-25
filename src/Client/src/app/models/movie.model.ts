import { Genre } from "./genre.model";
import { ProductionCompany } from "./production-company.model";
import { ProductionCountry } from "./production-country.model";
import { SpokenLanguage } from "./spoken-language.model";

export interface Movie {
    adult:                 boolean;
    backdrop_Path:         string;
    belongs_To_Collection: null;
    budget:                number;
    genres:                Genre[];
    homepage:              string;
    id:                    number;
    imdb_Id:               string;
    original_Language:     string;
    original_Title:        string;
    overview:              string;
    popularity:            number;
    poster_Path:           string;
    production_Companies:  ProductionCompany[];
    production_Countries:  ProductionCountry[];
    release_Date:          Date;
    revenue:               number;
    runtime:               number;
    spoken_Languages:      SpokenLanguage[];
    status:                string;
    tagline:               string;
    title:                 string;
    video:                 boolean;
    vote_Average:          number;
    vote_Count:            number;
}