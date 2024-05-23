import {combineReducers} from "redux";
import todo from './todo';
import visibilityFilter from "./visibilityFilters";

const rootReducer = combineReducers({
    todo,
    visibilityFilter
});

export type RootState = ReturnType<typeof rootReducer>;
export default rootReducer;