import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ToDoItem, ToDoItemInput } from '../_models/to-do-item';

@Injectable({
  providedIn: 'root'
})
export class ToDoItemService {

  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;


  addToDoItem(item: ToDoItemInput) {
    return this.http.post<number>(`${this.baseUrl}ToDoItems`, item);
  }

  getAllToDoItems(queryParams?: any) {
    return this.http.get<ToDoItem[]>(`${this.baseUrl}/search`, { params: queryParams });
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
