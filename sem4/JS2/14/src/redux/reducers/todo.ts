// todos.ts
import { TodoActionTypes, TodosState } from '../types';

const initialState: TodosState = [];

const todos = (state = initialState, action: TodoActionTypes): TodosState => {
    switch (action.type) {
        case 'ADD_TODO':
            return [
                ...state,
                {
                    id: action.id,
                    text: action.text,
                    completed: false,
                },
            ];
        case 'TOGGLE_TODO':
            return state.map((todo) =>
                todo.id === action.id
                    ? {...todo, completed: !todo.completed}
                    : todo
            );
        default:
            return state;
    }
};

export default todos;