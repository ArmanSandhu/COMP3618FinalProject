import React, {Component} from 'react';
import {Form, FormGroup, FormControl, FormLabel, Button, ButtonGroup, ButtonToolbar} from 'react-bootstrap';
import TitleForm from '../Form/TitleForm';
import './TitleView.css';
import * as TitleActions from '../../_actions/TitleActions';
import { bindActionCreators } from 'redux';
import {connect} from 'react-redux';

class TitleView extends Component {
    constructor(props){
        super(props);
        this.state = {
        };
        this.edit = this.edit.bind(this);
        this.delete = this.delete.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    componentDidMount(){
        this.props.actions.getTitle(this.props.match.params.id)
        .then(response => {
            //console.log(this.props.title);
            this.setState({
                tconst: this.props.title.tconst,
                titleType: this.props.title.titleType,
                primaryTitle: this.props.title.primaryTitle,
                originalTitle: this.props.title.originalTitle,
                isAdult: this.props.title.isAdult,
                startYear: this.props.title.startYear,
                endYear: this.props.title.endYear,
                runtimeMinutes: this.props.title.runtimeMinutes,
                genres: this.props.title.genres
            });
            //console.log(this.state)
        }).catch(error => {
            console.log(error);
        });
    }

    edit(ev){
        ev.preventDefault();
        //console.log("Edit");
        //console.log(this.state.tconst);
        //console.log(this.state);
        this.props.actions.putTitle(this.state);
        this.props.history.push('/');
    }

    delete(ev){
        ev.preventDefault();
        //console.log("Delete");
        //console.log(this.state);
        this.props.actions.deleteTitle(this.state.tconst);
        this.props.history.push('/');
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
        this.setState({[name]: value}); 
    }

    render() {
        if(this.props.isFetching){
            return ( 
            <div className="cm-spinner-container"><div className="cm-spinner"></div></div>
            );
        } else {
        return (
            <Form>
                <FormGroup controlId="tconst">
                    <FormLabel>ID:</FormLabel>
                    <FormControl type="text" name="tconst" readOnly value={this.state.tconst}/>
                </FormGroup>
                <TitleForm title={this.state} handleInputChange={this.handleInputChange}/>
                <ButtonToolbar>
                    <ButtonGroup className="mr-3">
                        <Button variant="primary" type="button" onClick={this.edit} value="Edit">Edit Title</Button>
                    </ButtonGroup>
                    <ButtonGroup className="mr-3">
                        <Button variant="danger" type="button" onClick={this.delete} value="Delete">Delete Title</Button>
                    </ButtonGroup>
                </ButtonToolbar>
            </Form>
        );
        }
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

export default connect(mapStateToProps, mapDispatchToProps)(TitleView);