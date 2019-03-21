import React, { Component } from 'react';
import store from './store/store.jsx'
import { connect } from 'react-redux';
import { setUsername } from './actions/authActions.jsx/index.js';
import { userInfo } from 'os';

    class LoginConn extends Component {

        constructor(props) {
            super(props);

            this.state = {
                email: '',
                pass: ''
            };

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
               
                <button onClick={this.props.Login()}>Login</button>

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