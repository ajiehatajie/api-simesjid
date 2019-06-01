using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Base
{
    public class ProcessResultT<T> : ProcessResult
    {
        public T data
        {
            get;
            set;
        }



        public ProcessResultT()
        {

        }

        public ProcessResultT(bool isSucceed, string message, Int32 code)
        {
            base.isSucceed = isSucceed;
            base.message = message;
            base.code = code;
        }

        public ProcessResultT(bool isSucceed, string message, T data, Int32 code)
        {
            base.isSucceed = isSucceed;
            base.message = message;
            this.data = data;
            base.code = code;

        }

    }
}
