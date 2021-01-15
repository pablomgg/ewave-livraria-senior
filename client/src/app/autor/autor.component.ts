import { Component, OnInit } from "@angular/core";
import { AutorService } from "./autor.service";

@Component({
  selector: "app-autor",
  templateUrl: "./autor.component.html",
  styleUrls: ["./autor.component.scss"],
})
export class AutorComponent implements OnInit {
  public autores: [] = [];

  constructor(private service: AutorService) {}

  ngOnInit(): void {
    this.obter();
  }

  public obter() {
    this.service.obter().subscribe(
      (server) => {
        this.autores = server;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  public criar() {}

  public alterar() {}

  public inativarOuAtivar() {}
}
