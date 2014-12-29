using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfChat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService :IChatService
    {
        private ChatOptions mainOpt=new ChatOptions();

        public ChatUser ClientConnect(string userName)
        {
            return mainOpt.AddNewChatUser(new ChatUser() { UserName = userName });        
        }

        public List<ChatMessage> GetNewMessages(ChatUser user)
        {
            return mainOpt.GetNewMessages(user);
        }
    
        public void SendNewMessage(ChatMessage newMessage)
        {
            mainOpt.AddNewMessage(newMessage);
        }

        public List<ChatUser> GetAllUsers()
        {
            return mainOpt.ConectedUsers;
        }

        public void RemoveUser(ChatUser user)
        {
            mainOpt.RemoveUser(user);
        }

 
    }
}
