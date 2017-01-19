﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.Xml;

#pragma warning disable 0168 // variable declared but not used. 

namespace ACTWebSocket_Plugin
{
    using static ACTWebSocketCore;
    using ACTWebSocket.Core;
    using Classes;
    using Newtonsoft.Json.Linq;
    using Open.Nat;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Net;
    using System.Diagnostics;
    using System.ComponentModel;
    using Ionic.Zip;
    using System.Text.RegularExpressions;

    public interface PluginDirectory
    {
        void SetPluginDirectory(string path);
        string GetPluginDirectory();
    }
    public class ACTWebSocketMain : UserControl, IActPluginV1, PluginDirectory
    {

        string overlaySkinDirectory { get; set; }
        string pluginDirectory = "";
        private ComboBox hostnames;
        private Label label2;
        private TextBox uPnPPort;
        private Button buttonAddURL;
        private Button buttonURL;
        private ListView skinList;
        private Button buttonOpen;
        private Button buttonManage;
        private Button buttonDownload;
        private Button buttonExit;
        private ProgressBar progressBar;
        private CheckBox skinOnAct;
        private Button buttonStart;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox autostartoverlay;
        private CheckBox chatFilter;

        public void SetSkinDir(string path)
        {
            overlaySkinDirectory = path;
        }

        public string GetSkinDir()
        {
            return overlaySkinDirectory;
        }

        public void SetPluginDirectory(string path)
        {
            overlayProcDir = path + "\\overlay_proc";
            overlayProcExe = overlayProcDir + "\\overlay_proc.exe";
            UpdateOverlayProc();
            pluginDirectory = path;
        }

