namespace Конфигуратор_датчика_вибрации
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьПрограммуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьПрограммуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проверитьНаличиеОбновленийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelDeviceID = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCom = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCom = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.textBoxАдресПрошивки = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxExtraInputStateOutput = new System.Windows.Forms.TextBox();
            this.buttonСостояниеВыхода = new System.Windows.Forms.Button();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.buttonСерийныйНомер = new System.Windows.Forms.Button();
            this.textBoxFirmwareVersion = new System.Windows.Forms.TextBox();
            this.buttonВерсияПрошивки = new System.Windows.Forms.Button();
            this.textBoxExtraInputStateInput = new System.Windows.Forms.TextBox();
            this.textBoxCardID = new System.Windows.Forms.TextBox();
            this.buttonСостояниеВхода = new System.Windows.Forms.Button();
            this.buttonЧтениеIDКарты = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.comboBoxSignalInversion = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBoxByteOrder = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxПорогZ = new System.Windows.Forms.TextBox();
            this.textBoxПорогY = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxПорогX = new System.Windows.Forms.TextBox();
            this.comboBoxЧастота = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxДиапазон = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxDeviceParity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxDeviceStopBits = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxDeviceBaudRate = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxКоличествоТочекВГрафике = new System.Windows.Forms.TextBox();
            this.trackBarКоличествоТочекВГрафике = new System.Windows.Forms.TrackBar();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxПериодОпроса = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBoxZ = new System.Windows.Forms.GroupBox();
            this.groupBoxY = new System.Windows.Forms.GroupBox();
            this.groupBoxX = new System.Windows.Forms.GroupBox();
            this.buttonStartKaliber = new System.Windows.Forms.Button();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxЛог = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarКоличествоТочекВГрафике)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(901, 28);
            this.menuStrip.TabIndex = 29;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.свернутьПрограммуToolStripMenuItem,
            this.закрытьПрограммуToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // свернутьПрограммуToolStripMenuItem
            // 
            this.свернутьПрограммуToolStripMenuItem.Name = "свернутьПрограммуToolStripMenuItem";
            this.свернутьПрограммуToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.свернутьПрограммуToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.свернутьПрограммуToolStripMenuItem.Text = "Свернуть программу";
            this.свернутьПрограммуToolStripMenuItem.Click += new System.EventHandler(this.свернутьПрограммуToolStripMenuItem_Click);
            // 
            // закрытьПрограммуToolStripMenuItem
            // 
            this.закрытьПрограммуToolStripMenuItem.Name = "закрытьПрограммуToolStripMenuItem";
            this.закрытьПрограммуToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.закрытьПрограммуToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.закрытьПрограммуToolStripMenuItem.Text = "Закрыть программу";
            this.закрытьПрограммуToolStripMenuItem.Click += new System.EventHandler(this.закрытьПрограммуToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проверитьНаличиеОбновленийToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // проверитьНаличиеОбновленийToolStripMenuItem
            // 
            this.проверитьНаличиеОбновленийToolStripMenuItem.Name = "проверитьНаличиеОбновленийToolStripMenuItem";
            this.проверитьНаличиеОбновленийToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F8)));
            this.проверитьНаличиеОбновленийToolStripMenuItem.Size = new System.Drawing.Size(408, 26);
            this.проверитьНаличиеОбновленийToolStripMenuItem.Text = "Проверить наличие обновлений";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1)));
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(408, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1MinSize = 320;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonClearLog);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxЛог);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(889, 703);
            this.splitContainer1.SplitterDistance = 570;
            this.splitContainer1.TabIndex = 30;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(546, 685);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.labelDeviceID);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.buttonCom);
            this.tabPage1.Controls.Add(this.buttonReset);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBoxCom);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(538, 656);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки порта";
            // 
            // labelDeviceID
            // 
            this.labelDeviceID.AutoSize = true;
            this.labelDeviceID.Location = new System.Drawing.Point(23, 72);
            this.labelDeviceID.Name = "labelDeviceID";
            this.labelDeviceID.Size = new System.Drawing.Size(103, 17);
            this.labelDeviceID.TabIndex = 13;
            this.labelDeviceID.Text = "ID устройства:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBoxBaudRate);
            this.groupBox1.Controls.Add(this.comboBoxStopBits);
            this.groupBox1.Controls.Add(this.comboBoxParity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(7, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 543);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(93, 22);
            this.comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(149, 24);
            this.comboBoxBaudRate.TabIndex = 17;
            this.comboBoxBaudRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudRate_SelectedIndexChanged);
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(93, 102);
            this.comboBoxStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(149, 24);
            this.comboBoxStopBits.TabIndex = 16;
            this.comboBoxStopBits.SelectedIndexChanged += new System.EventHandler(this.comboBoxStopBits_SelectedIndexChanged);
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(93, 61);
            this.comboBoxParity.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(149, 24);
            this.comboBoxParity.TabIndex = 15;
            this.comboBoxParity.SelectedIndexChanged += new System.EventHandler(this.comboBoxParity_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "StopBits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Parity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "BaudRate:";
            // 
            // buttonCom
            // 
            this.buttonCom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCom.Location = new System.Drawing.Point(283, 34);
            this.buttonCom.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCom.Name = "buttonCom";
            this.buttonCom.Size = new System.Drawing.Size(89, 28);
            this.buttonCom.TabIndex = 11;
            this.buttonCom.Text = "Открыть";
            this.buttonCom.UseVisualStyleBackColor = false;
            this.buttonCom.Click += new System.EventHandler(this.buttonCom_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(187, 34);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(88, 27);
            this.buttonReset.TabIndex = 10;
            this.buttonReset.Text = "Обновить";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Список портов:";
            // 
            // comboBoxCom
            // 
            this.comboBoxCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom.FormattingEnabled = true;
            this.comboBoxCom.Location = new System.Drawing.Point(18, 34);
            this.comboBoxCom.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCom.Name = "comboBoxCom";
            this.comboBoxCom.Size = new System.Drawing.Size(161, 24);
            this.comboBoxCom.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.buttonUpload);
            this.tabPage2.Controls.Add(this.textBoxАдресПрошивки);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.buttonOpenFile);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(538, 656);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Прошивка";
            // 
            // buttonUpload
            // 
            this.buttonUpload.Enabled = false;
            this.buttonUpload.Location = new System.Drawing.Point(179, 86);
            this.buttonUpload.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(161, 28);
            this.buttonUpload.TabIndex = 8;
            this.buttonUpload.Text = "Загрузить";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // textBoxАдресПрошивки
            // 
            this.textBoxАдресПрошивки.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxАдресПрошивки.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxАдресПрошивки.Enabled = false;
            this.textBoxАдресПрошивки.Location = new System.Drawing.Point(10, 28);
            this.textBoxАдресПрошивки.Multiline = true;
            this.textBoxАдресПрошивки.Name = "textBoxАдресПрошивки";
            this.textBoxАдресПрошивки.Size = new System.Drawing.Size(676, 51);
            this.textBoxАдресПрошивки.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Адрес прошивки:";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonOpenFile.Location = new System.Drawing.Point(10, 86);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(161, 28);
            this.buttonOpenFile.TabIndex = 5;
            this.buttonOpenFile.Text = "Выбрать файл";
            this.buttonOpenFile.UseVisualStyleBackColor = false;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.textBoxExtraInputStateOutput);
            this.tabPage3.Controls.Add(this.buttonСостояниеВыхода);
            this.tabPage3.Controls.Add(this.textBoxSerialNumber);
            this.tabPage3.Controls.Add(this.buttonСерийныйНомер);
            this.tabPage3.Controls.Add(this.textBoxFirmwareVersion);
            this.tabPage3.Controls.Add(this.buttonВерсияПрошивки);
            this.tabPage3.Controls.Add(this.textBoxExtraInputStateInput);
            this.tabPage3.Controls.Add(this.textBoxCardID);
            this.tabPage3.Controls.Add(this.buttonСостояниеВхода);
            this.tabPage3.Controls.Add(this.buttonЧтениеIDКарты);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(538, 656);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Регистры";
            // 
            // textBoxExtraInputStateOutput
            // 
            this.textBoxExtraInputStateOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxExtraInputStateOutput.Location = new System.Drawing.Point(174, 51);
            this.textBoxExtraInputStateOutput.Name = "textBoxExtraInputStateOutput";
            this.textBoxExtraInputStateOutput.ReadOnly = true;
            this.textBoxExtraInputStateOutput.Size = new System.Drawing.Size(85, 26);
            this.textBoxExtraInputStateOutput.TabIndex = 28;
            // 
            // buttonСостояниеВыхода
            // 
            this.buttonСостояниеВыхода.Enabled = false;
            this.buttonСостояниеВыхода.Location = new System.Drawing.Point(7, 49);
            this.buttonСостояниеВыхода.Margin = new System.Windows.Forms.Padding(4);
            this.buttonСостояниеВыхода.Name = "buttonСостояниеВыхода";
            this.buttonСостояниеВыхода.Size = new System.Drawing.Size(161, 28);
            this.buttonСостояниеВыхода.TabIndex = 27;
            this.buttonСостояниеВыхода.Text = "Состояние выхода";
            this.buttonСостояниеВыхода.UseVisualStyleBackColor = true;
            this.buttonСостояниеВыхода.Click += new System.EventHandler(this.buttonСостояниеВыхода_Click);
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxSerialNumber.Location = new System.Drawing.Point(174, 126);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.ReadOnly = true;
            this.textBoxSerialNumber.Size = new System.Drawing.Size(223, 26);
            this.textBoxSerialNumber.TabIndex = 26;
            // 
            // buttonСерийныйНомер
            // 
            this.buttonСерийныйНомер.Enabled = false;
            this.buttonСерийныйНомер.Location = new System.Drawing.Point(7, 125);
            this.buttonСерийныйНомер.Name = "buttonСерийныйНомер";
            this.buttonСерийныйНомер.Size = new System.Drawing.Size(161, 28);
            this.buttonСерийныйНомер.TabIndex = 25;
            this.buttonСерийныйНомер.Text = "Серийный номер";
            this.buttonСерийныйНомер.UseVisualStyleBackColor = true;
            this.buttonСерийныйНомер.Click += new System.EventHandler(this.buttonСерийныйНомер_Click);
            // 
            // textBoxFirmwareVersion
            // 
            this.textBoxFirmwareVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxFirmwareVersion.Location = new System.Drawing.Point(174, 86);
            this.textBoxFirmwareVersion.Name = "textBoxFirmwareVersion";
            this.textBoxFirmwareVersion.ReadOnly = true;
            this.textBoxFirmwareVersion.Size = new System.Drawing.Size(131, 26);
            this.textBoxFirmwareVersion.TabIndex = 24;
            // 
            // buttonВерсияПрошивки
            // 
            this.buttonВерсияПрошивки.Enabled = false;
            this.buttonВерсияПрошивки.Location = new System.Drawing.Point(7, 86);
            this.buttonВерсияПрошивки.Margin = new System.Windows.Forms.Padding(4);
            this.buttonВерсияПрошивки.Name = "buttonВерсияПрошивки";
            this.buttonВерсияПрошивки.Size = new System.Drawing.Size(161, 31);
            this.buttonВерсияПрошивки.TabIndex = 23;
            this.buttonВерсияПрошивки.Text = "Версия прошивки";
            this.buttonВерсияПрошивки.UseVisualStyleBackColor = true;
            this.buttonВерсияПрошивки.Click += new System.EventHandler(this.buttonВерсияПрошивки_Click);
            // 
            // textBoxExtraInputStateInput
            // 
            this.textBoxExtraInputStateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxExtraInputStateInput.Location = new System.Drawing.Point(174, 14);
            this.textBoxExtraInputStateInput.Name = "textBoxExtraInputStateInput";
            this.textBoxExtraInputStateInput.ReadOnly = true;
            this.textBoxExtraInputStateInput.Size = new System.Drawing.Size(85, 26);
            this.textBoxExtraInputStateInput.TabIndex = 22;
            // 
            // textBoxCardID
            // 
            this.textBoxCardID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxCardID.Location = new System.Drawing.Point(173, 210);
            this.textBoxCardID.Name = "textBoxCardID";
            this.textBoxCardID.ReadOnly = true;
            this.textBoxCardID.Size = new System.Drawing.Size(224, 26);
            this.textBoxCardID.TabIndex = 21;
            this.textBoxCardID.Visible = false;
            // 
            // buttonСостояниеВхода
            // 
            this.buttonСостояниеВхода.Enabled = false;
            this.buttonСостояниеВхода.Location = new System.Drawing.Point(7, 13);
            this.buttonСостояниеВхода.Margin = new System.Windows.Forms.Padding(4);
            this.buttonСостояниеВхода.Name = "buttonСостояниеВхода";
            this.buttonСостояниеВхода.Size = new System.Drawing.Size(161, 28);
            this.buttonСостояниеВхода.TabIndex = 20;
            this.buttonСостояниеВхода.Text = "Состояние входа";
            this.buttonСостояниеВхода.UseVisualStyleBackColor = true;
            this.buttonСостояниеВхода.Click += new System.EventHandler(this.buttonЧтениеВхода_Click);
            // 
            // buttonЧтениеIDКарты
            // 
            this.buttonЧтениеIDКарты.Enabled = false;
            this.buttonЧтениеIDКарты.Location = new System.Drawing.Point(7, 209);
            this.buttonЧтениеIDКарты.Margin = new System.Windows.Forms.Padding(4);
            this.buttonЧтениеIDКарты.Name = "buttonЧтениеIDКарты";
            this.buttonЧтениеIDКарты.Size = new System.Drawing.Size(161, 31);
            this.buttonЧтениеIDКарты.TabIndex = 19;
            this.buttonЧтениеIDКарты.Text = "Чтение ID карты";
            this.buttonЧтениеIDКарты.UseVisualStyleBackColor = true;
            this.buttonЧтениеIDКарты.Visible = false;
            this.buttonЧтениеIDКарты.Click += new System.EventHandler(this.buttonЧтениеIDКарты_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage4.Controls.Add(this.comboBoxSignalInversion);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.comboBoxByteOrder);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.buttonSave);
            this.tabPage4.Controls.Add(this.textBoxПорогZ);
            this.tabPage4.Controls.Add(this.textBoxПорогY);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.textBoxПорогX);
            this.tabPage4.Controls.Add(this.comboBoxЧастота);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.comboBoxДиапазон);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.comboBoxDeviceParity);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.comboBoxDeviceStopBits);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.comboBoxDeviceBaudRate);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.textBoxId);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(538, 656);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Настройка";
            // 
            // comboBoxSignalInversion
            // 
            this.comboBoxSignalInversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSignalInversion.Enabled = false;
            this.comboBoxSignalInversion.FormattingEnabled = true;
            this.comboBoxSignalInversion.Location = new System.Drawing.Point(174, 472);
            this.comboBoxSignalInversion.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSignalInversion.Name = "comboBoxSignalInversion";
            this.comboBoxSignalInversion.Size = new System.Drawing.Size(196, 24);
            this.comboBoxSignalInversion.TabIndex = 32;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 472);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.MaximumSize = new System.Drawing.Size(140, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 34);
            this.label19.TabIndex = 31;
            this.label19.Text = "Инверсия сигнала выхода:";
            // 
            // comboBoxByteOrder
            // 
            this.comboBoxByteOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxByteOrder.Enabled = false;
            this.comboBoxByteOrder.FormattingEnabled = true;
            this.comboBoxByteOrder.Location = new System.Drawing.Point(174, 430);
            this.comboBoxByteOrder.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxByteOrder.Name = "comboBoxByteOrder";
            this.comboBoxByteOrder.Size = new System.Drawing.Size(196, 24);
            this.comboBoxByteOrder.TabIndex = 30;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 433);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 17);
            this.label18.TabIndex = 29;
            this.label18.Text = "Порядок байт:";
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(174, 520);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(197, 28);
            this.buttonSave.TabIndex = 28;
            this.buttonSave.Text = "Сохранить изменения";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxПорогZ
            // 
            this.textBoxПорогZ.Enabled = false;
            this.textBoxПорогZ.Location = new System.Drawing.Point(174, 391);
            this.textBoxПорогZ.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxПорогZ.Name = "textBoxПорогZ";
            this.textBoxПорогZ.Size = new System.Drawing.Size(196, 22);
            this.textBoxПорогZ.TabIndex = 27;
            this.textBoxПорогZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxПорогZ_KeyPress);
            // 
            // textBoxПорогY
            // 
            this.textBoxПорогY.Enabled = false;
            this.textBoxПорогY.Location = new System.Drawing.Point(174, 358);
            this.textBoxПорогY.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxПорогY.Name = "textBoxПорогY";
            this.textBoxПорогY.Size = new System.Drawing.Size(196, 22);
            this.textBoxПорогY.TabIndex = 26;
            this.textBoxПорогY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxПорогY_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 394);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 17);
            this.label15.TabIndex = 25;
            this.label15.Text = "Порог Z:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 361);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 17);
            this.label14.TabIndex = 24;
            this.label14.Text = "Порог Y:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 327);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 17);
            this.label13.TabIndex = 23;
            this.label13.Text = "Порог X:";
            // 
            // textBoxПорогX
            // 
            this.textBoxПорогX.Enabled = false;
            this.textBoxПорогX.Location = new System.Drawing.Point(174, 324);
            this.textBoxПорогX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxПорогX.Name = "textBoxПорогX";
            this.textBoxПорогX.Size = new System.Drawing.Size(196, 22);
            this.textBoxПорогX.TabIndex = 22;
            this.textBoxПорогX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxПорогX_KeyPress);
            // 
            // comboBoxЧастота
            // 
            this.comboBoxЧастота.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxЧастота.Enabled = false;
            this.comboBoxЧастота.FormattingEnabled = true;
            this.comboBoxЧастота.Location = new System.Drawing.Point(174, 282);
            this.comboBoxЧастота.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxЧастота.Name = "comboBoxЧастота";
            this.comboBoxЧастота.Size = new System.Drawing.Size(196, 24);
            this.comboBoxЧастота.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 285);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Частота:";
            // 
            // comboBoxДиапазон
            // 
            this.comboBoxДиапазон.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxДиапазон.Enabled = false;
            this.comboBoxДиапазон.FormattingEnabled = true;
            this.comboBoxДиапазон.Location = new System.Drawing.Point(174, 240);
            this.comboBoxДиапазон.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxДиапазон.Name = "comboBoxДиапазон";
            this.comboBoxДиапазон.Size = new System.Drawing.Size(196, 24);
            this.comboBoxДиапазон.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 243);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 17);
            this.label11.TabIndex = 18;
            this.label11.Text = "Диапазон:";
            // 
            // comboBoxDeviceParity
            // 
            this.comboBoxDeviceParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeviceParity.Enabled = false;
            this.comboBoxDeviceParity.FormattingEnabled = true;
            this.comboBoxDeviceParity.Location = new System.Drawing.Point(174, 200);
            this.comboBoxDeviceParity.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDeviceParity.Name = "comboBoxDeviceParity";
            this.comboBoxDeviceParity.Size = new System.Drawing.Size(196, 24);
            this.comboBoxDeviceParity.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 203);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Parity:";
            // 
            // comboBoxDeviceStopBits
            // 
            this.comboBoxDeviceStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeviceStopBits.Enabled = false;
            this.comboBoxDeviceStopBits.FormattingEnabled = true;
            this.comboBoxDeviceStopBits.Location = new System.Drawing.Point(174, 162);
            this.comboBoxDeviceStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDeviceStopBits.Name = "comboBoxDeviceStopBits";
            this.comboBoxDeviceStopBits.Size = new System.Drawing.Size(196, 24);
            this.comboBoxDeviceStopBits.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "StopBits:";
            // 
            // comboBoxDeviceBaudRate
            // 
            this.comboBoxDeviceBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeviceBaudRate.Enabled = false;
            this.comboBoxDeviceBaudRate.FormattingEnabled = true;
            this.comboBoxDeviceBaudRate.Location = new System.Drawing.Point(174, 121);
            this.comboBoxDeviceBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDeviceBaudRate.Name = "comboBoxDeviceBaudRate";
            this.comboBoxDeviceBaudRate.Size = new System.Drawing.Size(196, 24);
            this.comboBoxDeviceBaudRate.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 124);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "BaudRate:";
            // 
            // textBoxId
            // 
            this.textBoxId.Enabled = false;
            this.textBoxId.Location = new System.Drawing.Point(174, 83);
            this.textBoxId.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(196, 22);
            this.textBoxId.TabIndex = 11;
            this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxId_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 86);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelStatus);
            this.groupBox2.Controls.Add(this.buttonStatus);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(664, 73);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Статус: ";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(121, 32);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(121, 17);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Нет информации";
            // 
            // buttonStatus
            // 
            this.buttonStatus.Enabled = false;
            this.buttonStatus.Location = new System.Drawing.Point(13, 26);
            this.buttonStatus.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(100, 28);
            this.buttonStatus.TabIndex = 3;
            this.buttonStatus.Text = "Запросить";
            this.buttonStatus.UseVisualStyleBackColor = true;
            this.buttonStatus.Click += new System.EventHandler(this.buttonStatus_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.textBoxПериодОпроса);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.groupBoxZ);
            this.tabPage5.Controls.Add(this.groupBoxY);
            this.tabPage5.Controls.Add(this.groupBoxX);
            this.tabPage5.Controls.Add(this.buttonStartKaliber);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(538, 656);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Калибровка";
            this.tabPage5.Resize += new System.EventHandler(this.tabPage5_Resize);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.textBoxКоличествоТочекВГрафике);
            this.groupBox3.Controls.Add(this.trackBarКоличествоТочекВГрафике);
            this.groupBox3.Location = new System.Drawing.Point(122, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(413, 81);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Количество точек в графике";
            // 
            // textBoxКоличествоТочекВГрафике
            // 
            this.textBoxКоличествоТочекВГрафике.Location = new System.Drawing.Point(340, 21);
            this.textBoxКоличествоТочекВГрафике.Name = "textBoxКоличествоТочекВГрафике";
            this.textBoxКоличествоТочекВГрафике.ReadOnly = true;
            this.textBoxКоличествоТочекВГрафике.Size = new System.Drawing.Size(59, 22);
            this.textBoxКоличествоТочекВГрафике.TabIndex = 12;
            // 
            // trackBarКоличествоТочекВГрафике
            // 
            this.trackBarКоличествоТочекВГрафике.Location = new System.Drawing.Point(6, 19);
            this.trackBarКоличествоТочекВГрафике.Maximum = 300;
            this.trackBarКоличествоТочекВГрафике.Minimum = 10;
            this.trackBarКоличествоТочекВГрафике.Name = "trackBarКоличествоТочекВГрафике";
            this.trackBarКоличествоТочекВГрафике.Size = new System.Drawing.Size(328, 56);
            this.trackBarКоличествоТочекВГрафике.TabIndex = 11;
            this.trackBarКоличествоТочекВГрафике.TickFrequency = 10;
            this.trackBarКоличествоТочекВГрафике.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarКоличествоТочекВГрафике.Value = 10;
            this.trackBarКоличествоТочекВГрафике.Scroll += new System.EventHandler(this.trackBarКоличествоТочекВГрафике_Scroll);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(505, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 20);
            this.label17.TabIndex = 10;
            this.label17.Text = "мс";
            // 
            // textBoxПериодОпроса
            // 
            this.textBoxПериодОпроса.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxПериодОпроса.Location = new System.Drawing.Point(424, 5);
            this.textBoxПериодОпроса.Name = "textBoxПериодОпроса";
            this.textBoxПериодОпроса.Size = new System.Drawing.Size(78, 22);
            this.textBoxПериодОпроса.TabIndex = 9;
            this.textBoxПериодОпроса.TextChanged += new System.EventHandler(this.textBoxПериодОпроса_TextChanged);
            this.textBoxПериодОпроса.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxПериодОпроса_KeyPress);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(280, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 20);
            this.label16.TabIndex = 8;
            this.label16.Text = "Период опроса";
            // 
            // groupBoxZ
            // 
            this.groupBoxZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxZ.Location = new System.Drawing.Point(3, 473);
            this.groupBoxZ.Name = "groupBoxZ";
            this.groupBoxZ.Size = new System.Drawing.Size(532, 180);
            this.groupBoxZ.TabIndex = 7;
            this.groupBoxZ.TabStop = false;
            this.groupBoxZ.Text = "Z:";
            // 
            // groupBoxY
            // 
            this.groupBoxY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxY.Location = new System.Drawing.Point(3, 295);
            this.groupBoxY.Name = "groupBoxY";
            this.groupBoxY.Size = new System.Drawing.Size(532, 172);
            this.groupBoxY.TabIndex = 6;
            this.groupBoxY.TabStop = false;
            this.groupBoxY.Text = "Y:";
            // 
            // groupBoxX
            // 
            this.groupBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxX.Location = new System.Drawing.Point(4, 127);
            this.groupBoxX.Name = "groupBoxX";
            this.groupBoxX.Size = new System.Drawing.Size(531, 162);
            this.groupBoxX.TabIndex = 5;
            this.groupBoxX.TabStop = false;
            this.groupBoxX.Text = "X:";
            // 
            // buttonStartKaliber
            // 
            this.buttonStartKaliber.Enabled = false;
            this.buttonStartKaliber.Location = new System.Drawing.Point(4, 4);
            this.buttonStartKaliber.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStartKaliber.Name = "buttonStartKaliber";
            this.buttonStartKaliber.Size = new System.Drawing.Size(116, 28);
            this.buttonStartKaliber.TabIndex = 4;
            this.buttonStartKaliber.Text = "Старт";
            this.buttonStartKaliber.UseVisualStyleBackColor = true;
            this.buttonStartKaliber.Click += new System.EventHandler(this.buttonStartKaliber_Click);
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearLog.Location = new System.Drawing.Point(3, 670);
            this.buttonClearLog.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(120, 28);
            this.buttonClearLog.TabIndex = 4;
            this.buttonClearLog.Text = "Очистить лог";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Лог:";
            // 
            // textBoxЛог
            // 
            this.textBoxЛог.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxЛог.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBoxЛог.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxЛог.Location = new System.Drawing.Point(3, 29);
            this.textBoxЛог.Multiline = true;
            this.textBoxЛог.Name = "textBoxЛог";
            this.textBoxЛог.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxЛог.Size = new System.Drawing.Size(300, 635);
            this.textBoxЛог.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusPort,
            this.toolStripStatusConnection});
            this.statusStrip.Location = new System.Drawing.Point(0, 734);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(901, 29);
            this.statusStrip.TabIndex = 31;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusPort
            // 
            this.toolStripStatusPort.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusPort.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusPort.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusPort.Name = "toolStripStatusPort";
            this.toolStripStatusPort.Size = new System.Drawing.Size(100, 24);
            this.toolStripStatusPort.Text = "Порт закрыт";
            // 
            // toolStripStatusConnection
            // 
            this.toolStripStatusConnection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusConnection.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusConnection.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusConnection.Name = "toolStripStatusConnection";
            this.toolStripStatusConnection.Size = new System.Drawing.Size(223, 24);
            this.toolStripStatusConnection.Text = "Статус подключения - ошибка";
            this.toolStripStatusConnection.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 763);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "Form1";
            this.Text = "Конфигуратор датчика вибрации 2.0.0.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarКоличествоТочекВГрафике)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьПрограммуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьПрограммуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проверитьНаличиеОбновленийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxЛог;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCom;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonCom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPort;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusConnection;
        private System.Windows.Forms.TextBox textBoxАдресПрошивки;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.Button buttonСерийныйНомер;
        private System.Windows.Forms.TextBox textBoxFirmwareVersion;
        private System.Windows.Forms.Button buttonВерсияПрошивки;
        private System.Windows.Forms.TextBox textBoxExtraInputStateInput;
        private System.Windows.Forms.TextBox textBoxCardID;
        private System.Windows.Forms.Button buttonСостояниеВхода;
        private System.Windows.Forms.Button buttonЧтениеIDКарты;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox comboBoxDeviceParity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxDeviceStopBits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxDeviceBaudRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.ComboBox comboBoxДиапазон;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxЧастота;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxПорогZ;
        private System.Windows.Forms.TextBox textBoxПорогY;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxПорогX;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelDeviceID;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button buttonStartKaliber;
        private System.Windows.Forms.GroupBox groupBoxZ;
        private System.Windows.Forms.GroupBox groupBoxY;
        private System.Windows.Forms.GroupBox groupBoxX;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxПериодОпроса;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button buttonСостояниеВыхода;
        private System.Windows.Forms.TextBox textBoxExtraInputStateOutput;
        private System.Windows.Forms.TrackBar trackBarКоличествоТочекВГрафике;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxКоличествоТочекВГрафике;
        private System.Windows.Forms.ComboBox comboBoxSignalInversion;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBoxByteOrder;
        private System.Windows.Forms.Label label18;
    }
}

