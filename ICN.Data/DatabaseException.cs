using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ICN.Data
{
    public class DatabaseException : DbException
    {
        string m_strMethod = string.Empty;
        string m_strMessage = string.Empty;
        int m_iErrorCode = 0;

        public string Method { get { return m_strMethod; } }
        public string DeMessage { get { return m_strMessage; } }
        public int DeErrorCode { get { return m_iErrorCode; } }

        public DatabaseException() : base()
        {

        }

        public DatabaseException(string message)
            : base(message)
        {

        }

        public DatabaseException(DbException ex, string strMethod)
            : this()
        {
            m_iErrorCode = ex.ErrorCode;
            m_strMessage = ex.Message;
            m_strMethod = strMethod;
        }
    }
}
