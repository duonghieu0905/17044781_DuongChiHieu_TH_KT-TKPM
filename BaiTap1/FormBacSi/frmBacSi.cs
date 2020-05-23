using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Entities;

namespace FormBacSi
{
    public partial class frmBacSi : Form
    {
        eBenhNhan e;
        public frmBacSi()
        {
            
            InitializeComponent();
            

        }
        private void ReceiverThongTinQueue()
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            IConnection connection = factory.CreateConnection("admin", "admin");
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue queue = new ActiveMQQueue("DuongChiHieu_17044781_Queue");
            IMessageConsumer consumerqueue = session.CreateConsumer(queue);
            consumerqueue.Listener += Consumerqueue_Listener;
           
        }

        private void Consumerqueue_Listener(IMessage message)
        {
            ActiveMQTextMessage text = message as ActiveMQTextMessage;
             e = new ConvertXML<eBenhNhan>().XML2O(text.Text.ToString());
            AddToTreeQueue(e.MSBN);
        }

        private void ReceiverThongTinTopic()
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616"); 
            IConnection connection = factory.CreateConnection("admin", "admin");
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQTopic topic = new ActiveMQTopic("DuongChiHieu_17044781_Topic");
            IMessageConsumer consumertopic = session.CreateConsumer(topic);
            consumertopic.Listener += Consumertopic_Listener;
        }

        private void Consumertopic_Listener(IMessage message)
        {
           
            ActiveMQTextMessage text = message as ActiveMQTextMessage;
             e = new ConvertXML<eBenhNhan>().XML2O(text.Text.ToString());
            AddToTreeTopic(e.MSBN);
        }
        private void AddToTreeTopic(string s)
        {
            InvokeAddNode(treeView2, new TreeNode(s));
        }
        private void AddToTreeQueue(string s)
        {
            InvokeAddNode(treeView1, new TreeNode(s));
        }

        private void frmBacSi_Load(object sender, EventArgs e)
        {
            ReceiverThongTinQueue();
            ReceiverThongTinTopic();
        }
        public void InvokeAddNode(TreeView treeView, TreeNode node)
        {
            if (treeView.InvokeRequired)
            {
                treeView.Invoke(new MethodInvoker(() => { InvokeAddNode(treeView, node); }));
            }
            else
            {
                treeView.Nodes.Add(node);
            }
        }
    }
}
