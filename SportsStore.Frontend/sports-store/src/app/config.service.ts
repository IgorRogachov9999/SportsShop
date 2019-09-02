import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  public static api = 'http://localhost:5200/api/';

  constructor() { }
}
