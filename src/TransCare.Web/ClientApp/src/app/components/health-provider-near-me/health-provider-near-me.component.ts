import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Coordinates } from 'src/app/models/coordinates';
import { HealthProvider } from 'src/app/models/health-provider';
import { HealthProviderService } from 'src/app/services/provider.service';

@Component({
  selector: 'app-health-provider-near-me',
  templateUrl: './health-provider-near-me.component.html',
  styleUrls: ['./health-provider-near-me.component.scss']
})
export class HealthProviderNearMeComponent implements OnInit {

  coordinates: Coordinates = new Coordinates(0, 0);
  healthProviders: HealthProvider[] = [];

  constructor(
    public auth: AuthService,
    private healthProviderService: HealthProviderService) { }

  ngOnInit(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((position) => {
        this.coordinates = new Coordinates(position.coords.latitude, position.coords.longitude);
        this.getTopFive(position.coords.latitude, position.coords.longitude);
        console.log(`User's location: ${this.coordinates.latitude}, ${this.coordinates.longitude}`);
      });
    }
  }

  private async getTopFive(latitude: number, longitude: number) {
    console.log(`User's location: ${latitude}, ${longitude}`);
    this.healthProviders = await this.healthProviderService.nearMe(5, new Coordinates(latitude, longitude));
  }
}
