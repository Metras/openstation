using System;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass.AddOn.Tags;
using Un4seen.Bass.Misc;
using FileHelpers;
using System.Linq;
using ComLib.Scheduling;
using NLog;
using System.Reflection;


namespace OpenStation
{


	public class MainForm : System.Windows.Forms.Form
    {

        #region Private Fields

        private System.Windows.Forms.Button buttonAddFile;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ProgressBar progressBarLeft;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBarRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTime;
        private ListBox listBoxPlaylist;
        private System.Windows.Forms.Timer timerUpdate;
        private IContainer components;
        private Label labelCurrentTrack;
        private Label labelRemain;
        private Label label3;
        private Label label4;
        private Button buttonSetEnvelope;
        private Button buttonRemoveEnvelope;
        private Button BtOpenSchedule;
        private OpenFileDialog OfdOpenSchedule;
        private Button BtPlay;
        private Button BtToggleZoom;
        private Button BtStop;
        private Panel panel1;
        private Panel Info;
        private Panel panel3;
        private Panel panel4;
        private Panel Buttons;
        private Panel panel6;
        private PictureBox PbWaveform2;
        private Button BtRemoveTrack;
        private Panel PanelLibrary;
        private DataGridView DgvLibrary;
        private Songs songs;
        private DataGridViewTextBoxColumn fileDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn introDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn segueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn endDataGridViewTextBoxColumn;
        private Panel PanelLibraryDetail;
        private PictureBox EditorPB;
        private Button button1;
        private OpenFileDialog AddTrackToLibraryOFD;
		private System.Windows.Forms.PictureBox UIWaveFormPB;
        private Panel panel2;
        private Label SegueTimeLBL;
        private Label label10;
        private Label label9;
        private Button CueStartTimeBTN;
        private NumericUpDown StartTimeNUD;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private BindingSource openStationDSBindingSource;
        private OpenStationDS openStationDS;
        private NumericUpDown EditorSegueTimeNUD;
        private Button EditorSegueTimeCueBTN;
        private NumericUpDown EditorStartTimeNUD;
        private Button EditorStartTimeCueBTN;
        private Label label6;
        private Label label7;
        private TextBox EditorArtistTitleTB;
        private Button EditorPlayBTN;
        private Button EditorStopBTN;
        private WaveForm TrackWF;
        private WaveForm EditorWf;
        private System.Windows.Forms.Timer EditorTimer;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView ScheduleDgw;
        private DataGridViewTextBoxColumn airtimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemTitleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemFilenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Timer timerUpdateSeconds;
        private BackgroundWorker AddScheduleItemToPlayerBGW;
        private Track EditorTrack;
        
        #endregion


