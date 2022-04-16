import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phoneLink'
})
export class PhoneLinkPipePipe implements PipeTransform {

  transform(phone: string): string {
    var cleaned = ('' + phone).replace(/\D/g, '');
    var match = cleaned.match(/^(\d{3})(\d{3})(\d{4})$/);
    return match ? `tel:+1-${match[1]}-${match[2]}-${match[3]}` : '';
  }

}
