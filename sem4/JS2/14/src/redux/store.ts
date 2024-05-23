// store.ts
import rootReducer from './reducers/rootReducer';
import {createStore} from "redux";

const store = createStore(rootReducer);

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;