import { connect, ConnectedProps } from 'react-redux';
import { setVisibilityFilter } from '../redux/actions/actions';
import Link from '../components/Link';
import { RootState } from '../redux/reducers/rootReducer';
import { VisibilityFilters } from '../redux/actions/actions';

interface OwnProps {
    filter: VisibilityFilters;
}

const mapStateToProps = (state: RootState, ownProps: OwnProps) => ({
    active: ownProps.filter === state.visibilityFilter,
});

const mapDispatchToProps = (dispatch: any, ownProps: OwnProps) => ({
    onClick: () => dispatch(setVisibilityFilter(ownProps.filter)),
});

const connector = connect(mapStateToProps, mapDispatchToProps);

type PropsFromRedux = ConnectedProps<typeof connector>;

export default connector(Link);
