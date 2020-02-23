import { StarshipQueryRequestDto } from 'src/app/dtos/requests/starship-query-request.dto';
import { BattleCommandRequestDto } from 'src/app/dtos/requests/battle-command-request.dto';
import { Observable, of } from 'rxjs';
import { StarshipDto } from 'src/app/dtos/view/starship.dto';
import { StarshipQueryResponseDto } from 'src/app/dtos/responses/starship-query-response.dto';
import { BattleCommandResponseDto } from 'src/app/dtos/responses/battle-command-response.dto';

export class SpaceHttpServiceMock {

  starshipsMock: StarshipDto[] = [
    {
      id: 1,
      amountOfPeopleInCrew: 1,
      amountOfWins: 0,
      name: 'starship 1',
      fightingPotential: 1
    },
    {
      id: 2,
      amountOfPeopleInCrew: 2,
      amountOfWins: 0,
      name: 'starship 2',
      fightingPotential: 2
    },
    {
      id: 3,
      amountOfPeopleInCrew: 3,
      amountOfWins: 0,
      name: 'starship 3',
      fightingPotential: 3
    }
  ];

  getStarships(request: StarshipQueryRequestDto): Observable<StarshipQueryResponseDto> {
    const response = new StarshipQueryResponseDto();
    response.allStarshipsCount = this.starshipsMock.length;
    response.starships = this.starshipsMock;

    return of(response);
  }

  startBattle(request: BattleCommandRequestDto): Observable<BattleCommandResponseDto> {
    const response = new BattleCommandResponseDto();
    response.status = 'SUCCESS';
    response.winnerFound = true;

    this.starshipsMock[1].amountOfWins += 1;
    response.winnerShip = this.starshipsMock[1];

    return of(response);
  }
}
