using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BLLInterfaces;
using BusinessEntity;
using SAL;

namespace BLL.BLLDocuments
{
    public class PatientDocument : IPatientDocument
    {
        IEhrServiceProvider _service = new ServiceProvider();

        /// <summary>
        /// validate login credentials of patient/staff member
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public int CheckLogin(Credentials credentials)
        {
            try
            {
                if (credentials==null) { return 0; }
                if (credentials.UserType == Utility.CommonUnit.UserType.Patient)
                {
                    return _service.CheckPatientLogin(credentials);
                }
                else if (credentials.UserType == Utility.CommonUnit.UserType.Staff)
                {
                    return _service.CheckStaffLogin(credentials);
                }
                else { return 0; }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Deactivate patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public bool DeletePatient(int patientId)
        {
            try
            {
                if (patientId<=0) { return false; }
                return _service.DeletePatient(patientId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get patient by PatientId or PIn
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Patient GetPatient(string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value)) { return null; }
                return _service.GetPatient(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get patient by PatientId
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatientById(int patientId)
        {
            try
            {
                if (patientId<=0) { return null; }
                return _service.GetPatientById(patientId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get patient by PIN
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public Patient GetPatientByPin(string pin)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pin)) { return null; }
                return _service.GetPatientByPin(pin);
            }
            catch (Exception)
            {
                throw;
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
                return _service.GetPatientCollection()?.OrderBy(o=>o.PatientName).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Insert/Update patinet and return full atient objact
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public Patient SavePatient(Patient patient)
        {
            try
            {
                if (patient==null) { return null; }

                patient.JoinedDate = patient.PatientId==0?DateTime.Now: patient.JoinedDate;
                patient.UpdatedDate = DateTime.Now;
                return _service.SavePatient(patient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
