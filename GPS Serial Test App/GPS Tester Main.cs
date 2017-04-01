using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GPSRoot;
using SerialPortRoot;

namespace GPSTesterApp
{
    public partial class GPSTestApp : Form
    {
        //create a new SerialPortManager Object
        SerialPortManager controlPort = new SerialPortManager();
        SerialPortManager testPort = new SerialPortManager();

        //create a new GPSStreamManager object
        GPSStreamManager controlGPSStreamManager = new GPSStreamManager();

        //create a new GPSSVTelemManager object
        GPSTelemManager controlGPSTelemMananger = new GPSTelemManager(); 

        #region Variables
        int iArrayIndex = 0;
        string[] sTemp = null;
        
        //maybe move this to Constants?
        string[] saSimData = { 
                                "$GPGSA,A,3,22,15,21,29,18,25,05,30,,,,,1.6,1.0,1.3*32\r\n",
                                "$GPRMC,015834.000,A,3318.1628,N,11156.1466,W,0.02,283.38,100912,,,A*7F\r\n",
                                "$GPGGA,015835.000,3318.1628,N,11156.1465,W,1,08,1.0,347.5,M,-26.7,M,,0000*66\r\n",
                                "$GPGSA,A,3,22,15,21,29,18,25,05,30,,,,,1.6,1.0,1.3*32\r\n",
                                "$GPRMC,015835.000,A,3318.1628,N,11156.1465,W,0.20,27.62,100912,,,A*4E\r\n",
                                "$GPGGA,015836.000,3318.1629,N,11156.1462,W,1,08,1.0,347.1,M,-26.7,M,,0000*67\r\n",
                                "$GPGSA,A,3,22,15,21,29,18,25,05,30,,,,,1.6,1.0,1.3*32\r\n",
                                "$GPGSV,3,1,11,29,68,141,26,21,55,320,25,18,50,237,21,15,45,113,38*7F\r\n",
                                "$GPGSV,3,2,11,26,30,068,,30,20,287,28,25,14,198,24,05,14,046,22*71\r\n",
                                "$GPGSV,3,3,11,16,11,316,23,22,09,231,17,06,00,318,21*4B\r\n"
                            };

        #endregion

        public GPSTestApp()
        {
            InitializeComponent();            
        }

        #region Form Maintenance
        private void GPSTestApp_Load(object sender, EventArgs e)       
        {                
                //create event handlers to listen for data
                controlPort.SerialDataReadyEvent += new SerialDataReadyEvent(controlPort_SerialDataReadyEvent);
                testPort.SerialDataReadyEvent += new SerialDataReadyEvent(testPort_SerialDataReadyEvent);                                
        }

        private void GPSTestApp_Shown(object sender, EventArgs e)
        {
                //Doing this init here because form load does not work sometimes, it loads before the text boxes exist?                
                InitDebug();
                LoadSerialFields();    
                SetSerialPortDefaults();                                
        }
       
        private void GPSTestApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close the ports before closing the app

            //unsubscribe from event handlers
            controlPort.SerialDataReadyEvent -= controlPort_SerialDataReadyEvent;
            testPort.SerialDataReadyEvent -= testPort_SerialDataReadyEvent;

            //check if controlPort is closed
            if (controlPort.CloseSerialPort())
            {
                if (controlPort.PortName != "")
                    tbControlDebugOut.AppendText(controlPort.PortName + " is closed\n");
            }

            else
            {
                tbControlDebugOut.AppendText("Error: " + controlPort.ReadSerialData() + "\n");
            }

            //testPort
            if (testPort.CloseSerialPort())
            {
                if(testPort.PortName != "")
                    tbTestDebugOut.AppendText(testPort.PortName + " is closed\n");
            }

            else
            {
                tbTestDebugOut.AppendText("Error: " + testPort.ReadSerialData() + "\n");
            }
        }
        #endregion       

        #region Initialization and Setup
        private void LoadSerialFields()
        {
            //Control Port Field Population
            controlPort.PopulateParityValues(ctbControlParity);
            controlPort.PopulatePortNames(ctbControlPort);
            controlPort.PopulateStopBits(ctbControlStopBits);

            //Test Port Field Population
            testPort.PopulateParityValues(ctbTestParity);
            testPort.PopulatePortNames(ctbTestPort);
            testPort.PopulateStopBits(ctbTestStopBits);
        }
        
        private void SetSerialPortDefaults()
        {
            //may need to add something checks if a serial port does not exist
            //Control Port Defaults
            ctbControlPort.SelectedIndex = 0;
            ctbControlBaud.SelectedText = "4800";
            ctbControlDataBits.SelectedIndex = 1;
            ctbControlParity.SelectedIndex = 0;
            ctbControlStopBits.SelectedIndex = 1;

            //Test Port Defaults
            ctbTestPort.SelectedIndex = 0;
            ctbTestBaud.SelectedText = "4800";
            ctbTestDataBits.SelectedIndex = 1;
            ctbTestParity.SelectedIndex = 0;
            ctbTestStopBits.SelectedIndex = 1;
        }
        #endregion

