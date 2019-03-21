export async function getUsername() {
    try {
        const response = await fetch("/api/account/getusername/");
        const json = await response.text();
        //this.props.setUsername(json);
        return json;
    }
    catch (alert) {
        return alert(alert);
    }
}
// in actions, dispath ressult of this
function f () {
fetch("api/account/Login/",
{
    method: 'POST',
    headers: {
        "Content-Type": "application/json",
    },
    body: JSON.stringify(model)
})
.then(response => {
    return response.text();
})
.then(res => {
    if (res == "_wronglogin_") {
        window.alert("Wrong login or password")
        this.setState({
            email: '',
            pass: ''
        });
    }
    else {
        this.props.setUsername(res);
    }
});
}