import { GET_MESSAGES, ADD_MESSAGE } from './actionTypes';
import {getMessagesService} from '../services/messageService';

export function addMessage(payload) {
    return { type: ADD_MESSAGE, payload };
}

export async function getMessages(model) {
    var payload = await getMessagesService(model);
    return { type: GET_MESSAGES, payload };
}
