import {REGISTER, LOGIN, LOGOUT, GET_USERNAME } from './actionTypes.js';
import {RegisterService, LoginService, LogoutService, getUsernameService} from '../services/authService';

export function userRegister(model){
    return async dispatch => {
    const payload = await RegisterService(model);
    dispatch({ type: REGISTER, payload })
    }
}

export function userLogin(model) {
    return async dispatch => {
    const payload = await LoginService(model);
    dispatch({ type: LOGIN, payload }) 
}}

export function userLogout(){ 
    return async dispatch => {
    await LogoutService();
    const payload = '';
    dispatch( { type: LOGOUT, payload } )
    }
}

export function getUsername(){
    return async dispatch => {
    const payload = await getUsernameService();
    dispatch({type: GET_USERNAME, payload })
    }
}