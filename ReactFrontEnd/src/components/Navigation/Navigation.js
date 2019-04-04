import React, {Component} from 'react';
import {Navbar, Nav, NavItem, Container} from 'react-bootstrap';
import {Link} from 'react-router-dom'
import './Navigation.css';

export default class Navigation extends Component {
    render() {
        return (
            <Navbar expand="lg">
                <Container>
                    <Navbar.Brand>COMP 3618</Navbar.Brand>
                    <Nav className="justify-content-end">
                        <NavItem ><Link to="/">Home</Link></NavItem>
                        <NavItem ><Link to="/title/create">Add Title</Link></NavItem>
                    </Nav>
                </Container>
            </Navbar>
        );
    }
}