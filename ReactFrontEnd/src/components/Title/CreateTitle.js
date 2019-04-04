import React, {Component} from 'react';
import {Form, FormGroup, FormControl, FormLabel, Button} from 'react-bootstrap';
import TitleForm from '../Form/TitleForm';
import './CreateTitle.css';
import * as TitleActions from '../../_actions/TitleActions';
import { bindActionCreators } from 'redux';
import {connect} from 'react-redux';

class CreateTitle extends Component {

    constructor(props){
        super(props);
        this.state = {
            tconst: '',
            titleType: '',
            primaryTitle: '',
            originalTitle: '',
            isAdult: false,
            startYear: 0,
            endYear: null,
            runtimeMinutes: null,
            genres: ''
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    handleSubmit(ev){
        ev.preventDefault();
        //console.log("Create");
        //console.log(this.state);
        this.props.actions.postTitle(this.state);
        this.props.history.push('/');
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
        this.setState({[name]: value}); 
    }

    render() {
        return (
            <Form onSubmit={this.handleSubmit}>
                <FormGroup controlId="tconst">
                    <FormLabel>ID:</FormLabel>
                    <FormControl type="text" name="tconst" required onChange={this.handleInputChange}/>
                </FormGroup>
                <TitleForm title={this.state} handleInputChange={this.handleInputChange}/>
                <Button variant="primary" type="submit">Create Title</Button>
            </Form>
        );
    }
}

function mapStateToProps(state){
    return {
        title: state.title,
        error: state.error,
        isFetching: state.isFetching
    };
}

function mapDispatchToProps(dispatch){
    return {
        actions: bindActionCreators(TitleActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(CreateTitle);