import { Component, TemplateRef } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-home',
  templateUrl: './person.component.html',
})

export class PersonComponent {
  public people: Person[] = [];
  personForm: FormGroup;
  public modalRef?: BsModalRef;

  constructor(private http: HttpClient, private fb: FormBuilder, private modalService: BsModalService) {
    this.personForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.getPeopleData();
  }

  getPeopleData() {
    this.http.get<Person[]>(window.location.origin + "/person/GetPeople").subscribe(data => {
      // Set the data to a component property
      this.people = data;
    });
  }

  onSubmit() {
    if (this.personForm.valid) {
        this.createPerson();
    }
  }

  createPerson() {
    var newPerson: Person = {
      personId: -1,
      firstName: this.personForm.value.firstName,
      lastName: this.personForm.value.lastName,
      dateOfBirth: this.personForm.value.dateOfBirth as Date,
    };

    this.http.post(window.location.origin + "/person/CreatePerson", newPerson).subscribe(response => {
      //var test = response.status;
      this.getPeopleData();
      this.closeModal();
    });
  }

  openCreatePersonForm(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template);
  }

  closeModal() {
    this.personForm.reset();
    this.modalService.hide();
  }
}

interface Person {
  personId: number;
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
}
