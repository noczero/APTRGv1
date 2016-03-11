using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; //Draw
using System.Drawing.Drawing2D; //Draw
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using SerialCOM;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Configuration;
// Crypto
using System.Security.Cryptography.X509Certificates;
//System Net
using System.Net;
using System.Net.Sockets;

//Graphic
using ZedGraph;
//GMap
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
//Library 
using System.Net.NetworkInformation;
using System.Globalization;
using System.Xml; // config file
using System.Runtime.InteropServices; // dll imports
using System.Reflection;

//Sharp GL
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Cameras;
using SharpGL.SceneGraph.Collections;
using SharpGL.SceneGraph.Primitives;
using SharpGL.Serialization;
using SharpGL.SceneGraph.Core;
using SharpGL.Enumerations;
using SharpGL.SceneGraph.Assets;


namespace APTRGv1
{
    #region Public Enumerations
    public enum DataMode { Text, Hex }
    public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
    // Various colors for logging info
    //private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
    #endregion

    public partial class Form1 : Form
    {
        // Nambah Variable comm
        CommunicationManager comm = new CommunicationManager();

        static GUI_settings gui_settings;

        // Deklarasi variable

        static LineItem curve_acc_roll, curve_acc_pitch, curve_acc_z;
        static LineItem curve_gyro_roll, curve_gyro_pitch, curve_gyro_yaw, curve_thermo;
        static LineItem curve_alt, curve_head, curve_suhu, curve_cepat, curve_azimuth, curve_tekanan, curve_suhutinggi;

        static RollingPointPairList list_acc_roll, list_acc_pitch, list_acc_z, list_suhutinggi;
        static RollingPointPairList list_gyro_roll, list_gyro_pitch, list_gyro_yaw;
        static RollingPointPairList list_alt, list_thermo, list_suhu, list_tekanan, list_azimuth, list_cepat;

        static double xTimeStamp = 0;
        string data_suhu, data_lembab, data_tinggi, data_lat, data_lon, data_jarak, data_sudut, data_cepat, data_tekanan, c1, c2, c3, c4, c5, c6;
        double roll, pitch, yaw, a, t, bearing, cepat;
        float x, y, z, r, p, h;
        //int t, a;
        int head, tinggi;

        static Pen drawPen;
        static System.Drawing.SolidBrush drawBrush;
        static System.Drawing.Font drawFont;

        //For logging
        /*StreamWriter wLogStream;
        StreamWriter wKMLLogStream;
        static bool bLogRunning = false;
        static bool bKMLLogRunning = false;
        static UInt32 last_mode_flags;*/
        //Contains the mode flags from the pervious log write tick

        static Int16 nav_lat, nav_lon;
        static int GPS_lat_old, GPS_lon_old;
        static bool GPSPresent = true;
        static int iWindLat = 0;
        static int iWindLon = 0;
        static int iAngleLat = 0;
        static int iAngleLon = 0;
        static double SpeedLat = 0;
        static double SpeedLon = 0;


        // static int GPS_lat_old, GPS_lon_old;

        //Routes on Map
        static GMapRoute GMRouteFlightPath;
        //static GMapRoute GMRouteMission;

        //Map Overlays
        static GMapOverlay GMOverlayFlightPath;// static so can update from gcs
        static GMapOverlay GMOverlayWaypoints;
        static GMapOverlay GMOverlayMission;
        static GMapOverlay GMOverlayLiveData;
        //static GMapOverlay GMOverlayPOI;

        static GMapProvider[] mapProviders;
        //static PointLatLng copterPos = new PointLatLng(47.402489, 19.071558);       //Just the corrds of my flying place
        static PointLatLng copterPos = new PointLatLng(-6.976901, 107.630193);
        // static PointLatLng copterPos = new PointLatLng(-7.788435, 109.664855);
        static bool isMouseDown = false;
        static bool isMouseDraging = false;

        static bool bPosholdRecorded = false;
        static bool bHomeRecorded = false;

        // markers
        GMarkerGoogle currentMarker;
        GMapMarkerRect CurentRectMarker = null;
        GMapMarker center;
        GMapMarker markerGoToClick = new GMarkerGoogle(new PointLatLng(0.0, 0.0), GMarkerGoogleType.lightblue);

        List<PointLatLng> points = new List<PointLatLng>();

        PointLatLng GPS_pos, GPS_pos_old;
        PointLatLng end;
        PointLatLng start;

        #region Local Properties
        private DataMode CurrentDataMode
        {
            get
            {
                if (radioButton1.Checked) return DataMode.Hex;
                else return DataMode.Text;
            }
            set
            {
                if (value == DataMode.Text) radioButton1.Checked = true;
                else radioButton2.Checked = true;
            }
        }
        #endregion
            
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
                    }

