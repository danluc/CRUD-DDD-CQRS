import { Pipe, PipeTransform } from '@angular/core';
import { Escolaridade } from 'src/_models/usuarios/EscolaridadeEnum';
import { ListaEscolaridade } from 'src/_functions/converter-escolaridade';

@Pipe({
  name: 'descricaoescolaridade',
})
export class DescricaoEscolaridadePipe implements PipeTransform {
  transform(valor: Escolaridade): string {
    const item = ListaEscolaridade().find((e) => e.id == valor);
    if (!item) return 'Não encontrado!';
    return item.descricao;
  }
}
