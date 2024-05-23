// Action types
const ADD_TODO = 'ADD_TODO' as const;
const SET_VISIBILITY_FILTER = 'SET_VISIBILITY_FILTER' as const;
const TOGGLE_TODO = 'TOGGLE_TODO' as const;

// Visibility Filters Enum
export enum VisibilityFilters {
    SHOW_ALL = 'SHOW_ALL',
    SHOW_COMPLETED = 'SHOW_COMPLETED',
    SHOW_ACTIVE = 'SHOW_ACTIVE',
}

// Action interfaces
interface AddTodoAction {
    type: typeof ADD_TODO;
    id: number;
    text: string;
}

interface SetVisibilityFilterAction {
    type: typeof SET_VISIBILITY_FILTER;
    filter: VisibilityFilters;
}

interface ToggleTodoAction {
    type: typeof TOGGLE_TODO;
    id: number;
}

// Union type for actions
type TodoActionTypes = AddTodoAction | SetVisibilityFilterAction | ToggleTodoAction;

// Action creators
let nextTodoId = 0;

export const addTodo = (text: string): AddTodoAction => ({
    type: ADD_TODO,
    id: nextTodoId++,
    text,
});

export const setVisibilityFilter = (filter: VisibilityFilters): SetVisibilityFilterAction => ({
    type: SET_VISIBILITY_FILTER,
    filter,
});

export const toggleTodo = (id: number): ToggleTodoAction => ({
    type: TOGGLE_TODO,
    id,
});

// Example of usage in reducer (not provided in original code, but added for completeness)
type TodoState = {
    id: number;
    text: string;
    completed: boolean;
}[];

const todosReducer = (state: TodoState = [], action: TodoActionTypes): TodoState => {
    switch (action.type) {
        case ADD_TODO:
            return [
                ...state,
                {
                    id: action.id,
                    text: action.text,
                    completed: false,
                },
            ];
        case TOGGLE_TODO:
            return state.map(todo =>
                todo.id === action.id ? { ...todo, completed: !todo.completed } : todo
            );
        default:
            return state;
    }
};
