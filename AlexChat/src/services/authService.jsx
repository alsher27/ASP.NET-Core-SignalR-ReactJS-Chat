export async function Login(model){
    const response = await fetch("api/account/Login/", {
        method: 'POST',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(model)
    });
    const res = await response.text();
    if (res == "_wronglogin_") {
        window.alert("Wrong login or password");
        return null;
    }
    return res;
}

export function Register(model){
    const response = await fetch("api/account/register/",
    {
        method: 'POST',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(model)
    });
    const res = await response.text;
    if ( res == "_wrongregister_") {
        window.alert("This user already exists or invalid input")
        return null;
    }
    return res;
};

export function Logout(){
    fetch("api/account/logout/");
}