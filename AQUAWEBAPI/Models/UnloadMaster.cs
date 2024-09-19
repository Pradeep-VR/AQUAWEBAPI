// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.UnloadMaster
using System.Collections.Generic;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class UnloadMaster
    {
        private List<UnloadNew> m_unload;

        public List<UnloadNew> unload
        {
            get
            {
                return m_unload;
            }
            set
            {
                m_unload = value;
            }
        }
    }
}