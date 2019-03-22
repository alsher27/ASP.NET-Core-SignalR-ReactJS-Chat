import { ADD_CHAT, GET_CHATS, SET_CURRENT_CHAT, SEARCH_USERS } from './actionTypes';
import {addChatService, getChatsService, searchUsersService} from '../services/chatService';

export async function addChat(model) {
    var payload = await addChatService(model);
    return { type: ADD_CHAT, payload };
}

export async function getChats(payload) {
    var payload = await getChatsService(model);
    return { type: GET_CHATS, payload };
}

export function setCurrentChat(payload) {
    return { type: SET_CURRENT_CHAT, payload };
}

export async function searchUsers(model) {
    var payload = await searchUsersService(model);
    return { type: SEARCH_USERS, payload };
}
