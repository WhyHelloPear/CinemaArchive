import { Component, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { Person } from '../../models/Person'

@Component({
  selector: 'app-home',
  templateUrl: './person.component.html',
})

export class PersonComponent {
  public selectedPerson?: Person;
  public people: Person[] = [];
  public isNewPerson: boolean = false;
  public personForm: FormGroup;
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
      if (this.isNewPerson) {
        this.createPerson();
      }
      else {
        this.updatePerson();
      }
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

  updatePerson() {
    debugger
    const updatedPerson = {
      ...this.selectedPerson, // copy the selected row data
      ...this.personForm.value // overwrite the values with the new form data
    };

    this.http.post(window.location.origin + "/person/UpdatePerson", updatedPerson).subscribe(response => {
      this.getPeopleData();
      this.closeModal();
    });
  }

  openCreatePersonForm(template: TemplateRef<any>): void {
    this.isNewPerson = true;
    this.modalRef = this.modalService.show(template);
  }

  openEditForm(template: TemplateRef<any>, person: Person) {
    this.isNewPerson = false;

    this.selectedPerson = person;

    this.personForm.setValue({
      firstName: person.firstName,
      lastName: person.lastName,
      dateOfBirth: person.dateOfBirth
    });

    //update release date form entry
    this.personForm.controls.dateOfBirth.patchValue(
      new Date(person.dateOfBirth).toISOString().substring(0, 10) //strip the timestamp off the date
    );

    this.modalRef = this.modalService.show(template);
  }

  closeModal() {
    this.personForm.reset();
    this.modalService.hide();
  }

  onDelete(personId:number) {
    if (!confirm("You sure? Mighty fine thing you're doin")) {
      return;
    }

    this.http.post(window.location.origin + "/person/DeletePerson", personId).subscribe(response => {
      this.getPeopleData();
    });
  }
}
