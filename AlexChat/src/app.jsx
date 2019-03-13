import React from 'react';
import ReactDOM from 'react-dom';
import Chat from './Chat.jsx';

class App extends React.Component {
    render() {
        return (
            <div> <Chat apiUrl="/api/message" /> </div>
        );
    }
}
ReactDOM.render(
    <App />,
    document.getElementById("content")
);