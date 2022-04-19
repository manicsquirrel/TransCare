import { Injectable, isDevMode } from '@angular/core';
import { Coordinates } from '../models/coordinates';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor() { }

  getUserLocation(): Coordinates {
    // geographic center of the contiguous US as default
    let coordinates = new Coordinates(39.5, -98.35);

    // attempt to get user location
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((position) => {
        coordinates = new Coordinates(position.coords.latitude, position.coords.longitude);
      });
    }
    else {
      console.log("User declined access to location.");
    }
    return coordinates;
  }
}
