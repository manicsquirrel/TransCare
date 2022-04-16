import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { HealthProvider } from 'src/app/models/health-provider';
import { HealthProviderService } from 'src/app/services/provider.service';

@Component({
  selector: 'app-health-provider-near-me',
  templateUrl: './health-provider-near-me.component.html',
  styleUrls: ['./health-provider-near-me.component.scss']
})
export class HealthProviderNearMeComponent implements OnInit {

  healthProviders: HealthProvider[] = [];

  constructor(
    public auth: AuthService,
    private healthProviderService: HealthProviderService) { }

  async ngOnInit(): Promise<void> {
    this.healthProviders = await this.healthProviderService.nearMe(5);
  }
}
