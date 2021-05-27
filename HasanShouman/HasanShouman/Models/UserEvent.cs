using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasanShouman.Models
{
    /// <summary>
    /// A class that will hold the data loaded from the data repo.
    /// </summary>
    public class UserEvent
    {
        /// <summary>
        /// The Id of the user that performed the action.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The data of the action.
        /// </summary>
        public DateTime EventDate { get; set; }

        /// <summary>
        /// The type of the action performed.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// Description of the action.
        /// </summary>
        public string Description { get; set; }
    }
}