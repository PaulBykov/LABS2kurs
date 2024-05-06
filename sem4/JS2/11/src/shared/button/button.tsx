import React from 'react';

import styles from "./style.module.css"


interface IButtonProps{
    text: string;
    onClick?: () => void;
}

function Button({text, onClick}: IButtonProps){
    return (
        <button className={styles.btn} onClick={onClick}> {text} </button>
    );
}

export default Button;