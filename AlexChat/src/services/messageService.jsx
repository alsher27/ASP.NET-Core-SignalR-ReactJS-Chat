
export async function getMessages(chatid){
    const response = await fetch("api/chat/searchusers?username=" + chatid);
    const res = await response.json();
    return res;
}
