import { ResponseBaseDto } from './response-base.dto';
import { StarshipDto } from '../view/starship.dto';

export class StarshipQueryResponseDto extends ResponseBaseDto {
  starships: StarshipDto[];
  allStarshipsCount: number;
}
