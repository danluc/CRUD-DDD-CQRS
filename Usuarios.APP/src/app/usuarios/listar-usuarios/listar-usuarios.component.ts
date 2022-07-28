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
  constructor(private _usuariosControllerService: UsuariosControllerService) {}

  ngOnInit() {
    this._buscarDados();
  }

  private _buscarDados(): void {
    this._usuariosControllerService.listarUsuarios().subscribe(
      (res) => {
        this.usuarios = res.usuarios;
        this.carregando = false;
        console.log(this.usuarios);
      },
      (erro) => {
        this.carregando = false;
        console.log(erro);
      }
    );
  }
}
