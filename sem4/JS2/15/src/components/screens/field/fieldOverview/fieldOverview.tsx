import React from 'react';
import Ceil from "../../../ui/ceil/ceil";
import styles from "./fieldOverview.module.css"
import {Field} from "../fieldClass/Field";

interface IField{
    validation: boolean[][],
    fieldClass: Field,
    isFullValid: boolean,
    selectedNumber: number,
    selectNumber: (a:number) => void;
    validatorMethod: () => void;
    updateState: number;
}
function FieldOverview({validatorMethod,isFullValid, validation, fieldClass, selectedNumber, selectNumber, updateState}: IField) {
    const fieldInfo = fieldClass;
    const ceilList : JSX.Element[] = [];
    const n = fieldInfo.Length();

    for(let i = 0; i < n; i++){
        for(let j = 0; j < n; j++){
            ceilList.push(
                <Ceil key={(i+1) * 10 + (j+1)}
                      isValid={validation[i][j]}
                      getCurrentValue={() => fieldInfo.GetCeil(i, j)}
                      onClick={() => {
                          fieldInfo.SetCeil(i, j, selectedNumber);
                          validatorMethod();
                      }}
                />
            );
        }
    }

    return (
        <div className={styles.field}
             style={isFullValid ? {boxShadow: "0 0 10px 10px yellow"} : undefined}
        >
            {ceilList.map((ceil) => ceil)}
        </div>
    );
}

export default FieldOverview;