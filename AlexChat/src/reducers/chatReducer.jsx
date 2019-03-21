const initialState = {
    current_chat:{},
    chats: [],
    search_res: []
};

function authReducer(state = initialState, action) {
    if(action.type === "ADD_CHAT"){
        return Object.assign({}, state, { chats: [...state.chats, action.payload] })
    }

    if(action.type === "GET_CHATS"){
        return Object.assign({}, state, { chats: action.payload })
    }

    if(action.type === "SET_CURRENT_CHAT"){
        return Object.assign({}, state, { current_chat: action.payload })
    }

    return state;
};
export default authReducer;