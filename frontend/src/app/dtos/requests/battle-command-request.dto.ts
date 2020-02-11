export class BattleCommandRequestDto {

  constructor(starshipOneId: number, starshipTwoId: number) {
    this.starshipOneId = starshipOneId;
    this.starshipTwoId = starshipTwoId;
  }

  starshipOneId: number;
  starshipTwoId: number;
}
