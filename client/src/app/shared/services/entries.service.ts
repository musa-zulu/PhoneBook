import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { Entry } from "../models/Entry";
import { ServerConfig } from "./server-config";

@Injectable({
  providedIn: "root",
})
export class EntriesService {
  private readonly _apiURL = "entries";
  constructor(private _http: HttpClient, private _serverConfig: ServerConfig) {}

  getEntries(): Observable<any> {
    return this._http
      .get<Entry[]>(
        this._serverConfig.getBaseUrl() + this._apiURL,
        this._serverConfig.getRequestOptions()
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  getEntry(entryId: string): Observable<any> {
    return this._http
      .get<Entry>(
        this._serverConfig.getBaseUrl() + this._apiURL + "/" + entryId,
        this._serverConfig.getRequestOptions()
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  addEntry(entry: Entry): Promise<any> {
    return this._http
      .post(
        this._serverConfig.getBaseUrl() + this._apiURL,
        entry,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  updateEntry(entry: Entry) {
    return this._http
      .put(
        this._serverConfig.getBaseUrl() + this._apiURL + "/",
        entry,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  deleteEntry(entry: Entry) {
    return this._http
      .delete<Entry>(
        this._serverConfig.getBaseUrl() +
          this._apiURL +
          "/" +
          entry.entryId,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  private handleError(error: any) {
    return Observable.throw(error);
  }
}
