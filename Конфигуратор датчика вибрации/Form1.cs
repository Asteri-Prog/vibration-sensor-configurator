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
using System.Globalization;
using System.Threading;
using System.Activities.Statements;
using System.Runtime;
using System.Windows.Forms.DataVisualization.Charting;

namespace Конфигуратор_датчика_вибрации
{
    public partial class Form1 : Form
    {
        int size_of_piece = 1024;
        int id=-1;
        bool калибровка_запущена = false;
        int длина_графика = 100;
        Int16[] Массив_данных_X;
        Int16[] Массив_данных_Y;
        Int16[] Массив_данныx_Z;
        Chart ChartX;
        Chart ChartY;
        Chart ChartZ;
        int Период_опроса_устройства_XYZ = 200;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Заполнение combobox-ов
            comboBoxBaudRate.Items.Add("1200");
            comboBoxBaudRate.Items.Add("2400");
            comboBoxBaudRate.Items.Add("4800");
            comboBoxBaudRate.Items.Add("9600");
            comboBoxBaudRate.Items.Add("14400");
            comboBoxBaudRate.Items.Add("19200");
            comboBoxBaudRate.Items.Add("38400");
            comboBoxBaudRate.Items.Add("57600");
            comboBoxBaudRate.Items.Add("115200");
            comboBoxBaudRate.Items.Add("230400");

            comboBoxParity.Items.Add("None");
            comboBoxParity.Items.Add("Even");
            comboBoxParity.Items.Add("Odd");

            comboBoxStopBits.Items.Add("One");
            comboBoxStopBits.Items.Add("OnePointFive");
            comboBoxStopBits.Items.Add("Two");

            comboBoxDeviceBaudRate.Items.Add("1200");
            comboBoxDeviceBaudRate.Items.Add("2400");
            comboBoxDeviceBaudRate.Items.Add("4800");
            comboBoxDeviceBaudRate.Items.Add("9600");
            comboBoxDeviceBaudRate.Items.Add("14400");
            comboBoxDeviceBaudRate.Items.Add("19200");
            comboBoxDeviceBaudRate.Items.Add("38400");
            comboBoxDeviceBaudRate.Items.Add("57600");
            comboBoxDeviceBaudRate.Items.Add("115200");
            comboBoxDeviceBaudRate.Items.Add("230400");

            comboBoxDeviceStopBits.Items.Add("1.0");
            comboBoxDeviceStopBits.Items.Add("2.0");

            comboBoxDeviceParity.Items.Add("None");
            comboBoxDeviceParity.Items.Add("Even");
            comboBoxDeviceParity.Items.Add("Odd");

            comboBoxДиапазон.Items.Add("2 g");
            comboBoxДиапазон.Items.Add("4 g");
            comboBoxДиапазон.Items.Add("8 g");
            comboBoxДиапазон.Items.Add("16 g");

            comboBoxЧастота.Items.Add("1 Hz");
            comboBoxЧастота.Items.Add("10 Hz");
            comboBoxЧастота.Items.Add("25 Hz");
            comboBoxЧастота.Items.Add("50 Hz");
            comboBoxЧастота.Items.Add("100 Hz");
            comboBoxЧастота.Items.Add("200 Hz");
            comboBoxЧастота.Items.Add("400 Hz");
            comboBoxЧастота.Items.Add("1.344 кHz");

            comboBoxByteOrder.Items.Add("MSB");
            comboBoxByteOrder.Items.Add("LSB");

            comboBoxSignalInversion.Items.Add("Выкл.");
            comboBoxSignalInversion.Items.Add("Вкл.");

            textBoxПериодОпроса.Text = Период_опроса_устройства_XYZ.ToString();

            ОбновлениеСпискаCOMПортов();

            ChartX = new Chart();
            ChartX.Name = "ChartX";
            ChartX.Parent = tabControl1.TabPages[4].Controls.Find("groupBoxX", false)[0];
            ChartX.Dock = DockStyle.Fill;
            ChartX.BorderlineColor = Color.Black;
            ChartX.BorderlineDashStyle = ChartDashStyle.Solid;
            ChartX.BackColor = ChartX.Parent.BackColor;

            ChartY = new Chart();
            ChartY.Name = "ChartY";
            ChartY.Parent = tabControl1.TabPages[4].Controls.Find("groupBoxY", false)[0];
            ChartY.Dock = DockStyle.Fill;
            ChartY.BorderlineColor = Color.Black;
            ChartY.BorderlineDashStyle = ChartDashStyle.Solid;
            ChartY.BackColor = ChartY.Parent.BackColor;

            ChartZ = new Chart();
            ChartZ.Name = "ChartZ";
            ChartZ.Parent = tabControl1.TabPages[4].Controls.Find("groupBoxZ", false)[0];
            ChartZ.Dock = DockStyle.Fill;
            ChartZ.BorderlineColor = Color.Black;
            ChartZ.BorderlineDashStyle = ChartDashStyle.Solid;
            ChartZ.BackColor = ChartY.Parent.BackColor;

            //Запус потока проверки состояния порта
            Thread ThreadStatusCheck = new Thread(new ThreadStart(StatusCheck));
            ThreadStatusCheck.IsBackground = true;
            ThreadStatusCheck.Start();

            //Запус потока калибровки
            Thread ThreadKalibr = new Thread(new ThreadStart(Обработка_графиков));
            ThreadKalibr.IsBackground = true;
            ThreadKalibr.Start();

            // настройки порта
            serialPort1.BaudRate = 115200;
            serialPort1.DataBits = 8;
            serialPort1.Parity = System.IO.Ports.Parity.None;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            serialPort1.ReadTimeout = 500;
            serialPort1.WriteTimeout = 1000;
            ЗагрузкаНастроекИзФайла();
            textBoxКоличествоТочекВГрафике.Text = длина_графика.ToString();
            trackBarКоличествоТочекВГрафике.Value = длина_графика;
        }

