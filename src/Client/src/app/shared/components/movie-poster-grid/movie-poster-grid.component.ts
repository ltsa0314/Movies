import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MovieSummary } from 'src/app/models/movie-summary.model';

@Component({
  selector: 'app-movie-poster-grid',
  templateUrl: './movie-poster-grid.component.html',
  styleUrls: ['./movie-poster-grid.component.scss']
})
export class MoviePosterGridComponent implements OnInit {
  @Input() movies: MovieSummary[];
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  onMovieClick(movie: MovieSummary ){
    this.router.navigate(['/movie', movie.id ]);
  }
}
