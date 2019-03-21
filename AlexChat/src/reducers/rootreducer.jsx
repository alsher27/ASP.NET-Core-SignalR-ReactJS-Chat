
const initialState = {
    username: '',
    current_chat: {},
    chats: [],
    messages: []
    
};

function rootReducer(state = initialState, action) {
    if (action.type === "SET_USERNAME") {
        return Object.assign({}, state, { username: action.payload } )
    }
    if (action.type === "SET_CURRENT_CHAT") {
        return Object.assign({}, state, { current_chat: action.payload })
    }
    if (action.type === "ADD_MESSAGES") {
        return Object.assign({}, state, { messages: [...state.messages, ...action.payload] })
    }
    if (action.type === "ADD_MESSAGE") {
        return { 
            ...state,
            messages: [...state.messages, action.payload]
        }
    }
    if (action.type === "ADD_CHATS") {
        return Object.assign({}, state, { chats: [...state.chats, ...action.payload] })
    }
    if (action.type === "ADD_CHAT") {
        return { 
            ...state,
            chats: [...state.chats, action.payload]
        }
    }


    return state;
};
export default rootReducer;