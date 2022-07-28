import { ResultadoController } from '../resultado-controller';
import { Usuario } from './usuario';

export class ResultadoUsuarios extends ResultadoController {
  usuarios: Array<Usuario> = [];
}
