import { Component, Inject } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { CardDetailsModalComponent } from './card-details-modal/card-details-modal.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  animal = 'ee';
  name = 'ss';

  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  length: number;

  title = 'space-card-game';

  allStarships = [
    'Get to work',
    'Pick up groceries',
    'Go home',
    'Fall asleep',
    'Walk dog',
    'Get up',
    'Get to work',
    'Pick up groceries',
    'Go home',
    'Fall asleep',
    'Walk dog',
    'Get up',
  ];

  fightingSideOne = [];

  fightingSideTwo = [];

  constructor(public dialog: MatDialog) {}

  // public getServerData(event?: PageEvent) {
  //   this.fooService.getdata(event).subscribe(
  //     response => {
  //       if (response.error) {
  //         // handle error
  //       } else {
  //         this.datasource = response.data;
  //         this.pageIndex = response.pageIndex;
  //         this.pageSize = response.pageSize;
  //         this.length = response.length;
  //       }
  //     },
  //     error => {
  //       // handle error
  //     }
  //   );
  //   return event;
  // }


  openDialog(): void {
    const dialogRef = this.dialog.open(CardDetailsModalComponent, {
      width: '250px',
      data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.animal = result;
    });
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

  swapElements(event: CdkDragDrop<string[]>) {
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

  private swap(array: string[]) {
    if (array.length > 0) {
      this.allStarships.push(array[0]);
      delete array[0];
      array.length = 0;
    }
  }

}
