import React, { Component } from 'react';

import { connect } from 'react-redux';
import { userRegister } from '../actions/authActions.js';


class RegisterConn extends Component {

    constructor(props) {
        super(props);

        this.state = {
            email: '',
            pass: '',
            confirm: ''
        };
        
    }

    register = () => {
        if (this.state.pass === this.state.confirm) {
        var model = {
            Email: this.state.email,
            Password: this.state.pass
        }    
        this.props.userRegister(model)
            
        }
        else {
            window.alert("Passwords dont match");
            this.setState({
                pass: '',
                confirm: ''
            });
        }
        
    }

    render() {
        return (
            <div>
                <br />
                Email:
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
                <br />
                Confirm Password:
                <input
                    type="password"
                    value={this.state.confirm}
                    onChange={e => this.setState({ confirm: e.target.value })}
                />

                <button onClick={this.register}>Register</button>
                
            </div>
        );
    }

}

const mapDispatchToProps = dispatch => {
    return {
        userRegister: model => dispatch(userRegister(model))
    };
}
const mapStateToProps = state => {
    return { username: state.username };
};
const Register = connect(mapStateToProps, mapDispatchToProps)(RegisterConn);

export default Register;