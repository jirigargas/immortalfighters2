import { Pipe, PipeTransform } from '@angular/core';
import { Rules } from '../../core/models/character-models';

@Pipe({
  name: 'rulesToReadableString'
})
export class RulesToReadableStringPipe implements PipeTransform {

  transform(value: Rules, ...args: unknown[]): string {
    switch (value) {
      case Rules.DraciDoupe:
        return "Dračí doupě";
      case Rules.DraciDoupe2:
        return "Dračí doupě 2";
      default:
        return "RulesToReadableStringPipe neimplementuje case pro " + value;
    }
  }

}
