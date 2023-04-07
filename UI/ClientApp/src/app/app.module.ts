import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FilmComponent } from './film/film.component';
import { GenreComponent } from './genre/genre.component';
import { PersonComponent } from './person/person.component';
import { FilmRoleComponent } from './filmRole/filmRole.component';
import { FilmDetailComponent } from './filmDetail/filmDetail.component';

import { NgxFileDropModule } from 'ngx-file-drop';
import { ModalModule, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FilmComponent,
    GenreComponent,
    PersonComponent,
    FilmRoleComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NgxFileDropModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    FormsModule,


    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'film', component: FilmComponent },
      { path: 'film/:id', component: FilmDetailComponent },
      { path: 'genre', component: GenreComponent },
      { path: 'person', component: PersonComponent },
      { path: 'filmRole', component: FilmRoleComponent },
      //{ path: '**', redirectTo: '' },
    ])
  ],
  providers: [
    BsModalService,
    FormBuilder,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
