import React from 'react';
import styles from "./Display.module.css"

interface IDisplayProps {
    value: React.ComponentState;
}
function Display(props: IDisplayProps) {
    return (
        <div className={styles.display}>
            {props.value}
        </div>
    );
}

export default Display;