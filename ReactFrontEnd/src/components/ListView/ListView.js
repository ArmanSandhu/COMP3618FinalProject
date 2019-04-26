import React, {Component} from 'react';
import {connect} from 'react-redux';
import {Link} from 'react-router-dom';
import './ListView.css';
import * as TitleActions from '../../_actions/TitleActions';
import { bindActionCreators } from 'redux';
import InfiniteScroll from 'react-infinite-scroll-component';

class ListView extends Component {

    constructor(props){
        super(props);
        this.state ={
            hasMore: true,
            calculatedHeight: 0
        }
    }

    componentDidMount(){
        if(this.props.titles.length == 0){
            this.props.actions.getTitlesIfNeeded();
        }
    }

    fetchMoreData = () => {
        this.props.actions.getMoreTitles(this.props.titles.length + 1, 100);
    }

    render() {
        if(this.props.isFetching){
            return ( 
            <div className="cm-spinner-container"><div className="cm-spinner"></div></div>
            );
        } else {
            if(this.props.error) {
                return (
                    <div>Error: {this.props.error}</div>
                );
            } else {
                return (
                    <div className="list" id="scrollableDiv">
                        <InfiniteScroll dataLength={this.props.titles.length} children={this.props.titles}
                        next={this.fetchMoreData} hasMore={true} loader={<h5>Loading...</h5>} scrollableTarget="scrollableDiv" initialScrollY={this.props.calculatedHeight}>
                            {this.props.titles.map((i, index) => (
                                <div key={index} className="list-row">
                                <div className="content d-flex justify-content-between">
                                    <span className="font-weight-bold">ID: {this.props.titles[index].tconst}</span>
                                    <span>{this.props.titles[index].primaryTitle}{' - '}{this.props.titles[index].startYear}{' '}</span>
                                    <span><Link to={"/title/get/" + this.props.titles[index].tconst}>View Details</Link></span>
                                </div>
                            </div>
                            ))}
                        </InfiniteScroll>
                    </div>
                );
            }
        }
    }
}

function mapStateToProps(state){
    return {
        titles: state.titles,
        isFetching: state.isFetching,
        error: state.error
    };
}

function mapDispatchToProps(dispatch){
    return {
        actions: bindActionCreators(TitleActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(ListView);