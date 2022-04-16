import { Injectable, isDevMode } from '@angular/core';
import { Coordinates } from '../models/coordinates';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor() { }

  getUserLocation(): Coordinates {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((position) => {
        return new Coordinates(position.coords.latitude, position.coords.longitude);
      });
    }
    // geographic center of the contiguous US
    return new Coordinates(39.5, -98.35);
  }
}
