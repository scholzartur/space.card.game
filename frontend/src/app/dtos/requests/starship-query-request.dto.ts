export class StarshipQueryRequestDto {

  constructor(startingIndex: number, amountToReturn: number) {
    this.startingIndex = startingIndex;
    this.amountToreturn = amountToReturn;
  }

  startingIndex: number;
  amountToreturn: number;
}
