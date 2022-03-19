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
    return this.httpClient.get<HealthProvider[]>(`${this.baseUrl}provider/search?query=${query}`);
  }


}
