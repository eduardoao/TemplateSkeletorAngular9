import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


import { NavComponent } from './components/template/nav/nav.component';
import { SidebarComponent } from './components/template/sidebar/sidebar.component';
import { HomeComponent } from './components/views/home/home.component';
import { ContentComponent } from './components/views/content/content.component';
import { LoginComponent } from './components/views/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    SidebarComponent,
    HomeComponent,
    ContentComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
