import { State } from "./state";

export class HealthProvider {
  id: number = 0;
  email: string = '';
  latitude: number = 0;
  longitude: number = 0;
  providerName: string = '';
  notes: string = '';
  phone: string = '';
  url: string = '';
  city: string = '';
  stateCode?: string;
  stateName?: string;
  street: string = '';
  zipCode: string = '';
}

