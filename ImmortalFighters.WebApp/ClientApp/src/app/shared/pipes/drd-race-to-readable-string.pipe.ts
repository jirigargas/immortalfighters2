import { Pipe, PipeTransform } from '@angular/core';
import { DrdRasa } from '../../core/models/character-models';

@Pipe({
  name: 'drdRaceToReadableString'
})
export class DrdRaceToReadableStringPipe implements PipeTransform {

  transform(value: DrdRasa, ...args: unknown[]): string {
    switch (value) {
      case DrdRasa.Barbar:
        return "Barbar";
      case DrdRasa.Clovek:
        return "Člověk";
      case DrdRasa.Elf:
        return "Elf";
      case DrdRasa.Hobit:
        return "Hobit";
      case DrdRasa.Kroll:
        return "Kroll";
      case DrdRasa.Kuduk:
        return "Kudůk";
      case DrdRasa.Trpaslik:
        return "Trpaslík";
      default:
        return "DrdRaceToReadableStringPipe neimplementuje case pro " + value;
    }
  }

}
