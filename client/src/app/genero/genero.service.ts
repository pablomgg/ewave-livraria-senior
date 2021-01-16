import { Injectable, Injector } from "@angular/core";
import { HttpService } from "../shared/http.service";

@Injectable({
  providedIn: "root",
})
export class GeneroService extends HttpService {
  constructor(public injector: Injector) {
    super(injector, "generos", "genero");
  }

  public obter() {
    return this.get();
  }

  public obterPorId(aggregateId: string) {
    return this.get(aggregateId);
  }

  public criar(body: any) {
    return this.post(null, body);
  }

  public alterar(aggregateId: string, body: any) {
    return this.put(aggregateId, body);
  }

  public inativarOuAtivar(aggregateId: string) {
    return this.put(`${aggregateId}/inativar-ou-ativar`, null);
  }
}
