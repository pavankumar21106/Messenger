import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'textHide'
})
export class TextHidePipe implements PipeTransform {

  transform(value: any, length: number=20): any | string | null {
    if (!value)
      return null;

    if (value.length > length) {
      return value.substring(0, 15) + "...";
    }
    return value;
  }

}
