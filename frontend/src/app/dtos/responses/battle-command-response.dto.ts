import { ResponseBaseDto } from './response-base.dto';
import { Starship } from '../view/starship.dto';

export class BattleCommandResponseDto extends ResponseBaseDto {
  status: string;
  message: string;
  winnerShip: Starship;
  winnerFound: boolean;
}
