using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPSRoot
{
    #region GPS Sentence Character Data Storage 
    class charDataStore_GPGGA
    {
        private char[] caFixTime, 
                    caLatDegMin, 
                    caLatPole,
                    caLonDegMin,
                    caLonPole,
                    caFixQuality,
                    caTrackedSats,
                    caHorDOP,
                    caAltValue,
                    caAltUnit,
                    caHeightGeoidValue,
                    caHeightGeoidUnit,
                    caDGPSUpdateTime,
                    caDGPSID;
    }

    class charDataStore_GPGSA
    {
        private char cFixSelect,
                    cFixValue;

        private char[] caSatPRNsUsedForFix,
                    caPDOP,
                    caHDOP,
                    caVDOP;        
    }

    class charDataStore_GPGSV
    {
        private char cNoOfSentences,
                    cSentenceNo;

        private char[] caNoSatPRNsInView,
                    caSatPRNInfo;
    }

    class charDataStore_GPRMC
    {
        private char cFixStatus,
                    cLatPole,
                    cLonPole;

        private char[] caFixTime,
                    caLatDegMin,
                    caLonDegMin,
                    caSpeedOverGround,
                    caTrackAngle,
                    caDate,
                    caMagneticVariation,
                    caMagneticVariationPole;
    }
    #endregion
    
    class singleSatInfoStore
    {        
        private int iSatPRNNo;
        private int iSatElevation;
        private int iSatAzimuth;
        private int iSatSNR;

        private singleSatInfoStore(int _iSatPRNNo, int _iSatElevation, int _iSatAzimuth, int _iSatSNR)
        {
            iSatPRNNo = _iSatPRNNo;
            iSatElevation = _iSatElevation;
            iSatAzimuth = _iSatAzimuth;
            iSatSNR = _iSatSNR;
        }        
    }

    class fixStatusStore
    {
        private bool bFixSelection;
        private int iFixValue;
        private int[] iaSatPRNsUsed;
        private float fPDOP, fHDOP, VDOP;
    }

    class gpsPVTStore
    {
        private int iFixTime;
        private float fLatDeg, fLonDeg;
        private char cLatPole, cLonPole;
    }
}