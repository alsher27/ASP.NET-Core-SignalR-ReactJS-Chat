import React, { Component } from 'react';
import * as SignalR from '@aspnet/signalr';

class Chat extends Component {
    constructor(props) {
        super(props);

        this.state = {
            nick: '',
            message: '',
            messages: [],
            chatid: 1,
            hubConnection: null,
        };
    }

    componentDidMount = () => {
        const nick = window.prompt('Your name:', '');
        this.getMessages();
        let token = "hfv6vpcsh3h5trxu";
        const hubConnection = new SignalR.HubConnectionBuilder()
            .withUrl('http://localhost:5000/chat', {
                skipNegotiation: true,
                accessTokenFactory: () => token,
                transport: SignalR.HttpTransportType.WebSockets
            })
            .configureLogging(SignalR.LogLevel.Information)
            .build();
        

        this.setState({ hubConnection, nick }, () => {
            this.state.hubConnection
                .start()
                .then(() => console.log('Connection started!'))
                .catch(err => console.log('Error while establishing connection'));

            this.state.hubConnection.on('Send', (mes) => {
                this.setState({
                    messages: this.state.messages.concat(mes)  
                });
                
            });
        });
    };

    sendMessage = () => {
        this.state.hubConnection
            .invoke('Send', this.state.nick, this.state.message, this.state.chatid)
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
                <br />
                <input
                    type="text"
                    value={this.state.message}
                    onChange={e => this.setState({ message: e.target.value })}
                />

                <button onClick={this.sendMessage}>Send</button>

                <div>
                    {this.state.messages.map((message, index) => (
                        <span style={{ display: 'block' }} key={index}><b>      </b>: {message.text} - {message.dateTime} </span>
                    ))}
                </div>
            </div>
        );
    }
}

export default Chat;
