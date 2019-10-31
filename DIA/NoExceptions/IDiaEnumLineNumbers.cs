using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DIA.NoExceptions
{
    /// <summary>
    /// Enumerates the various line numbers contained in the data source.
    /// </summary>
    [ComImport, Guid("FE30E878-54AC-44F1-81BA-39DE940F6052"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDiaEnumLineNumbers
    {
        /// <summary>
        /// Gets the enumerator. Internally, marshals the COM IEnumVARIANT interface to the .NET Framework <see cref="IEnumerator"/> interface, and vice versa.
        /// </summary>
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler")]
        IEnumerator GetEnumerator();

        /// <summary>
        /// Retrieves the number of line numbers.
        /// </summary>
        [DispId(1)]
        int count { get; }

        /// <summary>
        /// Retrieves an line number by means of an index.
        /// </summary>
        /// <param name="index">Index of the <see cref="IDiaLineNumber"/> object to be retrieved. The index is the range 0 to count-1, where count is returned by the <see cref="IDiaEnumLineNumbers.count"/> property.</param>
        /// <param name="lineNumber">Returns an <see cref="IDiaLineNumber"/> object representing the line number.</param>
        [PreserveSig]
        HResult Item(
            [In] uint index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaLineNumber lineNumber);

        /// <summary>
        /// Retrieves a specified number of line numbers in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of line numbers in the enumerator to be retrieved.</param>
        /// <param name="rgelt">Returns an array of <see cref="IDiaLineNumber"/> objects that represents the desired line numbers.</param>
        /// <param name="pceltFetched">Returns the number of line numbers in the fetched enumerator.</param>
        [PreserveSig]
        HResult Next(
            [In] uint celt,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IDiaLineNumber[] rgelt,
            [Out] out uint pceltFetched);

        /// <summary>
        /// Skips a specified number of line numbers in an enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of line numbers in the enumeration sequence to skip.</param>
        [PreserveSig]
        HResult Skip(
            [In] uint celt);

        /// <summary>
        /// Resets an enumeration sequence to the beginning.
        /// </summary>
        [PreserveSig]
        HResult Reset();

        /// <summary>
        /// Creates an enumerator that contains the same enumeration state as the current enumerator.
        /// </summary>
        /// <param name="ppenum">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a duplicate of the enumerator. The line numbers are not duplicated, only the enumerator.</param>
        [PreserveSig]
        HResult Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppenum);
    }
}
