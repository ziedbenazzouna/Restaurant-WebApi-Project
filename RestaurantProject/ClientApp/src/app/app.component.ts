import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http"

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  values:any;
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getValues();
  }

  getValues() {
    this.http.get('/WeatherForecast').subscribe(
    (response) => {
      this.values = response;
    },
    (error) => {
      console.log(error);
    }
    );
    
    
  }
}
