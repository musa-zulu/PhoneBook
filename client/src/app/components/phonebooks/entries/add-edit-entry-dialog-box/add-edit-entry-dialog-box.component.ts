import { Component, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Entry } from 'src/app/shared/models/Entry';
import { PhoneBookService } from 'src/app/shared/services/phone-book.service';

@Component({
  selector: 'app-add-edit-entry-dialog-box',
  templateUrl: './add-edit-entry-dialog-box.component.html',
  styleUrls: ['./add-edit-entry-dialog-box.component.css']
})
export class AddEditEntryDialogBoxComponent {
  action: string;
  localData: any;
  entry: Entry = new Entry();

  constructor(    
    public dialogRef: MatDialogRef<AddEditEntryDialogBoxComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Entry
  ) {
    this.localData = { ...data };
    this.action = this.localData.action;
  }

  doAction() {
    this.dialogRef.close({ event: this.action, data: this.localData });
  }

  closeDialog() {
    this.dialogRef.close({ event: "Cancel" });
  }
}
