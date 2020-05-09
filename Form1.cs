using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.IO;
using System.Threading;

namespace scm
{
    public partial class Form1 : Form
    {
        string path = @"rcv.ini";//файл инициализации
        private string portName = "";
        static _serialPort comport = new _serialPort();
        
        public Form1()
        {
            InitializeComponent();

            //CallBack.callbackEventHandler = new CallBack.callbackEvent(this.dataToTable);
            //CallBack.callbackEventHandler = new CallBack.callbackEvent(this.getData);
            comport.DataReceived += SerialPort_DataReceived;
            initFile();
            //
        }

        //**********************************************************************
        //кнопка подключения-отключения к COMPORT
        //**********************************************************************
        private bool openClkFlg = false;
        //открываем COM порт
        private void open_Click(object sender, EventArgs e)
        {
            openCloseComPort();
        }
        private void openCloseComPort()
        {
            if (openClkFlg == false)
            {
                portName = comPortList.Text;
                // comport.NamePort(portName);
                if (comport.NamePort(portName) == true)//если имя порта сущесвует
                {
                    openClkFlg = comport.OpenPort();//если порт открыли
                    if (openClkFlg)
                    {
                        comPortList.Enabled = false;//деактивируем выподающее меню
                        this.openBtt.Image = global::scm.Properties.Resources.cBtt;//меняем картинку на кнопке
                        this.label1.Text = "Порт открыт";
                    }
                }
            }
            else
            {
                closeComPort();
            }
        }
        private void closeComPort()
        {
                comport.Clos();
                comPortList.Enabled = true;//активируем выподающее меню
                this.openBtt.Image = global::scm.Properties.Resources.oBtt;//меняем картинку на кнопке
                this.label1.Text = "Нет соединения";
                openClkFlg = false;
        }
        
        //**********************************************************************
        //кнопка отключения от COMPORT (скрыта)
        //**********************************************************************
        private void close_Click(object sender, EventArgs e)
        {
            comport.Clos();
            comPortList.Enabled = true;
            openClkFlg = false;
        }
        //**********************************************************************
        //выбор COM PORT
        //**********************************************************************
        private void comPortList_DropDown(object sender, EventArgs e)
        {
            //составляем список доступных портов
            string[] ports = SerialPort.GetPortNames();
            comPortList.Items.Clear();
            //заполняем список доступных портов
            foreach (string port in ports)
            {
                comPortList.Items.Add(port);
            }
        }

