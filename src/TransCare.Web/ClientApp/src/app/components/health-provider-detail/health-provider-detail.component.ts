import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService, User } from '@auth0/auth0-angular';
import { HealthProvider } from 'src/app/models/health-provider';
import { HealthProviderService } from 'src/app/services/provider.service';

@Component({
  selector: 'app-health-provider-detail',
  templateUrl: './health-provider-detail.component.html',
  styleUrls: ['./health-provider-detail.component.scss']
})
export class HealthProviderDetailComponent implements OnInit {

  healthProvider: HealthProvider = new HealthProvider;
  id: number = 0;

  constructor(
    private router: Router,
    public auth: AuthService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private providerService: HealthProviderService) {
  }

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.setHealthProvider();
  }

  async setHealthProvider(): Promise<void> {
    let healthProvider = new HealthProvider;
    if (this.id > 0) {
      healthProvider = await this.providerService.get(this.id);
    }
    await this.loadProvider(healthProvider);
  }

  async loadProvider(healthProvider: HealthProvider) {
    this.healthProvider = healthProvider;
  }

  async onDelete() {
    await this.providerService.delete(this.id);
    this.router.navigate(['/search']);
  }
}
