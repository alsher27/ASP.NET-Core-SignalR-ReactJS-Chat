const initialState = {
    current_chat:{},
    chats: [],
    search_res: []
};

function authReducer(state = initialState, action) {
    
    if (action.type === "ADD_MESSAGE") {
        return { 
            ...state,
            messages: [...state.messages, action.payload]
        }
    }
    
    if (action.type === "GET_MESSAGES") {
        return Object.assign({}, state, { messages: [...state.messages, ...action.payload] })
    }
    return state;
};
export default authReducer;