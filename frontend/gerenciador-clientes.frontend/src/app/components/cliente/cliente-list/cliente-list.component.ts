import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../../services/cliente.service';
import { Cliente } from '../../../models/cliente.model';

@Component({
  selector: 'app-cliente-list',
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.css']
})
export class ClienteListComponent implements OnInit {
  clientes: Cliente[] = [];

  constructor(private clienteService: ClienteService) {}

  ngOnInit(): void {
    this.clienteService.getClientes().subscribe((data) => {
      this.clientes = data;
    });
  }

  deleteCliente(id: number): void {
    this.clienteService.deleteCliente(id).subscribe(() => {
      this.clientes = this.clientes.filter(cliente => cliente.id !== id);
    });
  }
}
