import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { HealthProvider } from '../models/health-provider';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HealthProviderService {
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  findHealthProviders(query: string): Observable<HealthProvider[]> {
    var x = this.httpClient.get<HealthProvider[]>(`${this.baseUrl}healthProvider/search?query=${query}`);
    return x;
  }

  search(query: string): Promise<HealthProvider[]> {
    return this.httpClient.get<HealthProvider[]>(`${this.baseUrl}healthProvider/search?query=${query}`)
      .toPromise()
      .then(res => res as HealthProvider[])
      .then(data => data);
  }

  get(id: number) {
    return this.httpClient.get<HealthProvider>(`${this.baseUrl}healthProvider?id=${id}`)
      .toPromise()
      .then(res => res as HealthProvider)
      .then(data => data);
  }

  getAll(): Promise<HealthProvider[]> {
    return this.httpClient.get<HealthProvider[]>(`${this.baseUrl}healthProvider/list`)
      .toPromise()
      .then(res => res as HealthProvider[])
      .then(data => data);
  }

  save(healthProvider: HealthProvider): Promise<HealthProvider> {
    if (healthProvider.id == null || healthProvider.id == 0) {
      healthProvider.id = 0;
    }

    return this.httpClient.post(`${this.baseUrl}healthProvider/save`, healthProvider)
      .toPromise()
      .then(res => res as HealthProvider)
      .then(data => data);
  }
}
