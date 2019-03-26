import { ADD_CHAT, CREATE_CHAT, GET_CHATS, SET_CURRENT_CHAT, SEARCH_USERS, SET_CHAT_AS_LOADED } from './actionTypes';
import { createChatService, getChatsService, searchUsersService} from '../services/chatService';

export function createChat(model) {
    return async dispatch => {
    const payload = await createChatService(model);
    dispatch({ type: CREATE_CHAT, payload })}
}

export function addChat(payload) {
    return { type: ADD_CHAT, payload }
}

export function getChats(model) {
    return async dispatch => {
    const payload = await getChatsService(model);
    dispatch({ type: GET_CHATS, payload })}
}

export function setCurrentChat(payload) {
    return { type: SET_CURRENT_CHAT, payload };
}

export function searchUsers(model) {
    return async dispatch => {
    const payload = await searchUsersService(model);
    dispatch({ type: SEARCH_USERS, payload })}
}

export function setChatAsLoaded(model) {
    let payload = model;
    return {type: SET_CHAT_AS_LOADED, payload}
}