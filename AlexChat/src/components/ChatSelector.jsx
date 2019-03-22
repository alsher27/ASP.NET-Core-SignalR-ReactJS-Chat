import React, { Component } from 'react';

import { connect } from 'react-redux';
import { setCurrentChat } from '../actions/chatActions.js';


class ChatSelectorConn extends Component {

    constructor(props) {
        super(props);
    }


    render() {
        return <div>    {this.props.chats.map((chat, index) => {
            return (<div key={index} onClick={() => this.props.setCurrentChat(chat)}> {chat.chatname} </div>)
        })}
        </div>
    }
}


const mapStateToProps = state => {
    return {
        chats: state.chat.chats
    };
};

const mapDispatchToProps = dispatch => {
    return {
        setCurrentChat: current_chat => dispatch(setCurrentChat(current_chat))
    };
};

const ChatSelector = connect(mapStateToProps, mapDispatchToProps)(ChatSelectorConn);

export default ChatSelector;