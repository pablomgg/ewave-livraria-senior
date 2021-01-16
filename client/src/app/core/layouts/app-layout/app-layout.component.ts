import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-app-layout",
  templateUrl: "./app-layout.component.html",
  styleUrls: ["./app-layout.component.scss"],
})
export class AppLayoutComponent implements OnInit {
  subscription;

  constructor(private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.subscription = this.activatedRoute.data.subscribe((res) => {
      console.log(res);
    });
  }

  public ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
