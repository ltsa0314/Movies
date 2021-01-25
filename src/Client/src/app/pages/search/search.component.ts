import { Component, HostListener, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieSummary } from '../../models/movie-summary.model';
import { SearchService } from '../../services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  public page: number = 1;
  public text: string = '';
  public movies: MovieSummary[] = [];
  public loading: boolean = false;

  constructor(private srvSearch: SearchService,private activatedRoute: ActivatedRoute,) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe( params => {
      this.text = params.text;

      this.srvSearch
      .movies(this.page,this.text)
      .subscribe((result) => (this.movies = result.movies));
    })


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
      this.srvSearch.movies(this.page,this.text).subscribe((result) => {
        this.movies.push(...result.movies);
        this.loading = false;
      });
    }
  }



}
