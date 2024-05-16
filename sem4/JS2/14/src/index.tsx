import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

let nextTodoId = 0;
export const addTodo = (text: string) => ({
    type: 'ADD_TODO',
    id: nextTodoId++,
    text,
});

export const setVisibilityFilter = (filter: string) => ({
    type: 'SET_VISIBILITY_FILTER',
    filter,
});

export const toggleTodo = (id: number) => ({
    type: 'TOGGLE_TODO',
    id,
});

export const VisibilityFilters = {
    SHOW_ALL: 'SHOW_ALL',
    SHOW_COMPLETED: 'SHOW_COMPLETED',
    SHOW_ACTIVE: 'SHOW_ACTIVE',
};