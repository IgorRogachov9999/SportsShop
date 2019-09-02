import { Component, OnInit, Input } from '@angular/core';
import { CartService, Product } from '../cart/cart.service';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @Input() product: Product

  constructor(private cartService: CartService) {
    
   }

   addToCart(product: Product) {
    this.cartService.getCart().add(product);
   }

  ngOnInit() {
  }

}

