import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ng2-validation';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatDialogModule, MatFormFieldModule, MatInputModule, MatPaginatorModule, MatSortModule, MatTableModule } from '@angular/material';
import { CommonModule } from '@angular/common';
import { AlertComponent } from './shared/alert/alert.component';
import { AlertService } from './shared/services/alert.service';
import { AddEditPhoneBookDialogBoxComponent } from './components/phonebooks/add-edit-phone-book-dialog-box/add-edit-phone-book-dialog-box.component';
import { PhoneBookFormComponent } from './components/phonebooks/phone-book-form/phone-book-form.component';
import { ViewEntriesComponent } from './components/phonebooks/entries/view-entries/view-entries.component';
import { AddEditEntryDialogBoxComponent } from './components/phonebooks/entries/add-edit-entry-dialog-box/add-edit-entry-dialog-box.component';
import { PhoneBookService } from './shared/services/phone-book.service';
import { EntriesService } from './shared/services/entries.service';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,    
    PhoneBookFormComponent,
    AlertComponent,
    AddEditPhoneBookDialogBoxComponent,
    ViewEntriesComponent,
    AddEditEntryDialogBoxComponent
  ],
  imports: [
    FormsModule,
    CustomFormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgbModule,
    AngularFontAwesomeModule,
    MatTableModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    CommonModule,
    MatPaginatorModule,    
    MatSortModule
  ],
  entryComponents: [AddEditPhoneBookDialogBoxComponent, AddEditEntryDialogBoxComponent],
  providers: [AlertService, PhoneBookService, EntriesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
