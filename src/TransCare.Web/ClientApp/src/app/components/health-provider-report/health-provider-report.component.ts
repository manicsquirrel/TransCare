import { Component, OnInit } from '@angular/core';
import { HealthProvider } from 'src/app/models/health-provider';
import { HealthProviderService } from 'src/app/services/provider.service';

@Component({
  selector: 'app-health-provider-report',
  templateUrl: './health-provider-report.component.html',
  styleUrls: ['./health-provider-report.component.css']
})
export class HealthProviderReportComponent implements OnInit {

  public providers: HealthProvider[] = [];

  constructor(private healthProviderService: HealthProviderService) { }

  async ngOnInit(): Promise<void> {
    this.providers = await this.healthProviderService.getAll();
    console.log(this.providers);
  }

  calculateStateTotal(stateCode: string) {
    if (!this.providers || !stateCode) return 0;
    return this.providers.filter(p => p.state === stateCode).length;
  }
}
