import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResultadoController } from 'src/_models/resultado-controller';
import { ResultadoUsuario } from 'src/_models/usuarios/resultado-usuario';
import { ResultadoUsuarios } from 'src/_models/usuarios/resultado-usuarios';
import { Usuario } from 'src/_models/usuarios/usuario';

@Injectable({
  providedIn: 'root',
})
export class UsuariosControllerService {
  constructor(private http: HttpClient) {}

  public listarUsuarios(): Observable<ResultadoUsuarios> {
    return this.http.get<ResultadoUsuarios>(`${environment.apiUrl}/usuarios`);
  }

  public cadastrarUsuario(dados: Usuario): Observable<ResultadoUsuario> {
    return this.http.post<ResultadoUsuario>(
      `${environment.apiUrl}/usuarios`,
      dados
    );
  }

  public atualizarUsuario(
    dados: Usuario,
    id: number
  ): Observable<ResultadoUsuario> {
    return this.http.put<ResultadoUsuario>(
      `${environment.apiUrl}/usuarios/${id}`,
      dados
    );
  }

  public excluirUsuario(id: number): Observable<ResultadoController> {
    return this.http.delete<ResultadoController>(
      `${environment.apiUrl}/usuarios/${id}`
    );
  }
}
