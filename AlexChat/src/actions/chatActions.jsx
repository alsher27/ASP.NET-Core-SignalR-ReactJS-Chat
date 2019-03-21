export function addChat(payload) {
    return { type: "ADD_CHaAT", payload };
}

export function addChats(payload) {
    return { type: "GET_CHATS", payload };
}

export function setCurrentChat(payload) {
    return { type: "SET_CURRENT_CHAT", payload };
}
