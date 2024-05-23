import {SET_CEILS_VALIDITY, SET_SELECTED_NUMBER, SetCeilsValidityAction, SetSelectedNumberAction} from "./types";

export const setCeilsValidity = (validity: boolean[][]): SetCeilsValidityAction => ({
    type: SET_CEILS_VALIDITY,
    payload: validity,
});


export const setSelectedNumber = (newValue: number): SetSelectedNumberAction => ({
    type: SET_SELECTED_NUMBER,
    payload: newValue,
});


