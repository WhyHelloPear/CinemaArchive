import { Component, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgxFileDropEntry, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-home',
  templateUrl: './film.component.html',
})

export class FilmComponent {
  //data entities used
  public films: Film[] = [];

  public selectedGenres: Genre[] = [];
  public unselectedGenres: Genre[] = [];
  public originalGenreList: Genre[] = [];

  public modalRef?: BsModalRef;
  public files: NgxFileDropEntry[] = [];

  filmForm: FormGroup;
  public selectedFilm?: Film;

  constructor(private modalService: BsModalService, private fb: FormBuilder, private http: HttpClient) {
    this.filmForm = this.fb.group({
      filmTitle: ['', Validators.required],
      releaseDate: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.getData();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  openFilmUpdateForm(updateTemplate: TemplateRef<any>, film: Film) {
    this.selectedFilm = film;

    this.filmForm.setValue({
      filmTitle: film.filmTitle,
      releaseDate:film.releaseDate,
    });

    //if genres have not been loaded before, load and save them
    if (this.originalGenreList.length == 0) {
      var url = window.location.origin + "/genre/GetGenres";
      this.http.get<Genre[]>(url).subscribe(data => {
        // Set the data to a component property
        this.originalGenreList = data;
      });
    }


    //update release date form entry
    this.filmForm.controls.releaseDate.patchValue(
      new Date(film.releaseDate).toISOString().substring(0, 10) //strip the timestamp off the date
    );

    this.modalRef = this.modalService.show(updateTemplate);
  }

  closeModal() {
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
      var newObject: Film = {
        filmId: -1,
        filmTitle: this.filmForm.value.filmTitle,
        releaseDate: this.filmForm.value.releaseDate as Date,
        genreList: [],
      };

      var url = window.location.origin + "/film/CreateFilm";
      this.http.post(url, newObject).subscribe(response => {
        //var test = response.status;
        this.getData();
        this.closeModal();
      });

    }
  }

  onUpdateFilm() {
    const updatedFilm = {
      ...this.selectedFilm, // copy the selected row data
      ...this.filmForm.value // overwrite the values with the new form data
    };


    var url = window.location.origin + "/film/UpdateFilm";
    this.http.post(url, updatedFilm).subscribe(response => {
      //var test = response.status;
      this.getData();
      this.closeModal();
    });

  }

  onDeleteFilm( filmId: number) {
    debugger

    const confirm = window.confirm("Are you sure you would like to delete this film?");

    if (confirm) {
      var url = window.location.origin + "/film/DeleteFilm";
      this.http.post(url, filmId).subscribe(response => {
        this.getData();
        this.closeModal();
      });

    }
  }
  

  public dropped(files: NgxFileDropEntry[]) {
    this.files = files;
    for (const droppedFile of files) {

      // Is it a file?
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {

          // Here you can access the real file
          console.log(droppedFile.relativePath, file);

          /**
          // You could upload it like this:
          const formData = new FormData()
          formData.append('logo', file, relativePath)

          // Headers
          const headers = new HttpHeaders({
            'security-token': 'mytoken'
          })

          this.http.post('https://mybackend.com/api/upload/sanitize-and-save-logo', formData, { headers: headers, responseType: 'blob' })
          .subscribe(data => {
            // Sanitized logo returned from backend
          })
          **/

        });
      } else {
        // It was a directory (empty directories are added, otherwise only files)
        const fileEntry = droppedFile.fileEntry as FileSystemDirectoryEntry;
        console.log(droppedFile.relativePath, fileEntry);
      }
    }
  }

  public fileOver(event:any) {
    console.log(event);
  }

  public fileLeave(event:any) {
    console.log(event);
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
