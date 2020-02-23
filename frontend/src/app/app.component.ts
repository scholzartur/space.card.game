import { Component, Inject } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem, CdkDropList, CdkDrag } from '@angular/cdk/drag-drop';
import { PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { CardDetailsModalComponent } from './components/card-details-modal/card-details-modal.component';
import { Starship } from './dtos/view/starship.dto';
import { AppViewService } from './services/app-view.service';
import { AppViewState } from './dtos/view/app-view-state.dto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {

  viewState: AppViewState = {
    pageSize: 5,
    allStarshipsCount: 0,
    allStarships: [],
    fightingSideOne: [],
    fightingSideTwo: [],
    fightingSideTwoWon: false,
    fightingSideOneWon: false,
    isDraw: false,
  };

  constructor(public dialog: MatDialog, public viewService: AppViewService) {
    this.viewService.getStarships(1, this.viewState);
  }

  public openDialog(item: Starship): void {
    this.dialog.open(CardDetailsModalComponent, {
      width: '400px',
      data: {starship: item}
    });
  }

  public drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      this.viewService.swapElements(event, this.viewState);
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }
}
