import { Component, OnInit } from '@angular/core';
import { CartService, Cart, Product } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cart: Cart = null;
  total: number = 0;

  constructor(private cartService: CartService) {
    this.cart = cartService.getCart();
    this.cart.lines.forEach(el => {
      this.total += el.quantity * el.product.price;
    });
  }

  removeFromCart(product: Product) {
    this.cart = this.cartService.getCart();
    this.cart.remove(product);
    this.total = 0;
    this.cart.lines.forEach(el => {
      this.total += el.quantity * el.product.price;
    });
 }

  ngOnInit() {
    
  }

}