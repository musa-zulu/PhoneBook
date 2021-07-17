import { Component, OnInit, ViewChild } from "@angular/core";
import { MatDialog, MatTable, MatTableDataSource } from "@angular/material";
import { ActivatedRoute } from "@angular/router";
import { Entry } from "src/app/shared/models/Entry";
import { AlertService } from "src/app/shared/services/alert.service";
import { EntriesService } from "src/app/shared/services/entries.service";
import { PhoneBookService } from "src/app/shared/services/phone-book.service";
import { AddEditEntryDialogBoxComponent } from "../add-edit-entry-dialog-box/add-edit-entry-dialog-box.component";

@Component({
  selector: "app-view-entries",
  templateUrl: "./view-entries.component.html",
  styleUrls: ["./view-entries.component.css"],
})
export class ViewEntriesComponent implements OnInit {
  entries: Entry[];
  @ViewChild(MatTable, { static: true }) table: MatTable<any>;

  displayedColumns: string[] = ["name", "phoneNumber", "action"];
  tableDataResource = new MatTableDataSource<Entry>();
  phoneBookId: string = "";

  pageLength: number = 0;
  constructor(
    private _phoneBookService: PhoneBookService,
    private _entriesService: EntriesService,
    private _alertService: AlertService,
    public dialog: MatDialog,
    private _router: ActivatedRoute
  ) {}

  ngOnInit() {
    this.phoneBookId = this._router.snapshot.queryParamMap.get("phoneBookId");
    this.getPhoneBookBy(this.phoneBookId);
  }

  getPhoneBookBy(phoneBookId: string) {
    this._phoneBookService.getPhoneBook(phoneBookId).subscribe((result) => {
      this.entries = result.entries;
      this.pageLength = this.entries.length;
      this.onPageChanged(null);
    });
  }

  openDialog(action: any, entry) {
    entry.action = action;
    const dialogRef = this.dialog.open(AddEditEntryDialogBoxComponent, {
      width: "350px",
      height: "390px",
      data: entry,
    });

    dialogRef.afterClosed().subscribe((result) => {
      result.data.phoneBookId = this.phoneBookId;
      if (result.event !== "Cancel") {        
        let regex: RegExp = new RegExp(/^[0-9]+(\.[0-9]*){0,1}$/g);
        if (regex.test(result.data.phoneNumber)) {
          if (action === "Add") {
            this.addEntry(result.data);
          } else if (action === "Update") {
            this.updateEntry(result.data);
          } else if (action === "Delete") {
            this.deleteEntry(result.data);
          }
        } else {
          this._alertService.error("Invalid input!!!");
        }
      }
    });
  }

  async addEntry(entry: Entry) {
    await this._entriesService
      .addEntry(entry)
      .then((result) => {
        this._alertService.success("Entry was saved successfully !!");
        this.getPhoneBookBy(this.phoneBookId);
      })
      .catch((error) => {
        this._alertService.error("Data was not saved, please try again");
      });
    this.refreshTable();
  }

  async updateEntry(entry: Entry) {
    this._entriesService
      .updateEntry(entry)
      .then((result) => {
        this._alertService.success("Entry was updated successfully !!");
        this.getPhoneBookBy(this.phoneBookId);
      })
      .catch((error) => {
        this._alertService.error("Data was not updated, please try again");
      });
    this.refreshTable();
  }

  async deleteEntry(entry: Entry) {
    this._entriesService
      .deleteEntry(entry)
      .then((result) => {
        this._alertService.success("Entry was deleted successfully !!");
        this.getPhoneBookBy(this.phoneBookId);
      })
      .catch((error) => {
        this._alertService.error("Data was not deleted, please try again");
      });
    this.refreshTable();
  }

  refreshTable() {
    this.getPhoneBookBy(this.phoneBookId);
  }

  private initializeTable(entries: Entry[]) {
    this.tableDataResource = new MatTableDataSource<Entry>(entries);
  }

  filter(query: any) {
    let searchTerm = query.target.value.toLocaleLowerCase();
    const filteredEntries = searchTerm
      ? this.entries.filter((p) => p.name.toLowerCase().includes(searchTerm))
      : this.entries;

    this.initializeTable(filteredEntries);
  }

  onPageChanged(e: { pageIndex: number; pageSize: number }): void {
    let filteredEntries = [];
    if (e == null) {
      let firstCut = 0;
      let secondCut = firstCut + 10;
      filteredEntries = this.entries.slice(firstCut, secondCut);
    } else {
      let firstCut = e.pageIndex * e.pageSize;
      let secondCut = firstCut + e.pageSize;
      filteredEntries = this.entries.slice(firstCut, secondCut);
    }
    this.initializeTable(filteredEntries);
  }
}