        //Функция при клике на пункт "Свернуть программу" в MenuStrip
        private void свернутьПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Функция при клике на пункт "Закрыть программу" в MenuStrip
        private void закрытьПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            this.Close();
        }

        private void ОбновлениеСпискаCOMПортов()
        {
            comboBoxCom.Items.Clear();
            foreach (string portName in SerialPort.GetPortNames())
            {
                comboBoxCom.Items.Add(portName);
            }
            if (comboBoxCom.Items.Count > 0)
                comboBoxCom.SelectedIndex = 0;

            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Список портов обновлен." + Environment.NewLine);
        }

        //Функция при нажатии на кнопку "Обновить" порт.
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ОбновлениеСпискаCOMПортов();
        }

        //Функция при нажатии на кнопку "Открыть/Закрыть" порт.
        private void buttonCom_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = ((string)comboBoxCom.SelectedItem);
                try
                {
                    serialPort1.Open();
                }
                catch (Exception ex)
                {
                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Не удалось открыть порт. {ex.Message}");
                    return;
                }
                buttonCom.Text = "Закрыть";
                buttonCom.BackColor = Color.FromArgb(192, 255, 192);
                ОтключитьЭлементыПриОткрытииПорта();
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} {serialPort1.PortName} {(serialPort1.IsOpen ? "открыт" : "закрыт")}." + Environment.NewLine);
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Поиск устройства." + Environment.NewLine);
                id = Device_polling();

                if (id == -1)
                {
                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Устройство не найдено." + Environment.NewLine);
                    labelDeviceID.Text = "ID устройства: Не определено";
                }
                else
                {
                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Устройство определено. ID "+ Convert.ToString(id, 16) + Environment.NewLine);
                    labelDeviceID.Text = "ID устройства: " + Convert.ToString(id, 16);
                }
            }
            else
            {
                buttonCom.Text = "Открыть";
                serialPort1.Close();
                buttonCom.BackColor = Color.FromArgb(255, 192, 192);
                ВключитьЭлементыПриЗакрытииПорта();
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} {serialPort1.PortName} {(serialPort1.IsOpen ? "открыт" : "закрыт")}." + Environment.NewLine);
            }
        }

        //Функция отключения элементов при открытии порта
        private void ОтключитьЭлементыПриОткрытииПорта()
        {
            comboBoxCom.Enabled = false;
            buttonReset.Enabled = false;
            comboBoxBaudRate.Enabled = false;
            comboBoxParity.Enabled = false;
            comboBoxStopBits.Enabled = false;
            buttonUpload.Enabled = true;
            buttonЧтениеIDКарты.Enabled = true;
            buttonСостояниеВхода.Enabled = true;
            buttonСостояниеВыхода.Enabled = true;
            buttonВерсияПрошивки.Enabled = true;
            buttonСерийныйНомер.Enabled = true;
            buttonStatus.Enabled = true;
            buttonStartKaliber.Enabled = true;
        }

        //Функция включения элементов при закрытии порта
        private void ВключитьЭлементыПриЗакрытииПорта()
        {
            comboBoxCom.Enabled = true;
            buttonReset.Enabled = true;
            comboBoxBaudRate.Enabled = true;
            comboBoxParity.Enabled = true;
            comboBoxStopBits.Enabled = true;
            buttonUpload.Enabled = false;
            buttonЧтениеIDКарты.Enabled = false;
            buttonСостояниеВхода.Enabled = false;
            buttonСостояниеВыхода.Enabled = false;
            buttonВерсияПрошивки.Enabled = false;
            buttonСерийныйНомер.Enabled = false;
            buttonStatus.Enabled = false;
            textBoxId.Enabled = false;
            comboBoxDeviceBaudRate.Enabled = false;
            comboBoxDeviceStopBits.Enabled = false;
            comboBoxDeviceParity.Enabled = false;
            comboBoxДиапазон.Enabled = false;
            comboBoxЧастота.Enabled = false;
            textBoxПорогX.Enabled = false;
            textBoxПорогY.Enabled = false;
            textBoxПорогZ.Enabled = false;
            comboBoxSignalInversion.Enabled = false;
            buttonSave.Enabled = false;
            buttonStartKaliber.Enabled = false;
        }

        //
        //Проверка состояния порта
        //
        private void StatusCheck()
        {
            for (; ; )
            {
                if (comboBoxCom.Items.Count > 0)
                    if (serialPort1.IsOpen)
                    {
                        toolStripStatusPortOn();
                    }
                    else
                    {
                        toolStripStatusPortOff();
                    }
                else
                {
                    toolStripStatusPortOff();
                }
                Thread.Sleep(900);
            }
        }

        private void toolStripStatusPortOn()
        {
            statusStrip.BeginInvoke(new MethodInvoker(toolStripStatusPortInvokeMethodOn));
        }
        private void toolStripStatusPortOff()
        {
            statusStrip.BeginInvoke(new MethodInvoker(toolStripStatusPortInvokeMethodOff));
        }
        public void toolStripStatusPortInvokeMethodOn()
        {
            ToolStripStatusLabel label = (ToolStripStatusLabel)statusStrip.Items.Find("toolStripStatusPort", false)[0];
            label.Text = "Порт открыт";
            label.ForeColor = Color.Green;
        }
        public void toolStripStatusPortInvokeMethodOff()
        {
            ToolStripStatusLabel label = (ToolStripStatusLabel)statusStrip.Items.Find("toolStripStatusPort", false)[0];
            label.Text = "Порт закрыт";
            label.ForeColor = Color.Red;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Загрузка настроек из файла
        public void ЗагрузкаНастроекИзФайла()
        {
            string file = "";
            try
            {
                using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\config.ini"))
                {
                    file = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                file = "Location=783,127;\r\nHeight=332;\r\nWidth=732;\r\nSerialPortBaudRate=115200;\r\nSerialPortDataBits=8;\r\nSerialPortParity=2;\r\nSerialPortStopBits=0;\r\n";
                //File.WriteAllText(Directory.GetCurrentDirectory() + @"\config.ini", file);
            }

            string temp = FindSetting(file, "Location");
            string x = temp.Remove(temp.IndexOf(","));
            string y = temp.Substring(temp.IndexOf(",") + 1);
            this.Location = new Point(int.Parse(x), int.Parse(y));
            temp = FindSetting(file, "Height");
            this.Height = Convert.ToInt32(temp);
            temp = FindSetting(file, "Width");
            this.Width = Convert.ToInt32(temp);

            temp = FindSetting(file, "SerialPortBaudRate");
            int n = Convert.ToInt32(temp);
            ИзменитьBaudRateПорта(n);
            for (int i = 0; i < comboBoxBaudRate.Items.Count; i++)
                if (comboBoxBaudRate.Items[i].ToString() == temp)
                    comboBoxBaudRate.SelectedIndex = i;

            temp = FindSetting(file, "SerialPortParity");
            n = Convert.ToInt32(temp);
            ИзменитьParityПорта(n);
            comboBoxParity.SelectedIndex = n;

            temp = FindSetting(file, "SerialPortStopBits");
            n = Convert.ToInt32(temp);
            ИзменитьStopBitsПорта(n);
            comboBoxStopBits.SelectedIndex = n;

            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Настройки загружены." + Environment.NewLine);
        }

        //Функция сохранения настроек в файл
        public void СохранитьНастройкиВФайл()
        {
            string writePath = Directory.GetCurrentDirectory() + @"\config.ini";
            string x = this.Location.X.ToString();
            string text = $"Location={x},{this.Location.Y};\r\n" +
                            $"Height={this.Height};\r\n" +
                            $"Width={this.Width};\r\n" +
                            $"SerialPortBaudRate={serialPort1.BaudRate};\r\n" +
                            $"SerialPortDataBits={serialPort1.DataBits};\r\n" +
                            $"SerialPortParity={(serialPort1.Parity == Parity.None ? "0" : serialPort1.Parity == Parity.Even ? "1" : serialPort1.Parity == Parity.Odd ? "2" : "0")};\r\n" +
                            $"SerialPortStopBits={(serialPort1.StopBits == StopBits.One ? "0" : serialPort1.StopBits == StopBits.OnePointFive ? "1" : serialPort1.StopBits == StopBits.Two ? "2" : "3")};\r\n";
            File.WriteAllText(writePath, text);
        }

        //Функция установки StopBits порта.
        void ИзменитьStopBitsПорта(int n)
        {
            switch (n)
            {
                default:
                case 0:
                    serialPort1.StopBits = StopBits.One;
                    break;
                case 1:
                    serialPort1.StopBits = StopBits.OnePointFive;
                    break;
                case 2:
                    serialPort1.StopBits = StopBits.Two;
                    break;
            }
        }

        //Функция установки Parity порта. Данные строка
        void ИзменитьParityПорта(int n)
        {
            switch (n)
            {
                default:
                case 0:
                    serialPort1.Parity = Parity.None;
                    break;
                case 1:
                    serialPort1.Parity = Parity.Even;
                    break;
                case 2:
                    serialPort1.Parity = Parity.Odd;
                    break;
            }
        }

        //Функция установки BaudRate порта. Данные число
        void ИзменитьBaudRateПорта(int n)
        {
            int temp = 115200;
            if (comboBoxBaudRate.Items.Count > 0)
                foreach (string item in comboBoxBaudRate.Items)
                    if (Convert.ToInt32(item) == n)
                    {
                        temp = n;
                        break;
                    }
            serialPort1.BaudRate = temp;
        }

        //Функция поиска в строке данных по ключу
        private string FindSetting(string data, string key)
        {
            string set = "";
            if (data.IndexOf(key) != -1)
            {
                set = data.Substring(data.IndexOf(key) + key.Length + 1);
                set = set.Remove(set.IndexOf(";"));
            }
            return set;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            СохранитьНастройкиВФайл();
        }

        private void comboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ИзменитьBaudRateПорта(Convert.ToInt32(comboBoxBaudRate.Items[comboBoxBaudRate.SelectedIndex]));
            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} BaudRate порта изменен на {serialPort1.BaudRate}." + Environment.NewLine);
        }

        private void comboBoxParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ИзменитьParityПорта(comboBoxParity.SelectedIndex);
            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Parity порта изменен на {serialPort1.Parity}." + Environment.NewLine);
        }

        private void comboBoxStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            ИзменитьStopBitsПорта(comboBoxStopBits.SelectedIndex);
            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} StopBits порта изменен на {serialPort1.StopBits}." + Environment.NewLine);
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.bsv|*.bsv|Все файлы|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                buttonOpenFile.BackColor = Color.FromArgb(255, 192, 192);
                return;
            }
            textBoxАдресПрошивки.Text = ofd.FileName;
            buttonOpenFile.BackColor = Color.FromArgb(192, 255, 192);
            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Выбран файл прошивки {ofd.FileName}." + Environment.NewLine);
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            string data = "";
            buttonUpload.Enabled = false;
            if (!serialPort1.IsOpen)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка: Порт закрыт или не выбран!" + Environment.NewLine);
                buttonUpload.Enabled = true;
                return;
            }

            if (textBoxАдресПрошивки.Text.Length == 0)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка: Файл для записи не выбран!" + Environment.NewLine);
                buttonUpload.Enabled = true;
                return;
            }

            try
            {
                data = File.ReadAllText(textBoxАдресПрошивки.Text);
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка чтение прошивки из файла: {ex.Message}" + Environment.NewLine);
                buttonUpload.Enabled = true;
                return;
            }

            for (int i = 0; ; i++)
            {
                string dataread = "";

                try
                {
                    serialPort1.Write("boot");
                }
                catch (Exception ex)
                {
                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} {ex.Message}" + Environment.NewLine);
                    buttonUpload.Enabled = true;
                    return;
                }

                Thread.Sleep(100);
                try
                {
                    dataread = serialPort1.ReadLine();
                }
                catch (Exception ex)
                {
                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка чтение ответа от устройства: {ex.Message}" + Environment.NewLine);
                    /*
                    buttonUpload.Enabled = true;
                    return;
                    */
                }

                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Полученный ответ: {dataread}" + Environment.NewLine);

                if (dataread != "")
                    break;

                if (i == 19)
                {
                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Не удалось начать передачу данных, попытка прекращена!" + Environment.NewLine);
                    buttonUpload.Enabled = true;
                    return;
                }
            }

            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Начата передача данных." + Environment.NewLine);

            for (int i = 0; i < data.Length; i += size_of_piece)
            {
                string data_piece = data.Substring(i, data.Length - i >= size_of_piece ? size_of_piece : data.Length - i);

                byte[] mas = Enumerable.Range(0, data_piece.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(data_piece.Substring(x, 2), 16))
                     .ToArray();

                int size = mas.Length + 4;
                byte b0 = (byte)size, b1 = (byte)(size >> 8), b2 = (byte)(size >> 16), b3 = (byte)(size >> 24);
                int номер_пакета = i / size_of_piece + 1;
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Отправка пакета номер {номер_пакета} длиной {size}" + Environment.NewLine);
                byte n0 = (byte)номер_пакета, n1 = (byte)(номер_пакета >> 8);
                int количество_пакетов = (int)data.Length / size_of_piece + (data.Length % size_of_piece != 0 ? 1 : 0);
                byte k0 = (byte)количество_пакетов, k1 = (byte)(количество_пакетов >> 8);
                byte[] first = new byte[] { 00, 0x10, b3, b2, b1, b0, n1, n0, k1, k0 };
                var to_CRC = first.Concat(mas);

                byte[] byte_to_CRC = new byte[to_CRC.Count()];
                for (int j = 0; j < to_CRC.Count(); j++)
                    byte_to_CRC[j] = to_CRC.ElementAt(j);

                UInt16 CRC = CRC16(byte_to_CRC, byte_to_CRC.Length);
                byte c0 = (byte)CRC, c1 = (byte)(CRC >> 8);
                byte[] last = new byte[] { c0, c1 };

                byte[] mas_temp = new byte[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                try
                {
                    serialPort1.Write(first, 0, first.Length);
                    serialPort1.Write(mas, 0, mas.Length);
                    serialPort1.Write(last, 0, last.Length);

                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Пакет отправлен, ожидаю ответ." + Environment.NewLine);

                    for (int j = 0; ; j++)
                    {
                        try
                        {
                            for (int k = 0; k < 13; k++)
                            {
                                try
                                {
                                    mas_temp[k] = Convert.ToByte(serialPort1.ReadByte());
                                }
                                catch
                                {
                                    break;
                                }
                                if (k == 10)
                                    if (mas_temp[k] != 0)
                                        textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Полученный код ошибки - {mas_temp[k]}" + Environment.NewLine);
                            }
                            if (mas_temp[12] != 0 || mas_temp[11] != 0)
                                break;
                        }
                        catch (Exception ex)
                        {
                            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} {ex.Message}" + Environment.NewLine);
                        }
                        if (j == 20)
                        {
                            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Превышено время ожидания, передача данных прекращена." + Environment.NewLine);
                            buttonUpload.Enabled = true;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} {ex.Message}" + Environment.NewLine);
                    buttonUpload.Enabled = true;
                    return;
                }


                if (mas_temp[10] != 0)
                {
                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка передачи данных, передача данных прекращена." + Environment.NewLine);
                    buttonUpload.Enabled = true;
                    return;
                }
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Передача пакета прошла успешно." + Environment.NewLine);
            }
        }

        private UInt16 CRC16(byte[] buf, int len)
        {
            UInt16 crc = 0xFFFF;

            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (UInt16)buf[pos];

                for (int i = 8; i != 0; i--)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                        crc >>= 1;
                }
            }

            return crc;
        }

        private int Device_polling()
        {
            byte[] output_data = new byte[6] { 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 };
            byte[] input_data = mk_data_exchange(output_data, 8);
            if (input_data[input_data.Length - 1] == 0xff)
                return -1;
            if (input_data[5] != 01)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Шестой байт не равен 1"+ Environment.NewLine);
                return -1;
            }
            return input_data[0];
        }

        private byte[] mk_data_exchange(byte[] output_data, int input_data_length)
        {
            UInt16 CRC = CRC16(output_data, output_data.Length);
            byte c0 = (byte)CRC, c1 = (byte)(CRC >> 8);
            byte[] last = new byte[] { c0, c1 };
            byte[] output_data_with_crc = new byte[output_data.Length + last.Length];
            output_data.CopyTo(output_data_with_crc, 0);
            last.CopyTo(output_data_with_crc, output_data.Length);
            byte[] input_data = new byte[input_data_length + 1];
            for (int i = 0; i < input_data.Length; i++)
                input_data[i] = 0xff;

            try
            {
                serialPort1.Write(output_data_with_crc, 0, output_data_with_crc.Length);

                for (int i = 0; i < input_data_length; i++)
                {
                    input_data[i] = Convert.ToByte(serialPort1.ReadByte());
                }
            }
            catch (Exception e)
            {
                BeginInvoke(new MethodInvoker(delegate {
                    textBoxЛог.AppendText(DateTime.Now.ToString("HH:mm:ss")+" "+e.Message+Environment.NewLine);
                }));
                return input_data;
            }
            /*
            string str = "";
            for (int i = 0; i < input_data.Length; i++)
                str += input_data[i].ToString() + " ";
            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Получены данные " + str + Environment.NewLine);
            */
            byte[] input_without_crc = new byte[input_data_length - 2];
            for (int i = 0; i < input_without_crc.Length; i++)
                input_without_crc[i] = input_data[i];
            CRC = CRC16(input_without_crc, input_without_crc.Length);
            c0 = (byte)CRC;
            c1 = (byte)(CRC >> 8);
            if (c0 != input_data[input_data_length - 2] || c1 != input_data[input_data_length - 1])
            {
                string полученное_сообщение = "";
                foreach (byte b in input_data)
                {
                    полученное_сообщение += (Convert.ToString(b, 16).Length == 1 ? "0" + Convert.ToString(b, 16) : Convert.ToString(b, 16)) + " ";
                }
                полученное_сообщение = полученное_сообщение.Remove(полученное_сообщение.Length - 3);
                BeginInvoke(new MethodInvoker(delegate {
                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} CRC в полученных данных не совпадает с расчетным. Полученное сообщение {полученное_сообщение}. " +
                    $"Рассчитанное CRC {(Convert.ToString(c0, 16).Length == 1 ? "0" + Convert.ToString(c0, 16) : Convert.ToString(c0, 16))} " +
                    $"{(Convert.ToString(c1, 16).Length == 1 ? "0" + Convert.ToString(c1, 16) : Convert.ToString(c1, 16))}");
                    serialPort1.ReadExisting();
                }));
                
                return input_data;
            }

            input_data[input_data.Length - 1] = 0x00;
            serialPort1.ReadExisting();
            return input_data;
        }

        private void buttonЧтениеIDКарты_Click(object sender, EventArgs e)
        {
            id = Device_polling();
            if (id == -1)
                return;

            byte[] output_data = new byte[6] { (byte)id, 0x03, 0x00, 0x00, 0x00, 0x04 };

            byte[] input_data = mk_data_exchange(output_data, 13);

            if (input_data[input_data.Length - 1] == 0xff)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Считать данные не удалось." + Environment.NewLine);
                textBoxCardID.Text = "";
                return;
            }

            textBoxCardID.Text = Convert.ToString(input_data[10], 16).Length == 1 ? "0" + Convert.ToString(input_data[10], 16) : Convert.ToString(input_data[10], 16);
            textBoxCardID.Text += " " + (Convert.ToString(input_data[9], 16).Length == 1 ? "0" + Convert.ToString(input_data[9], 16) : Convert.ToString(input_data[9], 16));
            textBoxCardID.Text += " " + (Convert.ToString(input_data[8], 16).Length == 1 ? "0" + Convert.ToString(input_data[8], 16) : Convert.ToString(input_data[8], 16));
            textBoxCardID.Text += " " + (Convert.ToString(input_data[7], 16).Length == 1 ? "0" + Convert.ToString(input_data[7], 16) : Convert.ToString(input_data[7], 16));
            textBoxCardID.Text += " " + (Convert.ToString(input_data[6], 16).Length == 1 ? "0" + Convert.ToString(input_data[6], 16) : Convert.ToString(input_data[6], 16));
            textBoxCardID.Text += " " + (Convert.ToString(input_data[5], 16).Length == 1 ? "0" + Convert.ToString(input_data[5], 16) : Convert.ToString(input_data[5], 16));
            textBoxCardID.Text += " " + (Convert.ToString(input_data[4], 16).Length == 1 ? "0" + Convert.ToString(input_data[4], 16) : Convert.ToString(input_data[4], 16));
            textBoxCardID.Text += " " + (Convert.ToString(input_data[3], 16).Length == 1 ? "0" + Convert.ToString(input_data[3], 16) : Convert.ToString(input_data[3], 16));
        }

        private void buttonЧтениеВхода_Click(object sender, EventArgs e)
        {
            id = Device_polling();
            if (id == -1)
                return;

            byte[] output_data = new byte[6] { (byte)id, 0x03, 0x00, 0x06, 0x00, 0x01 };

            byte[] input_data = mk_data_exchange(output_data, 7);

            if (input_data[input_data.Length - 1] == 0xff)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Считать данные не удалось." + Environment.NewLine);
                textBoxExtraInputStateInput.Text = "";
                return;
            }
            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Данные получены." + Environment.NewLine);
            textBoxExtraInputStateInput.Text = Convert.ToString(input_data[4], 16);
        }

        private void buttonВерсияПрошивки_Click(object sender, EventArgs e)
        {
            id = Device_polling();

            if (id == -1)
                return;

            byte[] output_data = new byte[6] { (byte)id, 0x03, 0x00, 0x04, 0x00, 0x02 };

            byte[] input_data = mk_data_exchange(output_data, 9);

            if (input_data[input_data.Length - 1] == 0xff)
            {
                textBoxFirmwareVersion.Text = "";
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Считать данные не удалось." + Environment.NewLine);
                return;
            }

            textBoxFirmwareVersion.Text = Convert.ToString(input_data[3], 16).Length == 1 ? "0" + Convert.ToString(input_data[3], 16) : Convert.ToString(input_data[3], 16);
            textBoxFirmwareVersion.Text += " " + (Convert.ToString(input_data[4], 16).Length == 1 ? "0" + Convert.ToString(input_data[4], 16) : Convert.ToString(input_data[4], 16));
            textBoxFirmwareVersion.Text += " " + (Convert.ToString(input_data[5], 16).Length == 1 ? "0" + Convert.ToString(input_data[5], 16) : Convert.ToString(input_data[5], 16));
            textBoxFirmwareVersion.Text += " " + (Convert.ToString(input_data[6], 16).Length == 1 ? "0" + Convert.ToString(input_data[6], 16) : Convert.ToString(input_data[6], 16));
        }

        private void buttonСерийныйНомер_Click(object sender, EventArgs e)
        {
            id = Device_polling();
            //MessageBox.Show("id получен");
            if (id == -1)
                return;

            byte[] output_data = new byte[6] { (byte)id, 0x03, 0x00, 0x00, 0x00, 0x04 };

            byte[] input_data = mk_data_exchange(output_data, 13);

            if (input_data[input_data.Length - 1] == 0xff)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Считать данные не удалось." + Environment.NewLine);
                textBoxSerialNumber.Text = "";
                return;
            }

            /*
            string str = "";
            for (int i = 0; i < input_data.Length; i++)
                str += input_data[i].ToString() + " ";
            MessageBox.Show("Получены данные " + str);
            */

            textBoxSerialNumber.Text = Convert.ToString(input_data[3], 16).Length == 1 ? "0" + Convert.ToString(input_data[3], 16) : Convert.ToString(input_data[3], 16);
            textBoxSerialNumber.Text += " " + (Convert.ToString(input_data[4], 16).Length == 1 ? "0" + Convert.ToString(input_data[4], 16) : Convert.ToString(input_data[4], 16));
            textBoxSerialNumber.Text += " " + (Convert.ToString(input_data[5], 16).Length == 1 ? "0" + Convert.ToString(input_data[5], 16) : Convert.ToString(input_data[5], 16));
            textBoxSerialNumber.Text += " " + (Convert.ToString(input_data[6], 16).Length == 1 ? "0" + Convert.ToString(input_data[6], 16) : Convert.ToString(input_data[6], 16));
            textBoxSerialNumber.Text += " " + (Convert.ToString(input_data[7], 16).Length == 1 ? "0" + Convert.ToString(input_data[7], 16) : Convert.ToString(input_data[7], 16));
            textBoxSerialNumber.Text += " " + (Convert.ToString(input_data[8], 16).Length == 1 ? "0" + Convert.ToString(input_data[8], 16) : Convert.ToString(input_data[8], 16));
            textBoxSerialNumber.Text += " " + (Convert.ToString(input_data[9], 16).Length == 1 ? "0" + Convert.ToString(input_data[9], 16) : Convert.ToString(input_data[9], 16));
            textBoxSerialNumber.Text += " " + (Convert.ToString(input_data[10], 16).Length == 1 ? "0" + Convert.ToString(input_data[10], 16) : Convert.ToString(input_data[10], 16));
        }

        private void textBoxПорогX_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (textBoxId.Text.Length == 4 && number != 8)
            {
                e.Handled = true;
                return;
            }
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 64 || e.KeyChar >= 71) && (e.KeyChar <= 96 || e.KeyChar >= 103))
            {
                e.Handled = true;
            }
        }

        private void textBoxПорогY_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (textBoxId.Text.Length == 4 && number != 8)
            {
                e.Handled = true;
                return;
            }
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 64 || e.KeyChar >= 71) && (e.KeyChar <= 96 || e.KeyChar >= 103))
            {
                e.Handled = true;
            }
        }

        private void textBoxПорогZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (textBoxId.Text.Length == 4 && number != 8)
            {
                e.Handled = true;
                return;
            }
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 64 || e.KeyChar >= 71) && (e.KeyChar <= 96 || e.KeyChar >= 103))
            {
                e.Handled = true;
            }
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (textBoxId.Text.Length == 4 && number != 8)
            {
                e.Handled = true;
                return;
            }
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 64 || e.KeyChar >= 71) && (e.KeyChar <= 96 || e.KeyChar >= 103))
            {
                e.Handled = true;
            }
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            buttonStatus.Enabled = false;
            textBoxId.Enabled = false;
            comboBoxDeviceBaudRate.Enabled = false;
            comboBoxDeviceStopBits.Enabled = false;
            comboBoxDeviceParity.Enabled = false;
            comboBoxДиапазон.Enabled = false;
            comboBoxЧастота.Enabled = false;
            textBoxПорогX.Enabled = false;
            textBoxПорогY.Enabled = false;
            textBoxПорогZ.Enabled = false;
            comboBoxSignalInversion.Enabled = false;
            buttonSave.Enabled = false;

            if (!serialPort1.IsOpen)
            {
                labelStatus.Text = "Порт закрыт";
                labelStatus.ForeColor = Color.Red;
                buttonStatus.Enabled = true;
                return;
            }
            string text = "Порт открыт, ";
            if (id == -1)
            {
                text += "устройство не найдено.";
                labelStatus.Text = text;
                labelStatus.ForeColor = Color.Red;
                buttonStatus.Enabled = true;
                return;
            }
            text += "устройство подключено.";
            labelStatus.Text = text;
            labelStatus.ForeColor = Color.Green;
            /*
            int result = Device_polling();
            if (result == -1)
            {
                text += "устройство не отвечает.";
                labelStatus.Text = text;
                labelStatus.ForeColor = Color.Red;
                buttonStatus.Enabled = true;
                return;
            }
            text += "устройство подключено.";
            labelStatus.Text = text;
            labelStatus.ForeColor = Color.Green;
            */
            serialPort1.DiscardInBuffer();
            Thread.Sleep(50);

            byte[] output_data = new byte[6];
            output_data[0] = (byte)id;
            output_data[1] = 0x21;
            output_data[2] = 0x00;
            output_data[3] = 0x00;
            output_data[4] = 0x00;
            output_data[5] = 0x0e;

            byte[] input_data = mk_data_exchange(output_data, 19);

            /*for (int i = 0; i < input_data.Length; i++)
            {
                string s = Convert.ToString(input_data[i], 16);
                if (s.Length < 2) s = "0" + s;
                textBoxЛог.AppendText(i+"-"+ s + Environment.NewLine);
            }*/

            try
            {
                id = input_data[3];
                textBoxId.Text = (Convert.ToString(input_data[3], 16).Length == 1 ? ("0" + Convert.ToString(input_data[3], 16)) : Convert.ToString(input_data[3], 16));
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка ID: " + ex.Message + Environment.NewLine);
                buttonStatus.Enabled = true;
                return;
            }

            try
            {
                comboBoxDeviceBaudRate.SelectedIndex = input_data[4];
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка BaudRate: " + ex.Message + Environment.NewLine);
                buttonStatus.Enabled = true;
                return;
            }

            try
            {
                comboBoxDeviceStopBits.SelectedIndex = input_data[5];
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка StopBits: " + ex.Message + Environment.NewLine);
                buttonStatus.Enabled = true;
                return;
            }

            try
            {
                comboBoxDeviceParity.SelectedIndex = input_data[6];
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Parity: " + ex.Message + Environment.NewLine);
                buttonStatus.Enabled = true;
                return;
            }

            try
            {
                comboBoxДиапазон.SelectedIndex = input_data[7];
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Диапазон: " + ex.Message + Environment.NewLine);
                buttonStatus.Enabled = true;
                return;
            }

            try
            {
                comboBoxЧастота.SelectedIndex = input_data[8];
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Частота: " + ex.Message + Environment.NewLine);
                buttonStatus.Enabled = true;
                return;
            }

            try
            {
                UInt16 s = (UInt16)((input_data[10] << 8) | input_data[9]);

                textBoxПорогX.Text= s.ToString();
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Порог Х: " + ex.Message + Environment.NewLine);
                buttonStatus.Enabled = true;
                return;
            }

            try
            {
                UInt16 s = (UInt16)((input_data[12] << 8) | input_data[11]);

                textBoxПорогY.Text = s.ToString();
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Порог Y: " + ex.Message + Environment.NewLine);
                buttonStatus.Enabled = true;
                return;
            }

            try
            {
                UInt16 s = (UInt16)((input_data[14] << 8) | input_data[13]);
                textBoxПорогZ.Text = s.ToString();
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Порог Z: " + ex.Message + Environment.NewLine);
                buttonStatus.Enabled = true;
                return;
            }

            try
            {
                comboBoxSignalInversion.SelectedIndex = input_data[16];
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Инверсия сигнала выхода: " + ex.Message + Environment.NewLine);
                buttonStatus.Enabled = true;
                return;
            }

            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Данные о настройках получены." + Environment.NewLine);

            buttonStatus.Enabled = true;
            textBoxId.Enabled = true;
            comboBoxDeviceBaudRate.Enabled = true;
            comboBoxDeviceStopBits.Enabled = true;
            comboBoxDeviceParity.Enabled = true;
            comboBoxДиапазон.Enabled = true;
            comboBoxЧастота.Enabled = true;
            textBoxПорогX.Enabled = true;
            textBoxПорогY.Enabled = true;
            textBoxПорогZ.Enabled = true;
            comboBoxSignalInversion.Enabled = true;
            buttonSave.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[14];

            try
            {
                data[0] = Convert.ToByte(Convert.ToInt16(textBoxId.Text, 16));
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка ID: " + ex.Message + Environment.NewLine);
                return;
            }

            try
            {
                data[1] = (byte)comboBoxDeviceBaudRate.SelectedIndex;
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка BaudRate: " + ex.Message + Environment.NewLine);
                return;
            }

            try
            {
                data[2] = (byte)(comboBoxDeviceStopBits.SelectedIndex);
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка StopBits: " + ex.Message + Environment.NewLine);
                return;
            }

            try
            {
                data[3] = (byte)comboBoxDeviceParity.SelectedIndex;
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Parity: " + ex.Message + Environment.NewLine);
                return;
            }

            try
            {
                data[4] = (byte)comboBoxДиапазон.SelectedIndex;
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Диапазон: " + ex.Message + Environment.NewLine);
                return;
            }

            try
            {
                data[5] = (byte)comboBoxЧастота.SelectedIndex;
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Частота: " + ex.Message + Environment.NewLine);
                return;
            }

            try
            {
                UInt16 t = Convert.ToUInt16(textBoxПорогX.Text);
                byte c0 = (byte)t, c1 = (byte)(t >> 8);

                data[7] = c1;
                data[6] = c0;
            }
            catch(Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Порог Х: " + ex.Message + Environment.NewLine);
                return;
            }

            try
            {
                UInt16 t = Convert.ToUInt16(textBoxПорогY.Text);
                byte c0 = (byte)t, c1 = (byte)(t >> 8);

                data[9] = c1;
                data[8] = c0;
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Порог Y: " + ex.Message + Environment.NewLine);
                return;
            }

            try
            {
                UInt16 t = Convert.ToUInt16(textBoxПорогZ.Text);
                byte c0 = (byte)t, c1 = (byte)(t >> 8);

                data[11] = c1;
                data[10] = c0;
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Порог Z: " + ex.Message + Environment.NewLine);
                return;
            }

            try
            {
                data[1] = (byte)comboBoxDeviceBaudRate.SelectedIndex;
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка BaudRate: " + ex.Message + Environment.NewLine);
                return;
            }

            ///////////////////////////////////////////////////////////////
            data[12] = 0;
            //////////////////////////////////////////////////////////////

            try
            {
                data[13] = (byte)comboBoxSignalInversion.SelectedIndex;
            }
            catch (Exception ex)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка Инверсия сигнала: " + ex.Message + Environment.NewLine);
                return;
            }

            if (!Write_register("0000", data))
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка записи данных!" + Environment.NewLine);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Изменения вступят в силу после перезагрузки устройства.\r\nВыполнить перезагрузку? ", "Изменения сохранены", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                byte[] output_data = new byte[6] { 0x00, 0x23, 0x00, 0x00, 0x00, 0x00 };

                UInt16 CRC = CRC16(output_data, output_data.Length);
                byte c0 = (byte)CRC, c1 = (byte)(CRC >> 8);
                byte[] last = new byte[] { c0, c1 };

                try
                {
                    serialPort1.Write(output_data, 0, output_data.Length);
                    serialPort1.Write(last, 0, last.Length);

                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            SerialPort temp_sp = new SerialPort();
            try
            {
                temp_sp.BaudRate = Convert.ToInt32(comboBoxDeviceBaudRate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("BoudRate не установлен - " + ex.Message);
                return;
            }

            try
            {
                switch (comboBoxDeviceParity.SelectedIndex)
                {
                    case 0:
                        {
                            temp_sp.Parity = Parity.None;
                            break;
                        }
                    case 1:
                        {
                            temp_sp.Parity = Parity.Even;
                            break;
                        }
                    case 2:
                        {
                            temp_sp.Parity = Parity.Odd;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parity не установлен - " + ex.Message);
                return;
            }

            try
            {
                switch (comboBoxDeviceStopBits.SelectedIndex)
                {
                    case 0:
                        {
                            temp_sp.StopBits = StopBits.One;
                            break;
                        }
                    case 1:
                        {
                            temp_sp.StopBits = StopBits.Two;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("StopBits не установлен - " + ex.Message);
                return;
            }

            serialPort1.BaudRate = temp_sp.BaudRate;
            comboBoxBaudRate.SelectedIndex = comboBoxDeviceBaudRate.SelectedIndex;

            serialPort1.DataBits = temp_sp.DataBits;

            serialPort1.Parity = temp_sp.Parity;
            comboBoxParity.SelectedIndex=comboBoxDeviceParity.SelectedIndex;

            serialPort1.StopBits = temp_sp.StopBits;
            comboBoxStopBits.SelectedIndex = comboBoxDeviceStopBits.SelectedIndex;
            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Данные сохранены, ожидание перезагрузки устройства." + Environment.NewLine);
            Thread.Sleep(2000);
            buttonStatus.PerformClick();
        }

        public bool Write_register(string reg_addr, byte[] contents)
        {
            bool ansver = false;
            if (reg_addr.Length != 4)
            {
                MessageBox.Show("Некорректный адрес регистра!");
                return ansver;
            }
            byte[] output_data = new byte[7 + contents.Length];

            try
            {
                Byte[] adress_byte = Enumerable.Range(0, reg_addr.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(reg_addr.Substring(x, 2), 16))
                             .ToArray();

                output_data[0] = (byte)id;
                output_data[1] = 0x22;
                output_data[2] = adress_byte[0];
                output_data[3] = adress_byte[1];
                output_data[4] = (byte)(contents.Length >> 8);
                output_data[5] = (byte)(contents.Length);
                output_data[6] = (byte)(contents.Length);
            }
            catch
            {
                MessageBox.Show("Некорректный адрес регистра!");
                return ansver;
            }

            for (int i = 0; i < contents.Length; i++)
            {
                output_data[i + 7] = (byte)(contents[i]);
            }
            /*
            string str = "";
            for (int i = 0; i < output_data.Length; i++)
                str += (Convert.ToString(output_data[i], 16).Length==1?"0"+ Convert.ToString(output_data[i], 16): Convert.ToString(output_data[i], 16)) + " ";
            MessageBox.Show("1 Отправляю на запись без CRC "+str);
            */

            int input_data_length = 8;
            byte[] input_data = mk_data_exchange(output_data, input_data_length);
            /*
            str = "";
            for (int i = 0; i < input_data.Length; i++)
                str += Convert.ToString(input_data[i], 16);
            MessageBox.Show("Получен ответ " + str);
            */

            if (input_data[input_data.Length - 1] == 0xff)
            {
                return ansver;
            }

            if (input_data[0] != (byte)Convert.ToInt32(textBoxId.Text, 16))
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Id устройства в ответе {input_data[0]} не соответствует ожидаемому {id}" + Environment.NewLine);
                return ansver;
            }

            if (input_data[1] != 0x22)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Код функции в ответе {Convert.ToString(input_data[1], 16)} не соответствует ожидаемому 22" + Environment.NewLine);
                return ansver;
            }

            if (((Convert.ToString(input_data[2], 16).Length == 1 ? ("0" + Convert.ToString(input_data[2], 16)) : Convert.ToString(input_data[2], 16)) +
                (Convert.ToString(input_data[3], 16).Length == 1 ? ("0" + Convert.ToString(input_data[3], 16)) : Convert.ToString(input_data[3], 16))).ToLower() != reg_addr.ToLower())
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Адрес регистра начала записи {(Convert.ToString(input_data[2], 16) + Convert.ToString(input_data[3], 16)).ToLower()} " +
                    $"не соответствует отправленному {reg_addr.ToLower()}" + Environment.NewLine);
                return ansver;
            }

            if (output_data[4] != input_data[4] || output_data[5] != input_data[5])
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Количество регистров в ответе {(Convert.ToString(input_data[4], 16) + Convert.ToString(input_data[5], 16)).ToLower()} " +
                    $"не соответствует ожидаемому {(Convert.ToString(output_data[4], 16) + Convert.ToString(output_data[5], 16)).ToLower()}" + Environment.NewLine);
                return ansver;
            }

            ansver = true;
            return ansver;
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            textBoxЛог.Clear();
        }

        private void buttonStartKaliber_Click(object sender, EventArgs e)
        {
            
            if (калибровка_запущена)
            {
                Остановка_режима_калибровки();
            }
            else
            {
                if(Device_polling()!=-1)
                    Запуск_режима_калибровки();
                else
                    Остановка_режима_калибровки();
            }
        }

        void Запуск_режима_калибровки()
        {
            trackBarКоличествоТочекВГрафике.Enabled = false;
            Массив_данных_X = new Int16[длина_графика];
            for (int i = 0; i < Массив_данных_X.Length; i++)
                Массив_данных_X[i] = 0;

            Массив_данных_Y = new Int16[длина_графика];
            for (int i = 0; i < Массив_данных_Y.Length; i++)
                Массив_данных_Y[i] = 0;

            Массив_данныx_Z = new Int16[длина_графика];
            for (int i = 0; i < Массив_данныx_Z.Length; i++)
                Массив_данныx_Z[i] = 0;

            if (!serialPort1.IsOpen)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Порт закрыт." + Environment.NewLine);
                return;
            }

            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Калибровка запущена." + Environment.NewLine);
            калибровка_запущена = true;
            buttonStartKaliber.Text = "Стоп";
        }

        void Остановка_режима_калибровки()
        {
             textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Калибровка остановлена." + Environment.NewLine);
            trackBarКоличествоТочекВГрафике.Enabled = true;
            калибровка_запущена = false;
            buttonStartKaliber.Text = "Старт";
        }

        Int16[] Получение_XYZ_из_МК()
        {
            byte[] output_data = new byte[6] { (byte)id, 0x03, 0x00, 0x08, 0x00, 0x03 };
            byte[] input_data = mk_data_exchange(output_data, 11);
            if (input_data[0] != (byte)id)
            {
                return new Int16[3] { -32768, -32768, -32768 };
            }
            Int16 X = (Int16)((input_data[3] << 8) | input_data[4]);
            Int16 Y = (Int16)((input_data[5] << 8) | input_data[6]);
            Int16 Z = (Int16)((input_data[7] << 8) | input_data[8]);
            return new Int16[3] { X, Y, Z };
        }
        
        Int16 Получение_значения_Int16_из_порта()
        {
            Int16 s= -32768;
            try
            {
                byte ch, cl;
                cl = (byte)serialPort1.ReadByte();
                ch = (byte)serialPort1.ReadByte();
                s = (Int16)((ch << 8) | cl);
            }
            catch (Exception e)
            {
                BeginInvoke(new MethodInvoker(delegate {
                    textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка получения данных: {e.Message} \r\n\tКалибровка остановлена." + Environment.NewLine);
                }));
                калибровка_запущена = false;
            }
            return s;
        }

        void Обработка_графиков()
        {
            int счетчик = 0;
            while (true)
            {
                while (счетчик*10 < Период_опроса_устройства_XYZ)
                {
                    Thread.Sleep(1);
                    счетчик++;
                }
                счетчик = 0;

                if (!калибровка_запущена)
                    continue;

                Int16[] data = Получение_XYZ_из_МК();
                if (data[0] == -32768 && data[1] == -32768 && data[2] == -32768)
                {
                    BeginInvoke(new MethodInvoker(delegate {
                        textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Ошибка получения данных." + Environment.NewLine);
                        Остановка_режима_калибровки();
                    }));
                    continue;
                }

                for (int i = Массив_данных_X.Length-1; i >0; i--)
                {
                    Массив_данных_X[i] = Массив_данных_X[i - 1];
                }
                Массив_данных_X[0] = data[0];

                for (int i = Массив_данных_Y.Length - 1; i > 0; i--)
                {
                    Массив_данных_Y[i] = Массив_данных_Y[i - 1];
                }
                Массив_данных_Y[0] = data[1];

                for (int i = Массив_данныx_Z.Length - 1; i > 0; i--)
                {
                    Массив_данныx_Z[i] = Массив_данныx_Z[i - 1];
                }
                Массив_данныx_Z[0] = data[2];

                BeginInvoke(new MethodInvoker(delegate {
                    ChartX.Series.Clear();
                    ChartX.ChartAreas.Clear();
                    ChartX.ChartAreas.Add(new ChartArea("Chart Area X"));

                    Series SeriesOfPointX = new Series("График X");
                    SeriesOfPointX.ChartType = SeriesChartType.Spline;
                    SeriesOfPointX.BorderColor = Color.Red;
                    SeriesOfPointX.Color = Color.Red;
                    SeriesOfPointX.BorderWidth = 3;
                    SeriesOfPointX.ChartArea = "Chart Area X";

                    for (int i = 0; i < Массив_данных_X.Length; i++)
                    {
                        SeriesOfPointX.Points.AddY(Массив_данных_X[i]);
                    }

                    ChartX.Series.Add(SeriesOfPointX);

                    ChartY.Series.Clear();
                    ChartY.ChartAreas.Clear();
                    ChartY.ChartAreas.Add(new ChartArea("Chart Area Y"));

                    Series SeriesOfPointY = new Series("График Y");
                    SeriesOfPointY.ChartType = SeriesChartType.Spline;
                    SeriesOfPointY.BorderColor = Color.Green;
                    SeriesOfPointY.Color = Color.Green;
                    SeriesOfPointY.BorderWidth = 3;
                    SeriesOfPointY.ChartArea = "Chart Area Y";

                    for (int i = 0; i < Массив_данных_Y.Length; i++)
                    {
                        SeriesOfPointY.Points.AddY(Массив_данных_Y[i]);
                    }

                    ChartY.Series.Add(SeriesOfPointY);

                    ChartZ.Series.Clear();
                    ChartZ.ChartAreas.Clear();
                    ChartZ.ChartAreas.Add(new ChartArea("Chart Area Z"));

                    Series SeriesOfPointZ = new Series("График Z");
                    SeriesOfPointZ.ChartType = SeriesChartType.Spline;
                    SeriesOfPointZ.BorderColor = Color.Blue;
                    SeriesOfPointZ.Color = Color.Blue;
                    SeriesOfPointZ.BorderWidth = 3;
                    SeriesOfPointZ.ChartArea = "Chart Area Z";

                    for (int i = 0; i < Массив_данных_Y.Length; i++)
                    {
                        SeriesOfPointZ.Points.AddY(Массив_данныx_Z[i]);
                    }

                    ChartZ.Series.Add(SeriesOfPointZ);
                }));
            }
        }

        private void textBoxПериодОпроса_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (textBoxПериодОпроса.Text.Length == 8 && number != 8)
            {
                e.Handled = true;
                return;
            }
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxПериодОпроса_TextChanged(object sender, EventArgs e)
        {
            if (textBoxПериодОпроса.Text.Length != 0)
                Период_опроса_устройства_XYZ = Convert.ToInt32(textBoxПериодОпроса.Text);
            else
                Период_опроса_устройства_XYZ = 1;
        }

        private void buttonСостояниеВыхода_Click(object sender, EventArgs e)
        {
            id = Device_polling();
            if (id == -1)
                return;

            byte[] output_data = new byte[6] { (byte)id, 0x03, 0x00, 0x06, 0x00, 0x01 };

            byte[] input_data = mk_data_exchange(output_data, 7);

            if (input_data[input_data.Length - 1] == 0xff)
            {
                textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Считать данные не удалось." + Environment.NewLine);
                textBoxExtraInputStateOutput.Text = "";
                return;
            }
            textBoxЛог.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} Данные получены." + Environment.NewLine);
            textBoxExtraInputStateOutput.Text = Convert.ToString(input_data[4], 16);
        }

        private void tabPage5_Resize(object sender, EventArgs e)
        {
            groupBoxX.Height = (tabPage5.Height - 120) / 3;
            groupBoxX.Width = tabPage5.Width - 6;

            groupBoxY.Location = new Point(groupBoxY.Location.X, groupBoxX.Location.Y + groupBoxX.Height + 4);
            groupBoxY.Height= (tabPage5.Height - 120) / 3;
            groupBoxY.Width = tabPage5.Width - 6;

            groupBoxZ.Location = new Point(groupBoxZ.Location.X, groupBoxY.Location.Y + groupBoxY.Height + 4);
            groupBoxZ.Height = (tabPage5.Height - 120) / 3;
            groupBoxZ.Width = tabPage5.Width - 6;
        }

        private void trackBarКоличествоТочекВГрафике_Scroll(object sender, EventArgs e)
        {
            textBoxКоличествоТочекВГрафике.Text = trackBarКоличествоТочекВГрафике.Value.ToString();
            длина_графика = trackBarКоличествоТочекВГрафике.Value;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (калибровка_запущена) e.Cancel = true;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия программы 2.0.0.2");
        }
    }
}
