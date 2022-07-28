import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DescricaoEscolaridadePipe } from './descricao-escolaridade.pipe';

@NgModule({
  imports: [CommonModule],
  declarations: [DescricaoEscolaridadePipe],
  exports: [DescricaoEscolaridadePipe],
})
export class PipesModule {}
