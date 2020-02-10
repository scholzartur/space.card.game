import { Component, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { CardDetailsDto } from 'src/app/dtos/view/card-details.dto';


@Component({
  selector: 'app-card-details-modal',
  templateUrl: './card-details-modal.component.html',
  styleUrls: ['./card-details-modal.component.css']
})
export class CardDetailsModalComponent  {

  constructor(
    public dialogRef: MatDialogRef<CardDetailsModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CardDetailsDto ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
