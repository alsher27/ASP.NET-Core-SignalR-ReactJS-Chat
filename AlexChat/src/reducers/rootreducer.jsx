
const initialState = {
    username: '',
    current_chat:0,
    messages: []
    
};

function rootReducer(state = initialState, action) {
    if (action.type === "SET_USERNAME") {
        return Object.assign({}, state, { username: action.payload } )
    }
    if (action.type === "SET_CHAT_ID") {
        return Object.assign({}, state, { current_chat: action.payload })
    }
    if (action.type === "ADD_MESSAGES") {
        return Object.assign({}, state, { messages: [...state.messages, ...action.payload] })
    }


    return state;
};
export default rootReducer;