        public string GetPluginDirectory()
        {
            return pluginDirectory;
        }
        private ACTWebSocketCore core;
        private TextBox port;
        private CheckBox autostart;
        private CheckBox MiniParseUse;
        private CheckBox BeforeLogLineReadUse;
        private CheckBox UPNPUse;
        private CheckBox OnLogLineReadUse;
        private Button buttonOff;
        private Button buttonOn;
        private CheckBox randomURL;
        private GroupBox startoption;
        private GroupBox hostdata;
        private Label label15;
        private Label label14;
        private GroupBox othersets;
        private GroupBox serverStatus;
        private Button copyURL;
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
            this.BeforeLogLineReadUse = new System.Windows.Forms.CheckBox();
            this.OnLogLineReadUse = new System.Windows.Forms.CheckBox();
            this.buttonOff = new System.Windows.Forms.Button();
            this.buttonOn = new System.Windows.Forms.Button();
            this.UPNPUse = new System.Windows.Forms.CheckBox();
            this.randomURL = new System.Windows.Forms.CheckBox();
            this.startoption = new System.Windows.Forms.GroupBox();
            this.skinOnAct = new System.Windows.Forms.CheckBox();
            this.hostdata = new System.Windows.Forms.GroupBox();
            this.hostnames = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uPnPPort = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.othersets = new System.Windows.Forms.GroupBox();
            this.chatFilter = new System.Windows.Forms.CheckBox();
            this.serverStatus = new System.Windows.Forms.GroupBox();
            this.copyURL = new System.Windows.Forms.Button();
            this.buttonAddURL = new System.Windows.Forms.Button();
            this.buttonURL = new System.Windows.Forms.Button();
            this.skinList = new System.Windows.Forms.ListView();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonManage = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.autostartoverlay = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.startoption.SuspendLayout();
            this.hostdata.SuspendLayout();
            this.othersets.SuspendLayout();
            this.serverStatus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // port
            // 
            resources.ApplyResources(this.port, "port");
            this.port.Name = "port";
            this.port.TextChanged += new System.EventHandler(this.port_TextChanged);
            this.port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.port_KeyPress);
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
            this.MiniParseUse.BackColor = System.Drawing.Color.Transparent;
            this.MiniParseUse.Checked = true;
            this.MiniParseUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiniParseUse.Name = "MiniParseUse";
            this.MiniParseUse.UseVisualStyleBackColor = false;
            this.MiniParseUse.CheckedChanged += new System.EventHandler(this.MiniParseUse_CheckedChanged);
            // 
            // BeforeLogLineReadUse
            // 
            resources.ApplyResources(this.BeforeLogLineReadUse, "BeforeLogLineReadUse");
            this.BeforeLogLineReadUse.BackColor = System.Drawing.Color.Transparent;
            this.BeforeLogLineReadUse.Name = "BeforeLogLineReadUse";
            this.BeforeLogLineReadUse.UseVisualStyleBackColor = false;
            this.BeforeLogLineReadUse.CheckedChanged += new System.EventHandler(this.BeforeLogLineReadUse_CheckedChanged);
            // 
            // OnLogLineReadUse
            // 
            resources.ApplyResources(this.OnLogLineReadUse, "OnLogLineReadUse");
            this.OnLogLineReadUse.BackColor = System.Drawing.Color.Transparent;
            this.OnLogLineReadUse.Name = "OnLogLineReadUse";
            this.OnLogLineReadUse.UseVisualStyleBackColor = false;
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
            // UPNPUse
            // 
            resources.ApplyResources(this.UPNPUse, "UPNPUse");
            this.UPNPUse.BackColor = System.Drawing.Color.Transparent;
            this.UPNPUse.Checked = true;
            this.UPNPUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UPNPUse.Name = "UPNPUse";
            this.UPNPUse.UseVisualStyleBackColor = false;
            this.UPNPUse.CheckedChanged += new System.EventHandler(this.UPNPUse_CheckedChanged);
            // 
            // randomURL
            // 
            resources.ApplyResources(this.randomURL, "randomURL");
            this.randomURL.BackColor = System.Drawing.Color.Transparent;
            this.randomURL.Name = "randomURL";
            this.randomURL.UseVisualStyleBackColor = false;
            // 
            // startoption
            // 
            resources.ApplyResources(this.startoption, "startoption");
            this.startoption.BackColor = System.Drawing.Color.Transparent;
            this.startoption.Controls.Add(this.skinOnAct);
            this.startoption.Controls.Add(this.UPNPUse);
            this.startoption.Controls.Add(this.randomURL);
            this.startoption.Controls.Add(this.autostart);
            this.startoption.Name = "startoption";
            this.startoption.TabStop = false;
            // 
            // skinOnAct
            // 
            resources.ApplyResources(this.skinOnAct, "skinOnAct");
            this.skinOnAct.BackColor = System.Drawing.Color.Transparent;
            this.skinOnAct.Name = "skinOnAct";
            this.skinOnAct.UseVisualStyleBackColor = false;
            this.skinOnAct.CheckedChanged += new System.EventHandler(this.skinOnAct_CheckedChanged);
            // 
            // hostdata
            // 
            resources.ApplyResources(this.hostdata, "hostdata");
            this.hostdata.BackColor = System.Drawing.Color.Transparent;
            this.hostdata.Controls.Add(this.hostnames);
            this.hostdata.Controls.Add(this.label2);
            this.hostdata.Controls.Add(this.uPnPPort);
            this.hostdata.Controls.Add(this.label15);
            this.hostdata.Controls.Add(this.label14);
            this.hostdata.Controls.Add(this.port);
            this.hostdata.Name = "hostdata";
            this.hostdata.TabStop = false;
            // 
            // hostnames
            // 
            resources.ApplyResources(this.hostnames, "hostnames");
            this.hostnames.FormattingEnabled = true;
            this.hostnames.Name = "hostnames";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // uPnPPort
            // 
            resources.ApplyResources(this.uPnPPort, "uPnPPort");
            this.uPnPPort.Name = "uPnPPort";
            this.uPnPPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.port_KeyPress);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Name = "label14";
            // 
            // othersets
            // 
            resources.ApplyResources(this.othersets, "othersets");
            this.othersets.BackColor = System.Drawing.Color.Transparent;
            this.othersets.Controls.Add(this.chatFilter);
            this.othersets.Controls.Add(this.BeforeLogLineReadUse);
            this.othersets.Controls.Add(this.OnLogLineReadUse);
            this.othersets.Controls.Add(this.MiniParseUse);
            this.othersets.Name = "othersets";
            this.othersets.TabStop = false;
            // 
            // chatFilter
            // 
            resources.ApplyResources(this.chatFilter, "chatFilter");
            this.chatFilter.BackColor = System.Drawing.Color.Transparent;
            this.chatFilter.Name = "chatFilter";
            this.chatFilter.UseVisualStyleBackColor = false;
            this.chatFilter.CheckedChanged += new System.EventHandler(this.chatFilter_CheckedChanged);
            // 
            // serverStatus
            // 
            resources.ApplyResources(this.serverStatus, "serverStatus");
            this.serverStatus.Controls.Add(this.buttonOn);
            this.serverStatus.Controls.Add(this.buttonOff);
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.TabStop = false;
            // 
            // copyURL
            // 
            resources.ApplyResources(this.copyURL, "copyURL");
            this.copyURL.Name = "copyURL";
            this.copyURL.UseVisualStyleBackColor = true;
            this.copyURL.Click += new System.EventHandler(this.copyURL_Click);
            // 
            // buttonAddURL
            // 
            resources.ApplyResources(this.buttonAddURL, "buttonAddURL");
            this.buttonAddURL.Name = "buttonAddURL";
            this.buttonAddURL.UseVisualStyleBackColor = true;
            this.buttonAddURL.Click += new System.EventHandler(this.buttonAddURL_Click);
            // 
            // buttonURL
            // 
            resources.ApplyResources(this.buttonURL, "buttonURL");
            this.buttonURL.Name = "buttonURL";
            this.buttonURL.UseVisualStyleBackColor = true;
            this.buttonURL.Click += new System.EventHandler(this.buttonURL_Click);
            // 
            // skinList
            // 
            resources.ApplyResources(this.skinList, "skinList");
            this.skinList.HideSelection = false;
            this.skinList.MultiSelect = false;
            this.skinList.Name = "skinList";
            this.skinList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.skinList.UseCompatibleStateImageBehavior = false;
            this.skinList.View = System.Windows.Forms.View.List;
            // 
            // buttonOpen
            // 
            resources.ApplyResources(this.buttonOpen, "buttonOpen");
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonManage
            // 
            resources.ApplyResources(this.buttonManage, "buttonManage");
            this.buttonManage.Name = "buttonManage";
            this.buttonManage.UseVisualStyleBackColor = true;
            this.buttonManage.Click += new System.EventHandler(this.buttonManage_Click);
            // 
            // buttonDownload
            // 
            resources.ApplyResources(this.buttonDownload, "buttonDownload");
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonExit
            // 
            resources.ApplyResources(this.buttonExit, "buttonExit");
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // buttonStart
            // 
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.autostartoverlay);
            this.groupBox1.Controls.Add(this.buttonDownload);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.buttonExit);
            this.groupBox1.Controls.Add(this.buttonManage);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // autostartoverlay
            // 
            resources.ApplyResources(this.autostartoverlay, "autostartoverlay");
            this.autostartoverlay.BackColor = System.Drawing.Color.Transparent;
            this.autostartoverlay.Name = "autostartoverlay";
            this.autostartoverlay.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.buttonOpen);
            this.groupBox2.Controls.Add(this.buttonURL);
            this.groupBox2.Controls.Add(this.skinList);
            this.groupBox2.Controls.Add(this.copyURL);
            this.groupBox2.Controls.Add(this.buttonAddURL);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // ACTWebSocketMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.serverStatus);
            this.Controls.Add(this.othersets);
            this.Controls.Add(this.hostdata);
            this.Controls.Add(this.startoption);
            this.Name = "ACTWebSocketMain";
            this.Load += new System.EventHandler(this.ACTWebSocket_Load);
            this.startoption.ResumeLayout(false);
            this.hostdata.ResumeLayout(false);
            this.hostdata.PerformLayout();
            this.othersets.ResumeLayout(false);
            this.serverStatus.ResumeLayout(false);
            this.serverStatus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #endregion
        public ACTWebSocketMain()
        {
            ChatFilter = false;
            InitializeComponent();
            UpdateOverlayProc();
        }

        ~ACTWebSocketMain()
        {
            SaveSettings();
        }

        Label lblStatus;    // The status label that appears in ACT's Plugin tab
        string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACTWebSocket.config.json");
        string overlaySettingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACTWebSocket.overlay.json");

        #region IActPluginV1 Members

        static List<KeyValuePair<string, MiniParseSortType>> sortTypeDict = new List<KeyValuePair<string, MiniParseSortType>>()
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
                core.overlaySkinDirectory = overlaySkinDirectory;
                core.hwnd = Handle;
            }
            progressBar.Hide();
            progressBar.BringToFront();
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
            Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space
            LoadSettings();
            BeforeLogLineReadUse.Checked = BeforeLogLineRead;
            OnLogLineReadUse.Checked = OnLogLineRead;
            MiniParseUse.Checked = MiniParse;
            UPNPUse.Checked = UseUPnP;
            randomURL.Checked = RandomURL;
            skinOnAct.Checked = SkinOnAct;
            chatFilter.Checked = ChatFilter;
            autostart.Checked = AutoRun;
            autostartoverlay.Checked = AutoOverlay;
            StopServer();

            if (core != null)
            {
                core.Filters["/BeforeLogLineRead"] = BeforeLogLineReadUse.Checked;
                core.Filters["/OnLogLineRead"] = OnLogLineReadUse.Checked;
                core.Filters["/MiniParse"] = MiniParseUse.Checked;
                // not configurable ?
                core.Config.SortKey = "encdps";
                core.Config.SortType = MiniParseSortType.NumericDescending;
            }

            try
            {
                if (autostart.Checked)
                {
                    StartServer();
                }
                else
                {
                    StopServer();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                StopServer();
            }

            try
            {
                if (autostartoverlay.Checked)
                {
                    buttonStart_Click(null, null);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                StopServer();
            }

            // Create some sort of parsing event handler.  After the "+=" hit TAB twice and the code will be generated for you.
            ActGlobals.oFormActMain.BeforeLogLineRead += oFormActMain_BeforeLogLineRead;
            ActGlobals.oFormActMain.OnLogLineRead += oFormActMain_OnLogLineRead;
            var s = ActGlobals.oFormActMain.ActPlugins;
            lblStatus.Text = "Plugin Started";
        }

        public void DeInitPlugin()
        {
            //StopServer();
            // Unsubscribe from any events you listen to when exiting!
            ActGlobals.oFormActMain.BeforeLogLineRead -= oFormActMain_BeforeLogLineRead;
            ActGlobals.oFormActMain.OnLogLineRead -= oFormActMain_OnLogLineRead;

            SaveSettings();
            buttonExit_Click(null, null);
            //browser.ExecuteScriptAsync("api_overlaywindow_close_all();");
            lblStatus.Text = "Plugin Exited";
        }

        #endregion

        void oFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
        {
        }

        void LoadSettings()
        {
            if (File.Exists(settingsFile))
            {
                JObject obj = new JObject();
                try {
                    String s = File.ReadAllText(settingsFile);
                    obj = JObject.Parse(s);
                    JToken token;
                    if (obj.TryGetValue("Port", out token))
                    {
                        Port = token.ToObject<int>();
                    }
                    else
                    {
                        Port = 10501;
                    }
                    if (obj.TryGetValue("UPnPPort", out token))
                    {
                        UPnPPort = token.ToObject<int>();
                    }
                    else
                    {
                        UPnPPort = Port;
                    }
                    if (obj.TryGetValue("Hostname", out token))
                    {
                        Hostname = token.ToObject<String>();
                    }
                    else
                    {
                        Hostname = "localhost";
                    }
                    if (obj.TryGetValue("RandomURL", out token))
                    {
                        RandomURL = token.ToObject<bool>();
                    }
                    else
                    {
                        RandomURL = false;
                    }
                    if (obj.TryGetValue("UseUPnP", out token))
                    {
                        UseUPnP = token.ToObject<bool>();
                    }
                    else
                    {
                        UseUPnP = false;
                    }
                    if (obj.TryGetValue("SkinOnAct", out token))
                    {
                        SkinOnAct = token.ToObject<bool>();
                    }
                    else
                    {
                        SkinOnAct = true;
                    }
                    if (obj.TryGetValue("AutoRun", out token))
                    {
                        AutoRun = token.ToObject<bool>();
                    }
                    else
                    {
                        AutoRun = false;
                    }
                    if (obj.TryGetValue("AutoOverlay", out token))
                    {
                        AutoOverlay = token.ToObject<bool>();
                    }
                    else
                    {
                        AutoOverlay = false;
                    }
                    if (obj.TryGetValue("BeforeLogLineRead", out token))
                    {
                        BeforeLogLineRead = token.ToObject<bool>();
                    }
                    else
                    {
                        BeforeLogLineRead = false;
                    }
                    if (obj.TryGetValue("ChatFilter", out token))
                    {
                        ChatFilter = token.ToObject<bool>();
                    }
                    else
                    {
                        ChatFilter = false;
                    }
                    if (obj.TryGetValue("OnLogLineRead", out token))
                    {
                        OnLogLineRead = token.ToObject<bool>();
                    }
                    else
                    {
                        OnLogLineRead = false;
                    }
                    if (obj.TryGetValue("MiniParse", out token))
                    {
                        MiniParse = token.ToObject<bool>();
                    }
                    else
                    {
                        MiniParse = true;
                    }
                    if(obj.TryGetValue("SkinURLList", out token))
                    {
                        SkinURLList.Clear();
                        foreach (var a in token.Values<string>())
                        {
                            SkinURLList.Add(a);
                        }
                        buttonRefresh_Click(null, null);
                    }
                }
                catch (Exception e)
                {
                }
                hostnames.Text = Hostname;
            }
        }


        void SaveSettings()
        {
            UpdateFormSettings();
            JObject obj = new JObject();
            obj.Add("Port", Port);
            obj.Add("UPnPPort", UPnPPort);
            obj.Add("Hostname", Hostname);
            obj.Add("RandomURL", RandomURL);
            obj.Add("UseUPnP", UseUPnP);
            obj.Add("AutoRun", AutoRun);
            obj.Add("AutoOverlay", AutoOverlay);
            obj.Add("BeforeLogLineRead", BeforeLogLineRead);
            obj.Add("OnLogLineRead", OnLogLineRead);
            obj.Add("MiniParse", MiniParse);
            obj.Add("ChatFilter", ChatFilter);
            obj.Add("SkinOnAct", SkinOnAct);
            JArray skins = new JArray();
            foreach (string a in SkinURLList)
            {
                skins.Add(a);
            }
            obj.Add("SkinURLList", skins);
            String s = obj.ToString();
            File.WriteAllText(settingsFile, s);
        }

        private List<String> addrs = new List<String>();
        private void ACTWebSocket_Load(object sender, EventArgs e)
        {

            Task task = Task.Factory.StartNew(() =>
            {
                String strHostName = string.Empty;
                strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

                addrs.Clear();
                addrs.Add("127.0.0.1");
                {
                    IPAddress[] addr = ipEntry.AddressList;
                    for (int i = 0; i < addr.Length; i++)
                    {
                        if (addr[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            addrs.Add(addr[i].ToString());
                    }
                }
                String ipaddress = Utility.GetExternalIp();
                if (ipaddress.Length > 0)
                    addrs.Add(ipaddress);

                addrs = Utility.Distinct<String>(addrs);
                addrs.Sort();

            });
            Task UITask = task.ContinueWith((t) =>
            {
                foreach (var addr in addrs)
                {
                    hostnames.Items.Add(addr);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void oFormActMain_BeforeLogLineRead(
            bool isImport,
            LogLineEventArgs logInfo)
        {
            FilterChatings("/BeforeLogLineRead", logInfo);
        }

        private void oFormActMain_OnLogLineRead(
            bool isImport,
            LogLineEventArgs logInfo)
        {
            FilterChatings("/OnLogLineRead", logInfo);
        }

        private void FilterChatings(string url, LogLineEventArgs e)
        {
            string[] data = e.logLine.Split('|');

            try
            {
                if (Convert.ToInt32(data[0]) == 0)
                {
                    if (Convert.ToInt32(data[2], 16) < 54 && ChatFilter)
                    {
                        return;
                    }
                }
            }catch(Exception)
            {
                // TODO ?
            }
            core.Broadcast(url, "Chat", e.logLine);
        }

        #region Web JSObject Part
        public int Port { get; set; }
        public int UPnPPort { get; set; }
        public string Hostname { get; set; }
        public bool SkinOnAct { get; set; }
        public bool RandomURL
        {
            get
            {
                return core == null || core.randomDir != null;
            }
            set
            {
                if (value)
                {
                    core.randomDir = Guid.NewGuid().ToString();
                }
                else
                {
                    core.randomDir = null;
                }
            }
        }

        public bool UseUPnP { get; set; }
        public bool AutoRun { get; set; }
        public bool AutoOverlay { get; set; }
        public bool ChatFilter { get; set; }
        public List<String> SkinURLList = new List<String>();

        public void StartServer()
        {
            core.Filters["/BeforeLogLineRead"] = true;
            core.Filters["/OnLogLineRead"] = true;
            core.Filters["/MiniParse"] = true;

            if (UseUPnP)
            {
                Task upnpTask = new Task(async () =>
                {
                    try
                    {
                        var discoverer = new NatDiscoverer();
                        var cts = new CancellationTokenSource(10000); // 10secs
                        var device = await discoverer.DiscoverDeviceAsync(PortMapper.Upnp, cts);

                        // not registered when first invoke...
                        await device.CreatePortMapAsync(new Mapping(Protocol.Tcp, Port, UPnPPort, "ACTWebSocket Port"));
                        await device.CreatePortMapAsync(new Mapping(Protocol.Tcp, Port, UPnPPort, "ACTWebSocket Port"));
                        await device.CreatePortMapAsync(new Mapping(Protocol.Tcp, Port, UPnPPort, "ACTWebSocket Port"));
                    }
                    catch(Exception e)
                    {

                    }
                });
                upnpTask.Start();
            }
            
            var addresses = Dns.GetHostAddresses(Hostname);

            bool localhostOnly = false;
            for(int i=0;i< addresses.Length;++i)
            {
                var ip = addresses[i];
                if (IPAddress.IsLoopback(ip))
                {
                    localhostOnly = true;
                    break;
                }
            }
            
            if (RandomURL)
            {
                core.randomDir = Guid.NewGuid().ToString();
            }
            else
            {
                core.randomDir = null;
            }
            try
            {
                if (UseUPnP)
                {
                    core.StartServer(localhostOnly ? "127.0.0.1" : "0.0.0.0", Port, UPnPPort, Hostname, SkinOnAct);
                }
                else
                {
                    core.StartServer(localhostOnly ? "127.0.0.1" : "0.0.0.0", Port, Port, Hostname, SkinOnAct);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                StopServer();
            }
            //BeforeLogLineReadUse.Enabled = false;
            //OnLogLineReadUse.Enabled = false;
            //MiniParseUse.Enabled = false;
            //chatFilter.Enabled = false;
            skinOnAct.Enabled = false;
            UPNPUse.Enabled = false;
            randomURL.Enabled = false;
            buttonOn.Enabled = false;
            port.Enabled = false;
            uPnPPort.Enabled = false;
            hostnames.Enabled = false;
            buttonOff.Enabled = true;
        }

        public void StopServer()
        {
            core.StopServer();
            //BeforeLogLineReadUse.Enabled = true;
            //OnLogLineReadUse.Enabled = true;
            //MiniParseUse.Enabled = true;
            //chatFilter.Enabled = true;
            skinOnAct.Enabled = true;
            UPNPUse.Enabled = true;
            randomURL.Enabled = true;
            buttonOn.Enabled = true;
            port.Enabled = true;
            uPnPPort.Enabled = false;
            hostnames.Enabled = true;
            buttonOff.Enabled = false;
        }

        public void consolelog(object s)
        {
            Console.WriteLine(s);
        }
        
        public bool BeforeLogLineRead
        {
            get {
                try
                {
                    if (core != null)
                    {
                        return core.Filters["/BeforeLogLineRead"];
                    }
                }
                catch(Exception)
                {
                }
                return false;
            }
            set
            {
                if (core != null)
                {
                    core.Filters["/BeforeLogLineRead"] = value;
                }
            }
        }

        public bool OnLogLineRead
        {
            get
            {
                try
                {
                    if (core != null)
                    {
                        return core.Filters["/OnLogLineRead"];
                    }
                }
                catch (Exception)
                {
                }
                return false;
            }
            set
            {
                if (core != null)
                {
                    core.Filters["/OnLogLineRead"] = value;
                }
            }
        }

        public bool MiniParse 
        {
            get
            {
                try
                {
                    if (core != null)
                    {
                        return core.Filters["/MiniParse"];
                    }
                }
                catch (Exception)
                {
                }
                return true;
            }
            set
            {
                if (core != null)
                {
                    core.Filters["/MiniParse"] = value;
                }
            }
        }

        public string overlayProcDir { get; private set; }
        public string overlayProcExe { get; private set; }

        public List<string> GetSkinList()
        {
            string dir = SkinOnAct ? overlaySkinDirectory : pluginDirectory;
            List<string> list = new List<string>();
            foreach (string file in Directory.EnumerateFiles(dir, "*.html", SearchOption.AllDirectories))
            {
                list.Add(Utility.GetRelativePath(file, dir));
            }
            return list;
        }

        public string getURLPath(string skinPath = "")
        {
            string url = "";
            {
                url = "://" + Hostname + ":" + Port + "/";
            }
            if (core.randomDir != null)
            {
                url += core.randomDir + "/";
            }
            if (skinPath.ToLower().StartsWith("http"))
            {
                try
                {
                    Uri uri = new Uri(skinPath + "?HOST_PORT=" + "ws" + url);
                    return uri.ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                if (skinPath.Length > 0)
                {
                    try
                    {
                        string fullURL = "http" + url + Uri.EscapeDataString(skinPath);
                        fullURL = fullURL.Replace("%5C", "/");
                        fullURL = fullURL.Replace("%2F", "/");
                        return fullURL;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else
                {
                    return url;
                }
            }
            return null;
        }

        public void copyURLPath(string skinPath = "")
        {
            string url = getURLPath(skinPath);
            if(url != null)
            {
                Clipboard.SetText(url);
            }
        }
        #endregion Web JSObject Part End

        private void UpdateFormSettings()
        {
            BeforeLogLineRead = BeforeLogLineReadUse.Checked;
            OnLogLineRead = OnLogLineReadUse.Checked;
            MiniParse = MiniParseUse.Checked;
            UseUPnP = UPNPUse.Checked;
            RandomURL = randomURL.Checked;
            SkinOnAct = skinOnAct.Checked;
            ChatFilter = chatFilter.Checked;
            AutoRun = autostart.Checked;
            AutoOverlay = autostartoverlay.Checked;
            Hostname = hostnames.Text;
            try
            {
                Port = Convert.ToInt32(port.Text);
            }
            catch(Exception ex)
            {
                Port = 10501;
                port.Text = Port.ToString();
            }
            try
            {
                UPnPPort = Convert.ToInt32(uPnPPort.Text);
            }
            catch (Exception ex)
            {
                UPnPPort = Port;
                uPnPPort.Text = UPnPPort.ToString();
            }
        }

        private void buttonOn_Click(object sender, EventArgs e)
        {
            UpdateFormSettings();
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

        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void buttonAddURL_Click(object sender, EventArgs e)
        {
            string url = ShowDialog("Add URL", "Add URL").Trim() ;
            SkinURLList.Add(url);
            AddURL(url);
        }

        private void buttonURL_Click(object sender, EventArgs e)
        {
            if (skinList.SelectedItems == null) return;
            if(skinList.SelectedItems.Count > 0)
            {
                string url = skinList.SelectedItems[0].Text;
                SkinURLList.Remove(url);
                skinList.Items.RemoveAt(skinList.SelectedItems[0].Index);
            }
        }

        private void copyURL_Click(object sender, EventArgs e)
        {
            if (skinList.SelectedItems == null) return;
            if (skinList.SelectedItems.Count > 0)
            {
                string url = (string)skinList.SelectedItems[0].Tag;
                copyURLPath(url);
            }
            else
            {
                copyURLPath();
            }
        }

        string GetTitle(string path)
        {
            string dir = SkinOnAct ? overlaySkinDirectory : pluginDirectory;
            string title = null;
            try
            {
                if (File.Exists(path))
                {
                    string source = File.ReadAllText(path);
                    title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                }
                if (File.Exists(dir + "/" + path))
                {
                    string source = File.ReadAllText(dir + "/" + path);
                    title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                }
                else
                {
                    WebClient wc = new WebClient();
                    string source = wc.DownloadString(path);
                    title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                }
            }
            catch (Exception ex)
            {

            }
            return title;
        }

        private void AddURL(string a)
        {
            string title = null;
            Task task = Task.Factory.StartNew(() =>
            {
                title = GetTitle(a);
            });
            Task UITask = task.ContinueWith((t) =>
            {
                bool find = false;
                foreach (ListViewItem i in skinList.Items)
                {
                    if (((string)i.Tag).CompareTo(a) == 0)
                    {
                        find = true;
                    }
                }

                if(!find)
                {
                    title = title == null ? a : title;
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = title;
                    lvi.Tag = a;
                    skinList.Items.Add(lvi);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            skinList.Items.Clear();
            foreach (var a in SkinURLList)
            {
                AddURL(a);
            }

            List<string> list =  GetSkinList();
            foreach(var a in list)
            {
                bool find = false;
                for(int i=0;i<skinList.Items.Count;++i)
                {
                    if(skinList.Items[i].Tag == a)
                    {
                        find = true;
                    }
                }
                if(!find)
                {
                    AddURL(a);
                }
            }
        }

        private void MiniParseUse_CheckedChanged(object sender, EventArgs e)
        {
            MiniParse = MiniParseUse.Checked;
        }

        private void OnLogLineReadUse_CheckedChanged(object sender, EventArgs e)
        {
            OnLogLineRead = OnLogLineReadUse.Checked;
        }

        private void BeforeLogLineReadUse_CheckedChanged(object sender, EventArgs e)
        {
            BeforeLogLineRead = BeforeLogLineReadUse.Checked;
        }

        private void chatFilter_CheckedChanged(object sender, EventArgs e)
        {
            ChatFilter = chatFilter.Checked;
        }

        private void UPNPUse_CheckedChanged(object sender, EventArgs e)
        {
            uPnPPort.Enabled = UPNPUse.Checked;
        }

        private void skinOnAct_CheckedChanged(object sender, EventArgs e)
        {
            SkinOnAct = skinOnAct.Checked;
            buttonRefresh_Click(sender, e);
        }

        void UpdateOverlayProc()
        {
            bool b = File.Exists(overlayProcExe);
            buttonOpen.Enabled = b;
            buttonExit.Enabled = b;
            buttonManage.Enabled = b;
            buttonStart.Enabled = b;
        }
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (skinList.SelectedItems.Count > 0)
            {
                string url = (string)skinList.SelectedItems[0].Tag;
                url = getURLPath(url);
                if(url != null)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(overlayProcExe);
                    startInfo.WorkingDirectory = overlayProcDir;
                    startInfo.Arguments = "-o " + Utility.Base64Encoding(url);
                    Process.Start(startInfo);
                }
            }
        }

        private void buttonManage_Click(object sender, EventArgs e)
        {
            UpdateOverlayProc();
            if (!buttonManage.Enabled)
                return;
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(overlayProcExe);
                startInfo.WorkingDirectory = overlayProcDir;
                startInfo.Arguments = "-m";
                Process.Start(startInfo);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            UpdateOverlayProc();
            try
            {
                if(File.Exists(overlayProcExe))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(overlayProcExe);
                    startInfo.WorkingDirectory = overlayProcDir;
                    startInfo.Arguments = "-x";
                    Process.Start(startInfo).WaitForExit();
                }
                buttonDownload.Enabled = false;
                string url = "https://www.dropbox.com/sh/ionr8nkmp49gr8d/AADzOjamXxPGjOzFuhBSthPHa?dl=1";
                WebClient webClient = new WebClient();
                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Show();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(url), pluginDirectory + "/overlay_proc.zip");
            }
            catch (Exception ex)
            {
                progressBar.Hide();
                buttonDownload.Enabled = true;
                UpdateOverlayProc();
                MessageBox.Show(ex.Message);
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.TotalBytesToReceive == -1)
            {
                if (progressBar.Style != ProgressBarStyle.Marquee)
                {
                    progressBar.Value = 100;
                    progressBar.Style = ProgressBarStyle.Marquee;
                }
            }
            else
            {
                progressBar.Value = e.ProgressPercentage;
                progressBar.Style = ProgressBarStyle.Blocks;
            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                ZipFile z = new ZipFile(pluginDirectory + "/overlay_proc.zip");
                z.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
                z.ExtractAll(pluginDirectory + "/overlay_proc");
            });
            Task UITask = task.ContinueWith((t) =>
            {
                progressBar.Hide();
                buttonDownload.Enabled = true;
                UpdateOverlayProc();
                buttonStart_Click(null, null);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            UpdateOverlayProc();
            if (!buttonStart.Enabled)
                return;
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(overlayProcExe);
                startInfo.WorkingDirectory = overlayProcDir;
                startInfo.Arguments = "";
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            UpdateOverlayProc();
            if (!buttonExit.Enabled)
                return;
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(overlayProcExe);
                startInfo.WorkingDirectory = overlayProcDir;
                startInfo.Arguments = "-x";
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void port_TextChanged(object sender, EventArgs e)
        {
            uPnPPort.Text = port.Text;
        }

    }
}
