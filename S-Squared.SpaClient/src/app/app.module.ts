import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { routing } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
//import { RouterModule } from '@angular/router';
import { EmployeeModule } from './employee/employee.module';
import { HomeModule } from './home/home.module';
import { HttpClientModule } from '@angular/common/http';
//import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    SharedModule.forRoot(),
    //ReactiveFormsModule,
    //RouterModule,
    HttpClientModule,
    EmployeeModule,
    HomeModule,
    routing
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
