import React, { Component } from 'react';
import store from './store/store.jsx'
import { connect } from 'react-redux';
import { setCurrentChat } from './actions/setCurrentChat.jsx';
import { addChats } from './actions/addChats.jsx';

class ChatSelectorConn extends Component {

    constructor(props) {
        super(props);
            
        this.state = {
            chats: this.props.chats
        };

    }


    render() {
        return <div>    {this.props.chats.map( (chat, index) => { 
                    return (<div key={index} onClick={() => this.props.setCurrentChat(chat)}> {chat.chatname} </div>)  
                        })}
                </div>               
    }
}


const mapStateToProps = state => {
    return {
        username: state.username,
        current_chat: state.current_chat,
        chats: state.chats
    };
};

const mapDispatchToProps = dispatch => {
    return {
        setCurrentChat: current_chat => dispatch(setCurrentChat(current_chat)),
        addChats: chats => dispatch(addChats(chats))
    };
};

const ChatSelector = connect(mapStateToProps, mapDispatchToProps)(ChatSelectorConn);

export default ChatSelector;