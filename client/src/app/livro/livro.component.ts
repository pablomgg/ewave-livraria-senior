import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { ModalDirective } from "ngx-bootstrap/modal";
import { Subscription } from "rxjs";

import { AutorService } from "../autor/autor.service";
import { GeneroService } from "../genero/genero.service";
import { LivroService } from "./livro.service";

@Component({
  selector: "app-livro",
  templateUrl: "./livro.component.html",
  styleUrls: ["./livro.component.scss"],
})
export class LivroComponent implements OnInit {
  @ViewChild("modal") modal: ModalDirective;
  @ViewChild("arquivoInput") arquivoInput: ElementRef;

  subscription: Subscription;

  form: FormGroup;

  aggregateId: string;

  livros = [];
  autores = [];
  generos = [];

  editar = false;
  submitted = false;

  constructor(
    private livroService: LivroService,
    private autorService: AutorService,
    private generoService: GeneroService,
    private formBuilder: FormBuilder
  ) {
    this.construiFormulario();
  }

  ngOnInit(): void {
    this.obter();
    this.obterAutores();
    this.obterGeneros();
  }

  construiFormulario() {
    this.form = this.formBuilder.group({
      titulo: [null, Validators.required],
      sinopse: [null, Validators.required],
      paginas: [null, Validators.required],
      capa: [null, Validators.required],
      autorAggregateId: [null, Validators.required],
      generoAggregateId: [null, Validators.required],
    });
  }

  obter() {
    this.livroService.obter().subscribe((res) => (this.livros = res));
  }
  obterAutores() {
    this.autorService.obter().subscribe((res) => (this.autores = res));
  }

  obterGeneros() {
    this.generoService.obter().subscribe((res) => (this.generos = res));
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

    const request = this.aggregateId
      ? this.livroService.alterar(this.aggregateId, model)
      : this.livroService.criar(model);

    request.subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  alterarSituacao({ aggregateId }) {
    this.livroService.inativarOuAtivar(aggregateId).subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  abrirModal(livro?: any) {
    this.form.reset();

    if (livro) {
      const { aggregateId, autor, genero } = livro;

      this.aggregateId = aggregateId;
      this.form.patchValue({
        ...livro,
        autorAggregateId: autor.aggregateId,
        generoAggregateId: genero.aggregateId,
      });

      this.editar = true;
    } else {
      this.editar = false;
      this.form.reset();
    }

    this.modal.show();
  }

  fecharModal() {
    this.submitted = false;
    this.form.reset();
    this.modal.hide();
  }
}
