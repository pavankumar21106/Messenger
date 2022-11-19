import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'textHide'
})
export class TextHidePipe implements PipeTransform {

  transform(value: any, ...args: unknown[]): any | string | null {
    if (!value)
      return null;

    if (value.length > 20) {
      return value.substring(0, 15) + "...";
    }
    return value;
  }

}
