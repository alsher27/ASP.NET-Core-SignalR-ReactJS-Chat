import React, { Component } from 'react';
import store from './store/store.jsx'
import { connect } from 'react-redux';
import { setUsername } from './actions/loginAction.jsx';
import Login from './Login.jsx';
import Register from './Register.jsx';

class Signin extends Component {
    constructor(props) {
        super(props);

        this.state = {
            type: 'login'
        };
    }

    changeType = () => {
        if (this.state.type == 'login')
            this.setState({ type: 'register' })
        else
            this.setState({type: 'login'})
    }

    render() {
        if (this.state.type == 'login') {
            return (
                <div>
                    You can also <button onClick={this.changeType}>Register</button>
                    <Login />
                </div>
            )
        }
        if (this.state.type == 'register') {
                return (
                    <div>
                        If you already have an account, <button onClick={this.changeType}>Login</button>
                        <Register />
                    </div>
            )
        }
        else {
            this.changeType;
        }
    }

}

//const mapStateToProps = state => {
//    return { username: state.username };
//};
//const Signin = connect(mapStateToProps)(SigninConn);

export default Signin;

