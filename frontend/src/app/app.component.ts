import { Component, Inject } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem, CdkDropList, CdkDrag } from '@angular/cdk/drag-drop';
import { PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { CardDetailsModalComponent } from './components/card-details-modal/card-details-modal.component';
import { SpaceHttpService } from './services/space-http.service';
import { StarshipQueryRequestDto } from './dtos/requests/starship-query-request.dto';
import { Starship } from './dtos/view/starship.dto';
import { BattleCommandRequestDto } from './dtos/requests/battle-command-request.dto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  pageEvent: PageEvent;
  pageSize = 5;
  allStarshipsCount = 0;
  allStarships: Starship[] = [];
  fightingSideOne: Starship[] = [];
  fightingSideTwo: Starship[] = [];
  fightingSideTwoWon = false;
  fightingSideOneWon = false;
  isDraw = false;

  constructor(public dialog: MatDialog, public httpService: SpaceHttpService) {
    this.getStarships(1, this.pageSize);
  }

  public getServerData(event?: PageEvent) {
    const startingIndex = event.pageSize * event.pageIndex;
    this.getStarships(startingIndex, event.pageSize);
    return event;
  }

  startBattle() {
    this.fightingSideOneWon = false;
    this.fightingSideTwoWon = false;
    this.isDraw = false;
    const request = new BattleCommandRequestDto(this.fightingSideOne[0].id, this.fightingSideTwo[0].id);

    this.httpService.startBattle(request).subscribe(response => {
      if (response.winnerFound) {
        if (response.winnerShip.id === this.fightingSideOne[0].id) {
          this.fightingSideOne[0] = response.winnerShip;
          this.fightingSideOneWon = true;
        } else {
          this.fightingSideTwo[0] = response.winnerShip;
          this.fightingSideTwoWon = true;
        }
      } else {{
        this.isDraw = true;
      }}
    });
  }

  openDialog(item: Starship): void {
    const dialogRef = this.dialog.open(CardDetailsModalComponent, {
      width: '400px',
      data: {starship: item}
    });
  }

  isStarship(drag: CdkDrag) {
    if (drag.element.nativeElement.innerText.trim() !== '') {
      return true;
    }
    return false;
  }

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      this.swapElements(event);
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }

  private getStarships(startingIndex: number, amountToReturn: number) {
    this.httpService.getStarships(new StarshipQueryRequestDto(startingIndex, amountToReturn))
    .subscribe(
      response => {
        if (response.status === 'FAILURE') {
          // handle error
        } else {
          this.allStarships = response.starships;
          this.allStarshipsCount = response.allStarshipsCount;
        }
      },
      error => {
        // handle error
      }
    );
  }

  private swapElements(event: CdkDragDrop<string[]>) {
    switch (event.container.id) {
      case 'fightingSideTwo': {
        this.swap(this.fightingSideTwo);
        break;
      }
      case 'fightingSideOne': {
        this.swap(this.fightingSideOne);
        break;
      }
    }
  }

  private swap(array: Starship[]) {
    if (array.length > 0) {
      this.allStarships.push(array[0]);
      delete array[0];
      array.length = 0;
    }
  }
}
