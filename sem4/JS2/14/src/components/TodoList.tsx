import React from 'react';
import Todo from './Todo';

// Define the Todo type
interface TodoType {
    id: number;
    completed: boolean;
    text: string;
}

// Define the props for the TodoList component
interface TodoListProps {
    todos: TodoType[];
    toggleTodo: (id: number) => void;
}

const TodoList: React.FC<TodoListProps> = ({ todos, toggleTodo }) => (
    <ul>
        {todos.map((todo) => (
            <Todo
                key={todo.id}
                {...todo}
                onClick={() => toggleTodo(todo.id)}
            />
        ))}
    </ul>
);

export default TodoList;