        public MainForm()
		{

                InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBarLeft = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarRight = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.UIWaveFormPB = new System.Windows.Forms.PictureBox();
            this.listBoxPlaylist = new System.Windows.Forms.ListBox();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.labelCurrentTrack = new System.Windows.Forms.Label();
            this.labelRemain = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSetEnvelope = new System.Windows.Forms.Button();
            this.buttonRemoveEnvelope = new System.Windows.Forms.Button();
            this.BtOpenSchedule = new System.Windows.Forms.Button();
            this.OfdOpenSchedule = new System.Windows.Forms.OpenFileDialog();
            this.BtPlay = new System.Windows.Forms.Button();
            this.BtToggleZoom = new System.Windows.Forms.Button();
            this.BtStop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelLibrary = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ScheduleDgw = new System.Windows.Forms.DataGridView();
            this.airtimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemFilenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openStationDS = new OpenStation.OpenStationDS();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PanelLibraryDetail = new System.Windows.Forms.Panel();
            this.EditorPlayBTN = new System.Windows.Forms.Button();
            this.EditorStopBTN = new System.Windows.Forms.Button();
            this.EditorSegueTimeNUD = new System.Windows.Forms.NumericUpDown();
            this.EditorSegueTimeCueBTN = new System.Windows.Forms.Button();
            this.EditorStartTimeNUD = new System.Windows.Forms.NumericUpDown();
            this.EditorStartTimeCueBTN = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.EditorArtistTitleTB = new System.Windows.Forms.TextBox();
            this.EditorPB = new System.Windows.Forms.PictureBox();
            this.DgvLibrary = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openStationDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Buttons = new System.Windows.Forms.Panel();
            this.BtRemoveTrack = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Panel();
            this.PbWaveform2 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StartTimeNUD = new System.Windows.Forms.NumericUpDown();
            this.CueStartTimeBTN = new System.Windows.Forms.Button();
            this.SegueTimeLBL = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.AddTrackToLibraryOFD = new System.Windows.Forms.OpenFileDialog();
            this.EditorTimer = new System.Windows.Forms.Timer(this.components);
            this.timerUpdateSeconds = new System.Windows.Forms.Timer(this.components);
            this.AddScheduleItemToPlayerBGW = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.UIWaveFormPB)).BeginInit();
            this.panel1.SuspendLayout();
            this.PanelLibrary.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleDgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openStationDS)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.PanelLibraryDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditorSegueTimeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditorStartTimeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditorPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLibrary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openStationDSBindingSource)).BeginInit();
            this.Buttons.SuspendLayout();
            this.Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbWaveform2)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartTimeNUD)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(911, 15);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(147, 23);
            this.buttonAddFile.TabIndex = 0;
            this.buttonAddFile.Text = "Add Track to Playlist";
            this.buttonAddFile.Visible = false;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Audio Files (*.mp3;*.ogg;*.wav)|*.mp3;*.ogg;*.wav";
            this.openFileDialog.Title = "Select an audio file to play";
            // 
            // progressBarLeft
            // 
            this.progressBarLeft.Location = new System.Drawing.Point(158, 12);
            this.progressBarLeft.Maximum = 32768;
            this.progressBarLeft.Name = "progressBarLeft";
            this.progressBarLeft.Size = new System.Drawing.Size(181, 12);
            this.progressBarLeft.Step = 1;
            this.progressBarLeft.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(141, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "L";
            // 
            // progressBarRight
            // 
            this.progressBarRight.Location = new System.Drawing.Point(158, 28);
            this.progressBarRight.Maximum = 32768;
            this.progressBarRight.Name = "progressBarRight";
            this.progressBarRight.Size = new System.Drawing.Size(181, 12);
            this.progressBarRight.Step = 1;
            this.progressBarRight.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(141, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "R";
            // 
            // labelTime
            // 
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(0, 24);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(65, 15);
            this.labelTime.TabIndex = 12;
            this.labelTime.Text = "00:00:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIWaveFormPB
            // 
            this.UIWaveFormPB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UIWaveFormPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UIWaveFormPB.Dock = System.Windows.Forms.DockStyle.Top;
            this.UIWaveFormPB.ErrorImage = null;
            this.UIWaveFormPB.InitialImage = null;
            this.UIWaveFormPB.Location = new System.Drawing.Point(0, 0);
            this.UIWaveFormPB.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.UIWaveFormPB.Name = "UIWaveFormPB";
            this.UIWaveFormPB.Size = new System.Drawing.Size(1152, 60);
            this.UIWaveFormPB.TabIndex = 15;
            this.UIWaveFormPB.TabStop = false;
            this.UIWaveFormPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWaveForm_MouseDown);
            // 
            // listBoxPlaylist
            // 
            this.listBoxPlaylist.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxPlaylist.FormattingEnabled = true;
            this.listBoxPlaylist.Location = new System.Drawing.Point(15, 186);
            this.listBoxPlaylist.Name = "listBoxPlaylist";
            this.listBoxPlaylist.Size = new System.Drawing.Size(1152, 56);
            this.listBoxPlaylist.TabIndex = 16;
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 50;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // labelCurrentTrack
            // 
            this.labelCurrentTrack.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentTrack.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTrack.Location = new System.Drawing.Point(3, 4);
            this.labelCurrentTrack.Name = "labelCurrentTrack";
            this.labelCurrentTrack.Size = new System.Drawing.Size(599, 29);
            this.labelCurrentTrack.TabIndex = 10;
            // 
            // labelRemain
            // 
            this.labelRemain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemain.Location = new System.Drawing.Point(70, 24);
            this.labelRemain.Name = "labelRemain";
            this.labelRemain.Size = new System.Drawing.Size(65, 15);
            this.labelRemain.TabIndex = 12;
            this.labelRemain.Text = "00:00:00";
            this.labelRemain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Elapsed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Remain";
            // 
            // buttonSetEnvelope
            // 
            this.buttonSetEnvelope.Location = new System.Drawing.Point(611, 15);
            this.buttonSetEnvelope.Name = "buttonSetEnvelope";
            this.buttonSetEnvelope.Size = new System.Drawing.Size(110, 23);
            this.buttonSetEnvelope.TabIndex = 0;
            this.buttonSetEnvelope.Text = "Set Envelope";
            this.buttonSetEnvelope.Visible = false;
            this.buttonSetEnvelope.Click += new System.EventHandler(this.buttonSetEnvelope_Click);
            // 
            // buttonRemoveEnvelope
            // 
            this.buttonRemoveEnvelope.Location = new System.Drawing.Point(611, 59);
            this.buttonRemoveEnvelope.Name = "buttonRemoveEnvelope";
            this.buttonRemoveEnvelope.Size = new System.Drawing.Size(110, 23);
            this.buttonRemoveEnvelope.TabIndex = 0;
            this.buttonRemoveEnvelope.Text = "Remove Envelope";
            this.buttonRemoveEnvelope.Visible = false;
            this.buttonRemoveEnvelope.Click += new System.EventHandler(this.buttonRemoveEnvelope_Click);
            // 
            // BtOpenSchedule
            // 
            this.BtOpenSchedule.Location = new System.Drawing.Point(749, 15);
            this.BtOpenSchedule.Name = "BtOpenSchedule";
            this.BtOpenSchedule.Size = new System.Drawing.Size(110, 23);
            this.BtOpenSchedule.TabIndex = 17;
            this.BtOpenSchedule.Text = "Open Playlist";
            this.BtOpenSchedule.UseVisualStyleBackColor = true;
            this.BtOpenSchedule.Visible = false;
            this.BtOpenSchedule.Click += new System.EventHandler(this.BtOpenSchedule_Click);
            // 
            // OfdOpenSchedule
            // 
            this.OfdOpenSchedule.FileName = "openFileDialog1";
            // 
            // BtPlay
            // 
            this.BtPlay.Location = new System.Drawing.Point(18, 15);
            this.BtPlay.Name = "BtPlay";
            this.BtPlay.Size = new System.Drawing.Size(110, 23);
            this.BtPlay.TabIndex = 18;
            this.BtPlay.Text = "Play";
            this.BtPlay.UseVisualStyleBackColor = true;
            this.BtPlay.Click += new System.EventHandler(this.BtPlay_Click);
            // 
            // BtToggleZoom
            // 
            this.BtToggleZoom.Location = new System.Drawing.Point(749, 59);
            this.BtToggleZoom.Name = "BtToggleZoom";
            this.BtToggleZoom.Size = new System.Drawing.Size(110, 23);
            this.BtToggleZoom.TabIndex = 19;
            this.BtToggleZoom.Text = "Toggle Zoom";
            this.BtToggleZoom.UseVisualStyleBackColor = true;
            this.BtToggleZoom.Visible = false;
            this.BtToggleZoom.Click += new System.EventHandler(this.BtToggleZoom_Click);
            // 
            // BtStop
            // 
            this.BtStop.Location = new System.Drawing.Point(18, 59);
            this.BtStop.Name = "BtStop";
            this.BtStop.Size = new System.Drawing.Size(110, 23);
            this.BtStop.TabIndex = 20;
            this.BtStop.Text = "Stop";
            this.BtStop.UseVisualStyleBackColor = true;
            this.BtStop.Click += new System.EventHandler(this.BtStop_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PanelLibrary);
            this.panel1.Controls.Add(this.Buttons);
            this.panel1.Controls.Add(this.listBoxPlaylist);
            this.panel1.Controls.Add(this.Info);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(1182, 835);
            this.panel1.TabIndex = 0;
            // 
            // PanelLibrary
            // 
            this.PanelLibrary.Controls.Add(this.tabControl1);
            this.PanelLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelLibrary.Location = new System.Drawing.Point(15, 343);
            this.PanelLibrary.Name = "PanelLibrary";
            this.PanelLibrary.Padding = new System.Windows.Forms.Padding(15);
            this.PanelLibrary.Size = new System.Drawing.Size(1152, 477);
            this.PanelLibrary.TabIndex = 23;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(15, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1122, 447);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ScheduleDgw);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1114, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Schedule";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ScheduleDgw
            // 
            this.ScheduleDgw.AllowUserToAddRows = false;
            this.ScheduleDgw.AllowUserToDeleteRows = false;
            this.ScheduleDgw.AutoGenerateColumns = false;
            this.ScheduleDgw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ScheduleDgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduleDgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.airtimeDataGridViewTextBoxColumn,
            this.itemTitleDataGridViewTextBoxColumn,
            this.itemFilenameDataGridViewTextBoxColumn});
            this.ScheduleDgw.DataMember = "Schedule";
            this.ScheduleDgw.DataSource = this.openStationDS;
            this.ScheduleDgw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduleDgw.Location = new System.Drawing.Point(3, 3);
            this.ScheduleDgw.Name = "ScheduleDgw";
            this.ScheduleDgw.Size = new System.Drawing.Size(1108, 415);
            this.ScheduleDgw.TabIndex = 0;
            // 
            // airtimeDataGridViewTextBoxColumn
            // 
            this.airtimeDataGridViewTextBoxColumn.DataPropertyName = "Airtime";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.airtimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.airtimeDataGridViewTextBoxColumn.FillWeight = 20F;
            this.airtimeDataGridViewTextBoxColumn.HeaderText = "Airtime";
            this.airtimeDataGridViewTextBoxColumn.Name = "airtimeDataGridViewTextBoxColumn";
            // 
            // itemTitleDataGridViewTextBoxColumn
            // 
            this.itemTitleDataGridViewTextBoxColumn.DataPropertyName = "ItemTitle";
            this.itemTitleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.itemTitleDataGridViewTextBoxColumn.Name = "itemTitleDataGridViewTextBoxColumn";
            // 
            // itemFilenameDataGridViewTextBoxColumn
            // 
            this.itemFilenameDataGridViewTextBoxColumn.DataPropertyName = "ItemFilename";
            this.itemFilenameDataGridViewTextBoxColumn.HeaderText = "Filename";
            this.itemFilenameDataGridViewTextBoxColumn.Name = "itemFilenameDataGridViewTextBoxColumn";
            // 
            // openStationDS
            // 
            this.openStationDS.DataSetName = "OpenStationDS";
            this.openStationDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PanelLibraryDetail);
            this.tabPage2.Controls.Add(this.DgvLibrary);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1114, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Library";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PanelLibraryDetail
            // 
            this.PanelLibraryDetail.Controls.Add(this.EditorPlayBTN);
            this.PanelLibraryDetail.Controls.Add(this.EditorStopBTN);
            this.PanelLibraryDetail.Controls.Add(this.EditorSegueTimeNUD);
            this.PanelLibraryDetail.Controls.Add(this.EditorSegueTimeCueBTN);
            this.PanelLibraryDetail.Controls.Add(this.EditorStartTimeNUD);
            this.PanelLibraryDetail.Controls.Add(this.EditorStartTimeCueBTN);
            this.PanelLibraryDetail.Controls.Add(this.label6);
            this.PanelLibraryDetail.Controls.Add(this.label7);
            this.PanelLibraryDetail.Controls.Add(this.button1);
            this.PanelLibraryDetail.Controls.Add(this.EditorArtistTitleTB);
            this.PanelLibraryDetail.Controls.Add(this.EditorPB);
            this.PanelLibraryDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelLibraryDetail.Location = new System.Drawing.Point(397, 3);
            this.PanelLibraryDetail.Margin = new System.Windows.Forms.Padding(0);
            this.PanelLibraryDetail.Name = "PanelLibraryDetail";
            this.PanelLibraryDetail.Padding = new System.Windows.Forms.Padding(15, 0, 15, 15);
            this.PanelLibraryDetail.Size = new System.Drawing.Size(714, 415);
            this.PanelLibraryDetail.TabIndex = 10;
            this.PanelLibraryDetail.Visible = false;
            // 
            // EditorPlayBTN
            // 
            this.EditorPlayBTN.Location = new System.Drawing.Point(574, 267);
            this.EditorPlayBTN.Name = "EditorPlayBTN";
            this.EditorPlayBTN.Size = new System.Drawing.Size(136, 23);
            this.EditorPlayBTN.TabIndex = 25;
            this.EditorPlayBTN.Text = "Play";
            this.EditorPlayBTN.UseVisualStyleBackColor = true;
            this.EditorPlayBTN.Click += new System.EventHandler(this.EditorPlayBTN_Click);
            // 
            // EditorStopBTN
            // 
            this.EditorStopBTN.Location = new System.Drawing.Point(574, 296);
            this.EditorStopBTN.Name = "EditorStopBTN";
            this.EditorStopBTN.Size = new System.Drawing.Size(136, 23);
            this.EditorStopBTN.TabIndex = 26;
            this.EditorStopBTN.Text = "Stop";
            this.EditorStopBTN.UseVisualStyleBackColor = true;
            this.EditorStopBTN.Click += new System.EventHandler(this.EditorStopBTN_Click);
            // 
            // EditorSegueTimeNUD
            // 
            this.EditorSegueTimeNUD.Location = new System.Drawing.Point(81, 288);
            this.EditorSegueTimeNUD.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.EditorSegueTimeNUD.Name = "EditorSegueTimeNUD";
            this.EditorSegueTimeNUD.Size = new System.Drawing.Size(72, 21);
            this.EditorSegueTimeNUD.TabIndex = 24;
            // 
            // EditorSegueTimeCueBTN
            // 
            this.EditorSegueTimeCueBTN.Location = new System.Drawing.Point(153, 287);
            this.EditorSegueTimeCueBTN.Name = "EditorSegueTimeCueBTN";
            this.EditorSegueTimeCueBTN.Size = new System.Drawing.Size(38, 23);
            this.EditorSegueTimeCueBTN.TabIndex = 23;
            this.EditorSegueTimeCueBTN.Text = "Cue";
            this.EditorSegueTimeCueBTN.UseVisualStyleBackColor = true;
            // 
            // EditorStartTimeNUD
            // 
            this.EditorStartTimeNUD.Location = new System.Drawing.Point(81, 241);
            this.EditorStartTimeNUD.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.EditorStartTimeNUD.Name = "EditorStartTimeNUD";
            this.EditorStartTimeNUD.Size = new System.Drawing.Size(72, 21);
            this.EditorStartTimeNUD.TabIndex = 22;
            // 
            // EditorStartTimeCueBTN
            // 
            this.EditorStartTimeCueBTN.Location = new System.Drawing.Point(153, 240);
            this.EditorStartTimeCueBTN.Name = "EditorStartTimeCueBTN";
            this.EditorStartTimeCueBTN.Size = new System.Drawing.Size(38, 23);
            this.EditorStartTimeCueBTN.TabIndex = 21;
            this.EditorStartTimeCueBTN.Text = "Cue";
            this.EditorStartTimeCueBTN.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Segue Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Start Time";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(574, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Add Track to Library";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditorArtistTitleTB
            // 
            this.EditorArtistTitleTB.BackColor = System.Drawing.Color.Gray;
            this.EditorArtistTitleTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditorArtistTitleTB.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorArtistTitleTB.Location = new System.Drawing.Point(15, 193);
            this.EditorArtistTitleTB.Name = "EditorArtistTitleTB";
            this.EditorArtistTitleTB.ReadOnly = true;
            this.EditorArtistTitleTB.Size = new System.Drawing.Size(684, 26);
            this.EditorArtistTitleTB.TabIndex = 2;
            // 
            // EditorPB
            // 
            this.EditorPB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EditorPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditorPB.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditorPB.ErrorImage = null;
            this.EditorPB.InitialImage = null;
            this.EditorPB.Location = new System.Drawing.Point(15, 0);
            this.EditorPB.Margin = new System.Windows.Forms.Padding(0);
            this.EditorPB.Name = "EditorPB";
            this.EditorPB.Size = new System.Drawing.Size(684, 193);
            this.EditorPB.TabIndex = 16;
            this.EditorPB.TabStop = false;
            this.EditorPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditorPB_MouseDown);
            // 
            // DgvLibrary
            // 
            this.DgvLibrary.AllowUserToAddRows = false;
            this.DgvLibrary.AllowUserToResizeColumns = false;
            this.DgvLibrary.AllowUserToResizeRows = false;
            this.DgvLibrary.AutoGenerateColumns = false;
            this.DgvLibrary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLibrary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.DgvLibrary.DataMember = "Songs";
            this.DgvLibrary.DataSource = this.openStationDSBindingSource;
            this.DgvLibrary.Dock = System.Windows.Forms.DockStyle.Left;
            this.DgvLibrary.Location = new System.Drawing.Point(3, 3);
            this.DgvLibrary.Name = "DgvLibrary";
            this.DgvLibrary.ReadOnly = true;
            this.DgvLibrary.Size = new System.Drawing.Size(394, 415);
            this.DgvLibrary.TabIndex = 0;
            this.DgvLibrary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLibrary_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "File";
            this.dataGridViewTextBoxColumn1.HeaderText = "File";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Start";
            this.dataGridViewTextBoxColumn2.HeaderText = "Start";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Segue";
            this.dataGridViewTextBoxColumn3.HeaderText = "Segue";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "End";
            this.dataGridViewTextBoxColumn4.HeaderText = "End";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Intro";
            this.dataGridViewTextBoxColumn5.HeaderText = "Intro";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // openStationDSBindingSource
            // 
            this.openStationDSBindingSource.DataSource = this.openStationDS;
            this.openStationDSBindingSource.Position = 0;
            // 
            // Buttons
            // 
            this.Buttons.Controls.Add(this.BtRemoveTrack);
            this.Buttons.Controls.Add(this.BtToggleZoom);
            this.Buttons.Controls.Add(this.BtOpenSchedule);
            this.Buttons.Controls.Add(this.BtPlay);
            this.Buttons.Controls.Add(this.BtStop);
            this.Buttons.Controls.Add(this.buttonAddFile);
            this.Buttons.Controls.Add(this.buttonSetEnvelope);
            this.Buttons.Controls.Add(this.buttonRemoveEnvelope);
            this.Buttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.Buttons.Location = new System.Drawing.Point(15, 242);
            this.Buttons.Name = "Buttons";
            this.Buttons.Size = new System.Drawing.Size(1152, 101);
            this.Buttons.TabIndex = 22;
            // 
            // BtRemoveTrack
            // 
            this.BtRemoveTrack.Location = new System.Drawing.Point(911, 59);
            this.BtRemoveTrack.Name = "BtRemoveTrack";
            this.BtRemoveTrack.Size = new System.Drawing.Size(147, 23);
            this.BtRemoveTrack.TabIndex = 21;
            this.BtRemoveTrack.Text = "Remove Track from Playlist";
            this.BtRemoveTrack.Visible = false;
            this.BtRemoveTrack.Click += new System.EventHandler(this.BtRemoveTrack_Click);
            // 
            // Info
            // 
            this.Info.Controls.Add(this.PbWaveform2);
            this.Info.Controls.Add(this.UIWaveFormPB);
            this.Info.Controls.Add(this.panel6);
            this.Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Info.Location = new System.Drawing.Point(15, 15);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(1152, 171);
            this.Info.TabIndex = 21;
            // 
            // PbWaveform2
            // 
            this.PbWaveform2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PbWaveform2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbWaveform2.Dock = System.Windows.Forms.DockStyle.Top;
            this.PbWaveform2.ErrorImage = null;
            this.PbWaveform2.InitialImage = null;
            this.PbWaveform2.Location = new System.Drawing.Point(0, 60);
            this.PbWaveform2.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.PbWaveform2.Name = "PbWaveform2";
            this.PbWaveform2.Size = new System.Drawing.Size(1152, 10);
            this.PbWaveform2.TabIndex = 16;
            this.PbWaveform2.TabStop = false;
            this.PbWaveform2.Visible = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 78);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1152, 93);
            this.panel6.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StartTimeNUD);
            this.panel2.Controls.Add(this.CueStartTimeBTN);
            this.panel2.Controls.Add(this.SegueTimeLBL);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(608, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 93);
            this.panel2.TabIndex = 18;
            this.panel2.Visible = false;
            // 
            // StartTimeNUD
            // 
            this.StartTimeNUD.Location = new System.Drawing.Point(75, 2);
            this.StartTimeNUD.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.StartTimeNUD.Name = "StartTimeNUD";
            this.StartTimeNUD.Size = new System.Drawing.Size(72, 21);
            this.StartTimeNUD.TabIndex = 5;
            this.StartTimeNUD.ValueChanged += new System.EventHandler(this.StartTimeNUD_ValueChanged_1);
            this.StartTimeNUD.Click += new System.EventHandler(this.StartTimeNUD_Click);
            // 
            // CueStartTimeBTN
            // 
            this.CueStartTimeBTN.Location = new System.Drawing.Point(147, 1);
            this.CueStartTimeBTN.Name = "CueStartTimeBTN";
            this.CueStartTimeBTN.Size = new System.Drawing.Size(38, 23);
            this.CueStartTimeBTN.TabIndex = 4;
            this.CueStartTimeBTN.Text = "Cue";
            this.CueStartTimeBTN.UseVisualStyleBackColor = true;
            this.CueStartTimeBTN.Click += new System.EventHandler(this.CueStartTimeBTN_Click);
            // 
            // SegueTimeLBL
            // 
            this.SegueTimeLBL.AutoSize = true;
            this.SegueTimeLBL.Location = new System.Drawing.Point(72, 25);
            this.SegueTimeLBL.Name = "SegueTimeLBL";
            this.SegueTimeLBL.Size = new System.Drawing.Size(0, 13);
            this.SegueTimeLBL.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Segue Time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Start Time";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.labelCurrentTrack);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(608, 93);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.labelRemain);
            this.panel4.Controls.Add(this.progressBarLeft);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.labelTime);
            this.panel4.Controls.Add(this.progressBarRight);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(807, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(345, 93);
            this.panel4.TabIndex = 17;
            // 
            // AddTrackToLibraryOFD
            // 
            this.AddTrackToLibraryOFD.FileOk += new System.ComponentModel.CancelEventHandler(this.AddTrackToLibraryOFD_FileOk);
            // 
            // EditorTimer
            // 
            this.EditorTimer.Interval = 50;
            this.EditorTimer.Tick += new System.EventHandler(this.EditorTimer_Tick);
            // 
            // timerUpdateSeconds
            // 
            this.timerUpdateSeconds.Enabled = true;
            this.timerUpdateSeconds.Interval = 1000;
            this.timerUpdateSeconds.Tick += new System.EventHandler(this.timerUpdateSeconds_Tick);
            // 
            // AddScheduleItemToPlayerBGW
            // 
            this.AddScheduleItemToPlayerBGW.WorkerReportsProgress = true;
            this.AddScheduleItemToPlayerBGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AddScheduleItemToPlayerBGW_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(1182, 835);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenPlayout";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Simple_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UIWaveFormPB)).EndInit();
            this.panel1.ResumeLayout(false);
            this.PanelLibrary.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleDgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openStationDS)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.PanelLibraryDetail.ResumeLayout(false);
            this.PanelLibraryDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditorSegueTimeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditorStartTimeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditorPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLibrary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openStationDSBindingSource)).EndInit();
            this.Buttons.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbWaveform2)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartTimeNUD)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        #region Private Vars
        private int _mixer = 0;
        private SYNCPROC _mixerStallSync;
        private Track _currentTrack = null;
        private Track _previousTrack = null;
        private ScheduleItem ScheduleItem = null;
        private Queue TrackCuePointQueue;
        #endregion


        static Logger logger
        {
            get
            {
                return LogManager.GetCurrentClassLogger();
            }
        }

		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			Application.Run(new MainForm());
		}

		private void Form_Load(object sender, System.EventArgs e)
		{
			// BassNet.Registration("your email", "your regkey");



            logger.Debug("************************Starting " + GetAppNameAndVersion() + "************************");

            SetFormTitle();
         
            InitializeSubfolders();

            logger.Debug("Initializing BASS");
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, this.Handle))
            {
                MessageBox.Show(this, "Bass_Init error!");
                logger.Error("Bass_Init error! Closing...");
                this.Close();
                return;
            }

            logger.Debug("Bass SetConfig, buffer = 200");
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_BUFFER, 200);

            logger.Debug("Bass SetConfig, updateperiod = 20");
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATEPERIOD, 20);

            logger.Debug("Bass StreamCreate: Sample rate 44100, 2 channels, 32bit floating point output");            
            _mixer = BassMix.BASS_Mixer_StreamCreate(44100, 2, BASSFlag.BASS_SAMPLE_FLOAT);

            if (_mixer == 0)
            {
                logger.Error("Could not create mixer! Closing...");
                MessageBox.Show(this, "Could not create mixer!");
                Bass.BASS_Free();
                this.Close();
                return;
            }

            _mixerStallSync = new SYNCPROC(OnMixerStall);
            logger.Debug("Bass ChannelSetSync (setting a synchronizer): default mixer, Sync on stall, default user instance");
            Bass.BASS_ChannelSetSync(_mixer, BASSSync.BASS_SYNC_STALL, 0L, _mixerStallSync, IntPtr.Zero);

            
            timerUpdate.Start();
            logger.Debug("timerUpdate started");
            EditorTimer.Start();
            logger.Debug("EditorTimer started");
            Bass.BASS_ChannelPlay(_mixer, false);
            logger.Debug("Bass ChannelPlay started, don't restart playback from beginning");

            if (File.Exists("songs.xml"))
            {
                logger.Debug("Load song library from songs.xml");
                openStationDS._Songs.ReadXml("songs.xml");
            }

            //InitializeTrackCuePointManager();

            LoadTodaySchedule();

            InitializeCrons();

		}

        private void SetFormTitle()
        {
            this.Text = GetAppNameAndVersion();
        }

        private string GetAppNameAndVersion()
        {
            System.Reflection.Assembly _assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();

            return _assemblyInfo.GetName().Name.ToString() + " " + _assemblyInfo.GetName().Version.ToString();
        }

        private void InitializeSubfolders()
        {
            if (!Directory.Exists(@"Schedules"))
            {
                Directory.CreateDirectory(@"Schedules");
                logger.Debug("Created directory: Schedules");
            }
            if (!Directory.Exists(@"Debug"))
            {
                Directory.CreateDirectory(@"Debug");
                logger.Debug("Created directory: Debug");
            }
        }

        private void InitializeCrons()
        {

            logger.Debug("Creating trigger for AddNextDaySchedule");
            Trigger trigger = new Trigger();
            trigger.Every(new TimeSpan(1,0,0,0));
            trigger.StartTime = DateTime.Today.AddDays(1);
            logger.Debug("Created trigger: " + trigger.ToString());
            Action action = new Action(AddNextDaySchedule);
            Scheduler.Schedule("Load next day's schedule", trigger, action);
            foreach (TaskSummary ts in Scheduler.GetStatuses())
            {
                logger.Debug("Task summary: " + ts.ToString());
            }
            logger.Debug("Check if scheduler is started: " + Scheduler.IsStarted);           
        }

        private void AddNextDaySchedule()
        {
            string ScheduleFile = @"Schedules\"+DateTime.Today.AddDays(1).ToString("yyyyMMdd")+".log";
            if (File.Exists(ScheduleFile))
            {
                LoadSchedule(DateTime.Today.AddDays(1));
            }
        }

        private void LoadTodaySchedule()
        {
            try
            { 
                string ScheduleFile = @"Schedules\" + DateTime.Today.ToString("yyyyMMdd") + ".log";
                if (File.Exists(ScheduleFile))
                {
                    logger.Debug("Loading Today Schedule");
                    LoadSchedule(DateTime.Today);
                    InitializePlayerFromSchedule();
                }
                else
                {
                    logger.Debug("Today Schedule (\\Schedules\\" + DateTime.Today.ToString("yyyyMMdd") + ".log) not found, do nothing");
                    MessageBox.Show("Today Schedule (\\Schedules\\" + DateTime.Today.ToString("yyyyMMdd") + ".log) not found!","Error",MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                logger.Error("FATAL ERROR");
                logger.Error(ex.Message);
                if (ex.InnerException != null)
                {
                    logger.Error(ex.InnerException);
                }
                logger.Error(ex.Data);
            }

        }

        private void LoadSchedule(DateTime ScheduleDate)
        {
            DelimitedFileEngine engine = new DelimitedFileEngine(typeof(ScheduleItem));
            engine.Encoding = System.Text.Encoding.UTF8;
            logger.Debug("Loading schedule for " + ScheduleDate.Date + @" from file \Schedules\" + ScheduleDate.ToString("yyyyMMdd") + ".log");
            DataTable dt = engine.ReadFileAsDT(@"Schedules\" + ScheduleDate.ToString("yyyyMMdd") + ".log");
            dt.Columns["Airtime"].ReadOnly = false;
            foreach (DataRow dr in dt.Rows)
            {            
                dr["Airtime"] = new DateTime(ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, ((DateTime)dr["Airtime"]).Hour, ((DateTime)dr["Airtime"]).Minute, ((DateTime)dr["Airtime"]).Second);
                logger.Trace("Loading schedule item " + dr.ToString());
                openStationDS.Schedule.ImportRow(dr);
            }
            logger.Debug("Schedule for " + ScheduleDate.Date + " loaded successfully");
        }

        private void InitializePlayerFromSchedule()
        {

            logger.Debug("Loading next 2 events to play from current schedule at current time");
            OpenStationDS.ScheduleRow[] NextScheduleItems = (OpenStationDS.ScheduleRow[])(openStationDS.Schedule.Select("Airtime >= #" + DateTime.Now.ToShortTimeString() + "#", "Airtime"));
            foreach (OpenStationDS.ScheduleRow Item in NextScheduleItems.Take<OpenStationDS.ScheduleRow>(2))
            {
                logger.Debug("Adding ScheduleItem *" + Item + "* to Player");
                try
                {
                    AddToPlayer(new Track(Item));
                }
                catch (Exception ex)
                {
                    logger.Error("Error loading Schedule Item!");
                    logger.Error(ex.Message);
                    if (ex.InnerException != null)
                    {
                        logger.Error(ex.InnerException);
                    }
                    logger.Error(ex.Data);
                }
            }
            logger.Debug("Start player");
            StartPlayer();
        }

		private void Simple_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            EditorTimer.Stop();
            timerUpdate.Stop();
            logger.Debug("Closing Bass");
            Bass.BASS_StreamFree(_mixer);
			Bass.BASS_Free();
		}

        private void OnMixerStall(int handle, int channel, int data, IntPtr user)
        {
            BeginInvoke((MethodInvoker)delegate()
            {
                // this code runs on the UI thread!
                if (data == 0)
                {
                    logger.Debug("Mixer stalled");
                    logger.Debug("Stopping timerUpdate");
                    timerUpdate.Stop();
                    logger.Debug("Stopping EditorTimer");
                    EditorTimer.Stop();
                    logger.Debug("Setting progress Bars to 0");
                    progressBarLeft.Value = 0;
                    progressBarRight.Value = 0;
                }
                else
                {
                    logger.Debug("Mixer resumed");
                    logger.Debug("Re-starting timerUpdate");
                    timerUpdate.Start();
                    logger.Debug("Re-starting EditorTimer");
                    EditorTimer.Start();
                }
            });
        }

        private void PlayTrack()
        {

            //logger.Debug("Locking playlist");
            //lock (listBoxPlaylist)
            //{
                if (listBoxPlaylist.Items.Count > 0)
                {
                    logger.Debug("Getting next track to play");
                    _previousTrack = _currentTrack;
                    _currentTrack = listBoxPlaylist.Items[0] as Track;
                    listBoxPlaylist.Items.RemoveAt(0);
                   

                    // the channel was already added
                    // so for instant playback, we just unpause the channel
                    logger.Debug("START PLAYING: " +_currentTrack.Tags.title + " - " + _currentTrack.Tags.artist);
                    BassMix.BASS_Mixer_ChannelPlay(_currentTrack.Channel);
                    labelCurrentTrack.Text = _currentTrack.Tags.title + " - " + _currentTrack.Tags.artist;

                    logger.Debug("Calling SetCurrentTrackWaveForm on " + _currentTrack);
                    SetCurrentTrackWaveForm();

                    if (_currentTrack.ScheduleID != -1)
                    {
                        logger.Debug("Calling UpdateSchedule...");
                        UpdateSchedule(_currentTrack);
                    }

                }
            //}
        }

        private void UpdateSchedule(Track currentTrack)
        {
            logger.Debug("Finding ScheduleItem from CurrentTrack.ScheduleID (=" + currentTrack.ScheduleID + ")");
            OpenStationDS.ScheduleRow CurrentScheduleItem = openStationDS.Schedule.FindByID(currentTrack.ScheduleID);
            int CurrentScheduleIndex = openStationDS.Schedule.Rows.IndexOf(CurrentScheduleItem);
            ScheduleDgw.FirstDisplayedScrollingRowIndex = CurrentScheduleIndex;
            logger.Debug("Coloring Row " + ScheduleDgw.Rows[CurrentScheduleIndex].Cells[1].Value.ToString() + " to Green background");
            ScheduleDgw.Rows[CurrentScheduleIndex].DefaultCellStyle.BackColor = Color.Green;
            logger.Debug("Coloring Row " + ScheduleDgw.Rows[CurrentScheduleIndex + 1].Cells[1].Value.ToString() + " to Yellow background");
            ScheduleDgw.Rows[CurrentScheduleIndex + 1].DefaultCellStyle.BackColor = Color.Yellow;
            logger.Debug("Coloring Row " + ScheduleDgw.Rows[CurrentScheduleIndex + 2].Cells[1].Value.ToString() + " to Yellow background");
            ScheduleDgw.Rows[CurrentScheduleIndex + 2].DefaultCellStyle.BackColor = Color.Yellow;
            if (CurrentScheduleIndex != 0)
            {
                logger.Debug("Uncoloring Row " + ScheduleDgw.Rows[CurrentScheduleIndex - 1].Cells[1].ToString());
                ScheduleDgw.Rows[CurrentScheduleIndex-1].DefaultCellStyle.BackColor = Color.White;
            }
            AddToPlayerAsync(openStationDS.Schedule.FindByID(currentTrack.ScheduleID + 2));
        }

        private void SetTrackCuePoints(Track tr)
        {
            logger.Debug("Rendering waveform for " + tr.Filename);
            TrackWF = new WaveForm(tr.Filename);
            TrackWF.RenderStart(true, BASSFlag.BASS_DEFAULT);
            while (!TrackWF.IsRendered)
            {
            }
            logger.Debug("Synchronizing waveform position with playback channel");
            TrackWF.SyncPlayback(tr.Channel);
            long startPos = 0L;
            long endPos = 0L;
            logger.Debug("Bass GetCuePoints on current waveform: calculating Start and Mix point using default Db thresholds: -24.0 on start, -12.0 on end");
            if (TrackWF.GetCuePoints(ref startPos, ref endPos, -24.0, -12.0, true))
            {
                tr.StartTrackPos = startPos;
                tr.NextTrackPos = endPos;
                logger.Debug("Start position (" + tr.StartTrackPos + ")");
                logger.Debug("Next Track position (" + tr.NextTrackPos + ")");
                logger.Debug("Calling SetTrackToPosition - Set start at calculated start position");
                SetTrackToPosition(tr.Channel, tr.StartTrackPos);

            }
            else
            {
                logger.Error("Error calculating Cue Points on current waveform");
            }
            logger.Debug("Adding calculated Waveform to its own Track...");
            tr.Waveform = TrackWF;
            if (tr == _currentTrack)
            {
                logger.Debug("Waveform rendered for " + tr + ". Since it's currently playing, we run SetCurrentTrackWaveForm");
                SetCurrentTrackWaveForm();
            }
        }





        private void OnTrackSync(int handle, int channel, int data, IntPtr user)
        {
            logger.Debug("Handle = " + handle + " Channel = " + channel + " Data = " + data + " User = " + user.ToInt32());
            if (user.ToInt32() == 0)
            {
                logger.Debug("Called a sync on end - deactivated");
                logger.Debug("Calling PlayTrack...");
                BeginInvoke(new MethodInvoker(PlayTrack));
            }
            else
            {
                //logger.Debug("Do nothing...(commented code)");
                logger.Debug("Called a sync on track position");
                BeginInvoke((MethodInvoker)delegate()
                {
                    // this code runs on the UI thread!
                    logger.Debug("Calling PlayTrack...");
                    PlayTrack();
                    StopPreviousTrack();
                });
            }
        }
	
		#region Wave Form 

		// zoom helper varibales
		private bool _zoomed = false;
		private int _zoomStart = -1;
		private long _zoomStartBytes = -1;
		private int _zoomEnd = -1;
		private float _zoomDistance = 5.0f; // zoom = 5sec.

		private Un4seen.Bass.Misc.WaveForm _WF = null;
		private void SetCurrentTrackWaveForm()
		{
            if (_currentTrack.Waveform != null)
            {
                logger.Debug("Getting waveform for " + _currentTrack);
                _zoomStart = -1;
                _zoomStartBytes = -1;
                _zoomEnd = -1;
                _zoomed = false;
                logger.Debug("Rendering the wave form");
                _WF = _currentTrack.Waveform;
                _WF.FrameResolution = 0.01f; // 10ms are nice
                _WF.CallbackFrequency = 30000; // every 5min.
                _WF.ColorBackground = Color.FromArgb(20, 20, 20);
                _WF.ColorLeft = Color.Gray;
                _WF.ColorLeftEnvelope = Color.LightGray;
                _WF.ColorRight = Color.Gray;
                _WF.ColorRightEnvelope = Color.LightGray;
                _WF.ColorMarker = Color.Gold;
                _WF.ColorBeat = Color.LightSkyBlue;
                _WF.ColorVolume = Color.White;
                _WF.DrawEnvelope = false;
                _WF.DrawWaveForm = WaveForm.WAVEFORMDRAWTYPE.HalfMono;
                _WF.DrawMarker = WaveForm.MARKERDRAWTYPE.Line | WaveForm.MARKERDRAWTYPE.Name | WaveForm.MARKERDRAWTYPE.NamePositionAlternate;
                _WF.MarkerLength = 0.75f;
                logger.Debug("Syncing UI Waveform to currentTrack channel - " + _currentTrack.Tags.title);
                _WF.SyncPlayback(_currentTrack.Channel);
                logger.Debug("UI Waveform: adding Start marker at position " + _currentTrack.StartTrackPos);
                _WF.AddMarker("Start", _currentTrack.StartTrackPos);
                logger.Debug("UI Waveform: adding Next marker at position " + _currentTrack.NextTrackPos);
                _WF.AddMarker("Next", _currentTrack.NextTrackPos);
                logger.Debug("Drawing Waveform");
                DrawWave();
            }
            else
            {
                logger.Debug("Waveform not found for current Track " + _currentTrack + ". Maybe not enough time to generate it?");
            }
		}

        private void EditorGetWaveForm()
        {
            // unzoom...(display the whole wave form)
            _zoomStart = -1;
            _zoomStartBytes = -1;
            _zoomEnd = -1;
            _zoomed = false;
            // render a wave form
            EditorWf = new WaveForm(EditorTrack.Filename, new WAVEFORMPROC(EditorWaveFormCallback), this);
            EditorWf.FrameResolution = 0.01f; // 10ms are nice
            EditorWf.CallbackFrequency = 30000; // every 5min.
            EditorWf.ColorBackground = Color.FromArgb(20, 20, 20);
            EditorWf.ColorLeft = Color.Gray;
            EditorWf.ColorLeftEnvelope = Color.LightGray;
            EditorWf.ColorRight = Color.Gray;
            EditorWf.ColorRightEnvelope = Color.LightGray;
            EditorWf.ColorMarker = Color.Gold;
            EditorWf.ColorBeat = Color.LightSkyBlue;
            EditorWf.ColorVolume = Color.White;
            EditorWf.DrawEnvelope = false;
            EditorWf.DrawWaveForm = WaveForm.WAVEFORMDRAWTYPE.Stereo;
            EditorWf.DrawMarker = WaveForm.MARKERDRAWTYPE.Line | WaveForm.MARKERDRAWTYPE.Name | WaveForm.MARKERDRAWTYPE.NamePositionAlternate;
            EditorWf.MarkerLength = 0.80f;
            EditorWf.MarkerFont = new Font(FontFamily.GenericSansSerif, 10);
            EditorWf.RenderStart(true, BASSFlag.BASS_DEFAULT);
        }

        private void MyWaveFormCallback(int framesDone, int framesTotal, TimeSpan elapsedTime, bool finished)
        {
            //if (finished)
            //{
            //    SetCurrentTrackWaveForm();
            //}

        }


        private void EditorWaveFormCallback(int framesDone, int framesTotal, TimeSpan elapsedTime, bool finished)
        {
            if (finished)
            {
                EditorWf.SyncPlayback(EditorTrack.Channel);

                // and do pre-calculate the next track position
                // in this example we will only use the end-position
                long startPos = 0L;
                long endPos = 0L;
                if (EditorWf.GetCuePoints(ref startPos, ref endPos, -24.0, -12.0, true))
                {
                    //_currentTrack.NextTrackPos = endPos;
                    //// if there is already a sync set, remove it first
                    //if (_currentTrack.NextTrackSync != 0)
                    //    BassMix.BASS_Mixer_ChannelRemoveSync(_currentTrack.Channel, _currentTrack.NextTrackSync);

                    //// set the next track sync automatically
                    //_currentTrack.NextTrackSync = BassMix.BASS_Mixer_ChannelSetSync(_currentTrack.Channel, BASSSync.BASS_SYNC_POS | BASSSync.BASS_SYNC_MIXTIME, _currentTrack.NextTrackPos, _currentTrack.TrackSync, new IntPtr(1));

                    EditorTrack.StartTrackPos = startPos;
                    EditorTrack.NextTrackPos = endPos;
                    EditorWf.AddMarker("Next", endPos);
                    EditorWf.AddMarker("Start", startPos);
                }
            }
           //  will be called during rendering...
            DrawWave(EditorPB,EditorWf);
        }

        private void DrawWave()
        {
            DrawWave(this.UIWaveFormPB);
        }

        private void DrawWave(PictureBox pb)
        {
            DrawWave(pb, _WF);
        }

        private void DrawWave(PictureBox pb, WaveForm wf)
		{
			if (wf != null)
				pb.BackgroundImage = wf.CreateBitmap( pb.Width, pb.Height, _zoomStart, _zoomEnd, true);
			else
				pb.BackgroundImage = null;
		}

        private void DrawWavePosition(long pos, long len)
        {
            DrawWavePosition(this.UIWaveFormPB, _WF, pos, len);
        }

		private void DrawWavePosition(PictureBox pb, WaveForm wf, long pos, long len)
		{
			if (wf == null || len == 0 || pos < 0)
			{
				pb.Image = null;
				return;
			}

			Bitmap bitmap = null;
			Graphics g = null;
			Pen p = null;
			double bpp = 0;

			try
			{
				if (_zoomed)
				{
					// total length doesn't have to be _zoomDistance sec. here
					len = wf.Frame2Bytes(_zoomEnd) - _zoomStartBytes;

					int scrollOffset = 10; // 10*20ms = 200ms.
					// if we scroll out the window...(scrollOffset*20ms before the zoom window ends)
					if ( pos > (_zoomStartBytes + len - scrollOffset*wf.Wave.bpf) )
					{
						// we 'scroll' our zoom with a little offset
						_zoomStart = wf.Position2Frames(pos - scrollOffset*wf.Wave.bpf);
						_zoomStartBytes = wf.Frame2Bytes(_zoomStart);
						_zoomEnd = _zoomStart + wf.Position2Frames( _zoomDistance ) - 1;
						if (_zoomEnd >= wf.Wave.data.Length)
						{
							// beyond the end, so we zoom from end - _zoomDistance.
							_zoomEnd = wf.Wave.data.Length-1;
							_zoomStart = _zoomEnd - wf.Position2Frames( _zoomDistance ) + 1;
							if (_zoomStart < 0)
								_zoomStart = 0;
							_zoomStartBytes = wf.Frame2Bytes(_zoomStart);
							// total length doesn't have to be _zoomDistance sec. here
							len = wf.Frame2Bytes(_zoomEnd) - _zoomStartBytes;
						}
						// get the new wave image for the new zoom window
						DrawWave(pb,wf);
					}
					// zoomed: starts with _zoomStartBytes and is _zoomDistance long
					pos -= _zoomStartBytes; // offset of the zoomed window
					
					bpp = len/(double)pb.Width;  // bytes per pixel
				}
				else
				{
					// not zoomed: width = length of stream
					bpp = len/(double)pb.Width;  // bytes per pixel
				}

				p = new Pen(Color.LightGreen);
				bitmap = new Bitmap(pb.Width, pb.Height);
				g = Graphics.FromImage(bitmap);
				g.Clear( Color.Black );
				int x = (int)Math.Round(pos/bpp);  // position (x) where to draw the line
                //p.Width = 2;
                //g.DrawLine( p, x, 0, x,  pb.Height-1);
                p.Width = (float)x;
                g.DrawLine(p, x / 2, 0, x / 2, pb.Height - 1);

				bitmap.MakeTransparent( Color.Black );
			}
			catch 
			{ 
				bitmap = null; 
			}
			finally
			{
				// clean up graphics resources
				if (p != null)
					p.Dispose();
				if (g != null)
					g.Dispose();
			}

			pb.Image = bitmap;
		}

        private void ToggleZoom()
        {
            if (_WF == null)
                return;

            // WF is not null, so the stream must be playing...
            if (_zoomed)
            {
                logger.Debug("Unzooming...(display the whole wave form)");
                _zoomStart = -1;
                _zoomStartBytes = -1;
                _zoomEnd = -1;
            }
            else
            {
                logger.Debug("Zooming waveform - default zoom: " + _zoomDistance);
                long pos = BassMix.BASS_Mixer_ChannelGetPosition(_currentTrack.Channel);
                // calculate the window to display
                _zoomStart = _WF.Position2Frames(pos);
                _zoomStartBytes = _WF.Frame2Bytes(_zoomStart);
                _zoomEnd = _zoomStart + _WF.Position2Frames(_zoomDistance) - 1;
                if (_zoomEnd >= _WF.Wave.data.Length)
                {
                    // beyond the end, so we zoom from end - _zoomDistance.
                    _zoomEnd = _WF.Wave.data.Length - 1;
                    _zoomStart = _zoomEnd - _WF.Position2Frames(_zoomDistance) + 1;
                    _zoomStartBytes = _WF.Frame2Bytes(_zoomStart);
                }
            }
            _zoomed = !_zoomed;
            // and display this new wave form
            DrawWave();
        }

        private void pictureBoxWaveForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_WF == null)
                return;

            bool doubleClick = e.Clicks > 1;
            bool lowerHalf = (e.Y > UIWaveFormPB.Height / 2);

            if (lowerHalf && doubleClick)
            {
                ToggleZoom();
            }
            else if (!lowerHalf && e.Button == MouseButtons.Left)
            {
                // left button will set the position
                long pos = _WF.GetBytePositionFromX(e.X, UIWaveFormPB.Width, _zoomStart, _zoomEnd);
                SetTrackToPosition(_currentTrack.Channel, pos);
            }
            else if (!lowerHalf)
            {
                _currentTrack.NextTrackPos = _WF.GetBytePositionFromX(e.X, UIWaveFormPB.Width, _zoomStart, _zoomEnd);
                // if there is already a sync set, remove it first
                if (_currentTrack.NextTrackSync != 0)
                    BassMix.BASS_Mixer_ChannelRemoveSync(_currentTrack.Channel, _currentTrack.NextTrackSync);

                // right button will set a next track position sync
                _currentTrack.NextTrackSync = BassMix.BASS_Mixer_ChannelSetSync(_currentTrack.Channel, BASSSync.BASS_SYNC_POS | BASSSync.BASS_SYNC_MIXTIME, _currentTrack.NextTrackPos, _currentTrack.TrackSync, new IntPtr(1));

                _WF.AddMarker("Next", _currentTrack.NextTrackPos);
                DrawWave();
            }
        }

		#endregion

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            //logger.Debug("Bass ChannelGetLevel: Getting volume level from mixer and updating progress bars");
            int level = Bass.BASS_ChannelGetLevel(_mixer);
            progressBarLeft.Value = Utils.LowWord32(level);
            progressBarRight.Value = Utils.HighWord32(level);



            if (_currentTrack != null)
            {
                long pos = BassMix.BASS_Mixer_ChannelGetPosition(_currentTrack.Channel);
                labelTime.Text = Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(_currentTrack.Channel, pos), "HHMMSS");
                labelRemain.Text = Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(_currentTrack.Channel, _currentTrack.TrackLength - pos), "HHMMSS");

                DrawWavePosition(pos, _currentTrack.TrackLength);

            }
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog.ShowDialog(this))
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    AddToPlayer(openFileDialog.FileName);

                }
            }
        }

        private void buttonSetEnvelope_Click(object sender, EventArgs e)
        {
            if (_currentTrack.Channel != 0)
            {
                BASS_MIXER_NODE[] nodes = 
                {
                    new BASS_MIXER_NODE(Bass.BASS_ChannelSeconds2Bytes(_mixer, 10d), 1f),
                    new BASS_MIXER_NODE(Bass.BASS_ChannelSeconds2Bytes(_mixer, 13d), 0f),
                    new BASS_MIXER_NODE(Bass.BASS_ChannelSeconds2Bytes(_mixer, 17d), 0f),
                    new BASS_MIXER_NODE(Bass.BASS_ChannelSeconds2Bytes(_mixer, 20d), 1f)
                };
                BassMix.BASS_Mixer_ChannelSetEnvelope(_currentTrack.Channel, BASSMIXEnvelope.BASS_MIXER_ENV_VOL, nodes);
                // already align the envelope position to the current playback position
                // pause mixer
                Bass.BASS_ChannelLock(_mixer, true);
                long pos = BassMix.BASS_Mixer_ChannelGetPosition(_currentTrack.Channel);
                // convert source pos to mixer pos 
                long envPos = Bass.BASS_ChannelSeconds2Bytes(_mixer, Bass.BASS_ChannelBytes2Seconds(_currentTrack.Channel, pos));
                BassMix.BASS_Mixer_ChannelSetEnvelopePos(_currentTrack.Channel, BASSMIXEnvelope.BASS_MIXER_ENV_VOL, envPos);
                // resume mixer 
                Bass.BASS_ChannelLock(_mixer, false);

                // and show it in our waveform
                _WF.DrawVolume = WaveForm.VOLUMEDRAWTYPE.Solid;
                foreach (BASS_MIXER_NODE node in nodes)
                {
                    _WF.AddVolumePoint(node.pos, node.val);
                }
                DrawWave();
            }
        }

        private void buttonRemoveEnvelope_Click(object sender, EventArgs e)
        {
            BassMix.BASS_Mixer_ChannelSetEnvelope(_currentTrack.Channel, BASSMIXEnvelope.BASS_MIXER_ENV_VOL, null);
            _WF.ClearAllVolumePoints();
            _WF.DrawVolume = WaveForm.VOLUMEDRAWTYPE.None;
            DrawWave();
        }

        private void SetTrackToPosition(int source, long newPos)
        {
            logger.Debug("Bass ChannelLock: locking mixer");
            Bass.BASS_ChannelLock(_mixer, true);
            logger.Debug("Bass Mixer ChannelSetPosition: setting mixer or channel to the given position");
            BassMix.BASS_Mixer_ChannelSetPosition(source, newPos);
            logger.Debug("Calculating mixer position from source position");
            long envPos = Bass.BASS_ChannelSeconds2Bytes(_mixer, Bass.BASS_ChannelBytes2Seconds(source, newPos));
            logger.Debug("Bass Mixer ChannelSetEnvelopePos: calculating envelope (it's a part of the playback volume)");
            BassMix.BASS_Mixer_ChannelSetEnvelopePos(source, BASSMIXEnvelope.BASS_MIXER_ENV_VOL, envPos);
            logger.Debug("Bass ChannelLock: unlocking mixer");
            Bass.BASS_ChannelLock(_mixer, false);
        }

        private void BtOpenSchedule_Click(object sender, EventArgs e)
        {
            OfdOpenSchedule.FileName = "";

            DialogResult dr = OfdOpenSchedule.ShowDialog();

            if (dr == DialogResult.OK)
            {
                
                FileHelperEngine engine = new FileHelperEngine(typeof(ScheduleItem));

                // To Read Use:
                PlayerItem[] songs = engine.ReadFile(OfdOpenSchedule.FileName) as PlayerItem[];

                foreach (PlayerItem song in songs)
                {
                    if (File.Exists(song.Item))
                    {
                        AddToPlayer(song.Item);

                    }
                }

            }

            
            


        }

        private void AddToPlayer(string song)
        {
            logger.Debug("Adding new song file (not from schedule) to Player internal playlist");
            Track track = new Track(song);
        }

        private void AddToPlayerAsync(OpenStationDS.ScheduleRow Item)
        {
            logger.Debug("Adding ScheduleItem " + Item.ItemTitle + " to player on separate thread...");
            AddScheduleItemToPlayerBGW.RunWorkerAsync(Item);
        }

        private void AddToPlayer(Track track)
        {
            //logger.Debug("Locking player internal playlist");
            //lock (listBoxPlaylist)
            //{

                logger.Debug("Adding track " + track + "to player playlist");

                listBoxPlaylist.Items.Add(track);
            
                

                logger.Debug("Bass StreamAddChannel: adding the track to the mixer in PAUSED mode, downmix to stereo, auto free the stream resource when ended");
                BassMix.BASS_Mixer_StreamAddChannel(_mixer, track.Channel, BASSFlag.BASS_MIXER_PAUSE | BASSFlag.BASS_MIXER_DOWNMIX | BASSFlag.BASS_STREAM_AUTOFREE);

                //logger.Debug("Calling SetTrackCuePoints on a separate thread - It detects start and end of current track");
                //CueTrackPointsBGW.RunWorkerAsync(track);
                SetTrackCuePoints(track);
                SyncTrackWithMixer(track);
                //logger.Debug("Adding " + track + " to TrackCuePointQueue to get its cue points");
                //TrackCuePointQueue.Enqueue(track);
            //}
        }

        private void AddToLibrary(Track track)
        {
            openStationDS._Songs.AddSongsRow(track.Filename, 0, track.NextTrackPos, track.TrackLength, 0);
        }

        private void BtPlay_Click(object sender, EventArgs e)
        {
            logger.Debug("User command - Play/Next");
            if (!AddScheduleItemToPlayerBGW.IsBusy)
            {
                PlayTrack();
                StopPreviousTrack(500);
            }
            else
            {
                logger.Debug("Cannot execute command since AddScheduleItemToPlayerBGW thread is busy. Try again later");
            }
        }

        private void StopPreviousTrack(int FadeLength)
        {
            if (_previousTrack != null)
            {
                logger.Debug("Bass ChannelSlideAttribute: Fading out and stopping the 'previous' track (for 2 seconds)");
                Bass.BASS_ChannelSlideAttribute(_previousTrack.Channel, BASSAttribute.BASS_ATTRIB_VOL, -1f, FadeLength);
            }
        }


        private void StopPreviousTrack()
        {
            StopPreviousTrack(2000);
        }

        private void StartPlayer()
        {
            try
            {
                if (_currentTrack != null)
                {
                    BeginInvoke((MethodInvoker)delegate()
                    {
                        logger.Debug("Calling PlayTrack...");
                        PlayTrack();
                    });
                }
                else
                {
                    logger.Debug("Current track is null");
                    logger.Debug("Calling PlayTrack...");
                    PlayTrack();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error running StartPlayer!");
                logger.Error(ex.Message);
                if (ex.InnerException != null)
                {
                    logger.Error(ex.InnerException);
                }
                logger.Error(ex.Data);
            }
        }

        private void BtToggleZoom_Click(object sender, EventArgs e)
        {
            ToggleZoom();
        }

        private void BtStop_Click(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate()
            {
                StopCurrentTrack();
            });
        }

        private void StopCurrentTrack()
        {
            if (_currentTrack != null)
            {
                logger.Debug("Bass ChannelSlideAttribute: fade out and stop the current track - "+ _currentTrack +" - (for 2 seconds)");
                Bass.BASS_ChannelSlideAttribute(_currentTrack.Channel, BASSAttribute.BASS_ATTRIB_VOL, -1f, 2000);
            }
        }

        private void BtRemoveTrack_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylist.SelectedItem != null)
            {
                lock (listBoxPlaylist)
                {
                    BassMix.BASS_Mixer_ChannelRemove((listBoxPlaylist.SelectedItem as Track).Channel);
                    listBoxPlaylist.Items.Remove(listBoxPlaylist.SelectedItem);
                }
            }
        }

        private void DgvLibrary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvLibrary.SelectedRows != null)
            {
                EditorLoadTrack(new Track(DgvLibrary.SelectedRows[0].Cells[0].Value.ToString()));
                
            }
        }

        private void EditorLoadTrack(Track track)
        {
            EditorTrack = track;
            EditorCueTrack();
            EditorGetWaveForm();
            EditorGetTrackData();

        }

        private void EditorCueTrack()
        {
            // add the new track to the mixer (in PAUSED mode!)
            BassMix.BASS_Mixer_StreamAddChannel(_mixer, EditorTrack.Channel, BASSFlag.BASS_MIXER_PAUSE | BASSFlag.BASS_MIXER_DOWNMIX | BASSFlag.BASS_STREAM_AUTOFREE);

            // an BASS_SYNC_END is used to trigger the next track in the playlist (if no POS sync was set)
            //EditorTrack.TrackSync = new SYNCPROC(OnTrackSync);
            //BassMix.BASS_Mixer_ChannelSetSync(EditorTrack.Channel, BASSSync.BASS_SYNC_END, 0L, EditorTrack.TrackSync, new IntPtr(0));
        }

        private void EditorGetTrackData()
        {
            EditorArtistTitleTB.Text = EditorTrack.Tags.artist + " - " + EditorTrack.Tags.title;


            EditorStartTimeNUD.Value = decimal.Parse(EditorTrack.StartTrackPos.ToString()) / 1000;
            EditorSegueTimeNUD.Value = decimal.Parse(EditorTrack.NextTrackPos.ToString()) / 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTrackToLibraryOFD.ShowDialog();
        }

        private void AddTrackToLibraryOFD_FileOk(object sender, CancelEventArgs e)
        {
            Track t = new Track(AddTrackToLibraryOFD.FileName);
            AddToLibrary(t);
        }

        private void CueStartTimeBTN_Click(object sender, EventArgs e)
        {
            _WF.SyncPlayback(_currentTrack.Channel);
            SetTrackToPosition(_currentTrack.Channel, _currentTrack.StartTrackPos);

        }

        private void StartTimeNUD_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void StartTimeNUD_Click(object sender, EventArgs e)
        {
            bool ValueChanged = (bool)StartTimeNUD.Tag;
            if (ValueChanged)
            {
                _currentTrack.StartTrackPos = long.Parse(((int)StartTimeNUD.Value).ToString())*1000;
                _WF.AddMarker("Start", _currentTrack.StartTrackPos);
                DrawWave();
            }
            StartTimeNUD.Tag = false;
        }

        private void StartTimeNUD_ValueChanged_1(object sender, EventArgs e)
        {
            StartTimeNUD.Tag = true;
        }

        private void EditorPlayBTN_Click(object sender, EventArgs e)
        {

                BeginInvoke((MethodInvoker)delegate()
                {

                    BassMix.BASS_Mixer_ChannelSetPosition(EditorTrack.Channel, EditorTrack.StartTrackPos);
                    BassMix.BASS_Mixer_ChannelPlay(EditorTrack.Channel);

                });

        }

        private void EditorStopBTN_Click(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate()
            {
                Bass.BASS_ChannelSlideAttribute(EditorTrack.Channel, BASSAttribute.BASS_ATTRIB_VOL, -1f, 0);
            });
        }

        private void EditorTimer_Tick(object sender, EventArgs e)
        {
            int level = Bass.BASS_ChannelGetLevel(_mixer);
            //progressBarLeft.Value = Utils.LowWord32(level);
            //progressBarRight.Value = Utils.HighWord32(level);

            if (EditorTrack != null)
            {
                long pos = BassMix.BASS_Mixer_ChannelGetPosition(EditorTrack.Channel);
                //labelTime.Text = Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(EditorTrack.Channel, pos), "HHMMSS");
                //labelRemain.Text = Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(EditorTrack.Channel, EditorTrack.TrackLength - pos), "HHMMSS");

                DrawWavePosition(EditorPB, EditorWf, pos, EditorTrack.TrackLength);
            }
        }

        private void EditorPB_MouseDown(object sender, MouseEventArgs e)
        {
            if (EditorWf == null)
                return;

            bool doubleClick = e.Clicks > 1;
            bool lowerHalf = (e.Y > EditorPB.Height / 2);

            if (lowerHalf && doubleClick)
            {
                ToggleZoom();
            }
            else if (!lowerHalf && e.Button == MouseButtons.Left)
            {
                // left button will set the position
                long pos = EditorWf.GetBytePositionFromX(e.X, EditorPB.Width, _zoomStart, _zoomEnd);
                SetTrackToPosition(EditorTrack.Channel, pos);
            }
            else if (!lowerHalf)
            {
                EditorTrack.NextTrackPos = EditorWf.GetBytePositionFromX(e.X, EditorPB.Width, _zoomStart, _zoomEnd);
                // if there is already a sync set, remove it first
                //if (EditorTrack.NextTrackSync != 0)
                //    BassMix.BASS_Mixer_ChannelRemoveSync(EditorTrack.Channel, EditorTrack.NextTrackSync);

                // right button will set a next track position sync
                //EditorTrack.NextTrackSync = BassMix.BASS_Mixer_ChannelSetSync(EditorTrack.Channel, BASSSync.BASS_SYNC_POS | BASSSync.BASS_SYNC_MIXTIME, EditorTrack.NextTrackPos, EditorTrack.TrackSync, new IntPtr(1));

                EditorWf.AddMarker("Next", EditorTrack.NextTrackPos);
                DrawWave(EditorPB,EditorWf);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            openStationDS._Songs.WriteXml("songs.xml");
            logger.Debug("Quitting OpenPlayout");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNextDaySchedule();
        }

        private void timerUpdateSeconds_Tick(object sender, EventArgs e)
        {
            if (_currentTrack != null)
            {
                if (DateTime.Now.Second % 10 == 0)
                {
                    logger.Debug(_currentTrack.Tags.title + " - Playback position: " + labelTime.Text);
                }
            }
        }

        private void TrackCuePointsBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Track track = (Track)e.Result;
            SyncTrackWithMixer(track);
        }

        private void SyncTrackWithMixer(Track track)
        {
            logger.Debug("Bass Mixer ChannelSetSync: setting a sync on next track position, calling TrackSync() method when it happens");
            track.TrackSync = new SYNCPROC(OnTrackSync);
            logger.Debug("ChannelSetSync Channel = " + track.Channel);
            track.NextTrackSync = BassMix.BASS_Mixer_ChannelSetSync(track.Channel, BASSSync.BASS_SYNC_POS | BASSSync.BASS_SYNC_MIXTIME, track.NextTrackPos, track.TrackSync, new IntPtr(1));
        }

        private void TrackCuePointsBGW_DoWork(object sender, DoWorkEventArgs e)
        {
            logger.Debug("Running TrackCuePointQueue check on separate thread...");
            while (true)
            {
                if (TrackCuePointQueue.Count > 0)
                {
                    logger.Debug("TrackCuePointQueue contains " + TrackCuePointQueue.Count + " elements.");
                    Track tr = (Track)(TrackCuePointQueue.Dequeue());
                    logger.Debug("Running SetTrackCuePoints on " + tr.Tags.title);
                    SetTrackCuePoints(tr);
                    logger.Debug("Running SyncTrackWithMixer on " + tr.Tags.title);
                    SyncTrackWithMixer(tr);
                }
            }

        }

        private void AddScheduleItemToPlayerBGW_DoWork(object sender, DoWorkEventArgs e)
        {
            OpenStationDS.ScheduleRow Item = (OpenStationDS.ScheduleRow)(e.Argument);
            AddToPlayer(new Track(Item));
        }

	}

  
}
