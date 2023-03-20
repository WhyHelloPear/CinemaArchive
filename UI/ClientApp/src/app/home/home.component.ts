import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public archiveMetadata: ArchiveMetadata = {
    numFilms: -1,
    numPeople: -1,
    numGenres: -1
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<number>(baseUrl + 'film/GetFilmCount').subscribe(
      result => {
        this.archiveMetadata.numFilms = result;
      },
      error => {
        console.error(error);
        this.archiveMetadata.numFilms = 0;
      }
    );

    http.get<number>(baseUrl + 'genre/GetGenreCount').subscribe(
      result => {
        this.archiveMetadata.numGenres = result;
      },
      error => {
        console.error(error);
        this.archiveMetadata.numGenres = 0;
      }
    );
  }
}

interface ArchiveMetadata {
  numFilms: number;
  numPeople: number;
  numGenres: number;
}
