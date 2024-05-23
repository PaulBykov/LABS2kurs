import {Reducer} from 'redux';
import {generateArray} from "../../api/generateArray";
import {SET_CEILS_VALIDITY, SetCeilsValidityAction} from "../types";


export interface CeilsValidityState {
    ceilsValidity: boolean[][];
}


const ValidityInitialState: CeilsValidityState = {
    ceilsValidity: generateArray(9),
};


const ceilsValidityReducer: Reducer<CeilsValidityState, SetCeilsValidityAction> = (state:CeilsValidityState = ValidityInitialState, action) =>
    {
        switch (action.type) {
            case SET_CEILS_VALIDITY:
                return {
                    ...state,
                    ceilsValidity: state.ceilsValidity = action.payload
                };
            default:
                return state;
        }
    };


export default ceilsValidityReducer;
