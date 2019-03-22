export async function getMessagesService(chatid){
    const response = await fetch("api/message/all?id=" + chatid);
    const res = await response.json();
    return res;
}
