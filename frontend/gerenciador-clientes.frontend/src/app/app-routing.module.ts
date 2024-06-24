import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteListComponent } from './components/cliente/cliente-list/cliente-list.component';
import { ClienteFormComponent } from './components/cliente/cliente-form/cliente-form.component';

const routes: Routes = [
  { path: '', redirectTo: '/clientes', pathMatch: 'full' },
  { path: 'clientes', component: ClienteListComponent },
  { path: 'add', component: ClienteFormComponent },
  { path: 'edit/:id', component: ClienteFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
