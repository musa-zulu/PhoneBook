import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ServerConfig {

  public getRequestOptions(): any {
    const headers = new HttpHeaders(
        {
            'Content-Type': 'application/json',
        });
    const options = (
        {
            headers
        });

    return options;
}

  public getBaseUrl(): string {
    return environment.baseUrl;
  }
}