        //**********************************************************************
        // загрузка начальных параметров из ini фаила
        //**********************************************************************
        private void initFile()
        {
            try
            {
                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        comPortList.Text = s;
                    }
                }
            }
            catch (Exception ex)
            {
                outTextBox.Text = "Не найден фаил rcv.ini\r\n";
            }
        }

        //*********************************************************************
        //прием данных comport
        //*********************************************************************
        private const int DataSize = 64;
        volatile private byte[] rxBuffer = new byte[DataSize];
        private int index;
        private int prefixRead;
        private bool dataReadFlg;
        private int rxBufferSize;
        private bool rxDataNotEmpty;
        //  
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            var port = (SerialPort)sender;
            try
            {
                // узнаем сколько байт пришло
                int buferSize = port.BytesToRead;
                for (int i = 0; i < buferSize; ++i)
                {
                    if (countRxTime != 10)  //если буфер не в обработке
                    {
                        rxBuffer[index] = (byte)port.ReadByte(); //  читаем по одному байту
                        index++;
                    }
                }
                countRxTime = 0;//timeout init
            }
            catch{ }
        }

        private byte[] rxData = new byte[64];
        private int indexStart;
        private int rxDataSize;
        private int countRxTime;
        //***************************************************************************
        // таймер 1ms
        //***************************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(countRxTime == 10)//обработка буфера по таймауту
            {
                int i = 0;
                indexStart = 0;
                prefixRead = 0;
                dataReadFlg = false;
                rxDataNotEmpty = false;
                for (i = 0; i < (index+1); i++)
                {
                    if (dataReadFlg == true)  //дописываем в буфер все остальное
                    {
                        indexStart++;
                        rxData[indexStart] = rxBuffer[i];

                        if(rxData[2] == (indexStart-2))
                        {
                            byte crc = 0;
                            //проверяем crc
                            for (int j = 0; j < indexStart; j++)
                            {
                                crc = crcCalc(crc, rxData[j]);
                            }
                            if (crc == rxData[indexStart])
                            {
                                rxBufferSize = indexStart+1;
                                rxDataNotEmpty = true;
                                i = index;
                            }
                        }
                    }

                    if (prefixRead == 1)
                    {
                        if (rxBuffer[i] == 0x49) // если встретили адрес устройсва
                        {
                            indexStart = 1;
                            rxData[indexStart] = rxBuffer[i];
                            dataReadFlg = true;
                        }
                        prefixRead = 2;
                    }

                    if ((prefixRead == 2) && (dataReadFlg == false))
                    {
                        prefixRead = 0;
                    }

                    //  если встретили начало кадра
                    if ((prefixRead == 0) && (rxBuffer[i] == 0xCC))
                    {
                        indexStart = 0;
                        rxData[indexStart] = rxBuffer[i];
                        prefixRead = 1;
                    }
                }
                index = 0;
            }
            //
            if(countRxTime<11)countRxTime++;
            //
            if (rxDataNotEmpty == true)
            {
                rxDataSize = rxBufferSize;

                if(rxData[3] == 0x06)//пришли все параметры
                {
                    parameterDataToDisplay();
                }
                else if(rxData[3] == 0x07)
                {
                    cutParameterDataToDisplay();
                }
                else if (rxData[3] == 0x4B)//пришли настройки
                {
                    settingsDataToDisplay();
                }

                for (int i=0; i < rxDataSize; i++)
                {
                    this.serialText(rxData[i].ToString("X2"));
                    serialText(" ");
                }
                serialText("\r\n");
                serialText("Scroll");
                this.serialText("ok" + "\r\n");
                rxDataNotEmpty = false;
            }
            //
        }//timer
        //
        /*******************************************************************/
        // вывод всех параметров 06h
        /*******************************************************************/
        private void parameterDataToDisplay()
        {
            int rpm = (rxData[4] << 8) | rxData[5];
            int fuel = rxData[6];
            int mile = (rxData[7] << 16) | (rxData[8] << 8) | rxData[9];
            int speed = rxData[10];
            int light = rxData[11];
            int door = rxData[12];
            int breaks = rxData[13];
            int locks = rxData[14];
            int tEngine = (sbyte)rxData[15];
            float voltage = (float)(rxData[16])/10;
            int selector = rxData[17];
            int warning = rxData[18];
            int inputs = rxData[19];

            allParamTextBox.Clear();
            allParamTextBox.AppendText("Обороты:  " + rpm + " об/мин\r\n");
            allParamTextBox.AppendText("Топливо:  " + fuel + " л\r\n");
            allParamTextBox.AppendText("Пробег:   " + mile + " км\r\n");
            allParamTextBox.AppendText("Скорость: " + speed + " км/ч\r\n");
            //свет
            allParamTextBox.AppendText("Свет:     ");
            if(light == 0) allParamTextBox.AppendText("выкл.\r\n");
            else
            {
                allParamTextBox.AppendText("" + ((light & 0x01) == 0x01 ? "\r\n  габариты" : ""));
                allParamTextBox.AppendText("" + ((light & 0x02) == 0x02 ? "\r\n  ближний" : ""));
                allParamTextBox.AppendText("" + ((light & 0x04) == 0x04 ? "\r\n  дальний" : ""));
                allParamTextBox.AppendText("" + ((light & 0x08) == 0x08 ? "\r\n  левый габарит" : ""));
                allParamTextBox.AppendText("" + ((light & 0x10) == 0x10 ? "\r\n  правый габарит" : ""));
                allParamTextBox.AppendText("\r\n");
            }
            //двери
            allParamTextBox.AppendText("Двери:    ");
            if (door == 0) allParamTextBox.AppendText("закрыто\r\n");
            else
            {
                allParamTextBox.AppendText("" + ((door & 0x01) == 0x01 ? "\r\n  левая-1" : ""));
                allParamTextBox.AppendText("" + ((door & 0x02) == 0x02 ? "\r\n  правая-1" : ""));
                allParamTextBox.AppendText("" + ((door & 0x04) == 0x04 ? "\r\n  левая-2" : ""));
                allParamTextBox.AppendText("" + ((door & 0x08) == 0x08 ? "\r\n  правая-2" : ""));
                allParamTextBox.AppendText("" + ((door & 0x10) == 0x10 ? "\r\n  багажник" : ""));
                allParamTextBox.AppendText("" + ((door & 0x20) == 0x20 ? "\r\n  капот" : ""));
                allParamTextBox.AppendText("\r\n");
            }
            //тормоза
            allParamTextBox.AppendText("" + ((breaks & 0x01) == 0x01 ? "\r\n Нажата педаль тормоза" : ""));
            allParamTextBox.AppendText("" + ((breaks & 0x02) == 0x02 ? "\r\n Ручник затянут" : "\r\n Ручник - не определено"));//на vw polo при выключенном зажигании бит всегда 0
            allParamTextBox.AppendText("\r\n");
            //замок зажигания
            allParamTextBox.AppendText("" + ((locks & 0x01) == 0x01 ? "\r\n Ключ в замке" : "Ключ извлечен"));
            allParamTextBox.AppendText("" + ((locks & 0x02) == 0x02 ? "\r\n Зажигаиние вкл." : ""));
            allParamTextBox.AppendText("" + ((locks & 0x04) == 0x04 ? "\r\n Аксессуары вкл." : ""));
            allParamTextBox.AppendText("" + ((locks & 0x08) == 0x08 ? "\r\n Старт вкл." : ""));
            allParamTextBox.AppendText("\r\n");
            //Температура
            allParamTextBox.AppendText("Температура двиг:  " + tEngine + " °C\r\n");
            //Напряжениe
            allParamTextBox.AppendText("Напряжениe:  " + voltage + " В\r\n");
            //передачи
            allParamTextBox.AppendText("Селектор передач: ");
            if (selector == 0) allParamTextBox.AppendText("неопределено\r\n");
            else
            {
                allParamTextBox.AppendText("" + ((selector & 0x01) == 0x01 ? "P" : ""));
                allParamTextBox.AppendText("" + ((selector & 0x02) == 0x02 ? "R" : ""));
                allParamTextBox.AppendText("" + ((selector & 0x04) == 0x04 ? "N" : ""));
                allParamTextBox.AppendText("" + ((selector & 0x08) == 0x08 ? "D" : ""));
                allParamTextBox.AppendText("" + ((selector & 0x10) == 0x10 ? "S" : ""));
                allParamTextBox.AppendText("\r\n");
            }
            //warning
            allParamTextBox.AppendText("" + ((warning & 0x01) == 0x01 ? "\r\n Низкий уровень топлива" : ""));
            allParamTextBox.AppendText("" + ((warning & 0x02) == 0x02 ? "\r\n Низкий уровень омывайки" : ""));
            allParamTextBox.AppendText("" + ((warning & 0x04) == 0x04 ? "\r\n Низкий уровень антифриза" : ""));
            allParamTextBox.AppendText("\r\n");
            //Логические входы
            allParamTextBox.AppendText("" + ((inputs & 0x01) == 0x01 ? "\r\n Сработка вход - 1" : ""));
            allParamTextBox.AppendText("" + ((inputs & 0x02) == 0x02 ? "\r\n Сработка вход - 2" : ""));
            allParamTextBox.AppendText("" + ((inputs & 0x04) == 0x04 ? "\r\n Сработка вход - 3" : ""));
            allParamTextBox.AppendText("" + ((inputs & 0x08) == 0x08 ? "\r\n Сработка вход - 4" : ""));
            allParamTextBox.AppendText("" + ((inputs & 0x10) == 0x10 ? "\r\n Сработка вход - 5" : ""));
            allParamTextBox.AppendText("" + ((inputs & 0x20) == 0x20 ? "\r\n Сработка вход - 6" : ""));
            allParamTextBox.AppendText("\r\n");
        }
        /*******************************************************************/
        // вывод сокращенно параметров 07h
        /*******************************************************************/
        private void cutParameterDataToDisplay()
        {
            int tEngine = (sbyte)rxData[4];
            float voltage = (float)(rxData[5]) / 10;

            allParamTextBox.Clear();
            //Температура
            allParamTextBox.AppendText("Температура двиг:\r\n  " + tEngine + " °C\r\n");
            //Напряжениe
            allParamTextBox.AppendText("Напряжениe:  " + voltage + " В\r\n");
        }
        /*******************************************************************/
        // вывод настроек 4Bh
        /*******************************************************************/
        private void settingsDataToDisplay()
        {
            numericUpDownByte0.Text = ((Int16)rxData[4]*10).ToString();         //время работы двигателя
            numericUpDownByte1.Text = ((sbyte)rxData[5]).ToString();            //температура прогрева двигателя
            numericUpDownByte2.Text = rxData[6].ToString();                     //Световые приборы
            numericUpDownByte3.Text = ((double)rxData[7]/10).ToString("F1");    //Время прокрутки стартера
            numericUpDownByte4.Text = ((Int16)rxData[8]*10).ToString();         //Порог оборотов двигателя для отсечки
            numericUpDownByte5.Text = (rxData[9]).ToString();                   //IWD Counter Event
        }

        //***************************************************************************
        // CRC lookup function
        //***************************************************************************
        static byte crcCalc(byte crc, byte b)
        {
            //******************** Полином расчета CRC. табличная реализация ********
            byte[] hash_table = new byte[256]
              {0, 94, 188, 226, 97, 63, 221, 131, 194, 156, 126, 32, 163, 253, 31, 65,
              157, 195, 33, 127, 252, 162, 64, 30, 95, 1, 227, 189, 62, 96, 130, 220,
              35, 125, 159, 193, 66, 28, 254, 160, 225, 191, 93, 3, 128, 222, 60, 98,
              190, 224, 2, 92, 223, 129, 99, 61, 124, 34, 192, 158, 29, 67, 161, 255,
              70, 24, 250, 164, 39, 121, 155, 197, 132, 218, 56, 102, 229, 187, 89, 7,
              219, 133, 103, 57, 186, 228, 6, 88, 25, 71, 165, 251, 120, 38, 196, 154,
              101, 59, 217, 135, 4, 90, 184, 230, 167, 249, 27, 69, 198, 152, 122, 36,
              248, 166, 68, 26, 153, 199, 37, 123, 58, 100, 134, 216, 91, 5, 231, 185,
              140, 210, 48, 110, 237, 179, 81, 15, 78, 16, 242, 172, 47, 113, 147, 205,
              17, 79, 173, 243, 112, 46, 204, 146, 211, 141, 111, 49, 178, 236, 14, 80,
              175, 241, 19, 77, 206, 144, 114, 44, 109, 51, 209, 143, 12, 82, 176, 238,
              50, 108, 142, 208, 83, 13, 239, 177, 240, 174, 76, 18, 145, 207, 45, 115,
              202, 148, 118, 40, 171, 245, 23, 73, 8, 86, 180, 234, 105, 55, 213, 139,
              87, 9, 235, 181, 54, 104, 138, 212, 149, 203, 41, 119, 244, 170, 72, 22,
              233, 183, 85, 11, 136, 214, 52, 106, 43, 117, 151, 201, 74, 20, 246, 168,
              116, 42, 200, 150, 21, 75, 169, 247, 182, 232, 10, 84, 215, 137, 107, 53};

            return hash_table[crc ^ b];
        }

        //*********** Вывод данных **************************************
        private void serialText(string txt)//all text
        {
            if (txt == "Scroll") outTextBox.ScrollToCaret();
            else outTextBox.AppendText(txt);
        }

        /*******************************************************************/
        //отправка преамбулы
        /*******************************************************************/
        private void preambleSend()
        {
            byte[] preamble = new byte[6];
            preamble[0] = 0xF0;
            preamble[1] = 0xF0;
            preamble[2] = 0xF0;
            preamble[3] = 0xF0;
            preamble[4] = 0xF0;
            preamble[5] = 0xF0;
            comport.Send(preamble, 6);
        }
        //
        private bool paramReadСheckBoxFlg = false;
        /*******************************************************************/
        //таймер 1с
        /*******************************************************************/
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(paramReadСheckBoxFlg) parametersRead();  //периодический запрос параметров
        }
        private void paramReadСheckBox_CheckedChanged(object sender, EventArgs e)
        {
            paramReadСheckBoxFlg = paramReadСheckBox.Checked;
        }
        private void paramReadButton_Click(object sender, EventArgs e)
        {
            parametersRead();
        }
        /*******************************************************************/
        //команда на чтение всех параметров 06h
        /*******************************************************************/
        private void parametersRead()
        {
            byte[] buf = new byte[5];

            buf[0] = 0xC3;
            buf[1] = 0x49;
            buf[2] = 0x02;
            buf[3] = 0x06;
            buf[4] = 0x0;

            for (int i = 0; i < 4; i++)
            {
                buf[4] = crcCalc(buf[4], buf[i]);
            }

            //выводим весь текст
            for (int i = 0; i < 5; i++)
            {
                serialText(buf[i].ToString("X2"));
                serialText(" ");
            }
            serialText("\r\n");
            serialText("Scroll");

            preambleSend();
            comport.Send(buf, 5);
        }
        /*******************************************************************/
        //чтение параметров кратко 07h
        /*******************************************************************/
        private void sectionReadButton_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[5];

            buf[0] = 0xC3;
            buf[1] = 0x49;
            buf[2] = 0x02;
            buf[3] = 0x07;//section
            buf[4] = 0x0;

            for (int i = 0; i < 4; i++)
            {
                buf[4] = crcCalc(buf[4], buf[i]);
            }

            //выводим весь текст
            for (int i = 0; i < 5; i++)
            {
                serialText(buf[i].ToString("X2"));
                serialText(" ");
            }
            serialText("\r\n");
            serialText("Scroll");

            preambleSend();
            comport.Send(buf, 5);
        }
        /*******************************************************************/
        //произвести замеры 08h
        /*******************************************************************/
        private void meterCmdButton_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[5];

            buf[0] = 0xC3;
            buf[1] = 0x49;
            buf[2] = 0x02;
            buf[3] = 0x08;//meter cmd
            buf[4] = 0x0;

            for (int i = 0; i < 4; i++)
            {
                buf[4] = crcCalc(buf[4], buf[i]);
            }

            //выводим весь текст
            for (int i = 0; i < 5; i++)
            {
                serialText(buf[i].ToString("X2"));
                serialText(" ");
            }
            serialText("\r\n");
            serialText("Scroll");

            preambleSend();
            comport.Send(buf, 5);
        }
        /*******************************************************************/
        //остановить прогрев двигателя 5Bh
        /*******************************************************************/
        private void stopCmdButton_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[5];

            buf[0] = 0xC3;
            buf[1] = 0x49;
            buf[2] = 0x02;
            buf[3] = 0x5B;//stop cmd
            buf[4] = 0x0;

            for (int i = 0; i < 4; i++)
            {
                buf[4] = crcCalc(buf[4], buf[i]);
            }

            //выводим весь текст
            for (int i = 0; i < 5; i++)
            {
                serialText(buf[i].ToString("X2"));
                serialText(" ");
            }
            serialText("\r\n");
            serialText("Scroll");
            //
            preambleSend();
            comport.Send(buf, 5);
        }
        /*******************************************************************/
        //запустить двигатель 5Ah
        /*******************************************************************/
        private void startCmdButton_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[5];

            buf[0] = 0xC3;
            buf[1] = 0x49;
            buf[2] = 0x02;
            buf[3] = 0x5A;//start cmd
            buf[4] = 0x0;

            for (int i = 0; i < 4; i++)
            {
                buf[4] = crcCalc(buf[4], buf[i]);
            }

            //выводим весь текст
            for (int i = 0; i < 5; i++)
            {
                serialText(buf[i].ToString("X2"));
                serialText(" ");
            }
            serialText("\r\n");
            serialText("Scroll");

            preambleSend();
            comport.Send(buf, 5);
        }
        /*******************************************************************/
        //читать настройки 4Bh
        /*******************************************************************/
        private void readSettingsButton_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[5];

            buf[0] = 0xC3;
            buf[1] = 0x49;
            buf[2] = 0x02;
            buf[3] = 0x4B;//readSettings
            buf[4] = 0x0;

            for (int i = 0; i < 4; i++)
            {
                buf[4] = crcCalc(buf[4], buf[i]);
            }

            //выводим весь текст
            for (int i = 0; i < 5; i++)
            {
                serialText(buf[i].ToString("X2"));
                serialText(" ");
            }
            serialText("\r\n");
            serialText("Scroll");

            preambleSend();
            comport.Send(buf, 5);

            numericUpDownByte0.Text = "0";
            numericUpDownByte1.Text = "0";
            numericUpDownByte2.Text = "0";
            numericUpDownByte3.Text = "0";
            numericUpDownByte4.Text = "0";
        }
        /*******************************************************************/
        //записать настройки 4Ah
        /*******************************************************************/
        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[10];

            buf[0] = 0xC3;
            buf[1] = 0x49;
            buf[2] = 7;
            buf[3] = 0x4A;//readSettings
            buf[4] = (byte)(System.Convert.ToInt16(numericUpDownByte0.Text)/10);     //время работы двигателя
            buf[5] = (byte)(System.Convert.ToSByte(numericUpDownByte1.Text));       //температура прогрева двигателя
            buf[6] = (byte)(System.Convert.ToByte(numericUpDownByte2.Text));        //Световые приборы
            buf[7] = (byte)(System.Convert.ToDouble(numericUpDownByte3.Text)*10);   //Время прокрутки стартера
            buf[8] = (byte)(System.Convert.ToInt16(numericUpDownByte4.Text)/10);    //Порог оборотов двигателя для отсечки

            for (int i = 0; i < 9; i++)
            {
                buf[9] = crcCalc(buf[9], buf[i]);
            }

            //выводим весь текст
            for (int i = 0; i < 10; i++)
            {
                serialText(buf[i].ToString("X2"));
                serialText(" ");
            }
            serialText("\r\n");
            serialText("Scroll");

            preambleSend();
            comport.Send(buf, 10);
        }
    }
}
