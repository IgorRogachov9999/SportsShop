import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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
    console.log(this.controller)
    this.http.post(this.controller, JSON.stringify(order));
    console.log("done?");
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