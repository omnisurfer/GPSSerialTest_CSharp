using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;

/*NOTES
 * 09/09/12 - The StreamManager at present only works with the NMEA stream from my SirfStar II GPS Reciever NMEA output. I don't know what version of NMEA this is. May be worth it to figure out some kind of version
 * detection for the NMEA protocol used.
 * 
 */ 
namespace GPSRoot
{
    #region GPSStreamManager Delegates
    //Delegate to broadcast that data is waiting to be read
    //public delegate void StreamProcessedEvent();
    #endregion

    //creating a struct object that will store the Sat PRN, Elevation, Azimuth and SNR for a single sattelite. Hoping to pass these struct objects within an object array..? - DMR 09-29-12    
    /* Maybe this is a better way:
     * 
     * http://answers.unity3d.com/questions/217893/best-practice-for-passing-data-between-classes-in.html
     */

    class GPSStreamManager
    {
        #region GPSStreamManager Variables

        #region Stream and Data Buffers and Control
        private string _strDataBuffer = string.Empty;
        
        //variables for BuildSentence
        private char[] _caSentenceBuffer = new char[GPSConstants.caSentenceBufferSize];

        private int _iSentenceBufferIndex = 0, _iStreamInIndex = 0;

        //bool used to control Build Sentence
        private bool _bGPSSentenceStart = false;
        #endregion

        #region GPGGA Sentence Storage Arrays
        private char[] _caGPGGA_FixTime = new char[GPSConstants.iGPGGA_FixTimeArraySize];
        private char[] _caGPGGA_LatDegMin = new char[GPSConstants.iGPGGA_LatDegMinArraySize];
        private char [] _caGPGGA_LatPole = new char[GPSConstants.iGPGGA_LatPoleArraySize];
        private char[] _caGPGGA_LonDegMin = new char[GPSConstants.iGPGGA_LonDegMinArraySize];
        private char [] _caGPGGA_LonPole = new char[GPSConstants.iGPGGA_LonPoleArraySize];
        private char[] _caGPGGA_FixQuality = new char[GPSConstants.iGPGGA_FixQualityArraySize];
        private char[] _caGPGGA_TrackedSats = new char[GPSConstants.iGPGGA_TrackedSatsArraySize];
        private char[] _caGPGGA_HorDOP = new char[GPSConstants.iGPGGA_HorDOPArraySize];
        private char[] _caGPGGA_AltValue = new char[GPSConstants.iGPGGA_AltValueArraySize];
        private char[] _caGPGGA_AltUnit = new char[GPSConstants.iGPGGA_AltUnitArraySize];
        private char[] _caGPGGA_HeightGeoidValue = new char[GPSConstants.iGPGGA_HeightValueArraySize];
        private char[] _caGPGGA_HeightGeoidUnit = new char[GPSConstants.iGPGGA_HeightUnitArraySize];
        private char[] _caGPGGA_DGPSUpdateTime = new char[GPSConstants.iGPGGA_TimeDGPSUpdateArraySize];
        private char[] _caGPGGA_DGPSID = new char[GPSConstants.iGPGGA_DGPSStatIDArraySize];
        #endregion

        #region GPGSA Sentence Storage Arrays
        private char _cGPGSA_FixSelect = new char();
        private char _cGPGSA_FixValue = new char();
        private char[] _caGPGSA_SatPRNsUsedForFix = new char[GPSConstants.iGPGSA_SatPRNsUsedForFixArraySize];
        private char[] _caGPGSA_PDOP = new char[GPSConstants.iGPGSA_PDOPArraySize];
        private char[] _caGPGSA_HDOP = new char[GPSConstants.iGPGSA_HorDOPArraySize];
        private char[] _caGPGSA_VDOP = new char[GPSConstants.iGPGSA_VerDOPArraySize];        
        #endregion

