import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { InstituicaoService } from "src/app/instituicao/instituicao.service";
import { TerritorioService } from "src/app/shared/services/territorio.service";

@Component({
  selector: "app-instituicao-cadastro",
  templateUrl: "./instituicao-cadastro.component.html",
  styleUrls: ["./instituicao-cadastro.component.scss"],
})
export class InstituicaoCadastroComponent implements OnInit {
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
    private instituicaoService: InstituicaoService,
    private territorioService: TerritorioService
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

    this.formEndereco.get("estadoId").valueChanges.subscribe((value) => {
      this.obterCidades(value);
    });
  }

  construirFormulario() {
    this.form = this.formBuilder.group({
      pessoaJuridica: this.formBuilder.group({
        nomeFantasia: ["ALo", Validators.required],
        razaoSocial: ["Alo2 ", Validators.required],
        cnpj: ["50875585000161", Validators.required],
      }),
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
        cep: ["78049502"],
        estadoId: [1],
        cidadeId: [1],
        logradouro: ["asdasd"],
        numero: ["13"],
        bairro: ["adasd"],
        complemento: ["asdasdasd"],
      }),
    });
  }

  obter(aggregateId) {
    this.instituicaoService.obterPorId(aggregateId).subscribe((res) => {
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
      ? this.instituicaoService.alterar(this.aggregateId, model)
      : this.instituicaoService.criar(model);

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

  setFormularioSemAlteracao(form?: FormGroup) {
    const formulario = form ?? this.form;
    formulario.markAsPristine();
    formulario.markAsUntouched();
  }

  irParaTelaDeConsulta() {
    this.router.navigate(["instituicao"]);
  }
}