        string kata;
        string[] wordss;
        //  int xTimeStamp = 1;
        //string header, sAccx, sAccy, sAccz, sgrX, sgrY, sgrZ, ssuhu, sketinggian, slat, slng;

        string header, suhu, kelembaban, ketinggian, tekanan, latitude, longitude, jarak, sudut, kecepatan;

        //public delegate void myDelegate();
        //private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    kata = serialPort1.ReadLine();
        //    wordss = Regex.Split(kata, " ");
        //}
        private void FastTimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {

            //kata = serialPort1.ReadExisting();
            string[] tempArray = comm.DisplayWindow.Lines;
            string line = tempArray[tempArray.Length - 2];
            wordss = Regex.Split(line, " ");

            if (line == "")
                return;

            header = wordss[0];
            suhu = wordss[1];
            kelembaban = wordss[2];
            ketinggian = wordss[3];
            tekanan = wordss[4];
            latitude = wordss[5];
            longitude = wordss[6];
            jarak = wordss[7];
            sudut = wordss[8];
            kecepatan = wordss[9];

            attitudeIndicatorInstrumentControl1.SetAttitudeIndicatorParameters(Convert.ToDouble(latitude), Convert.ToDouble(longitude));
            airSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters(Convert.ToInt32(kecepatan));
            verticalSpeedIndicatorInstrumentControl1.SetVerticalSpeedIndicatorParameters(Convert.ToInt32(ketinggian));
            
            
            richTextBox1.Invoke(new EventHandler(delegate
            {
                textBox1.Text = suhu + " Celcius";
                textBox2.Text = kelembaban + " %";
                textBox3.Text = ketinggian + " mdpl";
                textBox4.Text = Convert.ToString(Convert.ToDouble(tekanan) / 100) + " Pa";
                textBox5.Text = latitude;
                textBox6.Text = longitude;
                textBox7.Text = jarak + " Km";
                textBox8.Text = sudut + " Derajat";
                textBox9.Text = kecepatan + " Km/Jam";
              //  label18.Text = data_sudut + " Derajat";
             //   label25.Text = data_cepat + " Km/Jam";
                //richTextBox2.AppendText(line);
            }));

            //Menampilkan Data di Text Box

            //textBox1.Text = suhu;
            //textBox2.Text = kelembaban;
            //textBox3.Text = ketinggian;
            //textBox4.Text = tekanan;
            //textBox5.Text = latitude;
            //textBox6.Text = longitude;
            //textBox7.Text = jarak;
            //textBox8.Text = sudut;
            //textBox9.Text = kecepatan;


            //MAP
            GMOverlayLiveData.Markers.Clear();
            MainMap.Position = GPS_pos;
            GMOverlayLiveData.Markers.Add(new GMapMarkerCopter(GPS_pos, float.Parse(sudut), 0, 0));
            MainMap.Invalidate(false);


        }


        //Port Name
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            //string[] ports = SerialPort.GetPortNames(); //nyari port/terminal yang tersedia, dimasukin ke array of string

            /*public List<string> GetAllPorts()
            {            List<String> allPorts = new List<String>();
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                allPorts.Add(portName);
            }
            return allPorts;
            //comboBox1.Items.Add(allPorts);

             }*/
            /*if (intlen != ports.Length)
            {
                intlen = ports.Length;
                comboBox1.Items.Clear();
                for (int j = 0; j < intlen; j++)
                {
                    comboBox1.Items.Add(ports[j]);
                }
                comboBox1.Text = ports[0];
            //}*/

            //hapus tex yg ada di combo box, karena bekas yang lama 
            comboBox1.Items.Clear();
            comm.SetPortNameValues(comboBox1);

            /*foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }*/

            //setiap port yang terbuka, masukin namanya ke combobox
            /*foreach (String portName in ports)
            {
                comboBox1.Items.Add(portName);
            }*/
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

