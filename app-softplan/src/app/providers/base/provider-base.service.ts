import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

export abstract class ProviderBaseService {

  private urlBaseApiOne: string;
  private urlBaseApiTwo: string;
  private apiOne: string;
  private apiTwo: string;

  constructor(apiOne: string, apiTwo: string) {
    this.urlBaseApiOne = `${environment.apiOneUrl}`;
    this.urlBaseApiTwo = `${environment.apiTwoUrl}`;
    this.apiOne = apiOne;
    this.apiTwo = apiTwo;
  }

  get urlApiOne(): string {
    return `${this.urlBaseApiOne}/${this.apiOne}`;
  }

  urlOptionApiOne(api: string): string {
    return `${this.urlBaseApiOne}/${api}`;
  }

  get urlApiTwo(): string {
    return `${this.urlBaseApiTwo}/${this.apiTwo}`;
  }

  urlOptionApiTwo(api: string): string {
    return `${this.urlBaseApiTwo}/${api}`;
  }

}

