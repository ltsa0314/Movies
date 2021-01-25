import { Component, HostListener, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MovieSummary } from 'src/app/models/movie-summary.model';
import { MovieService } from '../../services/movie.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  public page: number = 1;
  public loading: boolean = false;
  public movies: MovieSummary[] = [];

  constructor(private srvMovies: MovieService) {}

  ngOnInit(): void {
    this.srvMovies
      .nowPlaying(this.page)
      .subscribe((result) => (this.movies = result.movies));
  }

  @HostListener('window:scroll', ['$event'])
  onScroll() {
    const pos =
      (document.documentElement.scrollTop || document.body.scrollTop) + 1300;
    const max =
      document.documentElement.scrollHeight || document.body.scrollHeight;

    if (pos > max) {
      if (this.loading) {
        return;
      }

      this.loading = true;
      this.page++;
      this.srvMovies.nowPlaying(this.page).subscribe((result) => {
        this.movies.push(...result.movies);
        this.loading = false;
      });
    }
  }

}
