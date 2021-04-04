import { Pipe, PipeTransform } from '@angular/core';
import { DrdPovolani } from '../../core/models/character-models';

@Pipe({
  name: 'drdClassToReadableString'
})
export class DrdClassToReadableStringPipe implements PipeTransform {

  transform(value: DrdPovolani, ...args: unknown[]): string {
    switch (value) {
      case DrdPovolani.Alchymista:
        return "Alchymista";
      case DrdPovolani.Bojovnik:
        return "Bojovník";
      case DrdPovolani.Carodej:
        return "Čaroděj";
      case DrdPovolani.Chodec:
        return "Chodec";
      case DrdPovolani.Druid:
        return "Druid";
      case DrdPovolani.Hranicar:
        return "Hraničář";
      case DrdPovolani.Kouzelnik:
        return "Kouzelník";
      case DrdPovolani.Lupic:
        return "Lupič";
      case DrdPovolani.Mag:
        return "Mág";
      case DrdPovolani.Pyrofor:
        return "Pyrofor";
      case DrdPovolani.Sermir:
        return "Šermíř";
      case DrdPovolani.Sicco:
        return "Sicco";
      case DrdPovolani.Theurg:
        return "Theurg";
      case DrdPovolani.Valecnik:
        return "Válečník";
      case DrdPovolani.Zlodej:
        return "Zloděj";
      default:
        return "DrdClassToReadableStringPipe neimplementuje case pro " + value;
    }
  }

}
