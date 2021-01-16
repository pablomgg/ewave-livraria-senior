import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { InstituicaoService } from "src/app/instituicao/instituicao.service";
import { TerritorioService } from "src/app/shared/services/territorio.service";
import { UsuarioService } from "../usuario.service";

@Component({
  selector: "app-usuario-cadastro",
  templateUrl: "./usuario-cadastro.component.html",
  styleUrls: ["./usuario-cadastro.component.scss"],
})
export class UsuarioCadastroComponent implements OnInit {
  form: FormGroup;

  estados = [];
  cidades = [];
  instituicoes = [];
  telefones = [];
  emails = [];

  aggregateId: string;

  editar = false;
  submitted = false;

  formEndereco;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private usuarioService: UsuarioService,
    private territorioService: TerritorioService,
    private instituicaoService: InstituicaoService
  ) {
    this.construirFormulario();
    this.formEndereco = this.form.get("endereco");
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(({ id: aggregateId }) => {
      if (aggregateId) {
        this.aggregateId = aggregateId;
        this.obter(aggregateId);
      }
    });

    this.obterEstados();
    this.obterInstituicoes();

    this.formEndereco.get("estadoId").valueChanges.subscribe((value) => {
      this.obterCidades(value);
    });
  }

  construirFormulario() {
    this.form = this.formBuilder.group({
      pessoaFisica: this.formBuilder.group({
        nome: ["123123"],
        cpf: ["123123"],
      }),
      instituicaoDeEnsinoAggregateId: [null, Validators.required],
      emails: [
        [
          {
            endereco: "cristiano@jajaja.com.br",
            tipoId: 1,
          },
        ],
      ],
      telefones: [
        [
          {
            numero: "65996460014",
            tipoId: 1,
          },
        ],
      ],
      endereco: this.formBuilder.group({
        cep: ["123123"],
        estadoId: [1],
        cidadeId: [1],
        logradouro: ["asdasd"],
        numero: ['123'],
        bairro: ["adasd"],
        complemento: ["asdasdasd"],
      }),
    });
  }

  obter(aggregateId) {
    this.usuarioService.obterPorId(aggregateId).subscribe((res) => {
      this.patchValue(res);
    });
  }

  patchValue(usuario: any) {
    this.form.patchValue(usuario);
  }

  submit() {
    if (this.form.valid) {
      this.submitted = false;
      this.salvar();
    }

    this.submitted = true;
  }

  salvar() {
    const model = this.form.getRawValue();

    const { endereco } = model;
    model.endereco.cidadeId = +endereco.cidadeId;

    const request = this.aggregateId
      ? this.usuarioService.alterar(this.aggregateId, model)
      : this.usuarioService.criar(model);

    request.subscribe(() => {
      this.form.reset();
      this.irParaTelaDeConsulta();
    });
  }

  cancelar() {
    this.setFormularioSemAlteracao();
  }

  obterEstados() {
    this.territorioService.obterEstados().subscribe((res) => {
      this.estados = res;
    });
  }

  obterCidades(estadoId: number) {
    this.territorioService.obterCidades(estadoId).subscribe((res) => {
      this.cidades = res;
    });
  }

  obterInstituicoes() {
    this.instituicaoService.obter().subscribe((res) => {
      this.instituicoes = res;
    });
  }

  setFormularioSemAlteracao(form?: FormGroup) {
    const formulario = form ?? this.form;
    formulario.markAsPristine();
    formulario.markAsUntouched();
  }

  irParaTelaDeConsulta() {
    this.router.navigate(["usuario"]);
  }
}
