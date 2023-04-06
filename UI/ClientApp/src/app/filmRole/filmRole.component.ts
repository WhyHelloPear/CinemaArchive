import { Component, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { FilmRole } from '../../models/FilmRole'

@Component({
  selector: 'app-home',
  templateUrl: './filmRole.component.html',
})

export class FilmRoleComponent {
  public filmRoles: FilmRole[] = [];
  public filmRoleForm: FormGroup;
  public modalRef?: BsModalRef;
  public isNewFilmRole: boolean = false;
  public selectedFilmRole?: FilmRole;

  constructor(private http: HttpClient, private fb: FormBuilder, private modalService: BsModalService) {
    this.filmRoleForm = this.fb.group({
      filmRoleName: ['', Validators.required],
      description: [''],
    });
  }

  ngOnInit(): void {
    this.getFilmRoleData();
  }

  hideFilmRoleForm() {
    this.filmRoleForm.reset();
    this.modalService.hide();
  }

  getFilmRoleData() {
    this.http.get<FilmRole[]>(window.location.origin + "/filmRole/GetFilmRoles").subscribe(data => {
      this.filmRoles = data
    });
  }

  openCreateFilmRoleForm(template: TemplateRef<any>): void {
    this.isNewFilmRole = true;
    this.modalRef = this.modalService.show(template);
  }

  onFilmRoleSubmit() {
    if (this.filmRoleForm.valid) {
      if (this.isNewFilmRole) {
        this.createFilmRole();
      }
      else {
        this.updateFilmRole();
      }
    }
  }

  createFilmRole() {
    var newRole: FilmRole = {
      filmRoleId: -1,
      filmRoleName: this.filmRoleForm.value.filmRoleName,
      description: this.filmRoleForm.value.description,
    };

    this.http.post(window.location.origin + "/filmRole/CreateFilmRole", newRole).subscribe(response => {
      this.getFilmRoleData();
      this.hideFilmRoleForm();
    });
  }

  updateFilmRole() {
    const updatedFilm = {
      ...this.selectedFilmRole, // copy the selected row data
      ...this.filmRoleForm.value // overwrite the values with the new form data
    };

    var url = window.location.origin + "/filmRole/UpdateFilmRole";
    this.http.post(url, updatedFilm).subscribe(response => {
      this.getFilmRoleData();
      this.hideFilmRoleForm();
    });
  }

  openUpdateFilmRoleForm(updateTemplate: TemplateRef<any>, filmRole: FilmRole) {
    this.isNewFilmRole = false;
    this.selectedFilmRole = filmRole;

    this.filmRoleForm.setValue({
      filmRoleName: filmRole.filmRoleName,
      description: filmRole.description,
    });

    this.modalRef = this.modalService.show(updateTemplate);
  }

  onDeleteFilmRole(filmRoleId: number) {
    const confirm = window.confirm("Are you sure you would like to delete this film?");

    if (confirm) {
      var url = window.location.origin + "/filmRole/DeleteFilmRole";
      this.http.post(url, filmRoleId).subscribe(response => {
        this.getFilmRoleData();
      });

    }
  }
}
