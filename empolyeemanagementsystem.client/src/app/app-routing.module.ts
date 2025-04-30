import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { AppModule } from './app.module';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { EmployeeFormComponent } from './components/employee-form/employee-form.component';

const routes: Routes = [
  { path: '', component: EmployeeListComponent },
  { path: 'create', component: EmployeeFormComponent },
  { path: 'edit/:id', component: EmployeeFormComponent },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    CommonModule,
    HttpClientModule,
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
