using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using Utility;
using SAL.SvcURLs;
using System.Net;
using Newtonsoft.Json;

namespace SAL
{
    public class ServiceProvider : IEhrServiceProvider
    {
        ServiceResponseBE response;


        /// <summary>
        /// validate login credentials of patient member
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>PatientID</returns>
        public int CheckPatientLogin(Credentials credentials)
        {
            try
            {
                string data = JsonConvert.SerializeObject(credentials);
                response = ServiceHelper.GetPOSTResponse(
                    new Uri(SvcUrls.urlChekPatientLogin), UtilityLibrary.GetValueString(data));
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    int resp = JsonConvert.DeserializeObject<int>(response.ResponseMessage);
                    if (resp > 0)
                    {
                        return resp;
                    }
                    else return 0;
                }
                else throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// validate login credentials of staff member
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>StaffID</returns>
        public int CheckStaffLogin(Credentials credentials)
        {
            try
            {
                string data = JsonConvert.SerializeObject(credentials);
                response = ServiceHelper.GetPOSTResponse(
                    new Uri(SvcUrls.urlCheckStaffLogin), UtilityLibrary.GetValueString(data));
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    int resp = JsonConvert.DeserializeObject<int>(response.ResponseMessage);
                    if (resp > 0)
                    {
                        return resp;
                    }
                    else return 0;
                }
                else throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deactivate patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public bool DeletePatient(int patientId)
        {
            bool deleted = false;
            try
            {
                response = ServiceHelper.GetPOSTResponse(
                    new Uri(SvcUrls.urlDeletePatient), UtilityLibrary.GetValueString(patientId));
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    string resp = JsonConvert.DeserializeObject<string>(response.ResponseMessage);
                    if (resp == CommonUnit.oSuccess)
                    {
                        deleted = true;
                    }
                }
                return deleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get patient by PatientId or PIn
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Patient GetPatient(string value)
        {
            Patient result=null;
            try
            {
                response = ServiceHelper.GetPOSTResponse(
                    new Uri(SvcUrls.urlGetPatient), UtilityLibrary.GetValueString(value));
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<Patient>(response.ResponseMessage);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get patient by PatientId
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatientById(int patientId)
        {
            Patient result = null;
            try
            {
                response = ServiceHelper.GetPOSTResponse(
                    new Uri(SvcUrls.urlGetPatientById), UtilityLibrary.GetValueString(patientId));
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<Patient>(response.ResponseMessage);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get patient by PIN
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public Patient GetPatientByPin(string pin)
        {
            Patient result = null;
            try
            {
                response = ServiceHelper.GetPOSTResponse(
                    new Uri(SvcUrls.urlGetPatientByPin), UtilityLibrary.GetValueString(pin));
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<Patient>(response.ResponseMessage);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Patient Collection
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetPatientCollection()
        {
            try
            {
                response = ServiceHelper.GetPOSTResponse(
                    new Uri(SvcUrls.urlGetPatientCollection), UtilityLibrary.GetValueString(""));
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<Patient>>(response.ResponseMessage);
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert/Update patinet and return full atient objact
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public Patient SavePatient(Patient patient)
        {
            Patient result = null;
            try
            {
                string data = JsonConvert.SerializeObject(patient);
                response = ServiceHelper.GetPOSTResponse(
                    new Uri(SvcUrls.urlSavePatient), UtilityLibrary.GetValueString(data));
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<Patient>(response.ResponseMessage);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
