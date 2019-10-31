using System;
using System.Runtime.InteropServices;

namespace DIA.NoExceptions
{
    /// <summary>
    /// Provides methods to do a stack walk using information in the .pdb file.
    /// </summary>
    [ComImport, Guid("5485216B-A54C-469F-9670-52B24D5229BB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDiaStackWalker
    {
        /// <summary>
        /// Retrieves a stack frame enumerator for x86 platforms.
        /// </summary>
        /// <param name="pHelper">The helper <see cref="IDiaStackWalkHelper"/> object.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumStackFrames"/> object that contains a list of <see cref="IDiaStackFrame"/> objects.</param>
        [PreserveSig]
        HResult getEnumFrames(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaStackWalkHelper pHelper,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumStackFrames ppResult);

        /// <summary>
        /// Retrieves a stack frame enumerator for a specific platform type.
        /// </summary>
        /// <param name="cpuid">A value from the <see cref="CV_CPU_TYPE_e"/> enumeration, specifying the platform type.</param>
        /// <param name="pHelper">The helper <see cref="IDiaStackWalkHelper"/> object.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumStackFrames"/> object that contains a list of <see cref="IDiaStackFrame"/> objects.</param>
        [PreserveSig]
        HResult getEnumFrames2(
            [In] CV_CPU_TYPE_e cpuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDiaStackWalkHelper pHelper,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumStackFrames ppResult);
    }
}
