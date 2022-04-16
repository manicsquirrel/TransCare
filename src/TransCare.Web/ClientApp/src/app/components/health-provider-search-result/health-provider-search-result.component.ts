import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Observable, of, Subject } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { HealthProvider } from 'src/app/models/health-provider';
import { HealthProviderService } from 'src/app/services/provider.service';

@Component({
  selector: 'app-health-provider-search-result',
  templateUrl: './health-provider-search-result.component.html',
  styleUrls: ['./health-provider-search-result.component.scss']
})
export class HealthProviderSearchResultComponent {

  searchTerm = new Subject<string>();
  providers$: Observable<HealthProvider[] | null> = this.searchTerm.pipe(
    switchMap(searchTerm => this.healthProviderService.findHealthProviders(searchTerm)),
    catchError(errorResponse => {
      console.error(errorResponse);
      return of(null);
    })
  );

  constructor(public auth: AuthService, private healthProviderService: HealthProviderService) { }

  onTextChange(changedText: string) {
    if (changedText.length > 1) this.searchTerm.next(changedText);
  }

}
