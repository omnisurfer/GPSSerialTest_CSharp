using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPSRoot
{
    class GPSConstants
    {

        #region General Control Constants
        internal const int caSentenceBufferSize = 100;
        internal const int iGPSDataTypeArraySize = 7; //6 for the word and one for the comma
        #endregion
        
        #region GPGGA Sentence Constants
        internal const int iGPGGA_FixTimeArraySize = 10;
        internal const int iGPGGA_LatDegMinArraySize = 10;
        internal const int iGPGGA_LatPoleArraySize = 1;
        internal const int iGPGGA_LonDegMinArraySize = 10;
        internal const int iGPGGA_LonPoleArraySize = 1;
        internal const int iGPGGA_FixQualityArraySize = 1;
        internal const int iGPGGA_TrackedSatsArraySize = 2;
        internal const int iGPGGA_HorDOPArraySize = 3;
        internal const int iGPGGA_AltValueArraySize = 10;
        internal const int iGPGGA_AltUnitArraySize = 1;
        internal const int iGPGGA_HeightValueArraySize = 10;
        internal const int iGPGGA_HeightUnitArraySize = 1;
        internal const int iGPGGA_TimeDGPSUpdateArraySize = 2; //don't know how long this is
        internal const int iGPGGA_DGPSStatIDArraySize = 4; //don't know how long this is
        internal const int iGPGGA_CheckSumArraySize = 2; //maybe don't need this..?
        #endregion

        #region GPGSA Sentence Constants
        internal const int iGPGSA_FixSelectionArraySize = 1;
        internal const int iGPGSA_FixValueArraySize = 1;
        internal const int iGPGSA_SatPRNsUsedForFixArraySize = 36; //hold all 12 with commas
        internal const int iGPGSA_PDOPArraySize = 3;
        internal const int iGPGSA_HorDOPArraySize = 3;
        internal const int iGPGSA_VerDOPArraySize = 3;
        internal const int iGPGSA_CheckSumArraySize = 2;
        #endregion

        #region GPGSV Sentence Constants
        internal const int iGPGSV_NoOfSentencesArraySize = 1;
        internal const int iGPGSV_SentenceNoArraySize = 1;
        internal const int iGPGSV_NoOfSatsInViewArraySize = 2;        
        internal const int iGPGSV_SatPRNInfoArraySize = 12; //hold all the data for a single sat including the commas?
        internal const int iGPGSV_CheckSumArraySize = 2;        
        #endregion

        #region GPRMC Sentence Constants
        internal const int iGPRMC_FixTimeArraySize = 10;
        internal const int iGPRMC_FixStatArraySize = 1;
        internal const int iGPRMC_LatDegMinArraySize = 10;
        internal const int iGPRMC_LatPoleArraySize = 1;
        internal const int iGPRMC_LonDegMinArraySize = 10;
        internal const int iGPRMC_LonPoleArraySize = 1;
        internal const int iGPRMC_SoGArraySize = 5;
        internal const int iGPRMC_TrackAngleArraySize = 5;
        internal const int iGPRMC_DateArraySize = 6;
        internal const int iGPRMC_MagVarArraySize = 5;
        internal const int iGPRMC_MagPoleArraySize = 1;
        internal const int iGPRMC_CheckSumArraySize = 2;
        #endregion

        #region GPGLL Sentence Constants
        //not supporting these sentences
        #endregion

        #region GPVTG Sentence Constants
        //not supporting these sentences
        #endregion

    }
}
