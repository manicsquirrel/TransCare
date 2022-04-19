import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Observable, of, Subject } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { Coordinates } from 'src/app/models/coordinates';
import { HealthProvider } from 'src/app/models/health-provider';
import { LocationService } from 'src/app/services/location.service';
import { HealthProviderService } from 'src/app/services/provider.service';

@Component({
  selector: 'app-health-provider-search-result',
  templateUrl: './health-provider-search-result.component.html',
  styleUrls: ['./health-provider-search-result.component.scss']
})
export class HealthProviderSearchResultComponent implements OnInit {

  coordinates: Coordinates = new Coordinates(0, 0);
  isLocationAllowed: boolean = false;
  searchTerm = new Subject<string>();
  providers$: Observable<HealthProvider[] | null> = this.searchTerm.pipe(
    switchMap(searchTerm => this.healthProviderService.filter(searchTerm, this.coordinates)),
    catchError(errorResponse => {
      console.error(errorResponse);
      return of(null);
    })
  );

  constructor(
    public auth: AuthService,
    private healthProviderService: HealthProviderService,
    private locationService: LocationService) { }

  ngOnInit(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((position) => {
        this.coordinates = new Coordinates(position.coords.latitude, position.coords.longitude);
        console.log(`User's location: ${this.coordinates.latitude}, ${this.coordinates.longitude}`);
        this.isLocationAllowed = true;
      });
    }
    else {
      this.isLocationAllowed = false;
    }
  }

  onTextChange(changedText: string) {
    if (changedText.length > 1) this.searchTerm.next(changedText);
  }

}
