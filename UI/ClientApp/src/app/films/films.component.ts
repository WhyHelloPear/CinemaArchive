import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './films.component.html',
})
export class FilmsComponent {
  public films: Film[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Film[]>(baseUrl + 'film/GetFilms').subscribe(result => {
      this.films = result
    }, error => console.error(error));
  }
}

interface Film {
  filmId: number;
  filmTitle: string;
  releaseDate: Date;
}
