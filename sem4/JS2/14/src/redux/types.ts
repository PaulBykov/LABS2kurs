export interface Todo {
    id: number;
    text: string;
    completed: boolean;
}

export type TodosState = Todo[];

interface AddTodoAction {
    type: 'ADD_TODO';
    id: number;
    text: string;
}

interface ToggleTodoAction {
    type: 'TOGGLE_TODO';
    id: number;
}

export type TodoActionTypes = AddTodoAction | ToggleTodoAction;