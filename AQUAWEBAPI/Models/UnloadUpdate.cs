// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.UnloadUpdate
namespace AQUAWEBAPI
{
    public class UnloadUpdate
    {
        private string ReachedDate = string.Empty;

        private string UnloadDate = string.Empty;

        public string ReachDat
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

        public string UnloDat
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