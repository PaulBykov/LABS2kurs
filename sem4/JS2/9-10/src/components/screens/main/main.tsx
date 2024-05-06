import React, {useEffect, useMemo, useState} from 'react';

import styles from "./main.module.css"

import FieldOverview from "../field/fieldOverview/fieldOverview";
import Statistic from "../stats/stats/stats";
import {Field} from "../field/fieldClass/Field";
import {generateArray} from "../../../api/generateArray";
import {Validator} from "../../../helpers/Validator/Validator";
import {activateEvents} from "../../../helpers/binds/setupBinds";

function Main() {
    const [updateState, Update] = useState(0);
    const [selectedNumber, selectNumber] = useState(1);
    const [ceilsValidity, setCeilsValidity] = useState<boolean[][]>(generateArray(9));
    const gameField = useMemo(() => new Field(updateState, Update), []);
    const validator = useMemo(() => new Validator(gameField, ceilsValidity, setCeilsValidity), [gameField, ceilsValidity, setCeilsValidity]);

    useEffect(() => {
        activateEvents(selectNumber, () => gameField.takeHint())
    }, []);

    return (
        <div className={styles.gameContainer}>
            <FieldOverview updateState={updateState} validation={ceilsValidity} fieldClass={gameField} isFullValid={!validator.HasErrors} selectedNumber={selectedNumber} selectNumber={selectNumber} validatorMethod={() => validator.Validate()}/>
            <Statistic hintCount={gameField.getHintCount()} takeHint= {() => gameField.takeHint()} selectedNumber={selectedNumber} selectNumber={selectNumber}/>
        </div>
    );
}

export default Main;