        #region GPGSV Sentence Storage Arrays
        private char _cGPGSV_NoOfSentences = new char();
        private char _cGPGSV_SentenceNo = new char();
        private char[] _caGPGSV_NoSatPRNsInView = new char[GPSConstants.iGPGSV_NoOfSatsInViewArraySize];
        private char[] _caGPGSV_SatPRNInfo = new char[GPSConstants.iGPGSV_SatPRNInfoArraySize];
        
        //an object array to store each satellites info object
        private object[] SatInfoObjectArray;

        #endregion

        #region GPRMC Senetence Storage Arrays
        private char[] _caGPRMC_FixTime = new char[GPSConstants.iGPRMC_FixTimeArraySize];
        private char _cGPRMC_FixStatus = new char();
        private char[] _caGPRMC_LatDegMin = new char[GPSConstants.iGPRMC_LatDegMinArraySize];
        private char cGPRMC_LatPole = new char();
        private char[] caGPRMC_LonDegMin = new char[GPSConstants.iGPRMC_LonDegMinArraySize];
        private char cGPRMC_LonPole = new char();
        private char[] caGPRMC_SpeedOverGround = new char[GPSConstants.iGPRMC_SoGArraySize];
        private char[] caGPRMC_TrackAngle = new char[GPSConstants.iGPRMC_TrackAngleArraySize];
        private char[] caGPRMC_Date = new char[GPSConstants.iGPRMC_DateArraySize];
        private char[] caGPRMC_MagneticVariation = new char[GPSConstants.iGPRMC_MagPoleArraySize];
        private char[] cGPRMC_MagneticVariationPole = new char[GPSConstants.iGPRMC_MagPoleArraySize];
        #endregion

        #region GPGLL
        //not implemented
        #endregion

        #region GPVTG
        //not implemented
        #endregion

        #endregion

        #region GPSStreamManager Properties

        #region GPGGA Properties
        public int GPGGA_FixTime
        {
            get { return Convert.ToInt16(_caGPGGA_FixTime); }           
        }

        public double GPGGA_LatDegMin
        {
            get { return Convert.ToDouble(_caGPGGA_LatDegMin); }
        }

        public char GPGGA_LatPole
        {
            //just returning first char since not likely to have combination poles
            get { return _caGPGGA_LatPole[0]; }
        }

        public double GPGGA_LonDegMin
        {
            get { return Convert.ToDouble(_caGPGGA_LonDegMin); }
        }

        public char GPGGA_LonPole
        {
            //just returning first char since not likely to have combination poles
            get { return _caGPGGA_LonPole[0]; }
        }

        public int GPGGA_FixQuality
        {
            //so far all fix values fit within a single char
            get { return Convert.ToInt16(_caGPGGA_FixQuality); }
        }

        public int GPGGA_TrackedSats
        {
            get { return Convert.ToInt16(_caGPGGA_TrackedSats); }
        }

        public double GPGGA_HorDOP
        {
            get { return Convert.ToDouble(_caGPGGA_HorDOP); }
        }

        public double GPGGA_AltValue
        {
            get { return Convert.ToDouble(_caGPGGA_AltValue); }
        }

        public char GPGGA_AltUnit
        {
            get { return _caGPGGA_AltUnit[0]; }
        }

        public double GPGGA_HeightValue
        {
            get { return Convert.ToDouble(_caGPGGA_HeightGeoidValue); }
        }

        public char GPGGA_HeightUnit
        {
            get { return _caGPGGA_HeightGeoidUnit[0]; }
        }

        //calling this an int since no clue what it is
        public int GPGGA_LastDGPSUpdate
        {
            get { return Convert.ToInt16(_caGPGGA_DGPSUpdateTime); }
        }

        //calling this an int since no clue what it is
        public int GPGGA_DGPSStationID
        {
            get { return Convert.ToInt16(_caGPGGA_DGPSID); }
        }
        #endregion

        #region GPGSA Properties
        public char GPGSA_FixSelect
        {
            get { return _cGPGSA_FixSelect; }
        }

        public int GPGSA_FixType
        {
            get { return Convert.ToInt16(_cGPGSA_FixValue); }
        }

