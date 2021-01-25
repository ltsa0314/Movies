import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Movie } from '../../models/movie.model';
import { MovieService } from '../../services/movie.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss'],
})
export class MovieComponent implements OnInit {
  public movie: Movie;
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private location: Location,
    private srvMovie: MovieService
  ) {}

  ngOnInit(): void {
    const { id } = this.activatedRoute.snapshot.params;
    this.srvMovie.getDetails(id).subscribe((response) => {
      if (!response) this.router.navigateByUrl('/home');

      this.movie = response;
    });
  }
  onBack() {
    this.location.back();
  }
}
