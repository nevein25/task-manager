export interface ToDoItemInput {
    completed: boolean;
    title: string;
}

export interface ToDoItem {
    id: number;
    title: string;
    createdAt: Date;
    completed: boolean;
}