import { combineReducers } from "redux";
import authReducer from "./authReducer.js";
import messageReducer from "./messageReducer.js";
import chatReducer from "./chatReducer.js";

//
// TODO: ! BUG ! loading messages only on Logout
//
const rootReducer = combineReducers({
    auth: authReducer,
    message: messageReducer, 
    chat: chatReducer
})

export default rootReducer;