using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasanShouman.Models.Classes
{
    public class Functions
    {
        /// <summary>
        /// Build a success message.
        /// </summary>
        /// <typeparam name="T">The type of the data that will be passed to the method.</typeparam>
        /// <param name="pData">A list that contains the data we need to pass to the user.</param>
        /// <returns>String in JSON format</returns>
        public static string BuildSuccessMessage<T>(List<T> pData)
        {

            return JsonConvert.SerializeObject(new MainResponse<T>() {

                Key = "Success",
                Message = "Done",
                Data = pData
            });
        }

        /// <summary>
        /// Build an error message.
        /// </summary>
        /// <param name="pMessage">The message that should be returned to the user.</param>
        /// <returns>String in JSON format</returns>
        public static string BuildErrorMessage(string pMessage)
        {

            return JsonConvert.SerializeObject(new MainResponse<object>()
            {

                Key = "Success",
                Message = pMessage
            });
        }
    }
}