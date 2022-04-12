import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DataViewModule } from 'primeng/dataview';
import { AppRoutingModule } from './app-routing.module'
import { ReactiveFormsModule } from "@angular/forms";
import { GoogleMapsModule } from '@angular/google-maps'
import { TableModule } from 'primeng/table';
import { ProgressBarModule } from 'primeng/progressbar';
import { ButtonModule } from 'primeng/button';
import { HealthProviderEditComponent } from './components/health-provider-edit/health-provider-edit.component';
import { HealthProviderDetailComponent } from './components/health-provider-detail/health-provider-detail.component';
import { HealthProviderSearchBoxComponent } from './components/health-provider-search-box/health-provider-search-box.component';
import { HealthProviderSearchResultComponent } from './components/health-provider-search-result/health-provider-search-result.component';
import { HealthProviderNearMeComponent } from './components/health-provider-near-me/health-provider-near-me.component';
import { HealthProviderReportComponent } from './components/health-provider-report/health-provider-report.component';
import { CommonModule, DatePipe } from '@angular/common';
import { CardModule } from 'primeng/card';
import { DropdownModule } from 'primeng/dropdown';
import { InputSwitchModule } from 'primeng/inputswitch';
import { MessageModule } from 'primeng/message';
import { InputMaskModule } from 'primeng/inputmask';
import { RippleModule } from 'primeng/ripple';
import { MenuModule } from 'primeng/menu';
import { AuthModule } from '@auth0/auth0-angular';
import { environment as env } from 'src/environments/environment';
import { LoginButtonComponent } from './components/login-button/login-button.component';
import { LogoutButtonComponent } from './components/logout-button/logout-button.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    HealthProviderEditComponent,
    HealthProviderDetailComponent,
    HealthProviderSearchBoxComponent,
    HealthProviderSearchResultComponent,
    HealthProviderNearMeComponent,
    HealthProviderReportComponent,
    LoginButtonComponent,
    LogoutButtonComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    CommonModule,
    DataViewModule,
    BrowserAnimationsModule,
    Ng2SearchPipeModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    GoogleMapsModule,
    TableModule,
    ProgressBarModule,
    ButtonModule,
    CardModule,
    DropdownModule,
    InputSwitchModule,
    MessageModule,
    InputMaskModule,
    RippleModule,
    MenuModule,
    AuthModule.forRoot({
      ...env.auth
    })
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
