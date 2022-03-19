import { Component } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  ngOnInit() {
    this.primengConfig.ripple = true;
  }

  constructor(private primengConfig: PrimeNGConfig) { }
}

