import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { State } from '../models/state';

@Injectable({
  providedIn: 'root'
})
export class StateService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll(): Promise<State[]> {
    return this.httpClient.get<State[]>(`${this.baseUrl}state/list`)
      .toPromise()
      .then(res => res as State[])
      .then(data => data);
  }
}
