export class CharacterResponse {
    characterId: number = -1;
    name: string = "";
    rules: Rules = Rules.DraciDoupe;
}

export enum Rules {
    DraciDoupe = 0,
    DraciDoupe2 = 1
} 