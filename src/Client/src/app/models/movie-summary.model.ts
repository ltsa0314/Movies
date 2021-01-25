export interface MovieSummary{
    id:                number;
    popularity:        number;
    vote_count:        number;
    video:             boolean;
    poster_Path:       string;
    adult:             boolean;
    backdrop_Path:     string;
    original_Language: string;
    original_Title:    string;
    genres:             string[];
    title:             string;
    vote_Average:      number;
    overview:          string;
    release_Date:      Date;
}