        //double roll, pitch, yaw, a, t, bearing, cepat;
       // float x, y, z, r, p, h;
        private void update_gui()
        {
            // if (tabControl1.SelectedIndex == 2)
            //{


            /*GMRouteFlightPath.Points.Add(GPS_pos);
            MainMap.Position = GPS_pos;
            MainMap.Invalidate(false);*/

            //----lGPS_lat.Text = Convert.ToString((decimal)mw_gui.GPS_latitude / 10000000);
            //----lGPS_lon.Text = Convert.ToString((decimal)mw_gui.GPS_longitude / 10000000);

            //----PointLatLng GPS_home = new PointLatLng((double)mw_gui.GPS_home_lat / 10000000, (double)mw_gui.GPS_home_lon / 10000000);
            //----GMOverlayLiveData.Markers.Add(new GMapMarkerHome(GPS_home));


            //MainMap.Invalidate(false);
            //}

            //if (tabControl1.SelectedIndex == 0)
            //{
            //if (checkBox1.Checked) { list_acc_roll.Add(xTimeStamp, Convert.ToDouble(data_suhu)); }
            //if (checkBox2.Checked) { list_acc_pitch.Add(xTimeStamp, Convert.ToDouble(data_lembab)); }
            //if (checkBox3.Checked) { list_acc_z.Add(xTimeStamp, Convert.ToDouble(data_tinggi)); }
            //if (checkBox4.Checked) { list_gyro_roll.Add(xTimeStamp, Convert.ToDouble(data_jarak)); }
            //if (checkBox5.Checked) { list_gyro_pitch.Add(xTimeStamp, Double.Parse(data_sudut)); }
            //if (checkBox6.Checked) { list_gyro_yaw.Add(xTimeStamp, Double.Parse(data_cepat)); }
            //if (checkBox7.Checked) { list_alt.Add(xTimeStamp, Convert.ToDouble(data_)); }
            //if (checkBox8.Checked) { list_thermo.Add(xTimeStamp, Convert.ToDouble(data_t)); }



            xTimeStamp = xTimeStamp + 1;
            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            if (xTimeStamp > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = xTimeStamp + xScale.MajorStep;
                xScale.Min = xScale.Max - 30.0;
            }

            zedGraphControl1.AxisChange();

            zedGraphControl1.Invalidate();

            //curve_acc_roll.IsVisible = checkBox1.Checked;
            //curve_acc_pitch.IsVisible = checkBox2.Checked;
            //curve_acc_z.IsVisible = checkBox3.Checked;
            //curve_gyro_roll.IsVisible = checkBox4.Checked;
            //curve_gyro_pitch.IsVisible = checkBox5.Checked;
            //curve_gyro_yaw.IsVisible = checkBox6.Checked;
            //curve_alt.IsVisible = checkBox7.Checked;
            //curve_thermo.IsVisible = checkBox8.Checked;

            //grafik berparameter ketinggian
            //list_azimuth.Add(Convert.ToDouble(data_sudut),Convert.ToDouble(data_tinggi));
            //list_cepat.Add(Convert.ToDouble(data_cepat), Convert.ToDouble(data_tinggi));
            //list_suhu.Add(Convert.ToDouble(data_suhu), Convert.ToDouble(data_tekanan),Convert.ToDouble(data_tinggi));

            //foreach (Polygon polygon in polygons)
            //{
            //    polygon.Transformation.RotateX = r;
            //    polygon.Transformation.RotateY = y;
            //    polygon.Transformation.RotateZ = p;
            //}
            ////}
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            update_gui();
        }

        public Form1()
        {
            InitializeComponent();
            //  Get the OpenGL object, for quick access.
         //   SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            timer1.Tick += new EventHandler(timer1_Tick);
   //         gl.Enable(OpenGL.GL_TEXTURE_2D);
            //backgroundWorker1.WorkerSupportsCancellation = true;
            //backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            //worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            GPS_pos.Lat = 47.402489;
            GPS_pos.Lng = 19.071558;
            #region map_setup
            // config map             
            MainMap.MinZoom = 1;
            MainMap.MaxZoom = 20;
            MainMap.CacheLocation = Path.GetDirectoryName(Application.ExecutablePath) + "/mapcache/";

            mapProviders = new GMapProvider[7];
            mapProviders[0] = GMapProviders.BingHybridMap;
            mapProviders[1] = GMapProviders.BingSatelliteMap;
            mapProviders[2] = GMapProviders.GoogleSatelliteMap;
            mapProviders[3] = GMapProviders.GoogleHybridMap;
            mapProviders[4] = GMapProviders.OviSatelliteMap;
            mapProviders[5] = GMapProviders.OviHybridMap;

            /*mapProviders = new GMapProvider[9];
            mapProviders[0] = BingHybridMapProvider.Instance;
            mapProviders[1] = BingSatelliteMapProvider.Instance;
            mapProviders[2] = GoogleSatelliteMapProvider.Instance;
            mapProviders[3] = GoogleHybridMapProvider.Instance;
            mapProviders[4] = OviMapProvider.Instance;
            mapProviders[5] = OviHybridMapProvider.Instance;
            mapProviders[6] = OpenStreetMapProvider.Instance;
            mapProviders[7] = ArcGIS_World_Street_MapProvider.Instance;
            mapProviders[8] = ArcGIS_DarbAE_Q2_2011_NAVTQ_Eng_V5_MapProvider.Instance;*/

            for (int i = 0; i < 6; i++)
            {
                cbMapProviders.Items.Add(mapProviders[i]);
            }

            // map events

            MainMap.OnPositionChanged += new PositionChanged(MainMap_OnCurrentPositionChanged);
            //MainMap.OnMarkerClick += new MarkerClick(MainMap_OnMarkerClick);
            MainMap.OnMapZoomChanged += new MapZoomChanged(MainMap_OnMapZoomChanged);
            MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
            MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
            MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);
            MainMap.OnMarkerEnter += new MarkerEnter(MainMap_OnMarkerEnter);
            MainMap.OnMarkerLeave += new MarkerLeave(MainMap_OnMarkerLeave);

