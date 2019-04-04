import * as types from './TitleActionsTypes';
import TitleApi from '../api/TitleApi';

// GET ALL WITHOUT PARAMS
export const getTitlesRequest = () => ({
    type: types.GET_TITLES_REQUEST
});

export const getTitlesSuccess = (titles) => ({
    type: types.GET_TITLES_SUCCESS,
    titles
});

export const getTitlesError = (error) => ({
    type: types.GET_TITLES_ERROR,
    error
});

function shouldFetchTitles(state) {
    if(state.isFetching) {
        return false;
    } else {
        return true;
    }
}

export const getTitles = () => {
    return (dispatch) => {
        dispatch(getTitlesRequest());
        return TitleApi.getAllTitles()
            .then(titles => {
                dispatch(getTitlesSuccess(titles));
            }).catch(error => {
                dispatch(getTitlesError(error));
            });
    };
};

export const getTitlesIfNeeded = () => {
    return (dispatch, getState) => {
        if(shouldFetchTitles(getState())) {
            return dispatch(getTitles());
        }
    }
};

// GET SINGLE TITLE
export const getTitleRequest = (id) => ({
    type: types.GET_TITLE_REQUEST,
    id
});

export const getTitleSuccess = (title) => ({
    type: types.GET_TITLE_SUCCESS,
    title
});

export const getTitleError = (error) => ({
    type: types.GET_TITLE_ERROR,
    error
});

export const getTitle = (id) => {
    return (dispatch) => {
        dispatch(getTitleRequest(id));
        return TitleApi.getSingleTitle(id)
                .then(title => {
                    dispatch(getTitleSuccess(title));
                }).catch(error => {
                    dispatch(getTitleError(error));
                });
    };
};

// EDIT SINGLE TITLE
export const putTitleRequest = () => ({
    type: types.PUT_TITLE_REQUEST
});

export const putTitleSuccess = (title) => ({
    type: types.PUT_TITLE_SUCCESS,
    title
});

export const putTitleError = (error) => ({
    type: types.PUT_TITLE_ERROR,
    error
});

export const putTitle = (title) => {
    return (dispatch) => {
        dispatch(putTitleRequest());
        return TitleApi.putTitle(title)
            .then(title => {
                dispatch(putTitleSuccess(title));
        }).catch(error => {
            dispatch(putTitleError(error));
        });
    };
};

// DELETE SINGLE TITLE
export const deleteTitleRequest = () => ({
    type: types.DELETE_TITLE_REQUEST
});

export const deleteTitleSuccess = (id) => ({
    type: types.DELETE_TITLE_SUCCESS,
    id
});

export const deleteTitleError = (error) => ({
    type: types.DELETE_TITLE_ERROR,
    error
});

export const deleteTitle = (id) => {
    return (dispatch) => {
        dispatch(deleteTitleRequest());
        return TitleApi.deleteTitle(id)
            .then(id => {
                dispatch(deleteTitleSuccess(id));
            }).catch(error => {
                dispatch(deleteTitleError(error));
            });
    };
};

// POST SINGLE TITLE
export const postTitleRequest = () => ({
    type: types.POST_TITLE_REQUEST
});

export const postTitleSuccess = (title) => ({
    type: types.POST_TITLE_SUCCESS,
    title
});

export const postTitleError = (error) => ({
    type: types.POST_TITLE_ERROR,
    error
});

export const postTitle = (title) => {
    return (dispatch) => {
        dispatch(postTitleRequest());
        return TitleApi.postTitle(title)
            .then(title => {
                dispatch(postTitleSuccess(title));
            }).catch(error => {
                dispatch(deleteTitleError);
            });
    };
};

export const getMoreTitlesRequest = () => ({
    type: types.GET_MORE_TITLE_REQUEST
});

export const getMoreTitlesSuccess = (titles) => ({
    type: types.GET_MORE_TITLE_SUCCESS,
    titles
});

export const getMoreTitlesError = (error) => ({
    type: types.GET_MORE_TITLE_ERROR,
    error
})

export const getMoreTitles = (start, end) => {
    return (dispatch) => {
        dispatch(getMoreTitlesRequest());
        return TitleApi.getMoreTitles(start, end)
            .then(titles => {
                dispatch(getMoreTitlesSuccess(titles))
            }).catch(error => {
                dispatch(getMoreTitlesError(error));
            });
    };
};

export const searchTitlesRequest = () => ({
    type: types.SEARCH_TITLES_REQUEST
});

export const searchTitlesSuccess = (search) => ({
    type: types.SEARCH_TITLES_SUCCESS,
    search
});

export const searchTitlesError = (error) => ({
    type: types.SEARCH_TITLES_ERROR,
    error
});

export const searchTitles = (search) => {
    return (dispatch) => {
        dispatch(searchTitlesRequest());
        return TitleApi.searchTitles(search)
            .then(titles => {
                dispatch(searchTitlesSuccess(titles));
            }).catch(error => {
                dispatch(searchTitlesError(error));
            });
    };
};