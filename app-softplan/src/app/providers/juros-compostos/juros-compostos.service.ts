
import { ProviderBaseService } from '../base/provider-base.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JurosCompostosService extends ProviderBaseService {

  constructor(private httpClient: HttpClient) {
    super('api/v1/', 'api/v1/JurosCompostos/');
  }

  public calcularJurosCompostos(valorInicial: number, meses: number): Observable<string> {
    const queryString = `?valorinicial=${valorInicial}&meses=${meses}`;
    return this.httpClient.get<string>(`${this.urlApiTwo}calculajuros${queryString}`);
  }

}
