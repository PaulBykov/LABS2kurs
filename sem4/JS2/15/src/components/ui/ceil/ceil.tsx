import React, {useState} from 'react';
import styles from "./ceil.module.css"

interface ICeilProps{
    isValid: boolean,
    getCurrentValue: () => number;
    onClick: () => void;
}
function Ceil({isValid, getCurrentValue = () => -1, onClick} : ICeilProps) {
    const [currentCeilState, setCurrentCeilState] = useState(getCurrentValue);

    return (
        <button onClick={() => {onClick(); setCurrentCeilState(getCurrentValue);}}
                className={styles.btn}
                style={!isValid ? {backgroundColor: "red"} : undefined}
        >
            {getCurrentValue() === -1 ? '': getCurrentValue()}
        </button>
    );
}

export default Ceil;