import { Component, isDevMode, OnInit } from "@angular/core";
import { Observable, of, Subject, Subscription } from "rxjs";
import { catchError, switchMap } from "rxjs/operators";
import { HealthProvider } from "src/app/models/health-provider";
import { HealthProviderService } from "src/app/services/provider.service";

@Component({
  selector: 'app-provider-search',
  templateUrl: './provider-search.component.html',
  styleUrls: ['./provider-search.component.css']
})
export class ProviderSearchComponent implements OnInit {

  zoom = 12
  center!: google.maps.LatLngLiteral;
  options: google.maps.MapOptions = {
    mapTypeId: 'roadmap',
    zoomControl: false,
    scrollwheel: false,
    disableDoubleClickZoom: true,
    maxZoom: 15,
    minZoom: 8,
  }

  searchTerm = new Subject<string>();
  providers$: Observable<HealthProvider[] | null> = this.searchTerm.pipe(
    switchMap(searchTerm => this.healthProviderService.findHealthProviders(searchTerm)),
    catchError(errorResponse => {
      console.error(errorResponse);
      return of(null);
    })
  );

  constructor(private healthProviderService: HealthProviderService) { }

  onTextChange(changedText: string) {
    if (changedText.length > 1) this.searchTerm.next(changedText);
  }

  ngOnInit() {
    this.getUserLocation();
  }

  getUserLocation() {
    if (isDevMode()) {
      this.center = { lat: 35.6376233, lng: -83.9296153 };
    }
    else {
      navigator.geolocation.getCurrentPosition((position) => {
        this.center = {
          lat: position.coords.latitude,
          lng: position.coords.longitude
        }
      });
    }
    // if (navigator.geolocation) {
    //   navigator.geolocation.getCurrentPosition(position => {
    //     this.latitude = position.coords.latitude;
    //     this.longitude = position.coords.longitude;
    //   });
    // } else { console.log("User not allow") }
  }

  zoomIn() {
    if (!this.options.maxZoom) return;
    if (this.zoom < this.options.maxZoom) this.zoom++
  }

  zoomOut() {
    if (!this.options.minZoom) return;
    if (this.zoom > this.options.minZoom) this.zoom--
  }
}
