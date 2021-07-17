import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ServerConfig } from "./server-config";
import { Observable } from "rxjs";
import { PhoneBookDto } from "../models/phone-book";
import { catchError, retry } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class PhoneBookService {
  private readonly _apiURL = "phoneBooks";
  constructor(private _http: HttpClient, private _serverConfig: ServerConfig) {}

  getPhoneBooks(): Observable<any> {
    return this._http
      .get<PhoneBookDto[]>(
        this._serverConfig.getBaseUrl() + this._apiURL,
        this._serverConfig.getRequestOptions()
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  getPhoneBook(phoneBookId: string): Observable<any> {
    return this._http
      .get<PhoneBookDto>(
        this._serverConfig.getBaseUrl() + this._apiURL + "/" + phoneBookId,         
        this._serverConfig.getRequestOptions()
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  addPhoneBook(phoneBook: PhoneBookDto): Promise<any> {
    return this._http
      .post(
        this._serverConfig.getBaseUrl() + this._apiURL,
        phoneBook,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  updatePhoneBook(phoneBook: PhoneBookDto) {
    return this._http
      .put(
        this._serverConfig.getBaseUrl() + this._apiURL + "/",
        phoneBook,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  deletePhoneBook(phoneBook: PhoneBookDto) {
    return this._http
      .delete<PhoneBookDto>(
        this._serverConfig.getBaseUrl() +
          this._apiURL +
          "/" +
          phoneBook.phoneBookId,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  private handleError(error: any) {
    return Observable.throw(error);
  }
}
