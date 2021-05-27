using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasanShouman.Models.Classes
{
    /// <summary>
    /// The class that will hold the data that will be returned to the client-side.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MainResponse <T>
    {
        /// <summary>
        /// Specifies where the call and the loading of the data succeeded or not.
        /// Success if all OK.
        /// Error for exceptions.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The message to be sent to the client side.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The data that was loaded and manipulated.
        /// </summary>
       public List<T> Data = new List<T>();
    }
}