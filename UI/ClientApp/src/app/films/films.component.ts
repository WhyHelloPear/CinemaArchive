import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';



import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgxFileDropModule } from 'ngx-file-drop';


@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    NgxFileDropModule
  ],
  providers: [],
})
export class AppModule { }



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
