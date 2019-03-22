import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { userLogin } from '../actions/authActions.js'

class LoginConn extends Component {

        constructor(props) {
            super(props);

            this.state = {
                email: '',
                pass: ''
            };

        }

    executeLogin = () => {
        var model = {
            Email: this.state.email,
            Password: this.state.pass
        }
        this.props.Login(model);
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
               
                <button onClick={this.executeLogin}>Login</button>

            </div>
        );
    }

}

function mapDispatchToProps(dispatch) {
    return {
        // Login: model => dispatch(userLogin(model))
        
        bindActionCreators({
        Login: userLogin
        }, 
        dispatch)
    };
}
const mapStateToProps = state => {
    return { username: state.username };
};
const Login = connect(mapStateToProps, mapDispatchToProps)(LoginConn);

export default Login;