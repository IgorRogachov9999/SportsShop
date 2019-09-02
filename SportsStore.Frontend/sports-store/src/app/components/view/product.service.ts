import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from 'src/app/config.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private contoller = ConfigService.api + 'Product/';

  constructor(private http: HttpClient) { }

  getProducts(category: string,page: number) {
    var path = this.contoller  + page.toString() + '/' + (category == null ? '' : category);
    return this.http.get(path);
  }
}
