using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;

namespace SAL.SvcURLs
{
    public static class SvcUrls
    {
        public static string urlChekPatientLogin = UtilityLibrary.GetAppSettingValue("urlChekPatientLogin");
        public static string urlCheckStaffLogin = UtilityLibrary.GetAppSettingValue("urlCheckStaffLogin");
        public static string urlDeletePatient = UtilityLibrary.GetAppSettingValue("urlDeletePatient");
        public static string urlGetPatient = UtilityLibrary.GetAppSettingValue("urlGetPatient");
        public static string urlGetPatientById = UtilityLibrary.GetAppSettingValue("urlGetPatientById");
        public static string urlGetPatientByPin = UtilityLibrary.GetAppSettingValue("urlGetPatientByPin");
        public static string urlGetPatientCollection = UtilityLibrary.GetAppSettingValue("urlGetPatientCollection");
        public static string urlGetPatientCount = UtilityLibrary.GetAppSettingValue("urlGetPatientCount");
        public static string urlSavePatient = UtilityLibrary.GetAppSettingValue("urlSavePatient");
    }
}