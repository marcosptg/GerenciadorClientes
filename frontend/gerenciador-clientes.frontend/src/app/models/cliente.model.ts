import { Porte } from "../enums/porte.enum";

export interface Cliente {
  id: number;
  nomeEmpresa: string;
  porte: Porte;
}
