
const initialState = {
    username: ''
};

function authReducer(state = initialState, action) {
    if(action.type === "LOGIN"){
        return Object.assign({}, state, { username: action.payload })
    }

    if(action.type === "REGISTER"){
        return Object.assign({}, state, { username: action.payload })
    }

    if(action.type === "LOGOUT"){
        return Object.assign({}, state, { username: '' })
    }
    
    return state;
};
export default authReducer;