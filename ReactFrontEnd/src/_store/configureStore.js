import {createStore, applyMiddleware} from 'redux';
import TitleReducers from '../_reducers/TitleReducers';
import thunk from 'redux-thunk';

export default function configureStore(){
    return createStore(TitleReducers, applyMiddleware(thunk));
}