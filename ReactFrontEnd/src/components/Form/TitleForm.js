import React, {Component} from 'react';
import { FormGroup, FormLabel, FormText, FormControl, FormCheck } from 'react-bootstrap';

export default class TitleForm extends Component {
    constructor(props){
        super(props);
    }

    render() {
        return (
            <div>
                <FormGroup controlId="titleType">
                    <FormLabel>Type:</FormLabel>
                    <FormControl type="text" name="titleType" defaultValue={this.props.title.titleType} onChange={this.props.handleInputChange}/>
                </FormGroup>
                <FormGroup controlId="primaryTitle">
                    <FormLabel>Primary Title:</FormLabel>
                    <FormControl type="text" name="primaryTitle" defaultValue={this.props.title.primaryTitle}
                    onChange={this.props.handleInputChange}/>
                    <FormText>Translated Title</FormText>
                </FormGroup>
                <FormGroup controlId="originalTitle">
                    <FormLabel>Original Title:</FormLabel>
                    <FormControl type="text" name="originalTitle" defaultValue={this.props.title.originalTitle}
                    onChange={this.props.handleInputChange}/>
                </FormGroup>
                <FormGroup controlId="isAdult">
                    <FormLabel>Adult Content:</FormLabel>&nbsp;
                    <FormCheck inline="true" name="isAdult" defaultChecked={this.props.title.isAdult}
                    onChange={this.props.handleInputChange}/>
                </FormGroup>
                <FormGroup controlId="startYear">
                    <FormLabel>Start Year:</FormLabel>
                    <FormControl type="text" name="startYear" defaultValue={this.props.title.startYear}
                    onChange={this.props.handleInputChange}/>
                </FormGroup>
                <FormGroup controlId="endYear">
                    <FormLabel>End Year:</FormLabel>
                    <FormControl type="text" name="endYear" defaultValue={this.props.title.endYear}
                    onChange={this.props.handleInputChange}/>
                </FormGroup>
                <FormGroup controlId="runtimeMinutes">
                    <FormLabel>Runtime:</FormLabel>
                    <FormControl type="text" name="runtimeMinutes" defaultValue={this.props.title.runtimeMinutes}
                    onChange={this.props.handleInputChange}/>
                    <FormText>In Minutes</FormText>
                </FormGroup>
                <FormGroup controlId="genres">
                    <FormLabel>Genres:</FormLabel>
                    <FormControl type="text" name="genres" defaultValue={this.props.title.genres}
                    onChange={this.props.handleInputChange}/>
                    <FormText>Enter up to 3 genres separated by a comma</FormText>
                </FormGroup>
            </div>
        );
    }
}