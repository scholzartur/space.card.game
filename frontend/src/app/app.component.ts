import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AppViewService } from './services/app-view.service';
import { AppViewStateDto } from './dtos/view/app-view-state.dto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {

  viewState: AppViewStateDto = {
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
}
