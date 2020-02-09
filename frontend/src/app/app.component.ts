import { Component } from '@angular/core';
import {CdkDragDrop, moveItemInArray, transferArrayItem} from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'space-card-game';

  allStarships = [
    'Get to work',
    'Pick up groceries',
    'Go home',
    'Fall asleep'
  ];

  fightingSideOne = [
    'Walk dog'
  ];

  fightingSideTwo = [
    'Get up',
  ];


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
    this.allStarships.push(array[0]);
    delete array[0];
    array.length = 0;
  }

}
