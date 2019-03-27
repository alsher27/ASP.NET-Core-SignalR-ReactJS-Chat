import { GET_MESSAGES, ADD_MESSAGE } from './actionTypes';
import {getMessagesService} from '../services/messageService';

export function addMessage(payload) {
    return { type: ADD_MESSAGE, payload };
}

export function getMessages(model) {
    return async dispatch => {
    var payload = await getMessagesService(model);
    dispatch({ type: GET_MESSAGES, payload })}
}
