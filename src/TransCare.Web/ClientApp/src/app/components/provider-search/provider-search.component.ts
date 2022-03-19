import { Component, OnInit } from "@angular/core";
import { Observable, of, Subject, Subscription } from "rxjs";
import { catchError, switchMap } from "rxjs/operators";
import { HealthProvider } from "src/app/models/health-provider";
import { HealthProviderService } from "src/app/services/provider.service";
import { DataViewModule } from 'primeng/dataview';

@Component({
  selector: 'app-provider-search',
  templateUrl: './provider-search.component.html',
  styleUrls: ['./provider-search.component.css']
})
export class ProviderSearchComponent {

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

}
