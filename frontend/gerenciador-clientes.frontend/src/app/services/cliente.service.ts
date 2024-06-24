import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente.model';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private apiUrl = '/api/clientes'; 

  constructor(private http: HttpClient) { }

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.apiUrl);
  }

  getCliente(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.apiUrl}/${id}`);
  }

  addCliente(cliente: Cliente): Observable<Cliente> {
    const clienteDto = {
      ...cliente,
      porte: this.convertPorteToEnum(cliente.porte)
    };
    return this.http.post<Cliente>(this.apiUrl, clienteDto);
  }

  updateCliente(cliente: Cliente): Observable<Cliente> {
    const clienteDto = {
      ...cliente,
      porte: this.convertPorteToEnum(cliente.porte)
    };
    return this.http.put<Cliente>(`${this.apiUrl}/${cliente.id}`, clienteDto);
  }

  deleteCliente(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  private convertPorteToEnum(porte: string): number {
    switch (porte) {
      case 'Pequena': return 0;
      case 'Media': return 1;
      case 'Grande': return 2;
      default: return 0;
    }
  }
}
