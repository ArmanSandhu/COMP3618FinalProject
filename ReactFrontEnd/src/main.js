import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter, Route } from 'react-router-dom';
import configureStore from './_store/configureStore';


import HomePage from './components/HomePage';
import Navigation from './components/Navigation/Navigation';
import CreateTitle from './components/Title/CreateTitle';
import TitleView from './components/Title/TitleView';
import './style.css';

const store = configureStore();

ReactDOM.render(<Provider store={store}>
                    <BrowserRouter history={history}>
                        <div id="app-container">
                            <Navigation/>
                            <Route exact path="/" component={HomePage}/>
                            <Route exact path="/title/create" component={CreateTitle}/>
                            <Route exact path="/title/get/:id" component={TitleView}/>
                        </div>
                    </BrowserRouter>
                </Provider>, document.getElementById('root'));