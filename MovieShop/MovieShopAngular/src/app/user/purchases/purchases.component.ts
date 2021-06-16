import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/services/user.service';
import { MovieDetails } from 'src/app/shared/models/movieDetails';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent implements OnInit {
  id!: number;
  purchasedMovies!: MovieCard[];
  constructor(private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit(): void {
    //call our service
    this.route.paramMap.subscribe(
      params => {
        console.log(params);
        console.log(params.get('id'));
        this.id = Number(params.get('id'));
        console.log('Movie Id:' + this.id);
    
        this.userService.getPurchasedMovie(this.id).subscribe(
      
      m => {
        this.purchasedMovies = m;
        console.log('Inside Home Component');
        console.table(this.purchasedMovies);
      }

      );
    }
  )

}

}