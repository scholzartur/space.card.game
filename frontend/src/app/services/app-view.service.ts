import { Injectable } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { CdkDrag, CdkDragDrop } from '@angular/cdk/drag-drop';
import { Starship } from '../dtos/view/starship.dto';
import { SpaceHttpService } from './space-http.service';
import { StarshipQueryRequestDto } from '../dtos/requests/starship-query-request.dto';
import { BattleCommandRequestDto } from '../dtos/requests/battle-command-request.dto';
import { AppViewState } from '../dtos/view/app-view-state.dto';

@Injectable()
export class AppViewService {

  constructor(public httpService: SpaceHttpService) { }

  public getStarshipsOnPageChange(viewState: AppViewState, event?: PageEvent) {
    const startingIndex = event.pageSize * event.pageIndex;
    this.getStarships(startingIndex, viewState);
    return event;
  }

  public startBattle(viewState: AppViewState) {
    viewState.fightingSideOneWon = false;
    viewState.fightingSideTwoWon = false;
    viewState.isDraw = false;
    const request = new BattleCommandRequestDto(viewState.fightingSideOne[0].id, viewState.fightingSideTwo[0].id);

    this.httpService.startBattle(request).subscribe(response => {
      if (response.winnerFound) {
        if (response.winnerShip.id === viewState.fightingSideOne[0].id) {
          viewState.fightingSideOne[0] = response.winnerShip;
          viewState.fightingSideOneWon = true;
        } else {
          viewState.fightingSideTwo[0] = response.winnerShip;
          viewState.fightingSideTwoWon = true;
        }
      } else {{
        viewState.isDraw = true;
      }}
    });
  }

  public isStarship(drag: CdkDrag) {
    if (drag.element.nativeElement.innerText.trim() !== '') {
      return true;
    }
    return false;
  }

  public getStarships(startingIndex: number, viewState: AppViewState) {
    this.httpService.getStarships(new StarshipQueryRequestDto(startingIndex, viewState.pageSize))
      .subscribe(
        response => {
          if (response.status === 'FAILURE') {
            // handle error
          } else {
            viewState.allStarships = response.starships;
            viewState.allStarshipsCount = response.allStarshipsCount;
          }
        },
        error => {
          // handle error
        }
      );
  }

  public swapElements(event: CdkDragDrop<string[]>, viewState: AppViewState) {
    switch (event.container.id) {
      case 'fightingSideTwo': {
        this.swap(viewState.fightingSideTwo, viewState);
        break;
      }
      case 'fightingSideOne': {
        this.swap(viewState.fightingSideOne, viewState);
        break;
      }
    }
  }

  private swap(array: Starship[], viewState: AppViewState) {
    if (array.length > 0) {
      viewState.allStarships.push(array[0]);
      delete array[0];
      array.length = 0;
    }
  }

}
