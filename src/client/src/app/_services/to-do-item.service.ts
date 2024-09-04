import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ToDoItem, ToDoItemInput } from '../_models/to-do-item';
import { ToDoItemQueryParams } from '../_models/to-do-item-query-params';

@Injectable({
  providedIn: 'root'
})
export class ToDoItemService {

  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;


  addToDoItem(item: ToDoItemInput) {
    return this.http.post<number>(`${this.baseUrl}ToDoItems`, item);
  }

  getAllToDoItems(queryParams?: ToDoItemQueryParams) {
    let params = new HttpParams();

    if (queryParams) {
      for (const key of Object.keys(queryParams)) {
        const value = queryParams[key as keyof ToDoItemQueryParams];
        if (value !== undefined && value !== null) {
          params = params.set(key, value.toString()); 
        }
      }
    }

    return this.http.get<any>(`${this.baseUrl}ToDoItems/search`, { params });
  }

  getToDoItemById(id: number) {
    return this.http.get<ToDoItem>(`${this.baseUrl}ToDoItems/${id}`);
  }

  deleteToDoItem(id: number) {
    return this.http.delete(`${this.baseUrl}ToDoItems/${id}`);
  }

  updateToDoItem(id: number, todoItem: ToDoItemInput) {
    return this.http.patch(`${this.baseUrl}ToDoItems/${id}`, todoItem);
  }

}
