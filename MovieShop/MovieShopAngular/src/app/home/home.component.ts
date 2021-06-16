import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { MovieCard } from '../shared/models/moviecard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private movieService: MovieService) { }

  movies!: MovieCard[];
  //Born, school, married...death
  //angular lifecycle hooks
  ngOnInit(): void {
    //call our service
    this.movieService.getTopRevenueMovies().subscribe(
      
      m => {
        this.movies = m;
        console.log('Inside Home Component');
        console.table(this.movies);
      }

    );
  }

}
