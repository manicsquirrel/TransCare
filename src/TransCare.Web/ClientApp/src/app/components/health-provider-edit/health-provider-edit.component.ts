import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HealthProvider } from 'src/app/models/health-provider';
import { HealthProviderService } from 'src/app/services/provider.service';

@Component({
  selector: 'app-health-provider-edit',
  templateUrl: './health-provider-edit.component.html',
  styleUrls: ['./health-provider-edit.component.scss']
})
export class HealthProviderEditComponent implements OnInit {

  healthProvider: HealthProvider = new HealthProvider;
  form = this.fb.group({
    "id": [0, Validators.required],
    "providerName": ["", Validators.required],
    "street": ["", Validators.required],
    "city": ["", Validators.required],
    "state": ["", Validators.required],
    "zipCode": ["", Validators.required],
    "phone": ["", Validators.required],
    "email": [""],
    "url": [""],
    "notes": [""],
    "latitude": [0],
    "longitude": [0]
  });

  constructor(private route: ActivatedRoute,
    private fb: FormBuilder,
    private providerService: HealthProviderService) {
  }

  ngOnInit(): void {
    this.setHealthProvider();
  }

  async setHealthProvider(): Promise<void> {
    let healthProvider = new HealthProvider;
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      healthProvider = await this.providerService.get(id);
    }
    await this.loadProvider(healthProvider);
  }

  async loadProvider(healthProvider: HealthProvider) {
    this.healthProvider = healthProvider;
    console.log(this.healthProvider);
    this.form.patchValue({
      id: this.healthProvider.id,
      providerName: this.healthProvider.providerName,
      street: this.healthProvider.street,
      city: this.healthProvider.city,
      state: this.healthProvider.stateCode,
      zipCode: this.healthProvider.zipCode,
      phone: this.healthProvider.phone,
      email: this.healthProvider.email,
      url: this.healthProvider.url,
      notes: this.healthProvider.notes,
      latitude: this.healthProvider.latitude,
      longitude: this.healthProvider.longitude
    });
  }

  async onSubmit() {
    await this.providerService.save(this.form.value);
  }
}
