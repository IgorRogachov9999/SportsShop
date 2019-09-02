import { Component, OnInit } from '@angular/core';
import { Product } from '../cart/cart.service'
import { ProductService } from './product.service';
import { CategoryService } from '../nav-bar/category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  productViewModel: ProductViewModel = null;

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private router : Router
    ) {
        this.updateProductViewModel(null, 1);
  }

  ngOnInit() {
      this.categoryService.events$.forEach(category => this.updateProductViewModel(category, 1));
  }

  updateProductViewModel(category: string, page: number) {
    console.log(category, page);
    this.productService.getProducts(category, page).subscribe(
      value => this.productViewModel = <ProductViewModel>value,
      error => console.error(error) 
    );
  }
}

interface PagingInfo {
  currentPage: number,
  totalPages: number,
  itemsPerPage: number
}

interface ProductViewModel {
  pagingInfo: PagingInfo,
  products: Product[]
}
