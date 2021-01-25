import { MovieSummary } from "./movie-summary.model";

export interface ResultSearchMovies
{
    page: number;
    movies: MovieSummary[];
    total_Pages: number;
    total_Results: number;
}