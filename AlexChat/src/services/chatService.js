export async function addChatService(model){
    const response = await fetch("api/chat/createchat/",
    {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(model)
    });
    const res = await response.json();
    return res;
}

export async function getChatsService(username){
    const response = await fetch("api/chat/getchats?username=" + username);
    return await response.json();
     
}



export async function searchUsersService(username){
    const response = await fetch("api/chat/searchusers?username=" + username);
    const res = await response.json();
    return res;
}
