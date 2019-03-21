export async function addChat(model){
    const response = await fetch("api/chat/createchat/",
    {
        method: 'POST',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(model)
    });
    const res = await response.json();
    return res;
}

export async function searchUsers(username){
    const response = await fetch("api/chat/searchusers?username=" + username);
    const res = await response.json();
    return res;
}

export async function getChats(username){
    const response = await fetch("api/chat/getchats?username=" + username);
    const res = await response.json();
    return res;
            
}