import { Component, OnInit } from '@angular/core';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';
import { CartService } from '../cart/cart.service';
import { CheckoutService, Order } from './checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  
  checkoutForm: FormGroup;
  
  constructor(
    private formBuilder: FormBuilder,
    private cartService: CartService,
    private checkoutService: CheckoutService
  ) {
    this.createForm();
    this.checkoutService.getLast().subscribe(
      value => console.log(value), 
      error => console.error(error)
    );
   }

   createForm() {
     this.checkoutForm = this.formBuilder.group({
       name: ['', Validators.required],
       address: ['', Validators.required],
       city: ['', Validators.required],
       country: ['', Validators.required],
     })
   }

   checkout() {
    var value = this.checkoutForm.value;
    var order: Order = {
      orderID: 0,
      lines: this.cartService.getCart().lines,
      shipped: false,
      name: value.name,
      address: value.address,
      city: value.city,
      country: value.country
    };
    this.checkoutService.postOrder(order).subscribe(
      value => console.log(value),
      error => console.error(error)
    );
   }

  ngOnInit() {
  }

}

