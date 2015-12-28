using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ezytask.infrastructure.Data
{
    public class ezytaskDataStore
    {
        private static ezytask.infrastructure.Data.ezytaskDataContext m_DataContext;
        public static ezytaskDataContext DataContext
        {
            get
            {
                if (m_DataContext == null)
                    m_DataContext = new ezytaskDataContext();

                return m_DataContext;
            }

        }
    }
}
