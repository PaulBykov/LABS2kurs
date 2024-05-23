import React, {useEffect, useMemo, useState} from 'react';

import styles from "./main.module.css"

import FieldOverview from "../field/fieldOverview/fieldOverview";
import Statistic from "../stats/stats/stats";
import {Field} from "../field/fieldClass/Field";
import {Validator} from "../../../helpers/Validator/Validator";
import {activateEvents} from "../../../helpers/binds/setupBinds";
import {useDispatch, useSelector} from "react-redux";

import {Dispatch} from "redux";
import {RootState} from "../../../redux/store";
import {setCeilsValidity, setSelectedNumber} from "../../../redux/actions";

function Main() {
    const [updateState, Update] = useState(0);

    const dispatch :Dispatch<any> = useDispatch();
    const ceilsValidity: boolean[][] = useSelector((state: RootState) => state.ceilsValidity.ceilsValidity);

    const selectedNumber: number = useSelector((state: RootState) => state.selectedNumber.selectedNumber);;
    const selectNumber = (newValue :number) => dispatch(setSelectedNumber(newValue))


    const gameField = useMemo(() => new Field(updateState, Update), []);
    const validator = useMemo(() => new Validator(
        gameField,
        ceilsValidity,
        (validity: boolean[][]) => dispatch(setCeilsValidity(validity)))
        , [gameField, ceilsValidity, dispatch]
    );

    useEffect(() => {
        activateEvents(selectNumber, () => gameField.takeHint())
    }, []);

    return (
        <div className={styles.gameContainer}>
            <FieldOverview
                updateState={updateState}
                validation={ceilsValidity}
                fieldClass={gameField}
                isFullValid={!validator.HasErrors}
                selectedNumber={selectedNumber}
                selectNumber={selectNumber}
                validatorMethod={() => validator.Validate()}
            />
            <Statistic
                hintCount={gameField.getHintCount()}
                takeHint={() => gameField.takeHint()}
                selectedNumber={selectedNumber}
                selectNumber={selectNumber}
            />
        </div>
    );
}

export default Main;