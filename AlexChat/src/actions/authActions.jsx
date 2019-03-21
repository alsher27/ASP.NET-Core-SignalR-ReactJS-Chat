export function Login(model) {
    var payload = authService.Login(model);
    return { type: "LOGIN", payload } // payload: a ?
}

export function Register(model){
    var payload = authService.Register(model);
    return { type: "REGISTER", payload } // payload: a ?
}

export function Logout(){
    authService.Logout('');
    return { type: "REGISTER", payload } // payload: a ?
}
