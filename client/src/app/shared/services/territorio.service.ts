import { Injectable, Injector } from "@angular/core";
import { HttpService } from "../http.service";

@Injectable({
  providedIn: "root",
})
export class TerritorioService extends HttpService {
  constructor(public injector: Injector) {
    super(injector, "territorios", null);
  }

  public obterEstados() {
    return this.get("estados");
  }

  public obterCidades(estadoId: number) {
    return this.get(`estados/${estadoId}/cidades`);
  }
}
