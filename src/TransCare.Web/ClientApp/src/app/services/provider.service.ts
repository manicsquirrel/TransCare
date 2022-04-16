import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, OnInit } from '@angular/core';
import { HealthProvider } from '../models/health-provider';
import { Observable } from 'rxjs';
import { HealthProviderNearMeRequest } from '../models/requests/health-provider-near-me-request';
import * as queryString from 'query-string';
import { HealthProviderFilterRequest } from '../models/requests/health-provider-filter-request';
import { LocationService } from './location.service';
import { Coordinates } from '../models/coordinates';

@Injectable({
  providedIn: 'root'
})
export class HealthProviderService {

  constructor(
    private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private locationService: LocationService) { }

  filter(query: string): Observable<HealthProvider[]> {
    const coordinates = this.locationService.getUserLocation();
    const healthProviderFilterRequest = new HealthProviderFilterRequest(query, coordinates.latitude, coordinates.longitude);
    return this.httpClient.get<HealthProvider[]>(`${this.baseUrl}healthProvider/search?${queryString.stringify(healthProviderFilterRequest)}`);
  }

  nearMe(take: number): Promise<HealthProvider[]> {
    const coordinates = this.locationService.getUserLocation();
    const healthProviderNearMeRequest = new HealthProviderNearMeRequest(take, coordinates.latitude, coordinates.longitude);
    return this.httpClient.get<HealthProvider[]>(`${this.baseUrl}healthProvider/nearme?${queryString.stringify(healthProviderNearMeRequest)}`)
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
