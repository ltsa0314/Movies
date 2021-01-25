import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.prod';
import { ResultNowPaying } from '../models/result-now-playing.model';
import { Movie } from '../models/movie.model';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  constructor(private http: HttpClient) {}

  nowPlaying(page:number): Observable<ResultNowPaying> {
    return this.http.get<ResultNowPaying>(`${environment.apiUrl}/Movies/NowPlaying?page=${page}`);
  }

 getDetails(id:number): Observable<Movie> {
    return this.http.get<Movie>(`${environment.apiUrl}/Movies/GetDetails?movieId=${id}`);
  }
}
