import { VisibilityFilters } from '../actions/actions';


const SET_VISIBILITY_FILTER = 'SET_VISIBILITY_FILTER' as const;


interface SetVisibilityFilterAction {
    type: typeof SET_VISIBILITY_FILTER;
    filter: VisibilityFilters;
}


type VisibilityFilterActionTypes = SetVisibilityFilterAction;


type VisibilityFilterState = VisibilityFilters;


const initialState: VisibilityFilterState = VisibilityFilters.SHOW_ALL;



const visibilityFilter = (
    state: VisibilityFilterState = initialState,
    action: VisibilityFilterActionTypes
): VisibilityFilterState => {
    switch (action.type) {
        case SET_VISIBILITY_FILTER:
            return action.filter;
        default:
            return state;
    }
};

export default visibilityFilter;
