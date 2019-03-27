export async function getMessagesService(chatid){
    const response = await fetch("api/message/all?id=" + chatid);
    const res = response.json();
    return res;
}
