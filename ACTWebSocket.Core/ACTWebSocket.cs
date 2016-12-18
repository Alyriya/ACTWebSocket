﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;

namespace ACTWebSocket_Plugin
{
    using ACTWebSocket.Core;
    using Newtonsoft.Json.Linq;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Timers;
    using WebSocketSharp;
    using WebSocketSharp.Net;
    using WebSocketSharp.Server;
    using static ACTWebSocketCore;

    public interface PluginDirectory
    {
        void SetPluginDirectory(String path);
        String GetPluginDirectory();
    }
    public class ACTWebSocketMain : UserControl, IActPluginV1, PluginDirectory
    {
        private ACTWebSocketCore core;
        private TextBox port;
        private CheckBox autostart;
        private CheckBox MiniParseUse;
        private TextBox MiniParseSortKey;
        private ComboBox sortType;
        private CheckBox BeforeLogLineReadUse;
        private CheckBox localhostOnly;
        private TextBox hostname;
        private CheckBox OnLogLineReadUse;
        private Button buttonOff;
        private Button buttonOn;
        private Button copyURL;
        private CheckBox randomURL;
        private Button button1;
        private Button button2;
        private ListBox listBox2;
        private ListBox listBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button button3;
        private Label label13;
        private GroupBox startoption;
        private GroupBox hostdata;
        private Label label15;
        private Label label14;
        private GroupBox miniparse;
        private Label label17;
        private Label label16;
        private GroupBox othersets;
        private GroupBox serverStatus;
        private GroupBox groupBox1;
        private SplitContainer splitContainer1;
        private Button button4;
        private GroupBox groupBox2;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private TextBox overlayTitle;
        private Label label3;
        private Label label4;
        private TrackBar opacity;
        private TextBox url;
        private Label label5;
        private Button button5;
        private TrackBar zoom;
        private Label label6;
        #region Designer Created Code (Avoid editing)
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ACTWebSocketMain));
            this.port = new System.Windows.Forms.TextBox();
            this.autostart = new System.Windows.Forms.CheckBox();
            this.MiniParseUse = new System.Windows.Forms.CheckBox();
            this.MiniParseSortKey = new System.Windows.Forms.TextBox();
            this.sortType = new System.Windows.Forms.ComboBox();
            this.BeforeLogLineReadUse = new System.Windows.Forms.CheckBox();
            this.OnLogLineReadUse = new System.Windows.Forms.CheckBox();
            this.buttonOff = new System.Windows.Forms.Button();
            this.buttonOn = new System.Windows.Forms.Button();
            this.copyURL = new System.Windows.Forms.Button();
            this.localhostOnly = new System.Windows.Forms.CheckBox();
            this.hostname = new System.Windows.Forms.TextBox();
            this.randomURL = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.startoption = new System.Windows.Forms.GroupBox();
            this.hostdata = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.miniparse = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.othersets = new System.Windows.Forms.GroupBox();
            this.serverStatus = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.url = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.opacity = new System.Windows.Forms.TrackBar();
            this.overlayTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.zoom = new System.Windows.Forms.TrackBar();
            this.startoption.SuspendLayout();
            this.hostdata.SuspendLayout();
            this.miniparse.SuspendLayout();
            this.othersets.SuspendLayout();
            this.serverStatus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoom)).BeginInit();
            this.SuspendLayout();
            // 
            // port
            // 
            resources.ApplyResources(this.port, "port");
            this.port.Name = "port";
            // 
            // autostart
            // 
            resources.ApplyResources(this.autostart, "autostart");
            this.autostart.BackColor = System.Drawing.Color.Transparent;
            this.autostart.Name = "autostart";
            this.autostart.UseVisualStyleBackColor = false;
            // 
            // MiniParseUse
            // 
            resources.ApplyResources(this.MiniParseUse, "MiniParseUse");
            this.MiniParseUse.Checked = true;
            this.MiniParseUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiniParseUse.Name = "MiniParseUse";
            this.MiniParseUse.UseVisualStyleBackColor = true;
            this.MiniParseUse.CheckedChanged += new System.EventHandler(this.MiniParseUse_CheckedChanged);
            // 
            // MiniParseSortKey
            // 
            resources.ApplyResources(this.MiniParseSortKey, "MiniParseSortKey");
            this.MiniParseSortKey.Name = "MiniParseSortKey";
            this.MiniParseSortKey.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // sortType
            // 
            resources.ApplyResources(this.sortType, "sortType");
            this.sortType.Cursor = System.Windows.Forms.Cursors.Default;
            this.sortType.DisplayMember = "Key";
            this.sortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortType.FormattingEnabled = true;
            this.sortType.Name = "sortType";
            this.sortType.ValueMember = "Value";
            this.sortType.SelectedIndexChanged += new System.EventHandler(this.MiniParseSortType_SelectedIndexChanged);
            // 
            // BeforeLogLineReadUse
            // 
            resources.ApplyResources(this.BeforeLogLineReadUse, "BeforeLogLineReadUse");
            this.BeforeLogLineReadUse.Name = "BeforeLogLineReadUse";
            this.BeforeLogLineReadUse.UseVisualStyleBackColor = true;
            this.BeforeLogLineReadUse.CheckedChanged += new System.EventHandler(this.LogLineReadUse_CheckedChanged);
            // 
            // OnLogLineReadUse
            // 
            resources.ApplyResources(this.OnLogLineReadUse, "OnLogLineReadUse");
            this.OnLogLineReadUse.Name = "OnLogLineReadUse";
            this.OnLogLineReadUse.UseVisualStyleBackColor = true;
            this.OnLogLineReadUse.CheckedChanged += new System.EventHandler(this.OnLogLineReadUse_CheckedChanged);
            // 
            // buttonOff
            // 
            resources.ApplyResources(this.buttonOff, "buttonOff");
            this.buttonOff.Name = "buttonOff";
            this.buttonOff.UseVisualStyleBackColor = true;
            this.buttonOff.Click += new System.EventHandler(this.buttonOff_Click);
            // 
            // buttonOn
            // 
            resources.ApplyResources(this.buttonOn, "buttonOn");
            this.buttonOn.Name = "buttonOn";
            this.buttonOn.UseVisualStyleBackColor = true;
            this.buttonOn.Click += new System.EventHandler(this.buttonOn_Click);
            // 
            // copyURL
            // 
            resources.ApplyResources(this.copyURL, "copyURL");
            this.copyURL.Name = "copyURL";
            this.copyURL.UseVisualStyleBackColor = true;
            this.copyURL.Click += new System.EventHandler(this.copyURL_Click);
            // 
            // localhostOnly
            // 
            resources.ApplyResources(this.localhostOnly, "localhostOnly");
            this.localhostOnly.Checked = true;
            this.localhostOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.localhostOnly.Name = "localhostOnly";
            this.localhostOnly.UseVisualStyleBackColor = true;
            // 
            // hostname
            // 
            resources.ApplyResources(this.hostname, "hostname");
            this.hostname.Name = "hostname";
            // 
            // randomURL
            // 
            resources.ApplyResources(this.randomURL, "randomURL");
            this.randomURL.Name = "randomURL";
            this.randomURL.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox2
            // 
            resources.ApplyResources(this.listBox2, "listBox2");
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // startoption
            // 
            this.startoption.Controls.Add(this.localhostOnly);
            this.startoption.Controls.Add(this.randomURL);
            this.startoption.Controls.Add(this.autostart);
            resources.ApplyResources(this.startoption, "startoption");
            this.startoption.Name = "startoption";
            this.startoption.TabStop = false;
            // 
            // hostdata
            // 
            this.hostdata.Controls.Add(this.label15);
            this.hostdata.Controls.Add(this.label14);
            this.hostdata.Controls.Add(this.hostname);
            this.hostdata.Controls.Add(this.port);
            resources.ApplyResources(this.hostdata, "hostdata");
            this.hostdata.Name = "hostdata";
            this.hostdata.TabStop = false;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // miniparse
            // 
            this.miniparse.Controls.Add(this.label17);
            this.miniparse.Controls.Add(this.label16);
            this.miniparse.Controls.Add(this.MiniParseUse);
            this.miniparse.Controls.Add(this.sortType);
            this.miniparse.Controls.Add(this.MiniParseSortKey);
            resources.ApplyResources(this.miniparse, "miniparse");
            this.miniparse.Name = "miniparse";
            this.miniparse.TabStop = false;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // othersets
            // 
            this.othersets.Controls.Add(this.BeforeLogLineReadUse);
            this.othersets.Controls.Add(this.OnLogLineReadUse);
            resources.ApplyResources(this.othersets, "othersets");
            this.othersets.Name = "othersets";
            this.othersets.TabStop = false;
            // 
            // serverStatus
            // 
            this.serverStatus.Controls.Add(this.buttonOn);
            this.serverStatus.Controls.Add(this.buttonOff);
            resources.ApplyResources(this.serverStatus, "serverStatus");
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.TabStop = false;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.panel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.copyURL);
            this.panel2.Controls.Add(this.button4);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zoom);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.url);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.opacity);
            this.groupBox2.Controls.Add(this.overlayTitle);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.button3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // url
            // 
            resources.ApplyResources(this.url, "url");
            this.url.Name = "url";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // opacity
            // 
            resources.ApplyResources(this.opacity, "opacity");
            this.opacity.Maximum = 1000;
            this.opacity.Name = "opacity";
            this.opacity.Value = 1000;
            this.opacity.Scroll += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // overlayTitle
            // 
            resources.ApplyResources(this.overlayTitle, "overlayTitle");
            this.overlayTitle.Name = "overlayTitle";
            this.overlayTitle.TextChanged += new System.EventHandler(this.overlayTitle_TextChanged);
            this.overlayTitle.Leave += new System.EventHandler(this.overlayTitle_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // checkBox6
            // 
            resources.ApplyResources(this.checkBox6, "checkBox6");
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox5
            // 
            resources.ApplyResources(this.checkBox5, "checkBox5");
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox4
            // 
            resources.ApplyResources(this.checkBox4, "checkBox4");
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox3
            // 
            resources.ApplyResources(this.checkBox3, "checkBox3");
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // zoom
            // 
            this.zoom.LargeChange = 25;
            resources.ApplyResources(this.zoom, "zoom");
            this.zoom.Maximum = 500;
            this.zoom.Minimum = 25;
            this.zoom.Name = "zoom";
            this.zoom.Value = 25;
            this.zoom.Scroll += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ACTWebSocketMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.serverStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.othersets);
            this.Controls.Add(this.miniparse);
            this.Controls.Add(this.hostdata);
            this.Controls.Add(this.startoption);
            this.Controls.Add(this.label13);
            resources.ApplyResources(this, "$this");
            this.Name = "ACTWebSocketMain";
            this.Load += new System.EventHandler(this.ACTWebSocket_Load);
            this.startoption.ResumeLayout(false);
            this.startoption.PerformLayout();
            this.hostdata.ResumeLayout(false);
            this.hostdata.PerformLayout();
            this.miniparse.ResumeLayout(false);
            this.miniparse.PerformLayout();
            this.othersets.ResumeLayout(false);
            this.othersets.PerformLayout();
            this.serverStatus.ResumeLayout(false);
            this.serverStatus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #endregion
        public ACTWebSocketMain()
        {
            InitializeComponent();
        }

        ~ACTWebSocketMain()
        {
            CloseAll();
            SaveSettings();
        }

        String overlayWindowPrefix = "overlay_";

        Label lblStatus;    // The status label that appears in ACT's Plugin tab
        string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACTWebSocket.config.xml");
        SettingsSerializer xmlSettings;

        #region IActPluginV1 Members

        static readonly List<KeyValuePair<string, MiniParseSortType>> sortTypeDict = new List<KeyValuePair<string, MiniParseSortType>>()
        {
            new KeyValuePair<string, MiniParseSortType>("DoNotSort", MiniParseSortType.None),
            new KeyValuePair<string, MiniParseSortType>("SortStringAscending", MiniParseSortType.StringAscending),
            new KeyValuePair<string, MiniParseSortType>("SortStringDescending", MiniParseSortType.StringDescending),
            new KeyValuePair<string, MiniParseSortType>("SortNumberAscending", MiniParseSortType.NumericAscending),
            new KeyValuePair<string, MiniParseSortType>("SortNumberDescending", MiniParseSortType.NumericDescending)
        };

        JObject overlayWindows = new JObject(); // 설정 전부

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            if (core == null)
            {
                core = new ACTWebSocketCore();
                core.pluginDirectory = pluginDirectory;
            }
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
            this.Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space
            xmlSettings = new SettingsSerializer(this);	// Create a new settings serializer and pass it this instance
            sortType.SelectedIndex = -1;

            sortType.DataSource = sortTypeDict;
            LoadSettings();



            if (core != null)
            {
                core.Filters["/BeforeLogLineRead"] = BeforeLogLineReadUse.Checked;
                core.Filters["/OnLogLineRead"] = OnLogLineReadUse.Checked;
                core.Filters["/MiniParse"] = MiniParseUse.Checked;
                core.Config.SortKey = MiniParseSortKey.Text.Trim();
                core.Config.SortType = (MiniParseSortType)sortType.SelectedIndex;
            }
            if (autostart.Checked)
            {
                StartServer();
            }
            else
            {
                StopServer();
            }
            // Create some sort of parsing event handler.  After the "+=" hit TAB twice and the code will be generated for you.
            ActGlobals.oFormActMain.BeforeLogLineRead += this.oFormActMain_BeforeLogLineRead;
            ActGlobals.oFormActMain.OnLogLineRead += this.oFormActMain_OnLogLineRead;
            var s = ActGlobals.oFormActMain.ActPlugins;
            lblStatus.Text = "Plugin Started";
        }

        public void DeInitPlugin()
        {
            StopServer();
            // Unsubscribe from any events you listen to when exiting!
            ActGlobals.oFormActMain.BeforeLogLineRead -= this.oFormActMain_BeforeLogLineRead;
            ActGlobals.oFormActMain.OnLogLineRead -= this.oFormActMain_OnLogLineRead;

            SaveSettings();
            CloseAll();
            lblStatus.Text = "Plugin Exited";
        }

        #endregion

        void oFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
        {
        }

        void LoadSettings()
        {
            xmlSettings.AddControlSetting(port.Name, port);
            xmlSettings.AddControlSetting(localhostOnly.Name, localhostOnly);
            xmlSettings.AddControlSetting(autostart.Name, autostart);
            xmlSettings.AddControlSetting(hostname.Name, hostname);
            xmlSettings.AddControlSetting(MiniParseSortKey.Name, MiniParseSortKey);
            xmlSettings.AddControlSetting(sortType.Name, sortType);
            xmlSettings.AddControlSetting(MiniParseUse.Name, MiniParseUse);
            xmlSettings.AddControlSetting(BeforeLogLineReadUse.Name, BeforeLogLineReadUse);
            xmlSettings.AddControlSetting(randomURL.Name, randomURL);

            if (File.Exists(settingsFile))
            {
                FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlTextReader xReader = new XmlTextReader(fs);

                try
                {
                    while (xReader.Read())
                    {
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.LocalName == "SettingsSerializer")
                            {
                                xmlSettings.ImportFromXml(xReader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error loading settings: " + ex.Message;
                }
                xReader.Close();
            }

            // validate
            try
            {
                int p = Convert.ToInt16(port.Text);
            }
            catch (Exception e)
            {
                port.Text = "10501";
            }

            if (hostname.Text.Length == 0)
            {
                hostname.Text = "localhost";
            }

            UpdateList();
            if(File.Exists(Environment.CurrentDirectory + "\\overlayconfig.json"))
            {
                //overlayWindows = new JObject();
                try
                {
                    JObject overlayWindowsLoaded = JObject.Parse(File.ReadAllText(Environment.CurrentDirectory + "\\overlayconfig.json"));
                    IList<string> keys = overlayWindows.Properties().Select(p => p.Name).ToList();
                    IList<string> keysLoaded = overlayWindowsLoaded.Properties().Select(p => p.Name).ToList();
                    foreach (String title in keysLoaded)
                    {
                        overlayWindows[title] = overlayWindowsLoaded[title];
                        JObject o = (JObject)overlayWindows[title];
                        JToken val = null;
                        if (!o.TryGetValue("zoom", out val))
                        {
                            o["zoom"] = 1.0;
                        }
                        if (!o.TryGetValue("opacity", out val))
                        {
                            o["opacity"] = 1.0;
                        }
                    }
                    foreach (String title in keysLoaded)
                    {
                        IntPtr hwnd = Native.FindWindow(null, overlayWindowPrefix + title);
                        if (hwnd == null || hwnd.ToInt64() == 0)
                        {
                            if (NewOverlayWindow((JObject)overlayWindows[title]))
                            {
                                this.listBox2.Items.Add(title);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Parsing Error", "ActWebSocket");
                }
//                = File.ReadAllText(Environment.CurrentDirectory + "\\overlayconfig.json");
            }
        }
        void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;
            xWriter.Indentation = 1;
            xWriter.IndentChar = '\t';
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");    // <Config>
            xWriter.WriteStartElement("SettingsSerializer");    // <Config><SettingsSerializer>
            xmlSettings.ExportToXml(xWriter);   // Fill the SettingsSerializer XML
            xWriter.WriteEndElement();  // </SettingsSerializer>
            xWriter.WriteEndElement();  // </Config>
            xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
            xWriter.Flush();    // Flush the file buffer to disk
            xWriter.Close();

            IList<string> keys = overlayWindows.Properties().Select(p => p.Name).ToList();
            foreach (String title in keys)
            {
                IntPtr hwnd = Native.FindWindow(null, overlayWindowPrefix + title);
                if (hwnd == null || hwnd.ToInt64() == 0)
                {
                }
                else
                {
                    Native.RECT rect = new Native.RECT();
                    if(Native.GetWindowRect(hwnd, out rect))
                    {
                        overlayWindows[title]["x"] = rect.Left;
                        overlayWindows[title]["y"] = rect.Top;
                        overlayWindows[title]["width"] = rect.Right - rect.Left;
                        overlayWindows[title]["height"] = rect.Bottom - rect.Top;
                    }
                }
            }
            File.WriteAllText(Environment.CurrentDirectory + "\\overlayconfig.json", overlayWindows.ToString());
        }

        void SaveSettingXML(string url, JObject o)
        {
            XmlDocument doc = new XmlDocument();
            // Root node : Overlays
            // Child node rule : Overlays/Overlay
            // Child node settings : Overlays/Overlay/*
            string emptySetting = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Overlays></Overlays>";

            if (File.Exists(Environment.CurrentDirectory + "\\overlayconfig.xml"))
                doc.Load(Environment.CurrentDirectory + "\\overlayconfig.xml");
            else
                doc.LoadXml(emptySetting);

            XmlElement setting = null;

            foreach(XmlElement xe in doc.SelectNodes("/Overlays/Overlay"))
            {
                if(xe.SelectSingleNode("/Overlay/Url").InnerText == url)
                {
                    setting = xe as XmlElement;
                    break;
                }
            }

            string[] objects = 
                { "Url", "x", "y", "width", "height", "useDragFilter", "useDragMove", "NoActive", "Transparent", "hide"};

            if(setting == null)
            {
                setting = doc.CreateElement("Overlay");
                foreach(string s in objects)
                {
                    XmlElement elem = doc.CreateElement(s);
                    if(s == "Url")
                    {
                        elem.InnerText = url;
                    }
                    else
                    {
                        elem.InnerText = o[s].ToString();
                    }
                    setting.AppendChild(elem);
                }
                doc.AppendChild(setting);
            }
            else
            {
                foreach(string s in objects)
                {
                    if (s == "Url") continue;
                    setting.SelectSingleNode("/Overlay/" + s).InnerText = o[s].ToString();
                }
            }

            doc.Save(Environment.CurrentDirectory + "\\overlayconfig.xml");
        }

        JObject LoadSettingXml(string url)
        {
            XmlDocument doc = new XmlDocument();
            JObject o = new JObject();
            // default values
            o["useDragFilter"] = true;
            o["useDragMove"] = true;
            o["hide"] = false;
            o["width"] = 100;
            o["height"] = 100;
            o["x"] = 0;
            o["y"] = 0;
            o["Transparent"] = true;
            o["NoActivate"] = true;


            string[] objects =
                { "x", "y", "width", "height", "useDragFilter", "useDragMove", "NoActive", "Transparent", "hide"};

            if (File.Exists(Environment.CurrentDirectory + "\\overlayconfig.xml"))
            {
                doc.Load(Environment.CurrentDirectory + "\\overlayconfig.xml");
                foreach(XmlElement xe in doc.SelectNodes("/Overlays/Overlay"))
                {
                    if(xe.SelectSingleNode("/Overlay/Url").InnerText == url)
                    {
                        foreach (string s in objects)
                        {
                            if(s == "x" || s == "y" || s == "width" || s == "height")
                            {
                                o[s] = int.Parse(xe.SelectSingleNode("/Overlay/" + s).InnerText);
                            }
                            else
                            {
                                o[s] = (xe.SelectSingleNode("/Overlay/" + s).InnerText.ToLower() == "true" ? true : false);
                            }
                        }
                        break;
                    }
                }
            }

            return o;
        }

        private void ACTWebSocket_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void oFormActMain_BeforeLogLineRead(
            bool isImport,
            LogLineEventArgs logInfo)
        {
            core.Broadcast("/BeforeLogLineRead", logInfo.logLine);
        }

        private void oFormActMain_OnLogLineRead(
            bool isImport,
            LogLineEventArgs logInfo)
        {
            core.Broadcast("/OnLogLineRead", logInfo.logLine);
        }


        private void StartServer()
        {
            if (randomURL.Checked)
            {
                core.randomDir = Guid.NewGuid().ToString();
            }
            else
            {
                core.randomDir = null;
            }
            try
            {
                core.StartServer(localhostOnly.Checked ? "127.0.0.1" : "0.0.0.0", Convert.ToInt16(port.Text), hostname.Text.Trim());
                localhostOnly.Enabled = false;
                port.Enabled = false;
                hostname.Enabled = false;
                buttonOn.Enabled = false;
                buttonOff.Enabled = true;
                randomURL.Enabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                core.StopServer();
            }
            //tabPage1
        }

        private void StopServer()
        {
            core.StopServer();
            localhostOnly.Enabled = true;
            port.Enabled = true;
            hostname.Enabled = true;
            buttonOn.Enabled = true;
            buttonOff.Enabled = false;
            randomURL.Enabled = true;
        }

        private void buttonOn_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        String pluginDirectory = "";
        public void SetPluginDirectory(string path)
        {
            pluginDirectory = path;
        }

        public string GetPluginDirectory()
        {
            return pluginDirectory;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (core != null)
            {
                core.Config.SortKey = MiniParseSortKey.Text.Trim();
            }
        }

        private void MiniParseSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (core != null)
            {
                core.Config.SortType = (MiniParseSortType)sortType.SelectedIndex;
            }
        }

        private void LogLineReadUse_CheckedChanged(object sender, EventArgs e)
        {
            if (core != null)
            {
                core.Filters["/BeforeLogLineRead"] = BeforeLogLineReadUse.Checked;
            }
        }

        private void OnLogLineReadUse_CheckedChanged(object sender, EventArgs e)
        {
            if (core != null)
            {
                core.Filters["/OnLogLineRead"] = OnLogLineReadUse.Checked;
            }
        }

        private void MiniParseUse_CheckedChanged(object sender, EventArgs e)
        {
            if (core != null)
            {
                core.Filters["/MiniParse"] = MiniParseUse.Checked;
            }
        }

        string GetRelativePath(string filespec, string folder)
        {
            Uri pathUri = new Uri(filespec);
            // Folders must end in a slash
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        public void CloseAll()
        {
            UpdateList(false);
            for(int i=0;i<listBox2.Items.Count;++i)
            {
                String title = this.listBox2.Items[i].ToString();
                IntPtr hwnd = Native.FindWindow(null, overlayWindowPrefix + title);
                if (hwnd == null || hwnd.ToInt64() == 0)
                {
                }
                else
                {
                    Native.SendMessage(hwnd, 0x0400 + 1, new IntPtr(0x08), new IntPtr(0x08));
                    Native.CloseWindow(hwnd);
                }
            }
        }

        public void UpdateList(bool updateInfo = true)
        {
            this.listBox1.Items.Clear();
            foreach (string file in Directory.EnumerateFiles(pluginDirectory, "*.html", SearchOption.AllDirectories))
            {
                this.listBox1.Items.Add(GetRelativePath(file, pluginDirectory));
            }
            List<String> titles = Native.SearchForWindow(overlayWindowPrefix);
            this.listBox2.Items.Clear();
            this.listBox2.Sorted = true;

            foreach (string fulltitle in titles)
            {
                String title = fulltitle.Substring(overlayWindowPrefix.Length);
                this.listBox2.Items.Add(title);

                if (updateInfo)
                {
                    IList<string> keys = overlayWindows.Properties().Select(p => p.Name).ToList();
                    if (!keys.Contains(title))
                    {
                        overlayWindows[title] = new JObject();
                        IntPtr hwnd = Native.FindWindow(null, overlayWindowPrefix + title);
                        if (hwnd == null || hwnd.ToInt64() == 0)
                        {
                            overlayWindows[title]["Transparent"] = true;
                            overlayWindows[title]["NoActivate"] = true;
                        }
                        else
                        {
                            overlayWindows[title]["Transparent"] = (Native.GetWindowLongFlag(hwnd, new IntPtr(Native.WS_EX_TRANSPARENT)).ToInt64() > 0);
                            overlayWindows[title]["NoActivate"] = (Native.GetWindowLongFlag(hwnd, new IntPtr(Native.WS_EX_NOACTIVATE)).ToInt64() > 0);
                        }
                        overlayWindows[title]["hide"] = false;
                        overlayWindows[title]["useDragFilter"] = true;
                        overlayWindows[title]["useDragMove"] = true;
                        overlayWindows[title]["useResizeGrip"] = true;
                        overlayWindows[title]["opacity"] = 1.0;
                        overlayWindows[title]["zoom"] = 1.0;
                        overlayWindows[title]["title"] = title;
                    }
                    else
                    {
                        IntPtr hwnd = Native.FindWindow(null, overlayWindowPrefix + title);
                        if (hwnd == null || hwnd.ToInt64() == 0)
                        {
                            overlayWindows[title]["Transparent"] = true;
                            overlayWindows[title]["NoActivate"] = true;
                        }
                        else
                        {
                            overlayWindows[title]["Transparent"] = (Native.GetWindowLongFlag(hwnd, new IntPtr(Native.WS_EX_TRANSPARENT)).ToInt64() > 0);
                            overlayWindows[title]["NoActivate"] = (Native.GetWindowLongFlag(hwnd, new IntPtr(Native.WS_EX_NOACTIVATE)).ToInt64() > 0);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        public static string Base64Encoding(string EncodingText, System.Text.Encoding oEncoding = null)
        {
            if (oEncoding == null)
                oEncoding = System.Text.Encoding.UTF8;

            byte[] arr = oEncoding.GetBytes(EncodingText);
            return System.Convert.ToBase64String(arr);
        }

        public static string Base64Decoding(string DecodingText, System.Text.Encoding oEncoding = null)
        {
            if (oEncoding == null)
                oEncoding = System.Text.Encoding.UTF8;

            byte[] arr = System.Convert.FromBase64String(DecodingText);
            return oEncoding.GetString(arr);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
            {
                String url = "";
                if (localhostOnly.Checked)
                {
                    url = "http://localhost:" + port.Text + "/";
                }
                else
                {
                    url = "http://" + hostname.Text + ":" + port.Text + "/";
                }
                if (core.randomDir != null)
                {
                    url += core.randomDir + "/";
                }
                String param = url + System.Uri.EscapeDataString(this.listBox1.Items[this.listBox1.SelectedIndex].ToString());
                param = param.Replace("%5C", "/");
                String title = Guid.NewGuid().ToString();
                if(NewOverlayWindow(param, title))
                {
                    this.listBox2.Items.Add(title);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
            {
                String url = "";
                if (localhostOnly.Checked)
                {
                    url = "http://localhost:" + port.Text + "/";
                }
                else
                {
                    url = "http://" + hostname.Text + ":" + port.Text + "/";
                }
                if (core.randomDir != null)
                {
                    url += core.randomDir + "/";
                }
                String param = url + System.Uri.EscapeDataString(this.listBox1.Items[this.listBox1.SelectedIndex].ToString());
                param = param.Replace("%5C", "/");
                String title = Guid.NewGuid().ToString();
                if (NewOverlayWindow(param, title))
                {
                    this.listBox2.Items.Add(title);
                }
            }
        }
        private bool NewOverlayWindow(String url, String title)
        {
            String overlayPath = pluginDirectory + "/overlay/overlaydemo.exe";
            if (File.Exists(overlayPath) && this.listBox1.SelectedIndex >= 0)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = overlayPath;
                JObject o = new JObject();
                o["Transparent"] = checkBox1.Checked;
                o["NoActivate"] = checkBox2.Checked;
                o["hide"] = checkBox3.Checked;
                o["useDragFilter"] = checkBox4.Checked;
                o["useDragMove"] = checkBox4.Checked && checkBox5.Checked;
                o["useResizeGrip"] = checkBox6.Checked;
                o["opacity"] = (double)opacity.Value / (double)opacity.Maximum;
                o["url"] = url;
                o["title"] = title;
                o["zoom"] = 1.0;
                //o["width"] = 100;
                //o["height"] = 100;
                //o["x"] = 0;
                //o["y"] = 0;

                return NewOverlayWindow(o);
            }
            return false;
        }

        private bool NewOverlayWindow(JObject obj)
        {
            String overlayPath = pluginDirectory + "/overlay/overlaydemo.exe";
            if (File.Exists(overlayPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = overlayPath;
                JObject o = (JObject)obj.DeepClone();
                String title = o["title"].Value<String>();
                o["title"] = overlayWindowPrefix + o["title"];

                if (overlayWindows[title] == null)
                    overlayWindows[title] = obj;

                String json = json = o.ToString();
                startInfo.Arguments = Base64Encoding(json);
                Process.Start(startInfo);
                return true;
            }
            return false;
        }

        private void copyURL_Click(object sender, EventArgs e)
        {
            String url = "";
            if (localhostOnly.Checked)
            {
                url = "http://localhost:" + port.Text + "/";
            }
            else
            {
                url = "http://" + hostname.Text + ":" + port.Text + "/";
            }
            if (core.randomDir != null)
            {
                url += core.randomDir + "/";
            }
            if (this.listBox1.SelectedIndex >= 0)
            {
                String fullURL = url + System.Uri.EscapeDataString(this.listBox1.Items[this.listBox1.SelectedIndex].ToString());
                fullURL = fullURL.Replace("%5C", "/");
                Clipboard.SetText(fullURL);
            }
            else
            {
                Clipboard.SetText(url);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Enabled = checkBox4.Checked;
            if (this.listBox2.SelectedIndex >= 0)
            {
                String title = this.listBox2.Items[this.listBox2.SelectedIndex].ToString();
                IntPtr hwnd = Native.FindWindow(null, overlayWindowPrefix + title);
                if (hwnd == null || hwnd.ToInt64() == 0)
                {
                    UpdateList();
                }
                else
                {
                    JObject o = new JObject();
                    o["Transparent"] = checkBox1.Checked;
                    o["NoActivate"] = checkBox2.Checked;
                    o["hide"] = checkBox3.Checked;
                    o["useDragFilter"] = checkBox4.Checked;
                    o["useDragMove"] = checkBox4.Checked && checkBox5.Checked;
                    o["useResizeGrip"] = checkBox6.Checked;
                    o["opacity"] = (double)opacity.Value / (double)opacity.Maximum;
                    o["zoom"] = (double)zoom.Value / (double)100.0;
                    String json = o.ToString();
                    Native.SendMessageToWindow(hwnd, 1, json);

                    IList<string> keys = o.Properties().Select(p => p.Name).ToList();
                    foreach (String key in keys)
                    {
                        overlayWindows[title][key] = o[key].DeepClone();
                    }
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex >= 0)
            {
                String title = this.listBox2.Items[this.listBox2.SelectedIndex].ToString();
                IntPtr hwnd = Native.FindWindow(null, overlayWindowPrefix + title);
                if (hwnd == null || hwnd.ToInt64() == 0)
                {
                    //this.listBox2.Items.RemoveAt(this.listBox2.SelectedIndex);
                    UpdateList();
                }
                else
                {
                    overlayTitle.Text = title;
                    IList<string> keys = overlayWindows.Properties().Select(p => p.Name).ToList();
                    if (keys.Contains(title))
                    {
                        checkBox1.Checked = overlayWindows[title].Value<Boolean>("Transparent");
                        checkBox2.Checked = overlayWindows[title].Value<Boolean>("NoActivate");
                        checkBox3.Checked = overlayWindows[title].Value<Boolean>("hide");
                        checkBox4.Checked = overlayWindows[title].Value<Boolean>("useDragFilter");
                        checkBox5.Checked = overlayWindows[title].Value<Boolean>("useDragMove");
                        checkBox6.Checked = overlayWindows[title].Value<Boolean>("useResizeGrip");
                        opacity.Value = (int)(overlayWindows[title].Value<double>("opacity") * (double)opacity.Maximum);
                        zoom.Value = (int)(overlayWindows[title].Value<double>("zoom") * (double)100);
                        url.Text = overlayWindows[title].Value<String>("url");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex >= 0)
            {
                String title = this.listBox2.Items[this.listBox2.SelectedIndex].ToString();
                IntPtr hwnd = Native.FindWindow(null, overlayWindowPrefix + title);
                if (hwnd == null || hwnd.ToInt64() == 0)
                {
                    //this.listBox2.Items.RemoveAt(this.listBox2.SelectedIndex);
                    UpdateList();
                }
                else
                {
                    Native.SendMessage(hwnd, 0x0400 + 1, new IntPtr(0x08), new IntPtr(0x08));
                    Native.CloseWindow(hwnd);

                    overlayWindows.Remove(title);
                    this.listBox2.Items.RemoveAt(this.listBox2.SelectedIndex);
                }
            }
        }

        private void overlayTitle_TextChanged(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex >= 0)
            {
            }
        }

        private void overlayTitle_Leave(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex >= 0)
            {
                String title = this.listBox2.Items[this.listBox2.SelectedIndex].ToString();
                IntPtr hwnd = Native.FindWindow(null, overlayWindowPrefix + title);
                if (hwnd == null || hwnd.ToInt64() == 0)
                {
                    UpdateList();
                }
                else
                {
                    if (title.CompareTo(overlayTitle.Text) != 0)
                    {
                        JObject o = new JObject();
                        o["title"] = overlayWindowPrefix + overlayTitle.Text;
                        String json = o.ToString();
                        Native.SendMessageToWindow(hwnd, 1, json);
                        overlayWindows[overlayTitle.Text] = overlayWindows[title].DeepClone();
                        overlayWindows[overlayTitle.Text]["title"] = overlayTitle.Text;
                        overlayWindows.Remove(title);
                        UpdateList();
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex >= 0)
            {
                String title = this.listBox2.Items[this.listBox2.SelectedIndex].ToString();
                IntPtr hwnd = Native.FindWindow(null, overlayWindowPrefix + title);
                if (hwnd == null || hwnd.ToInt64() == 0)
                {
                    UpdateList();
                }
                else
                {
                    JObject o = new JObject();
                    o["url"] = url.Text;
                    String json = o.ToString();
                    Native.SendMessageToWindow(hwnd, 1, json);

                    IList<string> keys = o.Properties().Select(p => p.Name).ToList();
                    foreach (String key in keys)
                    {
                        overlayWindows[title][key] = o[key].DeepClone();
                    }
                }
            }
        }
    }
}
