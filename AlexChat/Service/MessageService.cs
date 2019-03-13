using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AlexChat.Models;
using AlexChat.Repository;
using AlexChat.ViewModels;
using AutoMapper;

namespace AlexChat.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepo _messageRepository;
        private readonly IMapper _mapper;
        public MessageService(IMessageRepo messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        public List<MessageViewModel> GetMessagesFor(int id)
        {
            var messages = _messageRepository.GetMessagesForChat(id).Result;
            var messagesViewModel = new List<MessageViewModel>();
            foreach (Message mes in messages)
            {
                messagesViewModel.Add(_mapper.Map<Message, MessageViewModel>(mes));
            }
            return messagesViewModel;
        }

        public void SendMessage(MessageViewModel message)
        {

            var mes = _mapper.Map<MessageViewModel, Message>(message);
            _messageRepository.SaveMessage(mes);
        }
        
    }
}
