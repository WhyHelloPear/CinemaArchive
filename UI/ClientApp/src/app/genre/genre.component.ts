import { Component, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-home',
  templateUrl: './genre.component.html',
})

export class GenreComponent {
  genreForm: FormGroup;
  private selectedGenre?: Genre;
  public genres: Genre[] = [];
  public modalRef?: BsModalRef;

  constructor(private modalService: BsModalService, private fb: FormBuilder, private http: HttpClient) {
    this.genreForm = this.fb.group({
      genreName: ['', Validators.required],
    });

    this.getData();
  }

  ngOnInit(): void {
    this.getData();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  closeModal() {
    this.genreForm.reset();
    this.modalService.hide();
  }

  getData() {
    var url = window.location.origin + "/film/GetGenres";
    this.http.get<Genre[]>(url).subscribe(data => {
      this.genres = data;
    });
  }

  onCreateGenre() {
    if (this.genreForm.valid) {
      var newObject: Genre = {
        genreId: -1,
        genreName: this.genreForm.value.genreName,
      };
      debugger
      var url = window.location.origin + "/film/CreateGenre";
      this.http.post(url, newObject).subscribe(response => {
        //var test = response.status;
        this.getData();
        this.closeModal();
      });

    }
  }

  onUpdateGenre() {
    if (this.genreForm.valid) {

      const updatedGenre = {
        ...this.selectedGenre, // copy the selected row data
        ...this.genreForm.value // overwrite the values with the new form data
      };

      var url = window.location.origin + "/film/UpdateGenre";
      this.http.post(url, updatedGenre).subscribe(response => {
        //var test = response.status;
        this.getData();
        this.closeModal();
      });

    }
  }

  onDeleteGenre(genreId : number) {
    const confirmDelete = window.confirm('Are you sure you want to delete this genre?');
    if (confirmDelete) {
      var url = window.location.origin + "/film/DeleteGenre";
      this.http.post(url, genreId).subscribe(response => {
        //var test = response.status;
        this.getData();
        this.closeModal();
      });
    }
  }

  openEditModal(template: TemplateRef<any>,genre: Genre) {
    this.selectedGenre = genre; // save the selected row data to a variable
    this.genreForm.setValue({
      genreName: genre.genreName,
    });
    this.modalRef = this.modalService.show(template);
  }
}

interface Genre {
  genreId: number;
  genreName: string;
}
