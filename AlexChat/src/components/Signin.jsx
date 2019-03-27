import React, { Component } from 'react';
import store from '../store/store.js'
import { connect } from 'react-redux';

import Login from './Login.jsx';
import Register from './Register.jsx';

class Signin extends Component {
    constructor(props) {
        super(props);

        this.state = {
            type: 'login'
        };
    }

    toggleType = () => {
        if (this.state.type == 'login')
            this.setState({ type: 'register' })
        else
            this.setState({type: 'login'})
    }

    render() {
        if (this.state.type == 'login') {
            return (
                <div>
                    You can also <button onClick={this.toggleType}>Register</button>
                    <Login />
                </div>
            )
        }
        if (this.state.type == 'register') {
                return (
                    <div>
                        If you already have an account, <button onClick={this.toggleType}>Login</button>
                        <Register />
                    </div>
            )
        }
        else {
            this.toggleType;
        }
    }

}

export default Signin;

