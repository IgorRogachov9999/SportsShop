import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { ConfigService } from 'src/app/config.service';
import { Category } from './nav-bar.component';
import { Subject } from 'rxjs/internal/Subject';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  
  private controller = ConfigService.api + 'Category/';
  private _subject = new Subject<any>();  

  constructor(private http: HttpClient) { }

  public getCategories(){
    return this.http.get(this.controller);
  }

  public changeCategory(category: string) {
    this._subject.next(category);
  }

  get events$ () {
    return this._subject.asObservable();
  }
}
