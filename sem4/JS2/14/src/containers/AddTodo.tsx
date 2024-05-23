import React, { useRef, FormEvent } from 'react';
import { connect, ConnectedProps } from 'react-redux';
import { addTodo } from '../redux/actions/actions';


type PropsFromRedux = ConnectedProps<typeof connector>;

type AddTodoProps = PropsFromRedux;


const AddTodo: React.FC<AddTodoProps> = ({ dispatch }) => {
    const inputRef = useRef<HTMLInputElement>(null);

    const handleSubmit = (e: FormEvent) => {
        e.preventDefault();
        if (inputRef.current && inputRef.current.value.trim()) {
            // @ts-ignore
            dispatch(addTodo(inputRef.current.value));
            inputRef.current.value = '';
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input ref={inputRef} />
                <button type="submit">Add Todo</button>
            </form>
        </div>
    );
};

// Connect the component
const connector = connect();

export default connector(AddTodo);
