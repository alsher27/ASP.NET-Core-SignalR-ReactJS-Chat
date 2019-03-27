import React, { Component } from 'react';

import { connect } from 'react-redux';
import { setCurrentChat } from '../actions/chatActions.js';
import { getMessages } from '../actions/messageActions.js';
import { setChatAsLoaded } from '../actions/chatActions';
class ChatSelectorConn extends Component {

    constructor(props) {
        super(props);
        this.state = {
            messagesGotForChats: []
        }
    }


    render() {
        return <div>    {this.props.chats.map((chat, index) => {
            return (<div key={index} onClick={() => { this.props.setCurrentChat(chat); if (!chat.messagesGot) { this.props.getMessages(chat.id); this.props.setChatAsLoaded(chat) } }}> {chat.chatname} </div>)
        })}
        </div>
    }
}

// const changeChat = () => {
//     this.props.setCurrentChat(chat);

//     if(!this.props.chats.messagesGot) 
//     {   
//         messagesGot = true;
//         this.props.getMessages(chat.id)
//     }
// }

const mapStateToProps = state => {
    return {
        chats: state.chat.chats
    };
};

const mapDispatchToProps = dispatch => {
    return {
        setCurrentChat: current_chat => dispatch(setCurrentChat(current_chat)),
        getMessages: chatid => dispatch(getMessages(chatid)),
        setChatAsLoaded: chat => dispatch(setChatAsLoaded(chat))
    };
};

const ChatSelector = connect(mapStateToProps, mapDispatchToProps)(ChatSelectorConn);

export default ChatSelector;