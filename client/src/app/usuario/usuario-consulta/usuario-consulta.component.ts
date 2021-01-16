import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { UsuarioService } from "./../usuario.service";

@Component({
  selector: "app-usuario-consulta",
  templateUrl: "./usuario-consulta.component.html",
  styleUrls: ["./usuario-consulta.component.scss"],
})
export class UsuarioConsultaComponent implements OnInit {
  usuarios = [];

  constructor(private router: Router, private usuarioService: UsuarioService) {}

  ngOnInit(): void {
    this.obter();
  }

  obter() {
    this.usuarioService.obter().subscribe((res) => (this.usuarios = res));
  }

  alterarSituacao({ aggregateId }) {
    this.usuarioService.inativarOuAtivar(aggregateId).subscribe(() => {
      this.obter();
    });
  }

  cadastar() {
    this.router.navigate(["usuario", "cadastrar"]);
  }

  alterar = (usuario: any) =>
    this.router.navigate(["usuario", usuario.aggregateId, "editar"]);
}
