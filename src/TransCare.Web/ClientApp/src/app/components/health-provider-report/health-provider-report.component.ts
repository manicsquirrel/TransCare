import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { HealthProvider } from 'src/app/models/health-provider';
import { HealthProviderService } from 'src/app/services/provider.service';
import jspdf from 'jspdf';
import 'jspdf-autotable';
import autoTable from 'jspdf-autotable';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-health-provider-report',
  templateUrl: './health-provider-report.component.html',
  styleUrls: ['./health-provider-report.component.scss']
})
export class HealthProviderReportComponent implements OnInit {

  public providers: any[] = [];
  currentDateTime: any;

  constructor(private healthProviderService: HealthProviderService, private datePipe: DatePipe) {
    this.currentDateTime = this.datePipe.transform((new Date), 'MM/dd/yyyy h:mm:ss');
  }

  async ngOnInit(): Promise<void> {
    this.providers = await this.healthProviderService.getAll();
    console.log(this.providers);
  }

  calculateStateTotal(stateName: string) {
    if (!this.providers || !stateName) return 0;
    return this.providers.filter(p => p.stateName === stateName).length;
  }

  exportPdf(): void {

    const doc = new jspdf();
    autoTable(doc, {
      columns: [
        { header: 'Name', dataKey: 'providerName' },
        { header: 'Street', dataKey: 'street' },
        { header: 'City', dataKey: 'city' },
        { header: 'State', dataKey: 'state' },
        { header: 'Zip', dataKey: 'zipCode' }
      ],
      body: this.providers,
      showHead: 'firstPage'
    });
    doc.save("healthcare-providers.pdf");
  }
}
