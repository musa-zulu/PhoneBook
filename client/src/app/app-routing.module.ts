import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewEntriesComponent } from './components/phonebooks/entries/view-entries/view-entries.component';
import { PhoneBookFormComponent } from './components/phonebooks/phone-book-form/phone-book-form.component';

const routes: Routes = [
  {path: '', redirectTo: '/phonebooks', pathMatch: 'full'},  
  {path: 'phonebooks', component: PhoneBookFormComponent},
  {path: 'viewentries', component: ViewEntriesComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
