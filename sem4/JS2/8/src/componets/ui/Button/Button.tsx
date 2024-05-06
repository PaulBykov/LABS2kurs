import React from 'react';
import styles from "./Button.module.css"
interface IButtonProps{
    title: string,
    handler: () => void,
    disable?: boolean
}
function Button(props: IButtonProps) {
    return (
        <button onClick={props.handler} className={styles.btn} disabled={props.disable}>
            {props.title}
        </button>
    );
}

export default Button;