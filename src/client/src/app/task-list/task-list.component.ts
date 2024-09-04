import { NgClass, NgFor } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ToDoItem, ToDoItemInput } from '../_models/to-do-item';
import { ToDoItemService } from '../_services/to-do-item.service';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ToDoItemQueryParams } from '../_models/to-do-item-query-params';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [NgFor, FormsModule, NgClass],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css'
})
export class TaskListComponent {
  toDoItems: any;
  newItem: ToDoItemInput = { title: '', completed: false};
  queryParams: ToDoItemQueryParams = {
    searchPhraseTitle: '',
    pageSize: 10,
    pageNumber: 1,
    sortBy: 'CreatedAt',
    sortDirection: 'Descending'
  };

  private toastr = inject(ToastrService);
  private toDoItemService = inject(ToDoItemService);


  ngOnInit(): void {
    this.loadItems();
  }

  loadItems() {
    this.toDoItemService.getAllToDoItems(this.queryParams).subscribe({
      next: response => {
       this.toDoItems = response.items;
        console.log(response.items);
        
      },
      error: err  => console.error('Failed to load todo items', err)
    });
  }

  onSearch(searchPhrase: string): void {
    this.queryParams.searchPhraseTitle = searchPhrase;
    this.loadItems();
  }

  addItem() {
    this.toDoItemService.addToDoItem(this.newItem).subscribe({
      next: _ => {
        this.loadItems();  
      },
      error: (err) => console.error('Failed to add item', err)
    });
  }

  deleteItem(id: number) {
    this.toDoItemService.deleteToDoItem(id).subscribe({
      next: () => this.loadItems(),
      error: (err) => console.error('Failed to delete item', err)
    });
  }

  updateItem(item: ToDoItem) {
    this.toDoItemService.updateToDoItem(item.id, item).subscribe({
      next: () => this.loadItems(),
      error: (err) => console.error('Failed to update item', err)
    });
  }

}
