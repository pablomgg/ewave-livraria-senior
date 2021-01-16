import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { InstituicaoService } from "../instituicao.service";

@Component({
  selector: "app-instituicao-consulta",
  templateUrl: "./instituicao-consulta.component.html",
  styleUrls: ["./instituicao-consulta.component.scss"],
})
export class InstituicaoConsultaComponent implements OnInit {
  instituicoes = [];

  constructor(
    private router: Router,
    private instituicaoService: InstituicaoService
  ) {}

  ngOnInit(): void {
    this.obter();
  }

  obter() {
    this.instituicaoService
      .obter()
      .subscribe((res) => (this.instituicoes = res));
  }

  alterarSituacao({ aggregateId }) {
    this.instituicaoService.inativarOuAtivar(aggregateId).subscribe(() => {
      this.obter();
    });
  }

  cadastar() {
    this.router.navigate(["instituicao", "cadastrar"]);
  }

  alterar = (instituicao: any) =>
    this.router.navigate(["instituicao", instituicao.aggregateId, "editar"]);
}
