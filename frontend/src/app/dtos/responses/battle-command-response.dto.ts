import { ResponseBaseDto } from './response-base.dto';
import { StarshipDto } from '../view/starship.dto';

export class BattleCommandResponseDto extends ResponseBaseDto {
  status: string;
  message: string;
  winnerShip: StarshipDto;
  winnerFound: boolean;
}
