import React, {Component} from 'react';
import {List, AutoSizer, InfiniteLoader} from 'react-virtualized';
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
            hasMore: true
        }
    }

    componentDidMount(){
        this.props.actions.getTitlesIfNeeded();
    }

    fetchMoreData = () => {
        this.props.actions.getMoreTitles(this.props.titles.length + 1, 100);
    }

    renderRow({index, key, style}){
        
            return (
                <div key={key} style={style} className="list-row">
                    <div className="content d-flex justify-content-between">
                        <span className="font-weight-bold">ID: {this.props.titles[index].tconst}</span>
                        <span>{this.props.titles[index].primaryTitle}{' - '}{this.props.titles[index].startYear}{' '}</span>
                        <span><Link to={"/title/get/" + this.props.titles[index].tconst}>View Details</Link></span>
                    </div>
                </div>
            );
        
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
                    /*<div className="list">
                        <AutoSizer>
                            {({height, width}) => (
                                <List 
                                width={width}
                                height={height}
                                rowHeight={60}
                                rowRenderer={this.renderRow}
                                rowCount={this.props.titles.length}
                                overscanRowCount={5}
                            />
                            )}
                        </AutoSizer>
                    </div>*/
                    <div className="list" id="scrollableDiv">
                        <InfiniteScroll dataLength={this.props.titles.length}
                        next={this.fetchMoreData} hasMore={true} loader={<h5>Loading...</h5>} scrollableTarget="scrollableDiv">
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
                    /*<div className="list">
                        <InfiniteLoader
                        isRowLoaded={this.isRowLoaded}
                        loadMoreRows={this.loadMoreRows}
                        rowCount={list.size}>
                            {({onRowsRendered, registerChild}) => (
                                <AutoSizer>
                                    {({height, width}) => (
                                        <List  
                                            ref={registerChild}
                                            height={height}
                                            onRowsRendered={onRowsRendered}
                                            rowCount={list.size}
                                            rowHeight={60}
                                            rowRenderer={this.renderRow}
                                            width={width}/>
                                    )}
                                </AutoSizer>
                            )}
                        </InfiniteLoader>
                    </div>*/
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