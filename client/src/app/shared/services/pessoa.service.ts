import { Injectable, Injector } from "@angular/core";
import { HttpService } from "../http.service";

@Injectable({
  providedIn: "root",
})
export class PessoaService extends HttpService {
  constructor(public injector: Injector) {
    super(injector, "pessoas", "pessoa");
  }

  public alterar(aggregateId: string, body: any) {
    return this.put(`${aggregateId}/pessoa-juridica`, body);
  }

  public alterarEndereco(aggregateId: string, body: any) {
    return this.put(`${aggregateId}/endereco`, body);
  }

  public alterarTelefone(aggregateId: string, id: number, body: any) {
    return this.put(`${aggregateId}/telefone/${id}`, body);
  }

  public alterarEmail(aggregateId: string, id: number, body: any) {
    return this.put(`${aggregateId}/email/${id}`, body);
  }
}
