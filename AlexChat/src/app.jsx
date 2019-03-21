import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from "react-redux";
import { connect } from "react-redux";

//import Login from './Login.jsx';
import Chat from "./Chat.jsx";
import Signin from "./Signin.jsx";
import { setUsername } from './actions/authActions.jsx/index.js';



class App extends React.Component {

    constructor(props) {
        super(props);
        
    }

    getUsername() {
        return fetch("/api/account/getusername/")
            .then(response => response.text())
            .then(json => {
                //this.props.setUsername(json);
                return json;
            })
            .catch(alert);
    }

    render() {
        var username = this.getUsername();
        username.then(this.props.setUsername);

        if (this.props.username) {
            return (
                <div>
                    <Chat apiUrl="/api/message" />
                </div>
            )
        }
        else {
            return (
                <div>
                    <Signin />
                </div>
            )
        }        
    }
}

const mapStateToProps = state => {
    return { username: state.username };
};

function mapDispatchToProps(dispatch) {
    return {
        setUsername: username => dispatch(setUsername(username))
    };
}
const ConnApp = connect(mapStateToProps, mapDispatchToProps)(App);

ReactDOM.render(
    <Provider store={store}>
        <ConnApp />
    </Provider>,
    document.getElementById("content")
);