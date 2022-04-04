import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HealthProviderDetailComponent } from './components/health-provider-detail/health-provider-detail.component';
import { HealthProviderReportComponent } from './components/health-provider-report/health-provider-report.component';
import { HealthProviderSearchResultComponent } from './components/health-provider-search-result/health-provider-search-result.component';

const routes: Routes = [
  { path: '', component: HealthProviderReportComponent, pathMatch: 'full' },
  { path: 'search', component: HealthProviderSearchResultComponent },
  { path: 'report', component: HealthProviderReportComponent },
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
