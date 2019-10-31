using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DIA.NoExceptions
{
    /// <summary>
    /// Undocumented on MSDN
    /// </summary>
    [ComImport, Guid("1C7FF653-51F7-457E-8419-B20F57EF7E4D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDiaEnumInputAssemblyFiles
    {
        /// <summary>
        /// Gets the enumerator. Internally, marshals the COM IEnumVARIANT interface to the .NET Framework <see cref="IEnumerator"/> interface, and vice versa.
        /// </summary>
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler")]
        IEnumerator GetEnumerator();

        /// <summary>
        /// Retrieves the number of input assembly files.
        /// </summary>
        [DispId(1)]
        int count { get; }

        /// <summary>
        /// Retrieves an input assembly file by means of an index.
        /// </summary>
        /// <param name="index">Index of the <see cref="IDiaInputAssemblyFile"/> object to be retrieved. The index is the range 0 to count-1, where count is returned by the <see cref="IDiaEnumInputAssemblyFiles.count"/> property.</param>
        /// <param name="inputAssemblyFile">Returns an <see cref="IDiaInputAssemblyFile"/> object representing the input assembly file.</param>
        [PreserveSig]
        HResult Item(
            [In] uint index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile inputAssemblyFile);

        /// <summary>
        /// Retrieves a specified number of input assembly files in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of input assembly files in the enumerator to be retrieved.</param>
        /// <param name="rgelt">Returns an array of <see cref="IDiaInputAssemblyFile"/> objects that represents the desired input assembly files.</param>
        /// <param name="pceltFetched">Returns the number of input assembly files in the fetched enumerator.</param>
        [PreserveSig]
        HResult Next(
            [In] uint celt,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IDiaInputAssemblyFile[] rgelt,
            [Out] out uint pceltFetched);

        /// <summary>
        /// Skips a specified number of input assembly files in an enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of input assembly files in the enumeration sequence to skip.</param>
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
        /// <param name="ppenum">Returns an <see cref="IDiaEnumInputAssemblyFiles"/> object that contains a duplicate of the enumerator. The input assembly files are not duplicated, only the enumerator.</param>
        [PreserveSig]
        HResult Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumInputAssemblyFiles ppenum);
    }
}
