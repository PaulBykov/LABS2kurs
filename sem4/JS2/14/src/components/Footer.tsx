import React from 'react';
import { VisibilityFilters } from '../redux/actions/actions';
import FilterLink from "../containers/FilterLink"

const Footer = () => (
    <div>
        <span>Show: </span>
        <FilterLink filter={VisibilityFilters.SHOW_ALL}>
            All
        </FilterLink>
        <FilterLink filter={VisibilityFilters.SHOW_ACTIVE}>
            Active
        </FilterLink>
        <FilterLink filter={VisibilityFilters.SHOW_COMPLETED}>
            Completed
        </FilterLink>
    </div>
);

export default Footer;