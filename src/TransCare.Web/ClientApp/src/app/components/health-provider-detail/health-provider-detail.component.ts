import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HealthProvider } from 'src/app/models/health-provider';
import { HealthProviderService } from 'src/app/services/provider.service';

@Component({
  selector: 'app-health-provider-detail',
  templateUrl: './health-provider-detail.component.html',
  styleUrls: ['./health-provider-detail.component.scss']
})
export class HealthProviderDetailComponent implements OnInit {

  healthProvider: HealthProvider = new HealthProvider;

  constructor(private route: ActivatedRoute,
    private fb: FormBuilder,
    private providerService: HealthProviderService) {
  }

  ngOnInit(): void {
    this.setHealthProvider();
  }

  async setHealthProvider(): Promise<void> {
    let healthProvider = new HealthProvider;
    healthProvider.providerName="Dr. Bob Bivens";
    healthProvider.street='123 Street Rd';
    healthProvider.city='Citytown';
    healthProvider.stateCode='TN';
    healthProvider.stateName='Tennessee';
    healthProvider.zipCode='77777';
    healthProvider.phone='8885551212';
    healthProvider.email='user@domain.com';
    healthProvider.url='https://google.com'
    healthProvider.notes='sdfhkshfkshfkd';
    // const id = Number(this.route.snapshot.paramMap.get('id'));
    // if (id) {
    //   healthProvider = await this.providerService.get(id);
    // }
     await this.loadProvider(healthProvider);
  }

  async loadProvider(healthProvider: HealthProvider) {
    this.healthProvider = healthProvider;
    console.log(this.healthProvider);
  }
}
