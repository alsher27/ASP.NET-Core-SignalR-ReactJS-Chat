import React, { Component } from 'react';
import store from './store/store.jsx'
import { connect } from 'react-redux';
import { setUsername } from './actions/loginAction.jsx';
import { setChatId } from './actions/setChatId.jsx';


class ChatSelectorConn extends Component {

    constructor(props) {
        super(props);
            
        this.state = {
            chatId: 0,
            chatName:''
        };

    }

    render() {
        return <div>
            <select>
                {this.props.messages.map()/*continue from here*/} 
            </select>
               </div>
    }
}
const mapStateToProps = state => {
    return {
        username: state.username,
        current_chat: state.current_chat
    };
};

const mapDispatchToProps = dispatch => {
    return {
        setChatId: current_chat => dispatch(setChatId(current_chat))
    };
}
const ChatSelector = connect(mapStateToProps, mapDispatchToProps)(ChatSelectorConn);

export default ChatSelector;