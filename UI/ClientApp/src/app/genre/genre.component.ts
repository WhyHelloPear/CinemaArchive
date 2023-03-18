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

  onSubmit() {
    if (this.genreForm.valid) {
      var newObject: Genre = {
        genreId: -1,
        genreName: this.genreForm.value.filmTitle,
      };

      //var url = window.location.origin + "/film/SaveFilm";
      //this.http.post(url, newObject).subscribe(response => {
      //  //var test = response.status;
      //  this.getData();
      //  this.closeModal();
      //});

    }
  }
}

interface Genre {
  genreId: number;
  genreName: string;
}
