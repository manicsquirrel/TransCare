import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { ProviderListComponent } from './components/provider-list/provider-list.component';
import { ProviderFilterComponent } from './components/provider-filter/provider-filter.component';
import { ProviderSearchComponent } from './components/provider-search/provider-search.component';
import { ProviderDetailsComponent } from './components/provider-details/provider-details.component';
import { ProviderReportComponent } from './components/provider-report/provider-report.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {DataViewModule} from 'primeng/dataview'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProviderListComponent,
    ProviderFilterComponent,
    ProviderSearchComponent,
    ProviderDetailsComponent,
    ProviderReportComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    DataViewModule,
    BrowserAnimationsModule,
    Ng2SearchPipeModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'provider-search', component: ProviderSearchComponent },
      { path: 'provider-report', component: ProviderReportComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
