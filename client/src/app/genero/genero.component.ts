import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { ModalDirective } from "ngx-bootstrap/modal";
import { Subscription } from "rxjs";

import { GeneroService } from "./genero.service";
@Component({
  selector: "app-genero",
  templateUrl: "./genero.component.html",
  styleUrls: ["./genero.component.scss"],
})
export class GeneroComponent implements OnInit {
  @ViewChild("modal") modal: ModalDirective;

  subscription: Subscription;

  form: FormGroup;

  generos = [];
  aggregateId: string;

  editar = false;
  submitted = false;

  constructor(
    private generoService: GeneroService,
    private formBuilder: FormBuilder,
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
      ? this.generoService.alterar(this.aggregateId, model)
      : this.generoService.criar(model);

    request.subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  alterarSituacao({ aggregateId }) {
    this.generoService.inativarOuAtivar(aggregateId).subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  abrirModal(genero?: any) {
    this.form.reset();

    if (genero) {
      const { aggregateId, nome } = genero;

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
