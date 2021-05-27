using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HasanShouman.Models
{
    public class GroupedData : UserEvent
    {
        // For the event of type "h" when the data grouped, we need to know how many persons, high-fived how many.
      
            
            /// <summary>
        /// This field will hold the distinct count of the total persons high-fived.
        /// For other events this will be equal to <see cref="CountReceiver"/>>
        /// </summary>
        public string CountSender { get; set; }

        /// <summary>
        /// This field will hold the distinct count of the total persons that were high-fived.
        /// For other events this will be equal to <see cref="CountSender"/>>
        /// </summary>
        public string CountReceiver { get; set; }

        /// <summary>
        /// Holds the children of the current group.
        /// </summary>
        public List <GroupedData> Children { get; set; }

       
    }
}