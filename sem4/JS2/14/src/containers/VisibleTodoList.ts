import { connect } from 'react-redux';
import { toggleTodo } from '../redux/actions/actions';
import TodoList from '../components/TodoList';
import { VisibilityFilters } from '../redux/actions/actions';
import { RootState } from '../redux/reducers/rootReducer';

interface Todo {
    id: number;
    text: string;
    completed: boolean;
}

type Filter = keyof typeof VisibilityFilters;


const getVisibleTodos = (todos: Todo[], filter: Filter): Todo[] => {
    switch (filter) {
        case VisibilityFilters.SHOW_ALL:
            return todos;
        case VisibilityFilters.SHOW_COMPLETED:
            return todos.filter((t) => t.completed);
        case VisibilityFilters.SHOW_ACTIVE:
            return todos.filter((t) => !t.completed);
        default:
            throw new Error('Unknown filter: ' + filter);
    }
};


const mapStateToProps = (state: RootState) => ({
    todos: getVisibleTodos(state.todo, state.visibilityFilter),
});


const mapDispatchToProps = (dispatch: any) => ({
    toggleTodo: (id: number) => dispatch(toggleTodo(id)),
});


const connector = connect(mapStateToProps, mapDispatchToProps);

export default connector(TodoList);
