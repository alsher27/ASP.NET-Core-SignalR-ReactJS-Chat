import { GET_MESSAGES, ADD_MESSAGE } from '../actions/actionTypes.js';

const initialState = {
    messages: []
};

function messageReducer(state = initialState, action) {
    
    if (action.type === ADD_MESSAGE) {
        console.log('inside!');
        return { 
            ...state,
            messages: [action.payload, ...state.messages ]
        }
    }

    if (action.type === GET_MESSAGES) {
        return { 
            ...state,
            messages: [...state.messages, ...action.payload]
        }
    }
    return state;
};
export default messageReducer;