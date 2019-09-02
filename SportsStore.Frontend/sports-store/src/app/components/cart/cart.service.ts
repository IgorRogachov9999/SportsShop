import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from 'src/app/config.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private controller = ConfigService.api + 'Cart/';

  constructor(private http: HttpClient) { }

  getCart() {
    var cartJson = sessionStorage.getItem("cart");
    if (cartJson == null) {
      return new Cart();
    }
    return Cart.fromJson(JSON.parse(cartJson));
  }
}

export class Product {
  productID: number;
  name: string;
  description: string;
  price: number;
  productCategory: string;

  constructor() {

  }

  public static fromJson(json) {
    var product = new Product();
    product.productID = parseInt(json.productID);
    product.name = json.name;
    product.description = json.description;
    product.price = parseInt(json.price);
    product.productCategory = json.productCategory;
    return product;
  }
}

export class Line {
  public cartLineID: number = 0;
  public product: Product;
  public quantity: number;

  constructor(id: number, product: Product) {
    this.cartLineID = id;
    this.product = product;
    this.quantity = 1;
  }

  public contains(id: number) {
    return this.product.productID == id;
  }

  public static fromJson(json) {
    var line = new Line(parseInt(json.cartLineID), 
                        Product.fromJson(json.product));
    line.quantity = parseInt(json.quantity);
    return line;
  }

}

export class Cart {
  public id: number = 0;
  public lines: Line[] = [];

  constructor() {
    
  }

  public static fromJson(json) {
    var cart = new Cart();
    for(var i = 0; i < json.lines.length; i++) {
      cart.lines.push(Line.fromJson(json.lines[i]));
    }
    return cart;
  }

  public save() {
    sessionStorage.setItem("cart", JSON.stringify(this));
  }

  public remove(product: Product) {
    var lineId = this.contains(product.productID);
    if (lineId != -1) {
      this.lines[lineId].quantity -= 1;

      if (this.lines[lineId].quantity == 0) {
        for (;lineId < this.lines.length - 1; lineId++) {
          this.lines[lineId] = this.lines[lineId + 1];
        }
        this.lines.pop();
      }

      this.save();
    }
  }

  public add(product: Product) {
    var lineId = this.contains(product.productID);
    if (lineId == -1) {
      this.lines.push(new Line(this.lines.length + 1, product));
    } else {
      this.lines[lineId].quantity += 1;
    }
    this.save();
  }

  public contains(productID: number) {
    for (var i = 0; i < this.lines.length; i++) {
      if (this.lines[i].contains(productID)) {
        return i;
      }
    }
    return -1;
  }
}
