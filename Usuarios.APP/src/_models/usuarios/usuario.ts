import { Escolaridade } from './EscolaridadeEnum';

export class Usuario {
  id: number = 0;
  nome: string = '';
  sobrenome: string = '';
  email: string = '';
  escolaridadeDescricao: string = '';
  escolaridade: Escolaridade = Escolaridade.Fundamental;
  dataNascimento: Date = new Date();
}
