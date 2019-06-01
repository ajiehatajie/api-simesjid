using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Base
{
    public class ProcessResult
    {
        public Dictionary<string, object> CustomField
        {
            get;
            set;
        }
        public bool isSucceed
        {
            get;
            set;

        }

        public string message
        {
            get;
            set;
        }

        public string data
        {
            get;
            set;
        }

        public string pagination
        {
            get;
            set;
        }
        public Int32 code
        {
            get;
            set;
        }
        public ProcessResult()
        {
            this.isSucceed = false;
            this.message = "";
            this.data = "";
            this.pagination = "";
            this.code = 200;
            this.CustomField = new Dictionary<string, object>();
        }


        public ProcessResultT<R> ToProcessResult<R>()
        {
            return new ProcessResultT<R>(this.isSucceed, this.message, this.code);
        }

        public ProcessResultT<R> ToProcessResult<R>(R data)
        {
            return new ProcessResultT<R>(this.isSucceed, this.message, data, this.code);
        }
    }
}
