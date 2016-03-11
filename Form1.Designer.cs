namespace APTRGv1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.cbMapProviders = new System.Windows.Forms.ComboBox();
            this.MainMap = new GMap.NET.WindowsForms.GMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.zedGraphControl5 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl4 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.attitudeIndicatorInstrumentControl1 = new APTRGv1.AttitudeIndicatorInstrumentControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.airSpeedIndicatorInstrumentControl1 = new APTRGv1.AirSpeedIndicatorInstrumentControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.verticalSpeedIndicatorInstrumentControl1 = new APTRGv1.VerticalSpeedIndicatorInstrumentControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM4"});
            this.comboBox1.Location = new System.Drawing.Point(71, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baudrate :";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "9600",
            "14400",
            "19200",
            "38400 ",
            "57600 ",
            "115200"});
            this.comboBox2.Location = new System.Drawing.Point(71, 46);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(117, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Sensor";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(117, 87);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(36, 116);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Send";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(208, 116);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1146, 567);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.cbMapProviders);
            this.tabPage1.Controls.Add(this.MainMap);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1138, 541);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Interface & Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(1002, 6);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Check 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(255, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Select";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(1073, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Check ";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Select Map Provider";
            // 
            // cbMapProviders
            // 
            this.cbMapProviders.FormattingEnabled = true;
            this.cbMapProviders.Location = new System.Drawing.Point(128, 20);
            this.cbMapProviders.Name = "cbMapProviders";
            this.cbMapProviders.Size = new System.Drawing.Size(121, 21);
            this.cbMapProviders.TabIndex = 13;
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(6, 55);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(1124, 484);
            this.MainMap.TabIndex = 12;
            this.MainMap.Zoom = 0D;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.zedGraphControl5);
            this.tabPage2.Controls.Add(this.zedGraphControl4);
            this.tabPage2.Controls.Add(this.zedGraphControl3);
            this.tabPage2.Controls.Add(this.zedGraphControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1138, 541);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Graph on Latitude";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl5
            // 
            this.zedGraphControl5.Location = new System.Drawing.Point(7, 3);
            this.zedGraphControl5.Name = "zedGraphControl5";
            this.zedGraphControl5.ScrollGrace = 0D;
            this.zedGraphControl5.ScrollMaxX = 0D;
            this.zedGraphControl5.ScrollMaxY = 0D;
            this.zedGraphControl5.ScrollMaxY2 = 0D;
            this.zedGraphControl5.ScrollMinX = 0D;
            this.zedGraphControl5.ScrollMinY = 0D;
            this.zedGraphControl5.ScrollMinY2 = 0D;
            this.zedGraphControl5.Size = new System.Drawing.Size(279, 538);
            this.zedGraphControl5.TabIndex = 4;
            // 
            // zedGraphControl4
            // 
            this.zedGraphControl4.Location = new System.Drawing.Point(858, 3);
            this.zedGraphControl4.Name = "zedGraphControl4";
            this.zedGraphControl4.ScrollGrace = 0D;
            this.zedGraphControl4.ScrollMaxX = 0D;
            this.zedGraphControl4.ScrollMaxY = 0D;
            this.zedGraphControl4.ScrollMaxY2 = 0D;
            this.zedGraphControl4.ScrollMinX = 0D;
            this.zedGraphControl4.ScrollMinY = 0D;
            this.zedGraphControl4.ScrollMinY2 = 0D;
            this.zedGraphControl4.Size = new System.Drawing.Size(272, 538);
            this.zedGraphControl4.TabIndex = 3;
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Location = new System.Drawing.Point(577, 3);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(272, 538);
            this.zedGraphControl3.TabIndex = 2;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(292, 3);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(279, 538);
            this.zedGraphControl2.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.zedGraphControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1138, 541);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Graph on Time";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1138, 541);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "RAW Data";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.attitudeIndicatorInstrumentControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 170);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attitude";
            // 
            // attitudeIndicatorInstrumentControl1
            // 
            this.attitudeIndicatorInstrumentControl1.Location = new System.Drawing.Point(18, 19);
            this.attitudeIndicatorInstrumentControl1.Name = "attitudeIndicatorInstrumentControl1";
            this.attitudeIndicatorInstrumentControl1.Size = new System.Drawing.Size(140, 145);
            this.attitudeIndicatorInstrumentControl1.TabIndex = 0;
            this.attitudeIndicatorInstrumentControl1.Text = "attitudeIndicatorInstrumentControl1";
            this.attitudeIndicatorInstrumentControl1.Click += new System.EventHandler(this.attitudeIndicatorInstrumentControl1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.airSpeedIndicatorInstrumentControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 334);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 170);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Velocity";
            // 
            // airSpeedIndicatorInstrumentControl1
            // 
            this.airSpeedIndicatorInstrumentControl1.Location = new System.Drawing.Point(18, 19);
            this.airSpeedIndicatorInstrumentControl1.Name = "airSpeedIndicatorInstrumentControl1";
            this.airSpeedIndicatorInstrumentControl1.Size = new System.Drawing.Size(140, 145);
            this.airSpeedIndicatorInstrumentControl1.TabIndex = 0;
            this.airSpeedIndicatorInstrumentControl1.Text = "airSpeedIndicatorInstrumentControl1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.verticalSpeedIndicatorInstrumentControl1);
            this.groupBox3.Location = new System.Drawing.Point(13, 513);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(179, 170);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acceleration";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // verticalSpeedIndicatorInstrumentControl1
            // 
            this.verticalSpeedIndicatorInstrumentControl1.Location = new System.Drawing.Point(17, 19);
            this.verticalSpeedIndicatorInstrumentControl1.Name = "verticalSpeedIndicatorInstrumentControl1";
            this.verticalSpeedIndicatorInstrumentControl1.Size = new System.Drawing.Size(140, 145);
            this.verticalSpeedIndicatorInstrumentControl1.TabIndex = 0;
            this.verticalSpeedIndicatorInstrumentControl1.Text = "verticalSpeedIndicatorInstrumentControl1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox9);
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.textBox8);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.textBox7);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.Location = new System.Drawing.Point(208, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1134, 93);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data Recieve";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(860, 65);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 20);
            this.textBox9.TabIndex = 2;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(681, 65);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(485, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(860, 39);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 2;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(681, 39);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 2;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(860, 11);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(485, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(681, 11);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(794, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Kecepatan";
            this.label11.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(485, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(615, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Longitude";
            this.label8.Click += new System.EventHandler(this.label5_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(794, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Sudut";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ketinggian";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(794, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Jarak";
            this.label9.Click += new System.EventHandler(this.label3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(615, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Latitude";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(615, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tekanan";
            this.label6.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Kelembaban ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Suhu ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(369, 71);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1354, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.SystemColors.Info;
            this.zedGraphControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zedGraphControl1.Location = new System.Drawing.Point(149, 63);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(841, 414);
            this.zedGraphControl1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 691);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "APTRGv1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private AttitudeIndicatorInstrumentControl attitudeIndicatorInstrumentControl1;
        private AirSpeedIndicatorInstrumentControl airSpeedIndicatorInstrumentControl1;
        private VerticalSpeedIndicatorInstrumentControl verticalSpeedIndicatorInstrumentControl1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private GMap.NET.WindowsForms.GMapControl MainMap;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbMapProviders;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private ZedGraph.ZedGraphControl zedGraphControl4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private ZedGraph.ZedGraphControl zedGraphControl5;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}

