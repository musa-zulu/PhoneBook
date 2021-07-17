import { Inject, Component, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { PhoneBookDto } from "src/app/shared/models/phone-book";

@Component({
  selector: "app-add-edit-phone-book-dialog-box",
  templateUrl: "./add-edit-phone-book-dialog-box.component.html",
  styleUrls: ["./add-edit-phone-book-dialog-box.component.css"],
})
export class AddEditPhoneBookDialogBoxComponent {
  action: string;
  localData: any;
  phonebooks: PhoneBookDto = new PhoneBookDto();

  constructor(
    public dialogRef: MatDialogRef<AddEditPhoneBookDialogBoxComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: PhoneBookDto
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
