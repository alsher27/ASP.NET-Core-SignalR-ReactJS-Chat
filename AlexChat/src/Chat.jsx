import React, { Component } from 'react';
import * as SignalR from '@aspnet/signalr';
import { connect } from "react-redux";
import { addMessages } from './actions/addMessages/'

class ConnChat extends Component {
    constructor(props) {
        super(props);

        this.state = {           
            message: '',
            messages: [],
            chatid: 0,
            hubConnection: null,
        };
    }

    componentDidMount = () => {
        //const nick = window.prompt('Your name:', '');
        this.getMessages();
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

            this.state.hubConnection.on('Receive', (mes) => {
                this.setState({
                    messages: this.state.messages.concat(mes)  
                });
                
            });
        });
    };

    sendMessage = () => {
        this.state.hubConnection
            .invoke('Transfer', this.props.username, this.state.message, this.state.chatid)
            .catch(err => console.error(err));

        this.setState({ message: '' });
    };

    getMessages = () => {
        fetch(this.props.apiUrl + "/all?id=" + this.state.chatid)
            .then(response => {
                return response.json();
            })
            .then(json => {
                this.setState({
                    messages: [...this.state.messages, ...json]
                });
            })
            .catch(alert);
    }

    render() {
        return (
            <div>
                <div>
                    {this.state.messages.map((message, index) => (
                        <span style={{ display: 'block' }} key={index}><b>{message.fromUsername}</b>: {message.text} - {message.dateTime} </span>
                    ))}
                </div>
                <br />
                <input
                    type="text"
                    value={this.state.message}
                    onChange={e => this.setState({ message: e.target.value })}
                />

                <button onClick={this.sendMessage}>Send</button>
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        username: state.username,
        current_chat: state.current_chat,
        messages: state.messages
    };
};

const mapDispatchToProps = dispatch => {
    return {
        addMessages: messages => dispatch(addMessages(messages))
    };
}
const Chat = connect(mapStateToProps, mapDispatchToProps)(ConnChat);

export default Chat;
