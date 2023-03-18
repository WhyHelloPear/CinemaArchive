import { Component, TemplateRef, EventEmitter, Output, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgxFileDropEntry, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-home',
  templateUrl: './films.component.html',
})

export class FilmsComponent {
  //@Output() saveFilm = new EventEmitter<{ filmTitle: string; releaseDate: string }>();

  public films: Film[] = [];
  public files: NgxFileDropEntry[] = [];
  public modalRef?: BsModalRef;

  filmForm: FormGroup;

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
      };

      var url = window.location.origin + "/film/SaveFilm";
      this.http.post(url, newObject).subscribe(response => {
        //var test = response.status;
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
}
