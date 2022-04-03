import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { ProviderSearchComponent } from './components/provider-search/provider-search.component';
import { ProviderReportComponent } from './components/provider-report/provider-report.component';
import { HealthProviderDetailComponent } from './components/health-provider-detail/health-provider-detail.component';
import { HealthProviderReportComponent } from './components/health-provider-report/health-provider-report.component';



const routes: Routes = [
  { path: '', component: HealthProviderReportComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'search', component: ProviderSearchComponent },
  { path: 'report', component: ProviderReportComponent },
  { path: 'edit/:id', component: HealthProviderDetailComponent },
  { path: 'new', component: HealthProviderDetailComponent },
  { path: 'detail/:id', component: HealthProviderDetailComponent }

];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
