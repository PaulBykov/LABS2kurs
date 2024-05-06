import styles from "./Counter.module.css"
import {useState} from "react";
import Display from "../../ui/Display/Display";
import Button from "../../ui/Button/Button";

export function Counter(){
    const [CounterState, setCounterState] = useState(0);

    return (
        <div className={styles.counter}>
            <Display value={CounterState}/>
            <div className={styles.btn_container}>
                <Button title="++" handler={() => {setCounterState(CounterState + 1);}} disable={CounterState >= 5}/>
                <Button title="reset" handler={() => {setCounterState(0);}} disable={CounterState===0}/>
            </div>
        </div>
    );
}