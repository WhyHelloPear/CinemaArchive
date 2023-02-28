import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sudoku-component',
  templateUrl: './sudoku.component.html'
})
export class SudokuComponent {
  public randomNumbers: RandomNumber[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.http.get<RandomNumber[]>(baseUrl + "sudoku").subscribe(data => {
      this.randomNumbers = data;
    });

    this.http.get<RandomNumber[]>(baseUrl + "sudoku/test").subscribe();

  }
}

interface RandomNumber {
  value: number;
}
