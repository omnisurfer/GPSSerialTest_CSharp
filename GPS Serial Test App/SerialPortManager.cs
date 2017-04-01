using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialPortRoot
{
    /* Following code example from here:
     * http://www.dreamincode.net/forums/topic/35775-serial-port-communication-in-c%23/
     * 
     */ 
    #region SerialPortManager Delegates
        //Delegate to broadcast that serial data is waiting in the buffer
        public delegate void SerialDataReadyEvent();
    #endregion

    class SerialPortManager
    {

        #region SerialPortManager Event Handlers
        /// <summary>
        /// Provides an event to subscribe to that is triggered when serial port data is ready to be read.
        /// </summary>
        public event SerialDataReadyEvent SerialDataReadyEvent;

        #endregion

        #region SerialPortManager Variables

        //COM Port Variables
        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;

        //String to hold that data
        private string _dataBuffer = string.Empty;

        //New instance of COM Port
        private SerialPort comPort = new SerialPort();

        #endregion

        #region SerialPortManager Properties

        public string BaudRate
        {
            get { return _baudRate; }
            set {_baudRate = value; }
        }

        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        #endregion

        #region SerialPortManager Constructors

        //Settable Constructor
        public SerialPortManager(string SetBaudRate, string SetParity, string SetStopBits, string SetDataBits, string SetPortName)
        {
            //Assign values from constructor
            _baudRate = SetBaudRate;
            _parity = SetParity;
            _stopBits = SetStopBits;
            _dataBits = SetDataBits;
            _portName = SetPortName;

            //create an event handler for DataRecieved
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }

        //Default Constructor
        public SerialPortManager()
        {
            _baudRate = string.Empty;
            _parity = string.Empty;
            _stopBits = string.Empty;
            _dataBits = string.Empty;
            _portName = string.Empty;

            //create an event handler for DataRecieved
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }

        #endregion

    #region SerialPortManager Methods

        #region Get Serial Port Names
        public void GetPortNames(object _object)
        {
            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)_object).Items.Add(str);
            }
        }
        #endregion

        #region Open and Close Serial Port
        public bool OpenSerialPort()
        {
            //check if port is already open
            try
            {
                //check if port is already open and if so close it
                if (comPort.IsOpen == true) comPort.Close();

                comPort.BaudRate = int.Parse(_baudRate);
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);
                comPort.DataBits = int.Parse(_dataBits);
                comPort.PortName = _portName;               

                comPort.Open();

                //clear the drivers buffer contents              
                comPort.DiscardInBuffer();
                comPort.DiscardOutBuffer();

#if DEBUG
                System.Diagnostics.Debug.Write("Opening Port " + comPort.PortName + " @ " + DateTime.Now + " running @ " + comPort.BaudRate + "\n");
#endif
                return true;
            }

            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.Write("Error " + ex.Message + "\n");
#endif

                //kind of a lame way to do this but for now copying the exception message into the data buffer
                //clear the buffer of any other text
                _dataBuffer = string.Empty;
                //and copy the exception data
                _dataBuffer = ex.Message;

                return false;
            }
        }

        public bool CloseSerialPort()                 
        {
            /* Note, if app hangs on close may be worth trying to put close method into its own thread and execute it
             * http://social.msdn.microsoft.com/forums/en-US/Vsexpressvcs/thread/ce8ce1a3-64ed-4f26-b9ad-e2ff1d3be0a5/
             * 
             * More info:
             * http://blogs.msdn.com/b/bclteam/archive/2006/10/10/top-5-serialport-tips-_5b00_kim-hamilton_5d00_.aspx
             */
            //check if port is already open
            try
            {
                //check if port is already open and if so close it
                if (comPort.IsOpen == false) return true;
#if DEBUG
                System.Diagnostics.Debug.Write("Closing Port " + comPort.PortName + " @ " + DateTime.Now + "\n");
#endif
                comPort.DiscardInBuffer();
                comPort.DiscardOutBuffer();              

                comPort.Dispose();

                return true;
            }

            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.Write("Error " + ex.Message + "\n");
#endif
                //kind of a lame way to do this but for now copying the exception message into the data buffer
                //clear the buffer of any other text
                _dataBuffer = string.Empty;
                //and copy the exception data
                _dataBuffer = ex.Message;
                return false;
            }
        }
        
        #endregion

        #region Serial Data Transactions
        public string ReadSerialData()
        {
            string sTemp;

            sTemp = _dataBuffer;

            //empty the data buffer
            _dataBuffer = string.Empty;

            return sTemp;
        }
        #endregion

    #endregion

        #region Class Event Handlers

        //maybe make this public so it can be used to read data?
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {            
            _dataBuffer = comPort.ReadExisting();

            //broadcast that there is data ready for reading
            if (this.SerialDataReadyEvent != null)
                this.SerialDataReadyEvent();
        }
        
        #endregion

        #region Populate Port Values
        public void PopulateParityValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }

        public void PopulateStopBits(object obj)
        {            
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }

        public void PopulatePortNames(object obj)
        {
            //check if not ports
            if (SerialPort.GetPortNames().Length != 0)
            {
                foreach (string str in SerialPort.GetPortNames())
                {
                    //test if there are any ports before returning the names                
                    ((ComboBox)obj).Items.Add(str);                    
                }
            }

            else
            {
                ((ComboBox)obj).Items.Add("NO COM FOUND");
            }
        }

        #endregion

        #region Debug and Test
        public void SimDataReady(string sTemp)
        {
            _dataBuffer = sTemp;
            
            //broadcast that there is data ready for reading
            if (this.SerialDataReadyEvent != null)
                this.SerialDataReadyEvent();

            //clear the databuffer
            _dataBuffer = string.Empty;
        }
        #endregion 
    }
}