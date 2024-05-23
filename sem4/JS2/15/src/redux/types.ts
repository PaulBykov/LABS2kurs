import {Action} from "redux";

export const SET_CEILS_VALIDITY = 'SET_CEILS_VALIDITY';
export const SET_SELECTED_NUMBER = 'SET_SELECTED_NUMBER';


export interface SetCeilsValidityAction extends Action<typeof SET_CEILS_VALIDITY> {
    payload: boolean[][];
}

export interface SetSelectedNumberAction {
    type: typeof SET_SELECTED_NUMBER;
    payload: number;
}

