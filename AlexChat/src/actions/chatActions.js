import { ADD_CHAT, GET_CHATS, SET_CURRENT_CHAT, SEARCH_USERS, SET_CHAT_AS_LOADED } from './actionTypes';
import {addChatService, getChatsService, searchUsersService} from '../services/chatService';

export function addChat(model) {
    return async dispatch => {
    const payload = await addChatService(model);
    dispatch({ type: ADD_CHAT, payload })}
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