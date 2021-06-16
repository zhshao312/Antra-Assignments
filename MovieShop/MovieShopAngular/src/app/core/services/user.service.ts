import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { MovieDetails } from 'src/app/shared/models/movieDetails';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getPurchasedMovie(id: number): Observable<MovieCard[]> {
    //  call the API to get the json data

    return this.http.get(`${environment.apiUrl}${'User/'+ id + '/purchases'}`)
      .pipe(map(resp => resp as MovieCard[]))

  }
}
