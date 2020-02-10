import { ResponseBaseDto } from './response-base.dto';
import { Starship } from '../view/starship.dto';

export class StarshipQueryResponseDto extends ResponseBaseDto {
  starships: Starship[];
  allStarshipsCount: number;
}
