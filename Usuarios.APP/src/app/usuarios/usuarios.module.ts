import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { UsuariosComponent } from './usuarios.component';
import { NgModule } from '@angular/core';
import { ListarUsuariosComponent } from './listar-usuarios/listar-usuarios.component';
import { CadastrarUsuarioComponent } from './cadastrar-usuario/cadastrar-usuario.component';
import { PipesModule } from 'src/_pipe/pipes.module';

const routes: Routes = [
  {
    path: '',
    component: UsuariosComponent,
    children: [
      { path: '', component: ListarUsuariosComponent },
      { path: 'cadastrar', component: CadastrarUsuarioComponent },
      { path: 'atualizar/:id', component: CadastrarUsuarioComponent },
    ],
  },
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes), PipesModule],
  declarations: [
    UsuariosComponent,
    ListarUsuariosComponent,
    CadastrarUsuarioComponent,
  ],
  providers: [],
})
export class UsuariosModule {}
