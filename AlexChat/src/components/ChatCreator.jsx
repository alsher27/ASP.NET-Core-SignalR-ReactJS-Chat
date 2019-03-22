import React, { Component } from 'react';
import { connect } from 'react-redux';

import { addChat, searchUsers } from '../actions/chatActions.js';

class ChatCreatorConn extends Component {

    constructor(props) {
        super(props);

        this.state = {
            nameForChat: '',
            usersForChat: [],
            query: ''

        };

    }

    createChat = () => {
        const model = {
            users: [...this.state.usersForChat, this.props.username],
            chatname: this.state.nameForChat
        }
        this.props.addChat(model);
    }

    searchUsers = () => {
        this.props.searchUsers(this.state.query)
    }


    render() {
        return <div>
            Search by username:
            <input
                type="text"
                value={this.state.query}
                onChange={e => { this.setState({ query: e.target.value }) }}
            />
            <button onClick={this.searchUsers}>Search</button>

            {this.props.search_res.map((username, index) =>
                <div key={index} onClick={() => this.setState({
                    usersForChat: [...this.state.usersForChat, username]
                })
                }>
                    {username}
                </div>)}
            <br />

            <div>
                Selected users:
            {this.state.usersForChat.map((username, index) =>
                    <div key={index} onClick={() => this.setState({
                        usersForChat: usersForChat.filter(s => s != username)
                    })
                    }>
                        {username}
                    </div>)}
            </div>
            <br />
            Name this chat:
            <input
                type="text"
                value={this.state.nameForChat}
                onChange={e => this.setState({ nameForChat: e.target.value })}
            />
            <button onClick={this.createChat}>Create</button>
        </div>
    }
}

const mapStateToProps = state => {
    return {
        username: state.auth.username,
        chats: state.chat.chats,
        search_res: state.chat.search_res
    };
};

const mapDispatchToProps = dispatch => {
    return {
        addChat: chat => dispatch(addChat(chat)),
        searchUsers: username => dispatch(searchUsers(username))
    };
}
const ChatCreator = connect(mapStateToProps, mapDispatchToProps)(ChatCreatorConn);

export default ChatCreator;