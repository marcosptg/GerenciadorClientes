import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteService } from '../../../services/cliente.service';
import { Cliente } from '../../../models/cliente.model';
import { Porte } from '../../../enums/porte.enum';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.css']
})
export class ClienteFormComponent implements OnInit {
  cliente: Cliente = { id: 0, nomeEmpresa: '', porte: Porte.Pequena };

  constructor(
    private clienteService: ClienteService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.clienteService.getCliente(+id).subscribe((data) => {
        this.cliente = data;
      });
    }
  }

  saveCliente(): void {
    if (this.cliente.id === 0) {
      this.clienteService.addCliente(this.cliente).subscribe(() => {
        this.router.navigate(['/clientes']);
      });
    } else {
      this.clienteService.updateCliente(this.cliente).subscribe(() => {
        this.router.navigate(['/clientes']);
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/clientes']);
  }
}
