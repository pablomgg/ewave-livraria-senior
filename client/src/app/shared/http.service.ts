import { environment } from "./../../environments/environment";
import { Inject, Injectable, Injector } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class HttpService {
  private http: HttpClient;
  private URL_BASE = environment.api;
  private urlQuerie: string;
  private urlWrite: string;

  constructor(
    protected injector: Injector,
    @Inject(String) protected querieController: string,
    @Inject(String) protected writeController: string
  ) {
    this.http = injector.get(HttpClient);
    this.urlQuerie = `${this.URL_BASE}${querieController}`;
    this.urlWrite = `${this.URL_BASE}${writeController}`;
  }

  public get<T>(url?, options?: any): Observable<any> {
    return this.http.get(
      this.getEndPoint(this.urlQuerie, url),
      this.prepareOptions(options)
    );
  }

  public post<T>(url, body, options?: any): Observable<any> {
    return this.http.post(
      this.getEndPoint(this.urlWrite, url),
      JSON.stringify(body),
      this.prepareOptions(options)
    );
  }

  public put<T>(url, body, options?: any): Observable<any> {
    return this.http.put(
      this.getEndPoint(this.urlWrite, url),
      body,
      this.prepareOptions(options)
    );
  }

  public delete<T>(url?, options?: any): Observable<any> {
    return this.http.get(
      this.getEndPoint(this.urlWrite, url),
      this.prepareOptions(options)
    );
  }

  public prepareOptions(options?: any) {
    if (options != undefined && options != null) {
      return options;
    } else {
      const httpOptions = {
        headers: new HttpHeaders({
          "Content-Type": "application/json; charset=utf-8",
          "Access-Control-Allow-Methods": "POST, GET, OPTIONS, DELETE, PUT",
        }),
      };
      return httpOptions;
    }
  }

  public getEndPoint = (controller: string, url: string) =>
    url ? `${controller}/${url}` : controller;
}
