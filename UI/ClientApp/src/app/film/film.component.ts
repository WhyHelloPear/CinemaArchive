import { Component, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-home',
  templateUrl: './film.component.html',
})

export class FilmComponent {
  //data entities used
  public films: Film[] = [];
  public isNewFilmModel: Boolean = false;

  public selectedGenres: Genre[] = [];
  public unselectedGenres: Genre[] = [];
  public originalGenreList: Genre[] = [];

  public modalRef?: BsModalRef;

  filmForm: FormGroup;
  public selectedFilm?: Film;

  constructor(private modalService: BsModalService, private fb: FormBuilder, private http: HttpClient) {
    this.filmForm = this.fb.group({
      filmTitle: ['', Validators.required],
      releaseDate: ['', Validators.required],
    });

    var url = window.location.origin + "/genre/GetGenres";
    this.http.get<Genre[]>(url).subscribe(data => {
      // Set the data to a component property
      this.originalGenreList = data;
    });
  }

  ngOnInit(): void {
    this.getData();
  }

  openModal(template: TemplateRef<any>) {
    this.isNewFilmModel = true;
    this.selectedGenres = [];
    this.unselectedGenres = this.originalGenreList;
    this.modalRef = this.modalService.show(template);
  }

  openFilmUpdateForm(updateTemplate: TemplateRef<any>, film: Film) {
    this.isNewFilmModel = false;
    this.selectedFilm = film;

    this.filmForm.setValue({
      filmTitle: film.filmTitle,
      releaseDate:film.releaseDate,
    });

    //update release date form entry
    this.filmForm.controls.releaseDate.patchValue(
      new Date(film.releaseDate).toISOString().substring(0, 10) //strip the timestamp off the date
    );

    var selectedGenreIds = this.selectedFilm.genreList.map(g => g.genreId);

    this.selectedGenres = this.originalGenreList.filter(
      genre => selectedGenreIds.includes(genre.genreId)
    );
    this.unselectedGenres = this.originalGenreList.filter(
      genre => !selectedGenreIds.includes(genre.genreId)
    );

    this.modalRef = this.modalService.show(updateTemplate);
  }

  closeModal() {
    this.selectedGenres = [];
    this.unselectedGenres = this.originalGenreList;

    this.filmForm.reset();
    this.modalService.hide();
  }

  getData() {
    var url = window.location.origin + "/film/GetFilms";
    this.http.get<Film[]>(url).subscribe(data => {
      // Set the data to a component property
      this.films = data;
    });
  }

  onSubmit() {
    if (this.filmForm.valid) {
      if (this.isNewFilmModel) {



        this.createFilm();
      }
      else {
        
        this.updateFilm();
      }

      

    }
  }

  createFilm() {
    var newObject: Film = {
      filmId: -1,
      filmTitle: this.filmForm.value.filmTitle,
      releaseDate: this.filmForm.value.releaseDate as Date,
      genreList: [],
    };
    this.http.post(window.location.origin + "/film/CreateFilm", newObject).subscribe(response => {
      //var test = response.status;
      this.getData();
      this.closeModal();
    });
  }

  updateFilm() {
    const updatedFilm = {
      ...this.selectedFilm, // copy the selected row data
      ...this.filmForm.value // overwrite the values with the new form data
    };

    updatedFilm.genreList = this.selectedGenres;

    var url = window.location.origin + "/film/UpdateFilm";
    this.http.post(url, updatedFilm).subscribe(response => {
      //var test = response.status;
      this.getData();
      this.closeModal();
    });

  }

  onDeleteFilm( filmId: number) {
    const confirm = window.confirm("Are you sure you would like to delete this film?");

    if (confirm) {
      var url = window.location.origin + "/film/DeleteFilm";
      this.http.post(url, filmId).subscribe(response => {
        this.getData();
        this.closeModal();
      });

    }
  }

  RemoveAssociatedGenre(genre: Genre) {

    this.unselectedGenres.push(genre);

    this.selectedGenres = this.selectedGenres.filter(
      sg => sg.genreId != genre.genreId
    )
  }

  AddAssociatedGenre(genre: Genre) {

    this.selectedGenres.push(genre);

    this.unselectedGenres = this.unselectedGenres.filter(
      sg => sg.genreId != genre.genreId
    )

  }
}

interface Film {
  filmId: number;
  filmTitle: string;
  releaseDate: Date;
  genreList: Genre[];
}

interface Genre {
  genreId: number;
  genreName: string;
}
