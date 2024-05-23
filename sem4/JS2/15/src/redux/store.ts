import {combineReducers, createStore} from 'redux';
import validityReducer from './reducers/ceilsValidityReducer';
import selectedNumberReducer from './reducers/selectedNumberReducer'

const rootReducer = combineReducers({
    ceilsValidity: validityReducer,
    selectedNumber: selectedNumberReducer,
})


const store = createStore(rootReducer);


export type RootState = ReturnType<typeof rootReducer>;
export default store;