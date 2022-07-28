import { ResultadoController } from '../resultado-controller';
import { Usuario } from './usuario';

export class ResultadoUsuario extends ResultadoController {
  usuario: Usuario = new Usuario();
}
