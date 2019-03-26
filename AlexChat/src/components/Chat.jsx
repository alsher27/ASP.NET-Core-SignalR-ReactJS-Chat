import * as SignalR from '@aspnet/signalr';
import React, { Component } from 'react';
import { connect } from "react-redux";
import { userLogout } from '../actions/authActions.js';
import { getChats } from '../actions/chatActions.js';
import { addMessage, getMessages } from '../actions/messageActions.js';
import ChatCreator from './ChatCreator.jsx';
import ChatSelector from './ChatSelector.jsx';



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

        this.props.getChats(this.props.username)
        const hubConnection = new SignalR.HubConnectionBuilder()
            .withUrl("/chat", {
                skipNegotiation: true,
                transport: SignalR.HttpTransportType.WebSockets
            })
            .configureLogging(SignalR.LogLevel.Information)
            .build();


        this.setState({ hubConnection }, () => {
            this.state.hubConnection
                .start()
                .then(() => console.log("Connection started!"))
                .catch(err => console.log("Error while establishing connection"));
                
            this.state.hubConnection.serverTimeoutInMilliseconds = 100000;

            this.state.hubConnection.on("Receive", (mes) => {
                this.props.addMessage(mes)
            });

            this.state.hubConnection.on("ChatCreated", (chat) => {
                this.props.addChat(chat)
            });
        });
    };

    sendMessage = () => {
        this.state.hubConnection
            .invoke('Transfer', this.props.username, this.state.message, this.props.current_chat.id)
            .catch(err => console.error(err));

        this.setState({ message: '' });
    };

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
                <button onClick={this.props.logout}>Log out</button>
                <br />

                <h2>Current chat: {this.props.current_chat.chatname || 'Not selected'}</h2>

                <input
                    type="text"
                    value={this.state.message}
                    onChange={e => this.setState({ message: e.target.value })}
                />
                <button onClick={this.sendMessage}>Send</button>

                <div>
                    {this.props.messages.map((message, index) => {
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
        username: state.auth.username,
        current_chat: state.chat.current_chat,
        chats: state.chat.chats,
        messages: state.message.messages,
    };
};

const mapDispatchToProps = dispatch => {
    return {
        addMessage: model => dispatch(addMessage(model)),
        addChat: model => dispatch(addChat(model)),
        getChats: username => dispatch(getChats(username)),
        getMessages: chatid => dispatch(getMessages(chatid)),
        logout: () => dispatch(userLogout())
    };
}
const Chat = connect(mapStateToProps, mapDispatchToProps)(ConnChat);

export default Chat;
