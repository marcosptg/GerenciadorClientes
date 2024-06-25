import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ClienteListComponent } from './cliente-list.component';
import { ClienteService } from '../../../services/cliente.service';
import { Cliente } from '../../../models/cliente.model';
import { Porte } from '../../../enums/porte.enum';

describe('ClienteListComponent', () => {
  let component: ClienteListComponent;
  let fixture: ComponentFixture<ClienteListComponent>;
  let httpMock: HttpTestingController;
  let clienteService: ClienteService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClienteListComponent],
      imports: [HttpClientTestingModule],
      providers: [ClienteService]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClienteListComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
    clienteService = TestBed.inject(ClienteService);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve clientes from the server', () => {
    const mockClientes: Cliente[] = [
      { id: 1, nomeEmpresa: 'Empresa A', porte: Porte.Pequena },
      { id: 2, nomeEmpresa: 'Empresa B', porte: Porte.Media }
    ];

    component.ngOnInit();

    const req = httpMock.expectOne('/api/clientes');
    expect(req.request.method).toEqual('GET');
    req.flush(mockClientes);

    expect(component.clientes).toEqual(mockClientes);
  });

  it('should delete a cliente', () => {
    const mockClientes: Cliente[] = [
      { id: 1, nomeEmpresa: 'Empresa A', porte: Porte.Pequena },
      { id: 2, nomeEmpresa: 'Empresa B', porte: Porte.Media }
    ];

    component.clientes = mockClientes;

    component.deleteCliente(1);

    const req = httpMock.expectOne('/api/clientes/1');
    expect(req.request.method).toEqual('DELETE');
    req.flush({});

    expect(component.clientes).toEqual([{ id: 2, nomeEmpresa: 'Empresa B', porte: Porte.Media }]);
  });
});
