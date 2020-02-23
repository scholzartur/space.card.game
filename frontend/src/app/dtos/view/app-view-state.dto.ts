import { PageEvent } from '@angular/material/paginator';
import { Starship } from './starship.dto';

export interface AppViewState {
  pageEvent?: PageEvent;
  pageSize: number;
  allStarshipsCount: number;
  allStarships: Starship[];
  fightingSideOne: Starship[];
  fightingSideTwo: Starship[];
  fightingSideTwoWon: boolean;
  fightingSideOneWon: boolean;
  isDraw: boolean;
}
