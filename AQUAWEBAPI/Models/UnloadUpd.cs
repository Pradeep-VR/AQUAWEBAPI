// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.UnloadUpd
using System.Collections.Generic;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class UnloadUpd
    {
        private List<UnloadUpdate> ReachedDate;

        private List<UnloadUpdate> UnloadDate;

        public List<UnloadUpdate> ReachDat
        {
            get
            {
                return ReachedDate;
            }
            set
            {
                ReachedDate = value;
            }
        }

        public List<UnloadUpdate> UnloDat
        {
            get
            {
                return UnloadDate;
            }
            set
            {
                UnloadDate = value;
            }
        }
    }
}