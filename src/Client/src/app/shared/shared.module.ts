import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/header/header.component';
import { MoviePosterGridComponent } from './components/movie-poster-grid/movie-poster-grid.component';
import { PosterPipe } from './pipes/poster.pipe';
import { RatingModule } from 'ng-starrating';


@NgModule({
  declarations: [HeaderComponent, MoviePosterGridComponent, PosterPipe],
  imports: [CommonModule,RatingModule],
  exports:[HeaderComponent, MoviePosterGridComponent,PosterPipe]
})
export class SharedModule {}
