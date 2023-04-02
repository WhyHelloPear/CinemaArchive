import { Component, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-home',
  templateUrl: './filmRole.component.html',
})

export class FilmRoleComponent {
  public filmRoles: FilmRole[] = [];
  public filmRoleForm: FormGroup;
  public modalRef?: BsModalRef;
  public isNewFilmRole: boolean = false;

  constructor(private http: HttpClient, private fb: FormBuilder, private modalService: BsModalService) {
    this.filmRoleForm = this.fb.group({
      filmRoleName: ['', Validators.required],
      filmRoleDescription: [''],
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
}

interface FilmRole {
  filmRoleId: number;
  filmRoleName: string;
  description: string;
}