        public int[] GPGSA_SatPRNUsed
        {
            get
            {
                //just to get it to not throw an error until I think this through
                int[] iX = {0};
                return iX;
            }
        }

        public double GPGSA_PDOP
        {
            get { return Convert.ToDouble(_caGPGSA_PDOP); }
        }

        public double GPGSA_HDOP
        {
            get { return Convert.ToDouble(_caGPGSA_HDOP); }
        }

        public double GPGSA_VDOP
        {
            get { return Convert.ToDouble(_caGPGSA_VDOP); }
        }

        #endregion

        #region GPGSV Properties
        public int GPGSV_NoOfSentences
        {
            get { return (int)_cGPGSV_NoOfSentences; }
        }

        public int GPGSV_SentenceNo
        {
            get { return (int)_cGPGSV_SentenceNo; }
        }

        public int[] GPGSV_SatPRNsInView
        {
            get
            {
                int[] iX = {0};

                return iX;
            }
        }

        public int GPGSV_NoOfSatsInView
        {
            get { return Convert.ToInt16(_caGPGSV_NoSatPRNsInView); }
        }

        public object GPGSV_SatPRNsInfo
        {
            get
            {
                //new SatInfo sat = SatInfo(99, 98, 97, 96);
                //SatInfoObjectArray[0] = sat;
                return null;
            }
        }

        #endregion

        #region GPRMC Properties
        #endregion

        #region GPGLL Properties
        //not supported
        #endregion

        #region GPVTG Properties
        //not supported
        #endregion

        #endregion

        #region GPSStreamManager Constructor
        public GPSStreamManager()
        {
            //for now does nothing
        }

        #endregion

        #region GPSStreamManager Methods

        #region Build GPS Sentence
        //08/28/12
        //rethink this, maybe make it where BuildSentence gets passed the string StreamIn and a state machine variable? Somehow return the state variable?
        //Could return a value by doing something like return 2 + BuildSentence(string s, int x); On calling side it could be int iTemp = BuildSentence(sTemp, iTemp);
        public int BuildSentence(string StreamIn)
        {
            //check if at end of StreamIn buffer or at end of SentenceBuffer
            if (_iStreamInIndex < StreamIn.Length && _iSentenceBufferIndex < _caSentenceBuffer.Length)
            {
                //discard anything that is not the start of sentence
                if (StreamIn[_iStreamInIndex] != '$' && _bGPSSentenceStart == false)
                {
                    _iStreamInIndex++;
                    return BuildSentence(StreamIn);
                }

                //found valid GPS start sequence
                else if (StreamIn[_iStreamInIndex] == '$' || _bGPSSentenceStart == true)
                {
                    //case to copy over the start and set GPSSentenceStart to true
                    if (_bGPSSentenceStart == false)
                    {
                        _caSentenceBuffer[_iSentenceBufferIndex] = StreamIn[_iStreamInIndex];

                        //increment the indexes
                        _iStreamInIndex++;
                        _iSentenceBufferIndex++;
                        _bGPSSentenceStart = true;                        

                        return BuildSentence(StreamIn);
                    }

                    //case to copy until the newline character is reached
                    else if (StreamIn[_iStreamInIndex] != '\n')
                    {
                        _caSentenceBuffer[_iSentenceBufferIndex] = StreamIn[_iStreamInIndex];

                        //increment the indexes
                        _iStreamInIndex++;
                        _iSentenceBufferIndex++;

                        return BuildSentence(StreamIn);
                    }

                    //case where newline character is reached
                    else if (StreamIn[_iStreamInIndex] == '\n')
                    {                                               
                        //get length of complete sentence in buffer
                        int iCompleteSentence = 0;

                        do
                        {
                            if (_caSentenceBuffer[iCompleteSentence] != '\r')
                                iCompleteSentence++;
                            else
                                break;

                        } while (iCompleteSentence < _caSentenceBuffer.Length);                        

                        //copy the contents of _caSentenceBuffer to _caSentenceStore
                        char[] _caSentenceStore = new char[iCompleteSentence];
                        
                        for(int i = 0; i < iCompleteSentence; i++)
                        {
                            _caSentenceStore[i] = _caSentenceBuffer[i];
                        }

                        //may call CRC first here or in Parse??

                        //call the Parser function, or alert it?
                        ParseSentence(_caSentenceStore);
                       
#if DEBUG
                        string s = new string(_caSentenceStore);
                        System.Diagnostics.Debug.Write("Processed " + s + "\r\n");
#endif

                        //increment the index
                        _iStreamInIndex++;

                        //reset the Sentence index
                        _iSentenceBufferIndex = 0;

                        //set SentenceStart to false
                        _bGPSSentenceStart = false;

                        return BuildSentence(StreamIn);
                    }

                    //catch all for now
                    else
                        return 0;
                }

                else
                    return 0;
            }

            //reached end of StreamIn buffer or SentenceBuffer
            else
            {
                //clear it
                _iStreamInIndex = 0;
                
                //check if at end of SentenceBuffer
                if(_iSentenceBufferIndex >= _caSentenceBuffer.Length)
                    _iSentenceBufferIndex = 0;                
                
                return 0;
            }
        }
        #endregion

