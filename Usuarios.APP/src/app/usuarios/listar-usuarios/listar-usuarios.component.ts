import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/_models/usuarios/usuario';
import { UsuariosControllerService } from 'src/_services/usuarios-controller.service';

@Component({
  selector: 'app-listar-usuarios',
  templateUrl: './listar-usuarios.component.html',
  styleUrls: ['./listar-usuarios.component.scss'],
})
export class ListarUsuariosComponent implements OnInit {
  public usuarios: Array<Usuario> = new Array<Usuario>();
  public carregando: boolean = true;
  public mensagem: string = '';
  constructor(private _usuariosControllerService: UsuariosControllerService) {}

  ngOnInit() {
    this._buscarDados();
  }

  private _buscarDados(): void {
    this._usuariosControllerService.listarUsuarios().subscribe(
      (res) => {
        this.usuarios = res.usuarios;
        this.carregando = false;
      },
      (erro) => {
        this.carregando = false;
        console.log(erro);
      }
    );
  }

  public excluir(item: Usuario): void {
    this.mensagem = '';
    this.carregando = true;
    this._usuariosControllerService.excluirUsuario(item.id).subscribe(
      (res) => {
        this.carregando = false;
        if (res.sucesso) {
          this.mensagem = `Usuário ${item.nome} excluído com sucesso!`;
          this._buscarDados();
          setTimeout(() => {
            this.mensagem = '';
          }, 2500);
        }
      },
      (erro) => {
        this.carregando = false;
        this.mensagem = erro.error.mensagem;
        console.log(erro);
      }
    );
  }
}
