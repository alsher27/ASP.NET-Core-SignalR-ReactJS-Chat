import React, { Component } from 'react';
import store from './store/store.jsx'
import { connect } from 'react-redux';
import { setUsername } from './actions/setUsername.jsx';
import { userInfo } from 'os';

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
            const model = {
                Email: this.state.email,
                Password: this.state.pass
            }
            fetch("api/account/register/",
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
                    if ( res == "_wrongregister_") {
                        window.alert("This user already exists or invalid input")
                        this.setState({
                            email: '',
                            pass: '',
                            confirm: ''
                        });
                    }
                    else {
                        //route to chat
                        this.props.setUsername( res );
                    }
                });
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
        setUsername: username => dispatch(setUsername(username))
  };
}
const mapStateToProps = state => {
    return { username: state.username };
};
const Register = connect(mapStateToProps, mapDispatchToProps)(RegisterConn);

export default Register;