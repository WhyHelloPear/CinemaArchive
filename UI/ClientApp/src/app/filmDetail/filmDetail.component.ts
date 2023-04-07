import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { CommonModule } from '@angular/common';

import { Film } from '../../models/Film'
import { Genre } from '../../models/Genre'
import { FilmPersonLink } from '../../models/FilmPersonLink'

@Component({
  selector: 'app-home',
  templateUrl: './filmDetail.component.html',
  standalone:true,
  imports: [
    CommonModule // add CommonModule here
  ]
})

export class FilmDetailComponent{ 

  public modalRef?: BsModalRef;

  filmForm: FormGroup;
  public targetFilm!: Film;

  constructor(
    private modalService: BsModalService,
    private fb: FormBuilder,
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.filmForm = this.fb.group({
      filmTitle: ['', Validators.required],
      releaseDate: ['', Validators.required],
    });

    //this.targetFilm = { filmId: 0, filmTitle: "", releaseDate: new Date(), genreList: [] };
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.http.get<Film>(window.location.origin + "/film/GetFilm?id=" + id).subscribe(data => {
      // Set the data to a component property
      this.targetFilm = data;
    });

  }
}
