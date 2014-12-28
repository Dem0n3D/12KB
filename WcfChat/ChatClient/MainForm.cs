﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WcfChat;
using System.ServiceModel;

namespace ChatClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblStatus.Text = "Disconnected";
        }

        private ChannelFactory<IChatService> remoteFactory;
        private IChatService remoteProxy;
        private ChatUser clientUser;
        private bool isConnected = false;


        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Connecting...";
                LoginForm loginDialog = new LoginForm();
                loginDialog.ShowDialog(this);
                if (!String.IsNullOrEmpty(loginDialog.UserName))
                {
                    remoteFactory = new ChannelFactory<IChatService>("ChatConfig");
                    remoteProxy = remoteFactory.CreateChannel();
                    clientUser = remoteProxy.ClientConnect(loginDialog.UserName);

                    if (clientUser != null)
                    {
                        usersTimer.Enabled = true;
                        messagesTimer.Enabled = true;
                        loginToolStripMenuItem.Enabled = false;
                        btnSend.Enabled = true;
                        txtMessage.Enabled = true;
                        isConnected = true;
                        lblStatus.Text = "Connected as : " + clientUser.UserName;
                    }
                }
                else
                    lblStatus.Text = "Disconnected";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Client cannot connect\nMessage:"+ex.Message,
                    "FATAL ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usersTimer_Tick(object sender, EventArgs e)
        {
            List<ChatUser> listUsers = remoteProxy.GetAllUsers();
            lstUsers.DataSource = listUsers;
        }

       

        private void messagesTimer_Tick(object sender, EventArgs e)
        {
            List<ChatMessage> messages = remoteProxy.GetNewMessages(clientUser);

            if (messages != null)
                foreach (var message in messages)
                    InsertMessage(message);
        }

        

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)            
            {
                btnSend_Click(sender, e);
                txtChat.Text = String.Empty;
            }

        }

    }
}
