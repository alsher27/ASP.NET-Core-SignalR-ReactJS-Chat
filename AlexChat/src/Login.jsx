import React, { Component } from 'react';
import store from './store/store.jsx'
import { connect } from 'react-redux';
import { setUsername } from './actions/setUsername.jsx';
import { userInfo } from 'os';

    class LoginConn extends Component {

        constructor(props) {
            super(props);

            this.state = {
                email: '',
                pass: ''
            };

        }

    Login = () => {
        
        const model = {
            Email: this.state.email,
            Password: this.state.pass
        }
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

    render() {
        return (
            <div>
                <br />
                Login:
                <input
                    type="text"
                    value={this.state.email}
                    onChange={e => this.setState({ email: e.target.value })}
                />
                <br />
                Password:
                <input
                    type="password"
                    value={this.state.pass}
                    onChange={e => this.setState({ pass: e.target.value })}
                />
               
                <button onClick={this.Login}>Login</button>

            </div>
        );
    }

}

function mapDispatchToProps(dispatch) {
    return {
        setUsername: username => dispatch(setUsername(username))
    };
}
const mapStateToProps = state => {
    return { username: state.username };
};
const Login = connect(mapStateToProps, mapDispatchToProps)(LoginConn);

export default Login;