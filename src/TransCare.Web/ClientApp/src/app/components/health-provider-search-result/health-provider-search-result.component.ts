import { Component, isDevMode, OnInit } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { HealthProvider } from 'src/app/models/health-provider';
import { HealthProviderService } from 'src/app/services/provider.service';

@Component({
  selector: 'app-health-provider-search-result',
  templateUrl: './health-provider-search-result.component.html',
  styleUrls: ['./health-provider-search-result.component.scss']
})
export class HealthProviderSearchResultComponent implements OnInit {

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
    // this.getUserLocation();
  }

  getFormattedUrl(url: string) {
    return url.startsWith("http") ? url : `\/\/${url}`;
  }

  getPhoneLink(phone: string) {
    var cleaned = ('' + phone).replace(/\D/g, '');
    var match = cleaned.match(/^(\d{3})(\d{3})(\d{4})$/);
    return match ?  `tel:+1-${match[1]}-${match[2]}-${match[3]}`: null;
  }

  getPhoneDisplay(phone: string) {
    var cleaned = ('' + phone).replace(/\D/g, '');
    var match = cleaned.match(/^(\d{3})(\d{3})(\d{4})$/);
    return match ?  `(${match[1]}) ${match[2]}-${match[3]}`: null;
  }

  // getUserLocation() {
  //   if (isDevMode()) {
  //     this.center = { lat: 35.6376233, lng: -83.9296153 };
  //   }
  //   else {
  //     navigator.geolocation.getCurrentPosition((position) => {
  //       this.center = {
  //         lat: position.coords.latitude,
  //         lng: position.coords.longitude
  //       }
  //     });
  //   }
  //   // if (navigator.geolocation) {
  //   //   navigator.geolocation.getCurrentPosition(position => {
  //   //     this.latitude = position.coords.latitude;
  //   //     this.longitude = position.coords.longitude;
  //   //   });
  //   // } else { console.log("User not allow") }
  // }


}
