import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from "react-redux";
import { connect } from "react-redux";
import {bindActionCreators} from "redux"
//import Login from './Login.jsx';
import Chat from "./components/Chat.jsx";
import Signin from "./components/Signin.jsx";
import { getUsername } from './actions/authActions.js';
import store from './store/store.js'


class ConnApp extends React.Component {

    constructor(props) {
        super(props);
        
    }

    render() {
        this.props.getUsername();

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
    return { username: state.auth.username };
};

function mapDispatchToProps(dispatch) {
    return{ 
        getUsername: () => dispatch(getUsername())
    }
    ;
}
const App = connect(mapStateToProps, mapDispatchToProps)(ConnApp);

ReactDOM.render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById("content")
);