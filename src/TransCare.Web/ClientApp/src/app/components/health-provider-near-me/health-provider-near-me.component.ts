import { Component, isDevMode, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { HealthProvider } from 'src/app/models/health-provider';
import { HealthProviderNearMeRequest } from 'src/app/models/requests/health-provider-near-me-request';
import { HealthProviderService } from 'src/app/services/provider.service';

@Component({
  selector: 'app-health-provider-near-me',
  templateUrl: './health-provider-near-me.component.html',
  styleUrls: ['./health-provider-near-me.component.scss']
})
export class HealthProviderNearMeComponent implements OnInit {

  healthProviders: HealthProvider[] = [];
  healthProviderNearMeRequest!: HealthProviderNearMeRequest;

  constructor(public auth: AuthService, private healthProviderService: HealthProviderService) { }

  async ngOnInit(): Promise<void> {
    this.setUserLocation();
    await this.setHealthProvider();
  }

  async setHealthProvider(): Promise<void> {
    this.healthProviders = await this.healthProviderService.nearMe(this.healthProviderNearMeRequest);
  }

  setUserLocation() {
    if (navigator.geolocation) {
      if (isDevMode()) {
        this.healthProviderNearMeRequest = new HealthProviderNearMeRequest(5, 35.6376233, -83.9296153);
      }
      else {
        navigator.geolocation.getCurrentPosition((position) => {
          this.healthProviderNearMeRequest = new HealthProviderNearMeRequest(5, position.coords.latitude, position.coords.longitude);
        });
      }
    } else { console.log("User denied location.") }
  }

}
