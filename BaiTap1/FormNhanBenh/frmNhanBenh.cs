using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using Apache.NMS.ActiveMQ.Commands;

namespace FormNhanBenh
{
    public partial class frmNhanBenh : Form
    {
        public frmNhanBenh()
        {
            InitializeComponent();
        }
        private void SendThongTinTopic(eBenhNhan bn)
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            IConnection connection = factory.CreateConnection("admin", "admin");
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQTopic topic = new ActiveMQTopic("DuongChiHieu_17044781_Topic");
            IMessageProducer producer = session.CreateProducer(topic);
            producer.Send(new ConvertXML<eBenhNhan>().O2XML(bn));
        }
        private void SendThongTinQueue(eBenhNhan bn)
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            IConnection connection = factory.CreateConnection("admin", "admin");
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue queue = new ActiveMQQueue("DuongChiHieu_17044781_Queue");
            IMessageProducer producer = session.CreateProducer(queue);
            producer.Send(new ConvertXML<eBenhNhan>().O2XML(bn));
            producer.Close();
            session.Close();
            connection.Close();

        }

        private eBenhNhan ConvertTextToEntity()
        {
            eBenhNhan e= new eBenhNhan { DIACHI=textBox4.Text.ToString(),HOTEN=textBox3.Text.ToString(),MSBN=textBox1.Text.ToString(),SOCMND=textBox2.Text.ToString()};       
            return e;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendThongTinTopic(ConvertTextToEntity());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendThongTinQueue(ConvertTextToEntity());
        }
    }
}
