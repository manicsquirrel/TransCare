import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HealthProviderDetailComponent } from './components/health-provider-detail/health-provider-detail.component';
import { HealthProviderEditComponent } from './components/health-provider-edit/health-provider-edit.component';
import { HealthProviderReportComponent } from './components/health-provider-report/health-provider-report.component';
import { HealthProviderSearchResultComponent } from './components/health-provider-search-result/health-provider-search-result.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AuthGuard } from '@auth0/auth0-angular';

const routes: Routes = [
  { path: '', component: HealthProviderSearchResultComponent, pathMatch: 'full' },
  { path: 'search', component: HealthProviderSearchResultComponent },
  { path: 'report', component: HealthProviderReportComponent },
  { path: 'edit/:id', component: HealthProviderEditComponent, canActivate: [AuthGuard] },
  { path: 'new', component: HealthProviderEditComponent, canActivate: [AuthGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'detail/:id', component: HealthProviderDetailComponent }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
