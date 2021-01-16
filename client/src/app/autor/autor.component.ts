import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";

import { ModalDirective } from "ngx-bootstrap/modal";
import { Subscription } from "rxjs";

import { AutorService } from "./autor.service";

@Component({
  selector: "app-autor",
  templateUrl: "./autor.component.html",
  styleUrls: ["./autor.component.scss"],
})
export class AutorComponent implements OnInit {
  @ViewChild("modal") modal: ModalDirective;

  subscription: Subscription;

  form: FormGroup;

  autores: [] = [];
  aggregateId: string;

  editar = false;
  submitted = false;

  constructor(
    private autorService: AutorService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute
  ) {
    this.construiFormulario();
  }

  ngOnInit(): void {
    this.obter();
  }

  construiFormulario() {
    this.form = this.formBuilder.group({
      nome: [null, Validators.required],
    });
  }

  obter() {
    this.autorService.obter().subscribe((res) => (this.autores = res));
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
      ? this.autorService.alterar(this.aggregateId, model)
      : this.autorService.criar(model);

    request.subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  alterarSituacao({ aggregateId }) {
    this.autorService.inativarOuAtivar(aggregateId).subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  abrirModal(autor?: any) {
    this.form.reset();

    if (autor) {
      const { aggregateId, nome } = autor;

      this.aggregateId = aggregateId;

      this.editar = true;
      this.form.get("nome").setValue(nome);
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
