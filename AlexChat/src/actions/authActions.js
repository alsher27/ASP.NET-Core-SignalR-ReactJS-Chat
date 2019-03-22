import {REGISTER, LOGIN, LOGOUT, GET_USERNAME } from './actionTypes';
import {RegisterService, LoginService, LogoutService, getUsernameService} from '../services/authService';

export async function userRegister(model){
    var payload = await RegisterService(model);
    return { type: REGISTER, payload }
}

export async function userLogin(model) {
    var payload = await LoginService(model);
    return { type: LOGIN, payload } 
}

export function userLogout(){
    LogoutService();
    return { type: LOGOUT, payload } 
}

export async function getUsername(){
    var payload = await getUsernameService();
    return { type: GET_USERNAME, payload}
}