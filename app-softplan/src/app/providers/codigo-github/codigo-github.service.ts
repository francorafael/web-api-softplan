import { Injectable } from '@angular/core';
import { ProviderBaseService } from '../base/provider-base.service';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CodigoGithubService extends ProviderBaseService {


  constructor(private httpClient: HttpClient) {
    super('api/v1/', 'api/v1/CodigoGitHub/');
  }

  public obterShowMeCodeGitHub(): Observable<string> {
    const requestOptions: Object = {
      responseType: 'text'
    }
    return this.httpClient.get<string>(`${this.urlApiTwo}showmethecode`, requestOptions);
  }
  

}
