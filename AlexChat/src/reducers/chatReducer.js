import { ADD_CHAT, GET_CHATS, SET_CURRENT_CHAT,SEARCH_USERS, SET_CHAT_AS_LOADED } from '../actions/actionTypes.js';

const initialState = {
    current_chat:{},
    chats: [],
    search_res: []
};

function chatReducer(state = initialState, action) {
    if(action.type === ADD_CHAT){
        return Object.assign({}, state, { chats: [...state.chats, action.payload] })
    }

    if(action.type === GET_CHATS){
        return Object.assign({}, state, { chats: action.payload })
    }

    if(action.type === SET_CURRENT_CHAT){
        return Object.assign({}, state, { current_chat: action.payload })
    }

    if(action.type === SEARCH_USERS){
        return Object.assign({}, state, { search_res: action.payload })
    }

    if(action.type === SET_CHAT_AS_LOADED){
        return { 
            ...state, 
            chats: state.chats.map(
                (chat, i) => chat.chatname === action.payload.chatname ? {...chat, messagesGot: true}
                                        : chat
            )
         }
    }
    return state;
};
export default chatReducer;