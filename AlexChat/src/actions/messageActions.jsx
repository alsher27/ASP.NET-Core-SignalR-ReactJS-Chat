export function addMessage(payload) {
    return { type: "ADD_MESSAGE", payload };
}


export function getMessages(payload) {
    return { type: "GET_MESSAGES", payload };
}
