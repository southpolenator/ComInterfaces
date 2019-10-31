using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DIA.NoExceptions
{
    /// <summary>
    /// Enumerate the various source files contained in the data source.
    /// </summary>
    [ComImport, Guid("10F3DBD9-664F-4469-B808-9471C7A50538"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDiaEnumSourceFiles
    {
        /// <summary>
        /// Gets the enumerator. Internally, marshals the COM IEnumVARIANT interface to the .NET Framework <see cref="IEnumerator"/> interface, and vice versa.
        /// </summary>
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler")]
        IEnumerator GetEnumerator();

        /// <summary>
        /// Retrieves the number of source files.
        /// </summary>
        [DispId(1)]
        int count { get; }

        /// <summary>
        /// Retrieves an source file by means of an index.
        /// </summary>
        /// <param name="index">Index of the <see cref="IDiaSourceFile"/> object to be retrieved. The index is the range 0 to count-1, where count is returned by the <see cref="IDiaEnumSourceFiles.count"/> property.</param>
        /// <param name="sourceFile">Returns an <see cref="IDiaSourceFile"/> object representing the source file.</param>
        [PreserveSig]
        HResult Item(
            [In] uint index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSourceFile sourceFile);

        /// <summary>
        /// Retrieves a specified number of source files in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of source files in the enumerator to be retrieved.</param>
        /// <param name="rgelt">Returns an array of <see cref="IDiaSourceFile"/> objects that represents the desired source files.</param>
        /// <param name="pceltFetched">Returns the number of source files in the fetched enumerator.</param>
        [PreserveSig]
        HResult Next(
            [In] uint celt,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IDiaSourceFile[] rgelt,
            [Out] out uint pceltFetched);

        /// <summary>
        /// Skips a specified number of source files in an enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of source files in the enumeration sequence to skip.</param>
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
        /// <param name="ppenum">Returns an <see cref="IDiaEnumSourceFiles"/> object that contains a duplicate of the enumerator. The source files are not duplicated, only the enumerator.</param>
        [PreserveSig]
        HResult Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSourceFiles ppenum);
    }
}
