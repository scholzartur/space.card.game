import { Injectable } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { CdkDrag, CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { StarshipDto } from '../dtos/view/starship.dto';
import { SpaceHttpService } from './space-http.service';
import { StarshipQueryRequestDto } from '../dtos/requests/starship-query-request.dto';
import { BattleCommandRequestDto } from '../dtos/requests/battle-command-request.dto';
import { AppViewStateDto } from '../dtos/view/app-view-state.dto';
import { CardDetailsModalComponent } from '../components/card-details-modal/card-details-modal.component';
import { MatDialog } from '@angular/material/dialog';

@Injectable()
export class AppViewService {

  constructor(public httpService: SpaceHttpService) { }


  public getStarshipsOnPageChange(viewState: AppViewStateDto, event?: PageEvent) {
    const startingIndex = event.pageSize * event.pageIndex;
    this.getStarships(startingIndex, viewState);
    return event;
  }

  public startBattle(viewState: AppViewStateDto) {
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

  public getStarships(startingIndex: number, viewState: AppViewStateDto) {
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

  public swapElements(event: CdkDragDrop<string[]>, viewState: AppViewStateDto) {
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

  public drop(event: CdkDragDrop<string[]>, viewState: AppViewStateDto) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      this.swapElements(event, viewState);
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }

  public openDialog(item: StarshipDto, dialog: MatDialog): void {
    dialog.open(CardDetailsModalComponent, {
      width: '400px',
      data: {starship: item}
    });
  }

  private swap(array: StarshipDto[], viewState: AppViewStateDto) {
    if (array.length > 0) {
      viewState.allStarships.push(array[0]);
      delete array[0];
      array.length = 0;
    }
  }

}
