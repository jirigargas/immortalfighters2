export class CharacterResponse {
    characterId: number = -1;
    name: string = "";
    rules: Rules = Rules.DraciDoupe;
    avatar: string | undefined;
}

export class DrdCharacterDetailResponse {
    characterId: number = -1;
    name: string = "";
    rasa: DrdRasa = DrdRasa.Hobit;
    povolani: DrdPovolani = DrdPovolani.Valecnik;
    sila: number = 0;
    obratnost: number = 0;
    odolnost: number = 0;
    inteligence: number = 0;
    charisma: number = 0;
    zivoty: number = 0;
    zkusenosti: number = 0;
    uroven: number = 0;
    presvedceni: DrdPresvedceni = DrdPresvedceni.ZakonneDobro;
    avatar: string = "";
}

export enum Rules {
    DraciDoupe = 0,
    DraciDoupe2 = 1
}

export class NewDrdCharacter {
    name: string = "";
    race: DrdRasa = DrdRasa.Hobit;
    class: DrdPovolani = DrdPovolani.Valecnik;
    conviction: DrdPresvedceni = DrdPresvedceni.ZakonneDobro;
}

export enum DrdRasa {
    Hobit,
    Kuduk,
    Trpaslik,
    Elf,
    Clovek,
    Barbar,
    Kroll
}

export enum DrdPovolani {
    Valecnik,
    Bojovnik,
    Sermir,
    Hranicar,
    Druid,
    Chodec,
    Alchymista,
    Theurg,
    Pyrofor,
    Kouzelnik,
    Mag,
    Carodej,
    Zlodej,
    Lupic,
    Sicco
}

export enum DrdPresvedceni {
    ZakonneDobro,
    ZmateneDobro,
    Neutralni,
    ZmateneZlo,
    ZakonneZlo
}