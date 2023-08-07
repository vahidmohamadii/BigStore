
using System;

namespace BusinessLayer.Utility
{
    public static class GenerateActiveCode
    {
        public static string GenerateActiveCodes() 
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }
    }
}
