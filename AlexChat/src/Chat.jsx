import React, { Component } from 'react';
import * as SignalR from '@aspnet/signalr';
import { connect } from "react-redux";

import ChatSelector from './ChatSelector.jsx'
import ChatCreator from './ChatCreator.jsx';

import { addMessages } from './actions/addMessages.jsx'
import { addChats } from './actions/addChats.jsx';
import { addMessage } from './actions/messageActions.jsx/index.js';
import {setUsername} from './actions/authActions.jsx/index.js';

class ConnChat extends Component {
    constructor(props) {
        super(props);

        this.state = {
            message: '',
            hubConnection: null,
            showChatSelector: false,
            showChatCreator: false
        };
    }

    componentDidMount = () => {
        //  get chats
        // .then(() =>
        //         this.props.chats.map((chat) => (
        //             this.getMessages(chat.id) // CHECK!
        //         ))
        //     )

        const hubConnection = new SignalR.HubConnectionBuilder()
            .withUrl('http://localhost:5000/chat', {
                skipNegotiation: true,
                transport: SignalR.HttpTransportType.WebSockets
            })
            .configureLogging(SignalR.LogLevel.Information)
            .build();


        this.setState({ hubConnection }, () => {
            this.state.hubConnection
                .start()
                .then(() => console.log('Connection started!'))
                .catch(err => console.log('Error while establishing connection'));
            this.state.hubConnection.serverTimeoutInMilliseconds = 100000;
            
            this.state.hubConnection.on('Receive', (mes) => {
                this.props.addMessage(mes) 
            });
        });
    };
    
    sendMessage = () => {
        this.state.hubConnection
            .invoke('Transfer', this.props.username, this.state.message, this.props.current_chat.id)
            .catch(err => console.error(err));

        this.setState({ message: '' });
    };

    getMessages = (chatid) => {
        
    }

    logout = () => {
        
    }

    toggleChatSelector = () => {
        this.setState((oldState) => ({ showChatSelector: !oldState.showChatSelector }))
    }
    toggleChatCreator = () => {
        this.setState((oldState) => ({ showChatCreator: !oldState.showChatCreator }))
    }

    render() {
        return (
            <div>
                <button onClick={this.toggleChatSelector}>{this.state.showChatSelector ? 'Hide' : 'Select chat'}</button>
                <div>
                    {this.state.showChatSelector && <ChatSelector />}
                </div>

                <button onClick={this.toggleChatCreator}>{this.state.showChatCreator ? 'Hide' : 'New Chat'}</button>
                <div>
                    {this.state.showChatCreator && <ChatCreator />}
                </div>
                
                <h2>Current user: {this.props.username}</h2>
                <button onClick={this.logout}>Log out</button>
                <h2>Current chat: {this.props.current_chat.chatname || 'Not selected'}</h2>
                
                <input
                    type="text"
                    value={this.state.message}
                    onChange={e => this.setState({ message: e.target.value })}
                />
                <button onClick={this.sendMessage}>Send</button>
                <div>
                    {this.props.messages.map((message, index) => {       // CHECK !!! 
                        if (message.chatId === this.props.current_chat.id)
                            return <span style={{ display: 'block' }} key={index}><b>{message.fromUsername}</b>: {message.text} - {message.dateTime} </span>
                        return;

                    })}
                </div>
                <br />
                

                
                
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        username: state.username,
        current_chat: state.current_chat,
        messages: state.messages,
        chats: state.chats
    };
};

const mapDispatchToProps = dispatch => {
    return {
        addMessages: messages => dispatch(addMessages(messages)),
        addChats: chats => dispatch(addChats(chats)),
        addMessage: message=>dispatch(addMessage(message)),
        setUsername: username => dispatch(setUsername(username))
    };
}
const Chat = connect(mapStateToProps, mapDispatchToProps)(ConnChat);

export default Chat;
