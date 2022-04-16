import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatUrl'
})
export class FormatUrlPipePipe implements PipeTransform {

  transform(url: string): string {
    return url.startsWith("http") ? url : `\/\/${url}`;
  }

}