            currentMarker = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.red);
            //MainMap.MapScaleInfoEnabled = true;

            MainMap.ForceDoubleBuffer = true;
            MainMap.Manager.Mode = AccessMode.ServerAndCache;

            MainMap.Position = copterPos;

            Pen penRoute = new Pen(Color.Yellow, 3);
            Pen penScale = new Pen(Color.Blue, 3);

            MainMap.ScalePen = penScale;

            GMOverlayFlightPath = new GMapOverlay("flightpath");
            MainMap.Overlays.Add(GMOverlayFlightPath);

            GMOverlayMission = new GMapOverlay("missionroute");
            MainMap.Overlays.Add(GMOverlayMission);

            GMOverlayWaypoints = new GMapOverlay("waypoints");
            MainMap.Overlays.Add(GMOverlayWaypoints);


            GMOverlayLiveData = new GMapOverlay("livedata");
            MainMap.Overlays.Add(GMOverlayLiveData);

            GMOverlayLiveData.Markers.Clear();
            GMOverlayLiveData.Markers.Add(new GMapMarkerCopter(copterPos, 0, 0, 0));

            GMRouteFlightPath = new GMapRoute(points, "flightpath");
            GMRouteFlightPath.Stroke = penRoute;
            GMOverlayFlightPath.Routes.Add(GMRouteFlightPath);

            center = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.blue_dot);
            //center = new GMapMarkerCross(MainMap.Position);

            MainMap.Invalidate(false);
            //MainMap.Refresh();
            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //—menset event handler untuk DataReceived event—
            // serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);

            //vertical_speed_indicator1.SetVerticalSpeedIndicatorParameters(60000);

            //headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters(280);
            tabPage1.Hide();

            //Set up zgMonitor control for real time monitoring
            GraphPane myPane = zedGraphControl5.GraphPane;
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";

            // Save 1200 points.  At 50 ms sample rate, this is one minute
            // The RollingPointPairList is an efficient storage class that always
            // keeps a rolling set of point data without needing to shift any data values
            //RollingPointPairList list = new RollingPointPairList(1200);

            // Initially, a curve is added with no data points (list is empty)
            // Color is blue, and there will be no symbols
            //Set up pointlists and curves
            list_acc_roll = new RollingPointPairList(300);
            curve_acc_roll = myPane.AddCurve("acc_roll", list_acc_roll, Color.Red, SymbolType.None);

            list_acc_pitch = new RollingPointPairList(300);
            curve_acc_pitch = myPane.AddCurve("acc_pitch", list_acc_pitch, Color.Yellow, SymbolType.None);

            list_acc_z = new RollingPointPairList(300);
            curve_acc_z = myPane.AddCurve("acc_z", list_acc_z, Color.Blue, SymbolType.None);

            list_gyro_roll = new RollingPointPairList(300);
            curve_gyro_roll = myPane.AddCurve("gyro_roll", list_gyro_roll, Color.Khaki, SymbolType.None);

            list_gyro_pitch = new RollingPointPairList(300);
            curve_gyro_pitch = myPane.AddCurve("gyro_pitch", list_gyro_pitch, Color.Cyan, SymbolType.None);

            list_gyro_yaw = new RollingPointPairList(300);
            curve_gyro_yaw = myPane.AddCurve("gyro_yaw", list_gyro_yaw, Color.Magenta, SymbolType.None);

            list_alt = new RollingPointPairList(300);
            curve_alt = myPane.AddCurve("altitude", list_alt, Color.Green, SymbolType.None);

            list_thermo = new RollingPointPairList(300);
            curve_thermo = myPane.AddCurve("thermo", list_thermo, Color.DarkOliveGreen, SymbolType.None);

            // Sample at 50ms intervals
            //timer1.Interval = 50;
            //timer1.Enabled = true;
            //timer1.Start();

            // Just manually control the X axis range so it scrolls continuously
            // instead of discrete step-sized jumps
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.DarkGray;
            myPane.YAxis.MajorGrid.Color = Color.DarkGray;

            //myPane.Border.Color = Color.FromArgb(64, 64, 64);

            myPane.Chart.Fill = new Fill(Color.Black, Color.Black, 45.0f);
            //myPane.Fill = new Fill(Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64), 45.0f);
            myPane.Legend.IsVisible = false;
            myPane.XAxis.Scale.IsVisible = true;
            myPane.YAxis.Scale.IsVisible = true;


            foreach (ZedGraph.LineItem li in myPane.CurveList)
            {
                li.Line.Width = 6;
            }

            // Scale the axes
            zedGraphControl5.AxisChange();

            // Save the beginning time for reference

            GraphPane suhutinggi_g = zedGraphControl1.GraphPane;
            list_suhutinggi = new RollingPointPairList(30000);
            curve_suhutinggi = suhutinggi_g.AddCurve("Suhu", list_suhutinggi, Color.Red, SymbolType.None);

            suhutinggi_g.Title.Text = "";
            suhutinggi_g.XAxis.Title.Text = "Suhu (Celcius)";
            suhutinggi_g.YAxis.Title.Text = "Ketinggian (Meter)";
            //suhutinggi_g.YAxis.Scale.IsReverse = true;
            /*suhutekanan_g.YAxis.Scale.Min = 10;
            suhutekanan_g.YAxis.Scale.Max = 100;
            suhutekanan_g.YAxis.Scale.MinorStep = 1;
            suhutekanan_g.YAxis.Scale.MajorStep = 5;*/

            suhutinggi_g.XAxis.Scale.Min = -50;
            suhutinggi_g.XAxis.Scale.Max = 50;
            suhutinggi_g.XAxis.Scale.MinorStep = 1;
            suhutinggi_g.XAxis.Scale.MajorStep = 5;

            suhutinggi_g.YAxis.Scale.Min = 0;
            suhutinggi_g.YAxis.Scale.Max = 1000;
            //suhutinggi_g.YAxis.Scale.Max = 20;
            suhutinggi_g.YAxis.Scale.MinorStep = 1;
            suhutinggi_g.YAxis.Scale.MajorStep = 5;

            // suhutinggi_g.XAxis.MajorGrid.IsVisible = true;
            //suhutinggi_g.YAxis.MajorGrid.IsVisible = true;
            //suhutekanan_g.Y2Axis.MajorGrid.IsVisible = true;

            suhutinggi_g.XAxis.Scale.IsVisible = true;
            suhutinggi_g.YAxis.Scale.IsVisible = true;

            foreach (ZedGraph.LineItem li in suhutinggi_g.CurveList)
            {
                li.Line.Width = 3;
            }

            //list_suhutinggi.Add(30, 100);

            zedGraphControl1.AxisChange();

            GraphPane suhutekanan_g = zedGraphControl2.GraphPane;
            suhutekanan_g.Title.Text = "";
            suhutekanan_g.XAxis.Title.Text = "Kelembaban (%)";
            suhutekanan_g.YAxis.Title.Text = "Ketinggian(mdpl)";
            list_suhu = new RollingPointPairList(30000);
            curve_suhu = suhutekanan_g.AddCurve("Kelembaban", list_suhu, Color.Red, SymbolType.None);

            //suhutekanan_g.YAxis.Scale.IsReverse = true;
            suhutekanan_g.YAxis.Scale.Min = 0;
            suhutekanan_g.YAxis.Scale.Max = 1000;
            suhutekanan_g.YAxis.Scale.MinorStep = 1;
            suhutekanan_g.YAxis.Scale.MajorStep = 5;

            suhutekanan_g.XAxis.Scale.Min = -30;
            suhutekanan_g.XAxis.Scale.Max = 150;
            suhutekanan_g.XAxis.Scale.MinorStep = 1;
            suhutekanan_g.XAxis.Scale.MajorStep = 5;

            //suhutekanan_g.XAxis.MajorGrid.IsVisible = true;
            //suhutekanan_g.YAxis.MajorGrid.IsVisible = true;
            //suhutekanan_g.Y2Axis.MajorGrid.IsVisible = true;

            suhutekanan_g.XAxis.Scale.IsVisible = true;
            suhutekanan_g.YAxis.Scale.IsVisible = true;
            //suhutekanan_g.Y2Axis.Scale.IsVisible = true;
            foreach (ZedGraph.LineItem li in suhutekanan_g.CurveList)
            {
                li.Line.Width = 3;
            }
            //list_suhutinggi.Add(30, 30);
            zedGraphControl2.AxisChange();

            GraphPane kecepatan_g = zedGraphControl3.GraphPane;
            kecepatan_g.Title.Text = "";
            kecepatan_g.XAxis.Title.Text = "Kecepatan Angin (Km/Jam)";
            kecepatan_g.YAxis.Title.Text = "Ketinggian (mdpl)";
            list_cepat = new RollingPointPairList(30000);
            curve_cepat = kecepatan_g.AddCurve("Kecepatan", list_cepat, Color.Blue, SymbolType.None);

            kecepatan_g.XAxis.Scale.Min = 0;
            kecepatan_g.XAxis.Scale.Max = 60;
            kecepatan_g.XAxis.Scale.MinorStep = 1;
            kecepatan_g.XAxis.Scale.MajorStep = 5;

            kecepatan_g.YAxis.Scale.Min = 0;
            kecepatan_g.YAxis.Scale.Max = 1000;
            //suhutinggi_g.YAxis.Scale.Max = 20;
            kecepatan_g.YAxis.Scale.MinorStep = 1;
            kecepatan_g.YAxis.Scale.MajorStep = 5;

            foreach (ZedGraph.LineItem li in kecepatan_g.CurveList)
            {
                li.Line.Width = 3;
            }

            zedGraphControl3.AxisChange();

            GraphPane azimuth_g = zedGraphControl4.GraphPane;
            azimuth_g.Title.Text = "";
            azimuth_g.XAxis.Title.Text = "Tekanan (Pa)";
            azimuth_g.YAxis.Title.Text = "Ketinggian (mdpl)";
            list_azimuth = new RollingPointPairList(30000);
            curve_azimuth = azimuth_g.AddCurve("Tekanan", list_azimuth, Color.Blue, SymbolType.None);

            /*azimuth_g.XAxis.Scale.Min = 0;
            azimuth_g.XAxis.Scale.Max = 360;
            azimuth_g.XAxis.Scale.MinorStep = 1;
            azimuth_g.XAxis.Scale.MajorStep = 5;*/

            azimuth_g.YAxis.Scale.Min = 0;
            azimuth_g.YAxis.Scale.Max = 1000;

            azimuth_g.YAxis.Scale.MinorStep = 1;
            azimuth_g.YAxis.Scale.MajorStep = 5;

            foreach (ZedGraph.LineItem li in azimuth_g.CurveList)
            {
                li.Line.Width = 3;
            }

            zedGraphControl4.AxisChange();

            gui_settings = new GUI_settings();
            // MAP
          //  cbMapProviders.SelectedIndex = gui_settings.iMapProviderSelectedIndex;
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            if (!Stuff.PingNetwork("pingtest.com"))
            {
                MainMap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection available, going to CacheOnly mode.", "GMap.NET - Demo.WindowsForms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

          //  cbMapProviders.SelectedIndex = gui_settings.iMapProviderSelectedIndex;
          //  MainMap.MapProvider = mapProviders[gui_settings.iMapProviderSelectedIndex];
            //MainMap.MapProvider = BingHybridMapProvider.Instance;
            MainMap.Zoom = 18;
            MainMap.Invalidate(false);

            int w = MainMap.Size.Width;
            MainMap.Width = w + 1;
            MainMap.Width = w;
            MainMap.ShowCenter = false;
        }
        //MANAGE DATA

       
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
           
            if (comm.isOpen() == true)
            {
                button1.Text = "Connect";
             //   button1.Image = Properties.Resources.connect;

                //backgroundWorker1.CancelAsync();
                System.Threading.Thread.Sleep(100);
                comm.ClosePort();

                //timer1.Stop();
                timer1.Enabled = false;
            }
            else
            {
                if (comboBox1.Text == "") { return; }  //if no port selected then do nothin' at connect
                //Assume that the selection in the combobox for port is still valid
                //—mengatur beberapa parameter untuk koneksi serialport                                                   
                /*serialPort1.PortName = comboBox1.Text; //nama port/terminal-nya
                serialPort1.BaudRate = int.Parse(comboBox2.Text); //baudrate-kecepatan data, konversi dari string ke integer
                serialPort1.Parity = System.IO.Ports.Parity.None; 
                serialPort1.DataBits = 8; //terima-kirim 8 bit
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;*/

                comm.Parity = "None";
                comm.StopBits = "One";
                comm.DataBits = "8";
                comm.BaudRate = comboBox2.Text;
                comm.DisplayWindow = richTextBox1;
                comm.PortName = comboBox1.Text;
                comm.OpenPort();

                //fasttimer = new Timer();         // Set up the timer for 3 seconds
               // Manggil Fast Timer Event Processor
                
                timer1.Tick += new EventHandler(FastTimerEventProcessor);
                timer1.Interval = 100;
                timer1.Enabled = true;
                timer1.Start();



                button1.Text = "DC";
               // button1.Image = Properties.Resources.disconnect;

                /*
                //Run BackgroundWorker
                if (!backgroundWorker1.IsBusy)
                {
                    try
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                    catch { MessageBox.Show("ga jalan euy"); }
                }
                    
                System.Threading.Thread.Sleep(1000);*/
            }
        }
        // Gmaps MAin Map

        // MapZoomChanged
        void MainMap_OnMapZoomChanged()
        {
            if (MainMap.Zoom > 0)
            {
                //tb_mapzoom.Value = (int)(MainMap.Zoom);
                center.Position = MainMap.Position;
            }
        }

        // current point changed
        void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            if (point.Lat > 90) { point.Lat = 90; }
            if (point.Lat < -90) { point.Lat = -90; }
            if (point.Lng > 180) { point.Lng = 180; }
            if (point.Lng < -180) { point.Lng = -180; }
            center.Position = point;
            //LMousePos.Text = "Lat:" + String.Format("{0:0.000000}", point.Lat) + " Lon:" + String.Format("{0:0.000000}", point.Lng);

        }

        void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is GMapMarkerRect)
                {

                    CurentRectMarker = null;

                    GMapMarkerRect rc = item as GMapMarkerRect;
                    rc.Pen.Color = Color.Blue;
                    MainMap.Invalidate(false);
                }
            }
        }

        void MainMap_OnMarkerEnter(GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is GMapMarkerRect)
                {
                    GMapMarkerRect rc = item as GMapMarkerRect;
                    rc.Pen.Color = Color.Red;
                    MainMap.Invalidate(false);

                    CurentRectMarker = rc;
                }
            }
        }

        void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            end = MainMap.FromLocalToLatLng(e.X, e.Y);

            if (isMouseDown) // mouse down on some other object and dragged to here.
            {
                if (e.Button == MouseButtons.Left)
                {
                    isMouseDown = false;
                }
                if (!isMouseDraging)
                {
                    if (CurentRectMarker != null)
                    {
                        // cant add WP in existing rect
                    }
                    else
                    {
                        //addWP("WAYPOINT", 0, currentMarker.Position.Lat, currentMarker.Position.Lng, iDefAlt);
                    }
                }
                else
                {
                    if (CurentRectMarker != null)
                    {
                        //update existing point in datagrid
                    }
                }
            }
            if (comm.isOpen() == true) timer1.Start();
            isMouseDraging = false;
        }

        void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            start = MainMap.FromLocalToLatLng(e.X, e.Y);

            if (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.Alt)
            {
                isMouseDown = true;
                isMouseDraging = false;

                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
            }
        }

        // move current marker with left holding
        void MainMap_MouseMove(object sender, MouseEventArgs e)
        {

            PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);

            currentMarker.Position = point;
           // label23.Text = "Lat:" + String.Format("{0:0.000000}", point.Lat) + " Lon:" + String.Format("{0:0.000000}", point.Lng);

            if (!isMouseDown)
            {

            }


            //draging
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                isMouseDraging = true;
                if (CurentRectMarker == null) // left click pan
                {
                    double latdif = start.Lat - point.Lat;
                    double lngdif = start.Lng - point.Lng;
                    MainMap.Position = new PointLatLng(center.Position.Lat + latdif, center.Position.Lng + lngdif);
                }
                else
                {
                   // if (comm.isOpen() == true) timer1.Stop();
                    PointLatLng pnew = MainMap.FromLocalToLatLng(e.X, e.Y);
                    if (currentMarker.IsVisible)
                    {
                        currentMarker.Position = pnew;
                    }
                    CurentRectMarker.Position = pnew;

                    if (CurentRectMarker.InnerMarker != null)
                    {
                        CurentRectMarker.InnerMarker.Position = pnew;
                        GPS_pos = pnew;
                    }
                }
            }
        }

        private void cbMapProviders_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            //MainMap.MapProvider = GMapProviders.GoogleSatelliteMap;
            MainMap.MapProvider = (GMapProvider)cbMapProviders.SelectedItem;
            MainMap.MinZoom = 5;
            MainMap.MaxZoom = 20;
            MainMap.Zoom = 18;
            MainMap.Invalidate(false);
            gui_settings.iMapProviderSelectedIndex = cbMapProviders.SelectedIndex;
            //gui_settings.save_to_xml(sGuiSettingsFilename);


            this.Cursor = Cursors.Default;

        }


        // Gmaps Marker
        public class GMapMarkerRect : GMapMarker
        {
            public Pen Pen = new Pen(Brushes.White, 2);

            public Color Color { get { return Pen.Color; } set { Pen.Color = value; } }

            public GMapMarker InnerMarker;

            public int wprad = 0;
            public GMapControl MainMap;

            public GMapMarkerRect(PointLatLng p)
                : base(p)
            {
                Pen.DashStyle = DashStyle.Dash;

                // do not forget set Size of the marker
                // if so, you shall have no event on it ;}
                Size = new System.Drawing.Size(50, 50);
                Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2 - 20);
            }

            public override void OnRender(Graphics g)
            {
                base.OnRender(g);

                if (wprad == 0 || MainMap == null)
                    return;

                // undo autochange in mouse over
                if (Pen.Color == Color.Blue)
                    Pen.Color = Color.White;

                double width = (MainMap.MapProvider.Projection.GetDistance(MainMap.FromLocalToLatLng(0, 0), MainMap.FromLocalToLatLng(MainMap.Width, 0)) * 1000.0);
                double height = (MainMap.MapProvider.Projection.GetDistance(MainMap.FromLocalToLatLng(0, 0), MainMap.FromLocalToLatLng(MainMap.Height, 0)) * 1000.0);
                double m2pixelwidth = MainMap.Width / width;
                double m2pixelheight = MainMap.Height / height;

                GPoint loc = new GPoint((int)(LocalPosition.X - (m2pixelwidth * wprad * 2)), LocalPosition.Y);// MainMap.FromLatLngToLocal(wpradposition);
                g.DrawArc(Pen, new System.Drawing.Rectangle((int)(LocalPosition.X - Offset.X - (Math.Abs(loc.X - LocalPosition.X) / 2)), (int)(LocalPosition.Y - Offset.Y - Math.Abs(loc.X - LocalPosition.X) / 2), (int)(Math.Abs(loc.X - LocalPosition.X)), (int)(Math.Abs(loc.X - LocalPosition.X))), 0, 360);

            }
        }

        public class GMapMarkerCopter : GMapMarker
        {
            const float rad2deg = (float)(180 / Math.PI);
            const float deg2rad = (float)(1.0 / rad2deg);

          //  static readonly System.Drawing.Size SizeSt = new System.Drawing.Size(global::APTRGv1.Properties.Resources.marker_quadx.Width, global::APTRGv1.Properties.Resources.marker_quadx.Height);
            float heading = 0;
            float cog = -1;
            float target = -1;
            //byte coptertype;

            //public GMapMarkerCopter(PointLatLng p, float heading, float cog, float target, byte coptertype)
            public GMapMarkerCopter(PointLatLng p, float heading, float cog, float target)
                : base(p)
            {
                this.heading = heading;
                this.cog = cog;
                this.target = target;
                //this.coptertype = coptertype;
     //           Size = SizeSt;
            }

            public override void OnRender(Graphics g)
            {
                System.Drawing.Drawing2D.Matrix temp = g.Transform;
                g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

      //          Image pic = global::APTRGv1.Properties.Resources.marker_quadx;


                int length = 100;
                // anti NaN
                g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float)Math.Cos((heading - 90) * deg2rad) * length, (float)Math.Sin((heading - 90) * deg2rad) * length);
                //g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length, (float)Math.Sin((cog - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length, (float)Math.Sin((target - 90) * deg2rad) * length);
                // anti NaN
                g.RotateTransform(heading);
   //             g.DrawImageUnscaled(pic, pic.Width / -2, pic.Height / -2);
                g.Transform = temp;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //timer1.Stop();                       //Stop timer(s), whatever it takes
            //backgroundWorker1.CancelAsync();
            //System.Threading.Thread.Sleep(500);         //Wait for 1 cycle to let backgroundworker finish it's last job.
            comm.ClosePort();
            Close();
        }

        public class GUI_settings
        {
            public int iMapProviderSelectedIndex { get; set; }
            public GUI_settings()
            {
                iMapProviderSelectedIndex = 1;  //Bing Map
            }
        }


        public class Stuff
        {
            public static bool PingNetwork(string hostNameOrAddress)
            {
                bool pingStatus = false;

                using (Ping p = new Ping())
                {
                    byte[] buffer = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                    int timeout = 4444; // 4s

                    try
                    {
                        PingReply reply = p.Send(hostNameOrAddress, timeout, buffer);
                        pingStatus = (reply.Status == IPStatus.Success);
                    }
                    catch (Exception)
                    {
                        pingStatus = false;
                    }
                }

                return pingStatus;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            RectLatLng area = MainMap.SelectedArea;
            if (area.IsEmpty)
            {
                DialogResult res = MessageBox.Show("No ripp area defined, ripp displayed on screen?", "Rip", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    area = MainMap.ViewArea;
                }
            }

            if (!area.IsEmpty)
            {
                DialogResult res = MessageBox.Show("Ready ripp at Zoom = " + (int)MainMap.Zoom + " ?", "GMap.NET", MessageBoxButtons.YesNo);

                for (int i = 1; i <= MainMap.MaxZoom; i++)
                {
                    if (res == DialogResult.Yes)
                    {
                        TilePrefetcher obj = new TilePrefetcher();
                        obj.ShowCompleteMessage = false;
                        obj.Start(area, i, MainMap.MapProvider, 100, 0);

                    }
                    else if (res == DialogResult.No)
                    {
                        continue;
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comm.WriteData("1");
        }

       



    }
}
