import { Component, Inject } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem, CdkDropList, CdkDrag } from '@angular/cdk/drag-drop';
import { PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { CardDetailsModalComponent } from './components/card-details-modal/card-details-modal.component';
import { SpaceHttpService } from './services/space-http.service';
import { StarshipQueryRequestDto } from './dtos/requests/starship-query-request.dto';
import { Starship } from './dtos/view/starship.dto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  pageEvent: PageEvent;
  pageSize = 5;
  allStarshipsCount = 0;
  title = 'space-card-game';
  allStarships: Starship[] = [];
  fightingSideOne: Starship[] = [];
  fightingSideTwo: Starship[] = [];

  constructor(public dialog: MatDialog, public httpService: SpaceHttpService) {
    this.getStarships(1, this.pageSize);
  }

  public getServerData(event?: PageEvent) {
    const startingIndex = event.pageSize * event.pageIndex;
    this.getStarships(startingIndex, event.pageSize);
    return event;
  }


  openDialog(item: Starship): void {
    const dialogRef = this.dialog.open(CardDetailsModalComponent, {
      width: '400px',
      data: {starship: item}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      //this.animal = result;
    });
  }

  isStarship(drag: CdkDrag) {
    if (drag.element.nativeElement.textContent !== '') {
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
