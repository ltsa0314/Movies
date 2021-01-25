import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResultSearchMovies } from '../models/result-search-movies.model';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private http: HttpClient) { }

  movies( page: number, text: string):Observable<ResultSearchMovies>{
    return this.http.get<ResultSearchMovies>(`${environment.apiUrl}/Search/Movies?page=${page}&textToSearch=${text}`);
  }
  
  
}
