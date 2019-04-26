
import * as types from '../_actions/TitleActionsTypes';

const initialState = {
    titles: [],
    isFetching: false,
    error: null,
    title: {},
    id: null,
}

const titleReducer = (state = initialState, action) => {
    switch(action.type) {
        case types.GET_TITLES_REQUEST: {
            state = Object.assign({}, state, {titles: [], isFetching: true});
            break;
        }
        case types.GET_TITLES_SUCCESS: {
            state = Object.assign({}, state, {titles: action.titles, isFetching: false});
            break;
        }
        case types.GET_TITLES_ERROR: {
            state = Object.assign({}, {titles: [], isFetching: false, error: action.error});
            break;
        }
        case types.GET_TITLE_REQUEST: {
            state = Object.assign({}, state, {title: {}, isFetching: true});
            break;
        }
        case types.GET_TITLE_SUCCESS: {
            state = Object.assign({}, state, {title: action.title, isFetching: false});
            break;
        }
        case types.GET_TITLE_ERROR: {
            state = Object.assign({}, {error: action.error, isFetching: false});
            break;
        }
        case types.PUT_TITLE_REQUEST: {
            state = Object.assign({}, state, {title: {}});
            break;
        }
        case types.PUT_TITLE_SUCCESS: {
            state = Object.assign({}, state, {title: action.title});
            break;
        }
        case types.PUT_TITLE_ERROR: {
            state = Object.assign({}, {error: action.error});
            break;
        }
        case types.DELETE_TITLE_REQUEST: {
            state = Object.assign({}, state, {id: null});
            break;
        }
        case types.DELETE_TITLE_SUCCESS: {
            state = Object.assign({}, state, {id: action.id});
            break;
        }
        case types.DELETE_TITLE_ERROR: {
            state = Object.assign({}, {error: action.error});
            break;
        }
        case types.POST_TITLE_REQUEST: {
            state = Object.assign({}, state, {title: {}});
            break;
        }
        case types.POST_TITLE_SUCCESS: {
            state = Object.assign({}, state, {title: action.title});
            break;
        }
        case types.POST_TITLE_ERROR: {
            state = Object.assign({}, {error: action.error});
            break;
        }
        case types.GET_MORE_TITLE_REQUEST: {
            state = Object.assign({}, state, {});
            break;
        }
        case types.GET_MORE_TITLE_SUCCESS: {
            const updateTitles = state.titles.concat(action.titles);
            state = Object.assign({}, state, {titles: updateTitles})
            break;
        }
        case types.GET_MORE_TITLE_ERROR: {
            state = Object.assign({}, state, {error: action.error});
            break;
        }
        case types.SEARCH_TITLES_REQUEST: {
            state = Object.assign({}, state, {titles: [], isFetching: true});
            break;
        }
        case types.SEARCH_TITLES_SUCCESS: {
            state = Object.assign({}, state, {titles: action.search, isFetching: false});
            break;
        }
        case types.SEARCH_TITLES_ERROR: {
            state = Object.assign({}, {titles: [], isFetching: false, error: action.error});
            break;
        }
        default: {
            break;
        }
    }
    return state;
}

export default titleReducer;