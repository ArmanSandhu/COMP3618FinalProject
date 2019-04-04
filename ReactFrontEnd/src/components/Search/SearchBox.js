import React, {Component} from 'react';
import {Container, Form, FormControl, Button, FormGroup, Row, Col} from 'react-bootstrap';
import './SearchBox.css';
import * as TitleActions from '../../_actions/TitleActions';
import { bindActionCreators } from 'redux';
import {connect} from 'react-redux';
import debounce from 'lodash/debounce';

class SearchBox extends Component{
    constructor(props){
        super(props);
        this.state = {};
        this.handleSubmit = this.handleSubmit.bind(this);
        this.onChangeDebounced = debounce(this.onChangeDebounced, 2000);
    }

    handleSubmit(ev){
        ev.preventDefault();
        //console.log("Search")
        //console.log(this.props);
        this.props.actions.searchTitles(this.state.tconst);
    }

    handleInputChange = (event) =>  {
        const target = event.target;
        const value = target.value;
        const name = target.name;
        this.setState({[name]: value});
        this.onChangeDebounced(value);
    }

    onChangeDebounced = (value) => {
        this.props.actions.searchTitles(value);
    }

    render(){
        return (
            <Form inline className="search-bar" onSubmit={this.handleSubmit}>
                <Container>
                    <FormGroup as ={Row}>
                        <Form.Label column sm={1}>
                            Search: 
                        </Form.Label>
                        <Col sm={9}>
                            <FormControl type="text" placeholder="ID" className="search-input" name="tconst" onChange={this.handleInputChange}/>
                        </Col>
                        <Col sm={2}>
                            <Button type="submit" variant="outline-primary">Search</Button>
                        </Col>
                    </FormGroup>
            </Container></Form>
        );
    }
}

function mapStateToProps(state){
    return {
        titles: state.titles,
        id: state.id,
        error: state.error,
        isFetching: state.isFetching
    };
}

function mapDispatchToProps(dispatch){
    return {
        actions: bindActionCreators(TitleActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(SearchBox);