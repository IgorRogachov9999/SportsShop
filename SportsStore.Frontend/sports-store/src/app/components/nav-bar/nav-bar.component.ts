import { Component, OnInit } from '@angular/core';
import { CategoryService } from './category.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  categories: Category[] = [];

  constructor(private categoryService : CategoryService) {
    this.categoryService.getCategories()
      .subscribe(value => this.categories = <Category[]>value);
  }

  selectCategory(category: string) {
    this.categoryService.changeCategory(category);
  }

  ngOnInit() {
    
  }

}

export interface Category {
  categoryID: number,
  name: string
}