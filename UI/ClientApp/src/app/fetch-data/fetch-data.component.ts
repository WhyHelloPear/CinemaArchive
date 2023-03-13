import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
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
