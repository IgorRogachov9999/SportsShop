import { Component, OnInit } from '@angular/core';
import { Product } from '../cart/cart.service'
import { ProductService } from './product.service';
import { CategoryService } from '../nav-bar/category.service';
import { ActivatedRoute } from '@angular/router';

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
    private route: ActivatedRoute
    ) {
      var name = this.route.snapshot.params['name'];
      this.updateProductViewModel(name, 1);
  }

  ngOnInit() {
      this.categoryService.events$.forEach(category => this.updateProductViewModel(category, 1));
  }

  updateProductViewModel(category: string, page: number) {
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
