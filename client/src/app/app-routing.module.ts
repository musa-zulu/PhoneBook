import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EntryFormComponent } from './components/entries/entry-form/entry-form.component';
import { PhoneBookFormComponent } from './components/phonebooks/phone-book-form/phone-book-form.component';

const routes: Routes = [
  {path: '', redirectTo: '/dashbord', pathMatch: 'full'},  
  {path: 'entries', component: EntryFormComponent},
  {path: 'phonebooks', component: PhoneBookFormComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