        #region Event Methods
        #region Button Clicks
        private void btnOpenControlPort_Click(object sender, EventArgs e)
        {           
            //Load settings from text boxes
            controlPort.PortName = ctbControlPort.Text;
            controlPort.BaudRate = ctbControlBaud.Text;
            controlPort.DataBits = ctbControlDataBits.Text;
            controlPort.Parity = ctbControlParity.Text;
            controlPort.StopBits = ctbControlStopBits.Text;

            //subscribe to event handlers
            controlPort.SerialDataReadyEvent += controlPort_SerialDataReadyEvent;

            //check if port is open
            if (controlPort.OpenSerialPort())
                tbControlDebugOut.AppendText(controlPort.PortName + " at " + controlPort.BaudRate + " baud is open\n");
         
            else              
                tbControlDebugOut.AppendText("Error: " + controlPort.ReadSerialData() + "\n");
        }

        private void btnCloseControlPort_Click(object sender, EventArgs e)
        {
            //unsubscribe from event handlers
            controlPort.SerialDataReadyEvent -= controlPort_SerialDataReadyEvent;

            //check if port is closed
            if(controlPort.CloseSerialPort())
                tbControlDebugOut.AppendText(controlPort.PortName + " is closed\n");

            else
                tbControlDebugOut.AppendText("Error: " + controlPort.ReadSerialData() + "\n");
        }

        private void btnOpenTestPort_Click(object sender, EventArgs e)
        {
            //Load settings from text boxes
            testPort.PortName = ctbTestPort.Text;
            testPort.BaudRate = ctbTestBaud.Text;
            testPort.DataBits = ctbTestDataBits.Text;
            testPort.Parity = ctbTestParity.Text;
            testPort.StopBits = ctbTestStopBits.Text;

            //subscribe to event handlers
            testPort.SerialDataReadyEvent += testPort_SerialDataReadyEvent;

            //check if port is open
            if (testPort.OpenSerialPort())
                tbTestDebugOut.AppendText(testPort.PortName + " at " + testPort.BaudRate + " baud is open\n");

            else
                tbTestDebugOut.AppendText("Error: " + testPort.ReadSerialData() + "\n");           
        }

        private void btnCloseTestPort_Click(object sender, EventArgs e)
        {
            //unsubscribe from event handlers
            testPort.SerialDataReadyEvent -= testPort_SerialDataReadyEvent;            

            //check if port is closed
            if (testPort.CloseSerialPort())
                tbTestDebugOut.AppendText(testPort.PortName + " is closed\n");

            else
                tbTestDebugOut.AppendText("Error: " + testPort.ReadSerialData() + "\n");                        
        }

        private void btnLoadSimData_Click(object sender, EventArgs e)
        {
            sTemp = tbSimStream.Text.Split('\r');
        }

        #endregion Button Click Events

        #region Serial Data Ready
        void controlPort_SerialDataReadyEvent()
        {
            string sTemp = controlPort.ReadSerialData();

            //may want to change this to something that reads the data, stores it and then appends to text box and processes it???
            if (tbControl.InvokeRequired)
            {
                tbControl.BeginInvoke(new MethodInvoker(delegate { tbControl.AppendText(sTemp); }));
            }

            //call the stream manager recursive sentence builder method to feed it new data
            //make sure to set ref iStreamInIndex to zero and bSentenceStart to false
            //DEBUG NOTE: feeding it the Fake Stream data for now            
            controlGPSStreamManager.BuildSentence(sTemp);
        }

        void testPort_SerialDataReadyEvent()
        {         
            if (tbControl.InvokeRequired)
            {
                tbControl.BeginInvoke(new MethodInvoker(delegate { tbTest.AppendText(testPort.ReadSerialData()); }));
            }
        }

        #endregion
        #endregion

        #region Debug and Test
        private void btnSimRcv_Click(object sender, EventArgs e)
        {         
            timerSimDebug.Enabled = !timerSimDebug.Enabled;

            //change color to show sim is enabled or not
            if (timerSimDebug.Enabled == true)
                btnSimDataRcv.BackColor = System.Drawing.Color.Green;
            else
                btnSimDataRcv.BackColor = System.Drawing.Color.Red;

            //disable loading new data
            if (timerSimDebug.Enabled == true)
                btnLoadSimData.Enabled = false;
            else
                btnLoadSimData.Enabled = true;
        }

        private void InitDebug()
        {
            //set up sTemp and the SimStream text box
            sTemp = saSimData;
            tbSimStream.Lines = saSimData;
        }
        #endregion

        #region Timing
        private void timerDebug_Tick(object sender, EventArgs e)
        {
            
            //if out of array index reset it
            if (iArrayIndex >= sTemp.Length)
                iArrayIndex = 0;

#if DEBUG
            System.Diagnostics.Debug.Write("SimInput " + sTemp[iArrayIndex] + "\r\n");
#endif

            controlPort.SimDataReady(sTemp[iArrayIndex]);
           
            iArrayIndex++;
        }
        #endregion              
    }
}
