import { Component, OnInit, ViewChild } from "@angular/core";
import { MatDialog, MatTable, MatTableDataSource } from "@angular/material";
import { AddEditPhoneBookDialogBoxComponent } from "../add-edit-phone-book-dialog-box/add-edit-phone-book-dialog-box.component";
import { PhoneBookDto } from "src/app/shared/models/phone-book";
import { PhoneBookService } from "src/app/shared/services/phone-book.service";
import { AlertService } from "src/app/shared/services/alert.service";
import "rxjs/add/operator/take";
import { Router } from "@angular/router";

@Component({
  selector: "app-phone-book-form",
  templateUrl: "./phone-book-form.component.html",
  styleUrls: ["./phone-book-form.component.css"],
})
export class PhoneBookFormComponent implements OnInit {
  phoneBooks: PhoneBookDto[];
  @ViewChild(MatTable, { static: true }) table: MatTable<any>;

  displayedColumns: string[] = ["name", "action"];
  tableDataResource = new MatTableDataSource<PhoneBookDto>();

  pageLength: number = 0;
  constructor(
    private _phoneBookService: PhoneBookService,
    private _alertService: AlertService,
    public dialog: MatDialog,
    private _router: Router
  ) {}

  ngOnInit() {
    this.getPhoneBooks();
  }

  getPhoneBooks() {
    this._phoneBookService.getPhoneBooks().subscribe((books) => {
      this.phoneBooks = books;
      console.log();
      this.pageLength = this.phoneBooks.length;
      this.onPageChanged(null);
    });
  }

  openDialog(action: any, phonebook) {
    phonebook.action = action;
    const dialogRef = this.dialog.open(AddEditPhoneBookDialogBoxComponent, {
      width: "350px",
      height: "290px",
      data: phonebook,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result.event !== "Cancel") {
        if (action === "Add") {
          this.addPhoneBook(result.data);
        } else if (action === "Update") {
          this.updatePhoneBook(result.data);
        } else if (action === "Delete") {
          this.deleteProduct(result.data);
        }
      }
    });

    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  async addPhoneBook(phoneBook: PhoneBookDto) {
    await this._phoneBookService
      .addPhoneBook(phoneBook)
      .then((result) => {
        this._alertService.success("Phonebook was saved successfully !!");
        this.getPhoneBooks();
      })
      .catch((error) => {
        this._alertService.error("Data was not saved, please try again");
      });
    this.refreshTable();
  }

  async updatePhoneBook(phoneBook: PhoneBookDto) {
    this._phoneBookService
      .updatePhoneBook(phoneBook)
      .then((result) => {
        this._alertService.success("Phone book was updated successfully !!");
        this.getPhoneBooks();
      })
      .catch((error) => {
        this._alertService.error("Data was not updated, please try again");
      });
    this.refreshTable();
  }

  async deleteProduct(phoneBook: PhoneBookDto) {
    this._phoneBookService
      .deletePhoneBook(phoneBook)
      .then((result) => {
        this._alertService.success("Phone Book was deleted successfully !!");
        this.getPhoneBooks();
      })
      .catch((error) => {
        this._alertService.error("Data was not deleted, please try again");
      });
    this.refreshTable();
  }

  refreshTable() {
    this.getPhoneBooks();
  }

  private initializeTable(phoneBooks: PhoneBookDto[]) {
    this.tableDataResource = new MatTableDataSource<PhoneBookDto>(phoneBooks);
  }

  filter(query: any) {
    let searchTerm = query.target.value.toLocaleLowerCase();
    const filteredPhoneBooks = searchTerm
      ? this.phoneBooks.filter((p) => p.name.toLowerCase().includes(searchTerm))
      : this.phoneBooks;

    this.initializeTable(filteredPhoneBooks);
  }

  onPageChanged(e) {
    let filteredPhoneBooks = [];
    if (e == null) {
      let firstCut = 0;
      let secondCut = firstCut + 10;
      filteredPhoneBooks = this.phoneBooks.slice(firstCut, secondCut);
    } else {
      let firstCut = e.pageIndex * e.pageSize;
      let secondCut = firstCut + e.pageSize;
      filteredPhoneBooks = this.phoneBooks.slice(firstCut, secondCut);
    }
    this.initializeTable(filteredPhoneBooks);
  }

  navigateTo(phoneBook: PhoneBookDto) {
    this._router.navigate(["/viewentries"], {
      queryParams: { phoneBookId: phoneBook.phoneBookId },
    });
  }
}
