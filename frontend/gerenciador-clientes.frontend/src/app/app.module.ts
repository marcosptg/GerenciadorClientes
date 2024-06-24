import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ClienteListComponent } from './components/cliente/cliente-list/cliente-list.component';
import { ClienteFormComponent } from './components/cliente/cliente-form/cliente-form.component';

import { ClienteService } from './services/cliente.service';

const appRoutes: Routes = [
  { path: '', redirectTo: '/clientes', pathMatch: 'full' },
  { path: 'clientes', component: ClienteListComponent },
  { path: 'add', component: ClienteFormComponent },
  { path: 'edit/:id', component: ClienteFormComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    ClienteListComponent,
    ClienteFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
