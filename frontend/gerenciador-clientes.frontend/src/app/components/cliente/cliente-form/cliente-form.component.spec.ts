import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ClienteFormComponent } from './cliente-form.component';
import { ClienteService } from '../../../services/cliente.service';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { RouterTestingModule } from '@angular/router/testing';
import { Porte } from '../../../enums/porte.enum';


describe('ClienteFormComponent', () => {
  let component: ClienteFormComponent;
  let fixture: ComponentFixture<ClienteFormComponent>;
  let httpMock: HttpTestingController;
  let clienteService: ClienteService;
  let route: ActivatedRoute;
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClienteFormComponent],
      imports: [HttpClientTestingModule, RouterTestingModule],
      providers: [
        ClienteService,
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {
              paramMap: {
                get: (key: string) => '1' 
              }
            }
          }
        }
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClienteFormComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
    clienteService = TestBed.inject(ClienteService);
    route = TestBed.inject(ActivatedRoute);
    router = TestBed.inject(Router);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should load cliente data if clienteId is provided', () => {
    const mockCliente = { id: 1, nomeEmpresa: 'Empresa A', porte: Porte.Pequena };

    spyOn(clienteService, 'getCliente').and.returnValue(of(mockCliente));

    component.ngOnInit();

    expect(clienteService.getCliente).toHaveBeenCalledWith(1);
    expect(component.cliente).toEqual(mockCliente);
  });

  it('should create a new cliente', () => {
    const mockCliente = { id: 0, nomeEmpresa: 'Empresa B', porte: Porte.Media };

    spyOn(clienteService, 'addCliente').and.returnValue(of(mockCliente));
    spyOn(router, 'navigate');

    component.cliente = { id: 0, nomeEmpresa: 'Empresa B', porte: Porte.Media };

    component.saveCliente();

    expect(clienteService.addCliente).toHaveBeenCalledWith(component.cliente);
    expect(router.navigate).toHaveBeenCalledWith(['/clientes']);
  });

  it('should update an existing cliente', () => {
    const mockCliente = { id: 1, nomeEmpresa: 'Empresa C', porte: Porte.Grande };

    spyOn(clienteService, 'updateCliente').and.returnValue(of(mockCliente));
    spyOn(router, 'navigate');

    component.cliente = { id: 1, nomeEmpresa: 'Empresa C', porte: Porte.Grande };

    component.saveCliente();

    expect(clienteService.updateCliente).toHaveBeenCalledWith(component.cliente);
    expect(router.navigate).toHaveBeenCalledWith(['/clientes']);
  });

  it('should navigate to /clientes when cancel is called', () => {
    spyOn(router, 'navigate');

    component.cancel();

    expect(router.navigate).toHaveBeenCalledWith(['/clientes']);
  });
});
