using System;

namespace DIA
{
    /// <summary>
    /// Helper class that can load different instances of MS DIA.
    /// </summary>
    public static class DiaLoader
    {
        /// <summary>
        /// MS DIA 14.0 implementation of <see cref="DiaSource"/> CLSID.
        /// </summary>
        private static readonly Guid Dia140 = new Guid("E6756135-1E65-4D17-8576-610761398C3C");

        /// <summary>
        /// MS DIA 12.0 implementation of <see cref="DiaSource"/> CLSID.
        /// </summary>
        private static readonly Guid Dia120 = new Guid("3BFCEA48-620F-4B6B-81F7-B9AF75454C7D");

        /// <summary>
        /// MS DIA 11.0 implementation of <see cref="DiaSource"/> CLSID.
        /// </summary>
        private static readonly Guid Dia110 = new Guid("761D3BCD-1304-41D5-94E8-EAC54E4AC172");

        /// <summary>
        /// MS DIA 10.0 implementation of <see cref="DiaSource"/> CLSID.
        /// </summary>
        private static readonly Guid Dia100 = new Guid("B86AE24D-BF2F-4ac9-B5A2-34B14E4CE11D");

        /// <summary>
        /// Array of all known MS DIA implementations referenced by <see cref="DiaSource"/> CLSID.
        /// </summary>
        private static readonly Guid[] DiaGuids = new[] { Dia140, Dia120, Dia110, Dia100 };

        /// <summary>
        /// Searches for different MS DIA versions registered on the system and loads one that was found.
        /// It should be used instead of creating new <see cref="DiaSource"/> class instance.
        /// </summary>
        /// <returns>Instance of <see cref="IDiaDataSource"/>.</returns>
        public static IDiaDataSource CreateDiaSource()
        {
            foreach (var diaGuid in DiaGuids)
            {
                IDiaDataSource dia = CreateDiaInstance(diaGuid);

                if (dia != null)
                {
                    return dia;
                }
            }

            return new DiaSource();
        }

        /// <summary>
        /// Tries to load MS DIA using specified CLSID.
        /// </summary>
        /// <param name="clsid">GUID that points to <see cref="DiaSource"/> registration.</param>
        /// <returns>Instance of <see cref="IDiaDataSource"/> if succeeds; <c>null</c> otherwise.</returns>
        private static IDiaDataSource CreateDiaInstance(Guid clsid)
        {
            try
            {
                Type comType = Type.GetTypeFromCLSID(clsid);

                return (IDiaDataSource)Activator.CreateInstance(comType);
            }
            catch
            {
                return null;
            }
        }
    }
}
