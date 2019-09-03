import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Line } from '../cart/cart.service';
import { ConfigService } from 'src/app/config.service';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  private controller:string = ConfigService.api + 'Checkout/';

  constructor(
    private http: HttpClient
  ) { 

  }

  getLast() {
    return this.http.get(this.controller);
  }

  postOrder(order: Order) {
    // return this.http.post<Order>(this.controller, body, {
    //   headers
    // });
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    return this.http.post(this.controller, order, httpOptions);
  }
}

export interface Order {
  orderID: number,
  lines: Line[],
  shipped: boolean,
  name: string,
  address: string,
  city: string,
  country: string,
}