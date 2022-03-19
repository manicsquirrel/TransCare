import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HealthProvider } from 'src/app/models/health-provider';

@Component({
  selector: 'app-provider-list',
  templateUrl: './provider-list.component.html',
  styleUrls: ['./provider-list.component.css']
})
export class ProviderListComponent {

  public providers: HealthProvider[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    var url = `${baseUrl}provider/search?query=pl`;
    http.get<HealthProvider[]>(url).subscribe(result => {
      this.providers = result;
    }, error => console.error(error));
  }
}


