import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  title = 'apiary-diary';
  private baseUrl = "http://localhost:5000/";
  message : string = "";
  private headers = new HttpHeaders().set('Content-Type', 'text/plain; charset=utf-8');
  private params = new HttpParams({fromString: 'name=term'});
  constructor(http: HttpClient) {
    http.get(this.baseUrl + 'test', {responseType: 'text'}).subscribe(result =>
      {
        this.message = result
      }, error =>console.log(error));
  }
}
