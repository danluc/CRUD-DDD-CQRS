import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ListaEscolaridade } from 'src/_functions/converter-escolaridade';
import { Usuario } from 'src/_models/usuarios/usuario';
import { UsuariosControllerService } from 'src/_services/usuarios-controller.service';

@Component({
  selector: 'app-cadastrar-usuario',
  templateUrl: './cadastrar-usuario.component.html',
  styleUrls: ['./cadastrar-usuario.component.scss'],
})
export class CadastrarUsuarioComponent implements OnInit {
  public form: FormGroup;
  public escolaridade = ListaEscolaridade();
  public carregando: boolean = false;
  public mensagem: string = '';
  public hasErro: boolean = false;
  constructor(
    private _formBuilder: FormBuilder,
    private _usuariosControllerService: UsuariosControllerService,
    private router: Router
  ) {}

  ngOnInit() {
    this.form = this._formBuilder.group({
      nome: ['', [Validators.maxLength(200), Validators.required]],
      sobrenome: ['', [Validators.maxLength(200), Validators.required]],
      email: ['', [Validators.email, Validators.required]],
      dataNascimento: ['', [Validators.required]],
      escolaridade: [],
    });
  }

  public salvar(): void {
    this.mensagem = '';
    if (this.form.invalid) {
      return;
    }
    this.carregando = true;
    const dados = this.form.value as Usuario;
    this._usuariosControllerService.cadastrarUsuario(dados).subscribe(
      (res) => {
        this.mensagem = 'Usuário cadastrado com sucesso!';
        this.carregando = false;
        if (res.sucesso) {
          setTimeout(() => {
            this.router.navigate(['/']);
          }, 1500);
        }
      },
      (erro) => {
        this.carregando = false;
        this.hasErro = true;
        this.mensagem = erro.error.mensagem;
        console.log(erro);
      }
    );
  }
}
