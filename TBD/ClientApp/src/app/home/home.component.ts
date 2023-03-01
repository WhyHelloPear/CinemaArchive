import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public userData: UserData[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    let lat: number;
    let lng: number;

    navigator.geolocation.getCurrentPosition((position) => {
      lat = position.coords.latitude;
      lng = position.coords.longitude;

      let params = new HttpParams()
        .set('lat', lat)
        .set('longitude', lng);

      http.get<UserData[]>(baseUrl + 'home/DoThis', { params: params }).subscribe(result => {
        this.userData = result;
      }, error => console.error(error));

    });

  }
}

interface UserData {
  address: string;
}
