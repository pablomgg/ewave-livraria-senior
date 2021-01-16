import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { ModalDirective } from "ngx-bootstrap/modal";
import { Subscription } from "rxjs";
import { LivroService } from "../livro/livro.service";
import { UsuarioService } from "../usuario/usuario.service";
import { EmprestimoService } from "./emprestimo.service";

@Component({
  selector: "app-emprestimo",
  templateUrl: "./emprestimo.component.html",
  styleUrls: ["./emprestimo.component.scss"],
})
export class EmprestimoComponent implements OnInit {
  @ViewChild("modal") modal: ModalDirective;

  subscription: Subscription;

  form: FormGroup;

  emprestimos = [];
  usuarios = [];
  livros = [];

  aggregateId: string;

  submitted = false;

  data = new Date();
  constructor(
    private formBuilder: FormBuilder,
    private emprestimoService: EmprestimoService,
    private usuarioService: UsuarioService,
    private livroService: LivroService
  ) {
    this.construiFormulario();
  }

  ngOnInit(): void {
    this.obter();
    this.obterUsuarios();
    this.obterLivros();
  }

  construiFormulario() {
    this.form = this.formBuilder.group({
      usuarioAggregateId: [null, Validators.required],
      livroAggregateId: [null, Validators.required],
      dataEmprestimo: [null, Validators.required],
      // dataDevolucao: [null, Validators.required],
    });
  }

  obter() {
    this.emprestimoService.obter().subscribe((res) => (this.emprestimos = res));
  }

  obterUsuarios() {
    this.usuarioService.obter().subscribe((res) => (this.usuarios = res));
  }

  obterLivros() {
    this.livroService.obter().subscribe((res) => (this.livros = res));
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

    this.emprestimoService.criar(model).subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  devolver({ aggregateId }) {
    this.emprestimoService.devolver(aggregateId).subscribe(() => this.obter());
  }

  abrirModal() {
    this.form.reset();
    this.modal.show();
  }

  fecharModal() {
    this.submitted = false;
    this.form.reset();
    this.modal.hide();
  }
}
