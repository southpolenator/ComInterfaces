using System;
using System.Runtime.InteropServices;

namespace DIA.NoExceptions
{
    /// <summary>
    /// Enumerates by address the various symbols contained in the data source.
    /// </summary>
    [ComImport, Guid("624B7D9C-24EA-4421-9D06-3B577471C1FA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDiaEnumSymbolsByAddr
    {
        /// <summary>
        /// Positions the enumerator by performing a lookup by image section number and offset.
        /// </summary>
        /// <param name="isect">Image section number.</param>
        /// <param name="offset">Offset in section.</param>
        /// <param name="symbol">Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</param>
        [PreserveSig]
        HResult symbolByAddr(
            [In] uint isect,
            [In] uint offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol symbol);

        /// <summary>
        /// Positions the enumerator by performing a lookup by relative virtual address (RVA).
        /// </summary>
        /// <param name="relativeVirtualAddress">Address relative to start of image.</param>
        /// <param name="symbol">Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</param>
        [PreserveSig]
        HResult symbolByRVA(
            [In] uint relativeVirtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol symbol);

        /// <summary>
        /// Positions the enumerator by performing a lookup by virtual address (VA).
        /// </summary>
        /// <param name="virtualAddress">Virtual address.</param>
        /// <param name="symbol">Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</param>
        [PreserveSig]
        HResult symbolByVA(
            [In] ulong virtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol symbol);

        /// <summary>
        /// Retrieves the next symbols in order by address.
        /// </summary>
        /// <param name="celt">The number of symbols in the enumerator to be retrieved.</param>
        /// <param name="rgelt">An array that is to be filled in with the <see cref="IDiaSymbol"/> object that represent the desired symbols.</param>
        /// <param name="pceltFetched">Returns the number of symbols in the fetched enumerator.</param>
        [PreserveSig]
        HResult Next(
            [In] uint celt,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IDiaSymbol[] rgelt,
            [Out] out uint pceltFetched);

        /// <summary>
        /// Retrieves the previous symbols in order by address.
        /// </summary>
        /// <param name="celt">The number of symbols in the enumerator to be retrieved.</param>
        /// <param name="rgelt">An array that is to be filled in with the <see cref="IDiaSymbol"/> object that represent the desired symbols.</param>
        /// <param name="pceltFetched">Returns the number of symbols in the fetched enumerator.</param>
        [PreserveSig]
        HResult Prev(
            [In] uint celt,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IDiaSymbol[] rgelt,
            [Out] out uint pceltFetched);

        /// <summary>
        /// Makes a copy of an object.
        /// </summary>
        /// <param name="ppenum">Returns an <see cref="IDiaEnumSymbolsByAddr"/> object that contains a duplicate of the enumerator. The symbols are not duplicated, only the enumerator.</param>
        [PreserveSig]
        HResult Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbolsByAddr ppenum);
    }
}
