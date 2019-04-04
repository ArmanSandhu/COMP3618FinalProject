import React, {Component, Fragment} from 'react';
import SearchBox from './Search/SearchBox';
import ListView from './ListView/ListView';

export default class HomePage extends Component {
    render() {
        return (
            <Fragment>
                <SearchBox/>
                <ListView/>
            </Fragment>
        );
    }
}