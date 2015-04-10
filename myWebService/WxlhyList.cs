using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWebService
{
    public class WxlhyList
    {

        public System.Guid ID { get; set; }
        private string _label;

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }
        
        
        private bool _isComplete;

        public bool IsComplete
        {
            get { return _isComplete; }
            set { _isComplete = value; }
        }

    }
}