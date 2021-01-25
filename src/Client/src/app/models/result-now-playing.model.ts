import { Dates } from './dates.model';
import { MovieSummary } from './movie-summary.model';
export interface ResultNowPaying {
  dates: Dates;
  page: number;
  movies: MovieSummary[];
  total_Pages: number;
  total_Results: number;
}
