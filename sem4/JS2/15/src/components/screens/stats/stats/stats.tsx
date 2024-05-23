import React from 'react';
import Selector from "../../../ui/selector/selector";
import styles from "./stats.module.css"
import Button from "../../../ui/button/button";
import {newGame} from "../../../../api/newGame";
import {Field} from "../../field/fieldClass/Field";

interface IStatsProps{
    hintCount: number,
    takeHint: () => void,
    selectedNumber: number,
    selectNumber: (a:number) => void;
}

function Statistic({hintCount, takeHint, selectedNumber, selectNumber} : IStatsProps) {
    return (
        <div className={styles.stats}>
            <Selector min={1} max={10} selectNumber={selectNumber} selectedNumber={selectedNumber}/>
            <div className={styles.content}>
                {Field._maxHints - hintCount}
                <Button title="new game" handler={() => newGame()}/>
                <Button title="hint" handler={() => takeHint()}/>
            </div>
        </div>
    );
}

export default Statistic;