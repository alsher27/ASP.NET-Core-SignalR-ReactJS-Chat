import {REGISTER, LOGIN, LOGOUT, GET_USERNAME} from '../actions/actionTypes';
const initialState = {
    username: ''
};

function authReducer(state = initialState, action) {
    if(action.type === LOGIN){
        return Object.assign({}, state, { username: action.payload })
    }

    if(action.type === REGISTER){
        return Object.assign({}, state, { username: action.payload })
    }

    if(action.type === LOGOUT){
        return Object.assign({}, state, { username: action.payload })
    }

    if (action.type === GET_USERNAME){
        const username = action.payload;
        return {...state, username}
    }
    
    return state;
};
export default authReducer;