import React, { Component } from 'react';
import { connect } from 'react-redux';
import { addChats } from './actions/addChats.jsx';
import { addChat } from './actions/addChat.jsx';

class ChatCreatorConn extends Component {

    constructor(props) {
        super(props);
            
        this.state = {
            nameForChat: '',
            usersForChat: [],
            query:'', 
            queryRes: []
        };

    }

    createChat = () => {
        const model = {
            users: [...this.state.usersForChat, this.props.username],
            chatname: this.state.nameForChat
            }
        fetch("api/chat/createchat/",
        {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(model)
        })
        .then(response => {
            return response.json();
        })
        .then(res => {
            this.props.addChat(res);
            this.setState({nameForChat: ''})
        });
    }

    searchUsers = () => {

        fetch("api/chat/searchusers?username=" + this.state.query)
            .then(response => {
                return response.json();
            })
            .then(res => {
                this.setState({queryRes: res})
            });

    }
    

    render() {
    return <div>
                Search by username:
                    <input
                    type="text"
                    value={this.state.query}
                    onChange={e => {this.setState ({ query: e.target.value }) } }
                    />
                    <button onClick={this.searchUsers}>Search</button>

                    {this.state.queryRes.map((username, index) => 
                    <div key={index} onClick={() => this.setState({usersForChat: [...this.state.usersForChat, username]})}>
                        {username}
                    </div> )}
                    <br/>
                    <div>
                        Selected users:
                        {this.state.usersForChat.map((username, index) => 
                        <div key={index}>
                            {username}
                        </div> )}        
                    </div>
                    <br/>
                    Name this chat:
                    <input
                    type="text"
                    value={this.state.nameForChat}
                    onChange={e => this.setState ({ nameForChat: e.target.value }) }
                    />
                    <button onClick={this.createChat}>Create</button>
               </div>
    }
}

const mapStateToProps = state => {
    return {
        username: state.username,
        chats: state.chats
    };
};

const mapDispatchToProps = dispatch => {
    return {
        addChats: chats => dispatch(addChats(chats)),
        addChat: chat => dispatch(addChat(chat))
    };
}
const ChatCreator = connect(mapStateToProps, mapDispatchToProps)(ChatCreatorConn);

export default ChatCreator;