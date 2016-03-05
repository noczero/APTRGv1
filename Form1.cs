using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using SerialCOM;

namespace APTRGv1
{
    public partial class Form1 : Form
    {
        // Nambah Variable comm
        CommunicationManager comm = new CommunicationManager();

        static GUI_settings gui_settings;

        // Deklarasi variable

        //static LineItem curve_acc_roll, curve_acc_pitch, curve_acc_z;
        //static LineItem curve_gyro_roll, curve_gyro_pitch, curve_gyro_yaw, curve_thermo;
        //static LineItem curve_alt, curve_head, curve_suhu, curve_cepat, curve_azimuth, curve_tekanan, curve_suhutinggi;

        //static RollingPointPairList list_acc_roll, list_acc_pitch, list_acc_z, list_suhutinggi;
        //static RollingPointPairList list_gyro_roll, list_gyro_pitch, list_gyro_yaw;
        //static RollingPointPairList list_alt, list_thermo, list_suhu, list_tekanan, list_azimuth, list_cepat;

        static double xTimeStamp = 0;
        string data_suhu, data_lembab, data_tinggi, data_lat, data_lon, data_jarak, data_sudut, data_cepat, data_tekanan, c1, c2, c3, c4, c5, c6;

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
                    }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        double roll, pitch, yaw, a, t, bearing, cepat;
        float x, y, z, r, p, h;

        public class GUI_settings
        {
            public int iMapProviderSelectedIndex { get; set; }
            public GUI_settings()
            {
                iMapProviderSelectedIndex = 1;  //Bing Map
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void attitudeIndicatorInstrumentControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comm.isOpen()) ;
        }
    }
}
