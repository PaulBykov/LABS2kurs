import React from 'react';
import PropTypes from 'prop-types';


interface ITodoProps {
    onClick: () => void;
    completed: boolean;
    text: string;
}

function Todo ({ onClick, completed, text } :ITodoProps) {
    return (
        <li
            onClick={onClick}
            style={{
                textDecoration: completed ? 'line-through' : 'none',
                color: completed ? 'green' : 'black',
            }}
        >
            {text}
        </li>
    );
}


Todo.propTypes = {
    onClick: PropTypes.func.isRequired,
    completed: PropTypes.bool.isRequired,
    text: PropTypes.string.isRequired,
};

export default Todo;