        #region Parse GPS Sentence
        public void ParseSentence(char[] StreamIn)
        {

            //may be worth it to make it not based on a fixed char length            
            char[] caTemp = new char[GPSConstants.iGPSDataTypeArraySize];

            //prob not that fastest way to do this but wanted to see if I could switch using strings
            for (int i = 0; i < caTemp.Length; i++)
            {
                caTemp[i] = StreamIn[i];
            }
            
            string sTemp = new string(caTemp);

            switch (sTemp)
            {
                #region GGA Sentence
                case "$GPGGA,":
                    {                        
                        //Start counting commmas, for this sentence expecting 14 before end of sentence
                        //Sentence format is as follows (take from http://www.gpsinformation.org/dale/nmea.htm)
                        /*
                        GGA - essential fix data which provide 3D location and accuracy data.

                         $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47

                        Where:
                             GGA          Global Positioning System Fix Data
                             123519       Fix taken at 12:35:19 UTC, this seems to be outdated, the format from my GPS is 123519.000, counts in thous?
                             4807.038,N   Latitude 48 deg 07.038' N
                             01131.000,E  Longitude 11 deg 31.000' E
                             1            Fix quality: 0 = invalid
                                                       1 = GPS fix (SPS)
                                                       2 = DGPS fix
                                                       3 = PPS fix
			                               4 = Real Time Kinematic
			                               5 = Float RTK
                                                       6 = estimated (dead reckoning) (2.3 feature)
			                               7 = Manual input mode
			                               8 = Simulation mode
                             08           Number of satellites being tracked
                             0.9          Horizontal dilution of position
                             545.4,M      Altitude, Meters, above mean sea level
                             46.9,M       Height of geoid (mean sea level) above WGS84
                                              ellipsoid
                             (empty field) time in seconds since last DGPS update
                             (empty field) DGPS station ID number
                             *47          the checksum data, always begins with *
                        */
                        
                        //clear the storage arrays
                        Array.Clear(_caGPGGA_AltUnit, 0, _caGPGGA_AltUnit.Length);
                        Array.Clear(_caGPGGA_AltValue, 0, _caGPGGA_AltValue.Length);
                        Array.Clear(_caGPGGA_DGPSID, 0, _caGPGGA_DGPSID.Length);
                        Array.Clear(_caGPGGA_DGPSUpdateTime, 0, _caGPGGA_DGPSUpdateTime.Length);
                        Array.Clear(_caGPGGA_FixQuality, 0, _caGPGGA_FixQuality.Length);
                        Array.Clear(_caGPGGA_FixTime, 0, _caGPGGA_FixTime.Length);
                        Array.Clear(_caGPGGA_HeightGeoidUnit, 0, _caGPGGA_HeightGeoidUnit.Length);
                        Array.Clear(_caGPGGA_HeightGeoidValue, 0, _caGPGGA_HeightGeoidValue.Length);
                        Array.Clear(_caGPGGA_HorDOP, 0, _caGPGGA_HorDOP.Length);
                        Array.Clear(_caGPGGA_LatDegMin, 0, _caGPGGA_LatDegMin.Length);
                        Array.Clear(_caGPGGA_LatPole, 0, _caGPGGA_LatPole.Length);
                        Array.Clear(_caGPGGA_LonDegMin, 0, _caGPGGA_LonDegMin.Length);
                        Array.Clear(_caGPGGA_LonPole, 0, _caGPGGA_LonPole.Length);
                        Array.Clear(_caGPGGA_TrackedSats, 0, _caGPGGA_TrackedSats.Length);

                        //look through all the chars in the array
                        for (int iTempIndex = 0, iOutIndex = 0, iCommas = 0; iTempIndex < StreamIn.Length; iTempIndex++)
                        {
                            //check for first comma which proceeds the GPGGA sentence
                            if (iCommas == 0)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iCommas++;                                    
                                }
                            }

                            //Time fix was taken
                            else if (iCommas == 1)
                            {                                
                                if (StreamIn[iTempIndex] == ',')
                                {                                          
                                    iOutIndex = 0;                                                                        
                                    iCommas++;
                                }                                

                                else
                                {
                                    if (iOutIndex < _caGPGGA_FixTime.Length)
                                    {
                                        _caGPGGA_FixTime[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }                            

                            //Lat deg and mins
                            else if (iCommas == 2)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_LatDegMin.Length)
                                    {
                                        _caGPGGA_LatDegMin[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }    

                            //Lat pole
                            else if (iCommas == 3)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_LatPole.Length)
                                    {
                                        _caGPGGA_LatPole[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //Long deg and mins
                            else if (iCommas == 4)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_LonDegMin.Length)
                                    {
                                        _caGPGGA_LonDegMin[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //Long pole
                            else if (iCommas == 5)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_LonPole.Length)
                                    {
                                        _caGPGGA_LonPole[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //Fix quality
                            else if (iCommas == 6)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_FixQuality.Length)
                                    {
                                        _caGPGGA_FixQuality[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //No of Sats
                            else if (iCommas == 7)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_TrackedSats.Length)
                                    {
                                        _caGPGGA_TrackedSats[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //Horiz DOP
                            else if (iCommas == 8)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_HorDOP.Length)
                                    {
                                        _caGPGGA_HorDOP[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //Alt value
                            else if (iCommas == 9)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_AltValue.Length)
                                    {
                                        _caGPGGA_AltValue[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //Alt unit
                            else if (iCommas == 10)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_AltUnit.Length)
                                    {
                                        _caGPGGA_AltUnit[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //Height of geoid value
                            else if (iCommas == 11)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_HeightGeoidValue.Length)
                                    {
                                        _caGPGGA_HeightGeoidValue[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //Height Unit
                            else if (iCommas == 12)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_HeightGeoidUnit.Length)
                                    {
                                        _caGPGGA_HeightGeoidUnit[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //Time in sec since last DGPS update
                            else if (iCommas == 13)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_DGPSUpdateTime.Length)
                                    {
                                        _caGPGGA_DGPSUpdateTime[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //DGPS station ID num
                            else if (iCommas == 14)
                            {
                                if (StreamIn[iTempIndex] == ',')
                                {
                                    iOutIndex = 0;
                                    iCommas++;
                                }

                                else
                                {
                                    if (iOutIndex < _caGPGGA_DGPSID.Length)
                                    {
                                        _caGPGGA_DGPSID[iOutIndex] = StreamIn[iTempIndex];
                                        iOutIndex++;
                                    }
                                }
                            }

                            //Checksum case?

                            //catch all?
                            else
                            {
                                //doing nothing for now
                            }

                        }

                        #region GPGGA Debug Output
                        //Have a look at the parsed out string
#if DEBUG
                        string sTemp0 = new string(_caGPGGA_FixTime), 
                               sTemp1 = new string(_caGPGGA_LatDegMin), 
                               sTemp2 = new string(_caGPGGA_LatPole), 
                               sTemp3 = new string(_caGPGGA_LonDegMin), 
                               sTemp4 = new string(_caGPGGA_LonPole),
                               sTemp5 = new string(_caGPGGA_FixQuality),
                               sTemp6 = new string(_caGPGGA_TrackedSats),
                               sTemp7 = new string(_caGPGGA_HorDOP),
                               sTemp8 = new string(_caGPGGA_AltValue),
                               sTemp9 = new string(_caGPGGA_AltUnit),
                               sTemp10 = new string(_caGPGGA_HeightGeoidValue),
                               sTemp11 = new string(_caGPGGA_HeightGeoidUnit),
                               sTemp12 = new string(_caGPGGA_DGPSUpdateTime),
                               sTemp13 = new string(_caGPGGA_DGPSID);

                        //Clunky way to do this, but don't want to deal with nulls here
                        System.Diagnostics.Debug.Write("\nGPGGA - Time Fix: " + sTemp0);
                        System.Diagnostics.Debug.Write(" Lat Val: " + sTemp1); 
                        System.Diagnostics.Debug.Write(" Lat Pole: " + sTemp2);  
                        System.Diagnostics.Debug.Write(" Lon Val: " + sTemp3);
                        System.Diagnostics.Debug.Write(" Lon Pole: " + sTemp4 + "\r\n");
                        System.Diagnostics.Debug.Write(" Fix Quality: " + sTemp5);
                        System.Diagnostics.Debug.Write(" Tracked Sats: " + sTemp6);
                        System.Diagnostics.Debug.Write(" HorDOP: " + sTemp7);
                        System.Diagnostics.Debug.Write(" AltVal: " + sTemp8);
                        System.Diagnostics.Debug.Write(" AltUnit: " + sTemp9);
                        System.Diagnostics.Debug.Write(" HghtVal: " + sTemp10);
                        System.Diagnostics.Debug.Write(" HghtUnit: " + sTemp11);
                        System.Diagnostics.Debug.Write(" DGPSTime: " + sTemp12);
                        System.Diagnostics.Debug.Write(" DGPSID: " + sTemp13 + "\r\n");
#endif
                        #endregion

                        break;
                    }
                #endregion

                #region GSA Sentence
                case "$GPGSA,":
                    {
                        /*  $GPGSA,A,3,04,05,,09,12,,,24,,,,,2.5,1.3,2.1*39

                            Where:
                                 GSA      Satellite status
                                 A        Auto selection of 2D or 3D fix (M = manual) 
                                 3        3D fix - values include: 1 = no fix
                                                                   2 = 2D fix
                                                                   3 = 3D fix
                                 04,05... PRNs of satellites used for fix (space for 12) 
                                 2.5      PDOP (dilution of precision) 
                                 1.3      Horizontal dilution of precision (HDOP) 
                                 2.1      Vertical dilution of precision (VDOP)
                                 *39      the checksum data, always begins with                          
                         */

                        break;
                    }
                #endregion 

                #region GSV Sentence
                case "$GPGSV,":
                    {
                        break;
                    }
                #endregion 

                #region RMC Sentence
                case "$GPRMC,":
                    {
                        break;
                    }
                #endregion 

                #region GPL Sentence
                case "$GPGLL,":
                    {
                        //not supported
                        break;
                    }
                #endregion

                #region VTG Sentence
                case "$GPVTG,":
                    {
                        //not supported
                        break;
                    }
                #endregion

                #region Default
                default:
#if DEBUG
                    System.Diagnostics.Debug.Write("No match found");
#endif
                    break;
            }
                #endregion            
        }
        #endregion

        #endregion        
    }
}
