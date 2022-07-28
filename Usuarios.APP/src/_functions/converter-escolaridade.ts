import { Escolaridade } from 'src/_models/usuarios/EscolaridadeEnum';
export function ListaEscolaridade(): Array<{
  descricao: string;
  id: Escolaridade;
}> {
  return [
    {
      descricao: 'Fundamental',
      id: Escolaridade.Fundamental,
    },
    {
      descricao: 'Infantil',
      id: Escolaridade.Infantil,
    },
    {
      descricao: 'Médio',
      id: Escolaridade.Medio,
    },
    {
      descricao: 'Superior',
      id: Escolaridade.Superior,
    },
  ];
}
