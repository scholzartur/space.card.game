import { PageEvent } from '@angular/material/paginator';
import { StarshipDto } from './starship.dto';

export interface AppViewStateDto {
  pageEvent?: PageEvent;
  pageSize: number;
  allStarshipsCount: number;
  allStarships: StarshipDto[];
  fightingSideOne: StarshipDto[];
  fightingSideTwo: StarshipDto[];
  fightingSideTwoWon: boolean;
  fightingSideOneWon: boolean;
  isDraw: boolean;
}
