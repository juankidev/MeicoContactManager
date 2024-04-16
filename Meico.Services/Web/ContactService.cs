using MeicoContactManager.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meico.Models.ViewModels;
using Meico.Services.Database;

namespace Meico.Services.Web
{
    public class ContactService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static List<ContactViewModel>? GetContacts(string userName)
        {
            try
            {
                StoredProcedure sp = new StoredProcedure("[CM].[GetContactsByUser]");
                sp.AddParameter("@UserName", userName);

                List<ContactViewModel> contacts = sp.ExecuteStoredProcedure<ContactViewModel>().ToList();

                return contacts;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool? CreateContact(ContactViewModel contact, string userName)
        {
            try
            {
                StoredProcedure sp = new StoredProcedure("[CM].[CreateContact]");
                sp.AddParameter("@Name", contact.Name);
                sp.AddParameter("@Email", contact.Email);
                sp.AddParameter("@PhoneNumber", contact.PhoneNumber);
                sp.AddParameter("@Address", contact.Address ?? "");
                sp.AddParameter("@Company", contact.Company ?? "");
                sp.AddParameter("@Note", contact.Note ?? "");
                sp.AddParameter("@UserName", userName);

                SpResponse? response = sp.ExecuteStoredProcedure<SpResponse>().FirstOrDefault();

                return response?.Success;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public static bool? UpdateContact(ContactViewModel contact)
        {
            try
            {
                StoredProcedure sp = new StoredProcedure("[CM].[UpdateContact]");
                sp.AddParameter("@ContactId", contact.ContactId);
                sp.AddParameter("@Name", contact.Name);
                sp.AddParameter("@Email", contact.Email);
                sp.AddParameter("@PhoneNumber", contact.PhoneNumber);
                sp.AddParameter("@Address", contact.Address ?? "");
                sp.AddParameter("@Company", contact.Company ?? "");
                sp.AddParameter("@Note", contact.Note ?? "");

                SpResponse? response = sp.ExecuteStoredProcedure<SpResponse>().FirstOrDefault();

                return response?.Success;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public static bool? DeleteContact(int contactId)
        {
            try
            {
                StoredProcedure sp = new StoredProcedure("[CM].[DeleteContact]");
                sp.AddParameter("@ContactId", contactId);

                SpResponse? response = sp.ExecuteStoredProcedure<SpResponse>().FirstOrDefault();

                return response?.Success;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
