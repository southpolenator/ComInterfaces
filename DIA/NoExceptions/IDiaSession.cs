using System;
using System.Runtime.InteropServices;

namespace DIA.NoExceptions
{
    /// <summary>
    /// Provides a query context for debug symbols.
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2F609EE1-D1C8-4E24-8288-3326BADCD211")]
    public interface IDiaSession
    {
        /// <summary>
        /// Gets or sets the load address for the executable file that corresponds to the symbols in this symbol store.
        /// </summary>
        [DispId(1)]
        ulong loadAddress { get; set; }

        /// <summary>
        /// Retrieves a reference to the global scope.
        /// </summary>
        [DispId(2)]
        IDiaSymbol globalScope
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            get;
        }

        /// <summary>
        /// Retrieves an enumerator for all tables contained in the symbol store.
        /// </summary>
        /// <param name="ppEnumTables">Returns an <see cref="IDiaEnumTables"/> object. Use this interface to enumerate the tables in the symbol store.</param>
        [PreserveSig]
        HResult getEnumTables(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumTables ppEnumTables);

        /// <summary>
        /// Retrieves an enumerator that finds symbols in the order of their addresses.
        /// </summary>
        /// <param name="ppEnumbyAddr">Returns an <see cref="IDiaEnumSymbolsByAddr"/> object. Use this interface to search for symbols in the symbol store by memory location.</param>
        [PreserveSig]
        HResult getSymbolsByAddr(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbolsByAddr ppEnumbyAddr);

        /// <summary>
        /// Retrieves all children of a specified parent identifier that match the name and symbol type.
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent. If this parent symbol is a function, module, or block, then its lexical children are returned in ppResult. If the parent symbol is a type, then its class children are returned. If this parameter is <c>null</c>, then symtag must be set to <see cref="SymTagEnum.Exe"/> or <see cref="SymTagEnum.Null"/>, which returns the global scope (.exe file).</param>
        /// <param name="symTag">Specifies the symbol tag of the children to be retrieved. Values are taken from the <see cref="SymTagEnum"/> enumeration. Set to <see cref="SymTagEnum.Null"/> to retrieve all children.</param>
        /// <param name="name">Specifies the name of the children to be retrieved. Set to <c>null</c> for all children to be retrieved.</param>
        /// <param name="compareFlags">Specifies the comparison options applied to name matching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of child symbols retrieved.</param>
        [PreserveSig]
        HResult findChildren(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves the children of a specified parent identifier that match the name and symbol type. The local symbols that are returned include live range information, if the program is compiled with optimization on.
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent. If this parent symbol is a function, module, or block, then its lexical children are returned in ppResult. If the parent symbol is a type, then its class children are returned. If this parameter is <c>null</c>, then symtag must be set to <see cref="SymTagEnum.Exe"/> or <see cref="SymTagEnum.Null"/>, which returns the global scope (.exe file).</param>
        /// <param name="symTag">Specifies the symbol tag of the children to be retrieved. Values are taken from the <see cref="SymTagEnum"/> enumeration. Set to <see cref="SymTagEnum.Null"/> to retrieve all children.</param>
        /// <param name="name">Specifies the name of the children to be retrieved. Set to <c>null</c> for all children to be retrieved.</param>
        /// <param name="compareFlags">Specifies the comparison options applied to name matching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of child symbols retrieved.</param>
        [PreserveSig]
        HResult findChildrenEx(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves the children of a specified parent identifier that are valid at a specified address.
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent. If this parent symbol is a function, module, or block, then its lexical children are returned in ppResult. If the parent symbol is a type, then its class children are returned. If this parameter is <c>null</c>, then symtag must be set to <see cref="SymTagEnum.Exe"/> or <see cref="SymTagEnum.Null"/>, which returns the global scope (.exe file).</param>
        /// <param name="symTag">Specifies the symbol tag of the children to be retrieved. Values are taken from the <see cref="SymTagEnum"/> enumeration. Set to <see cref="SymTagEnum.Null"/> to retrieve all children.</param>
        /// <param name="name">Specifies the name of the children to be retrieved. Set to <c>null</c> for all children to be retrieved.</param>
        /// <param name="compareFlags">Specifies the comparison options applied to name matching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="isect">Specifies the section component of the address.</param>
        /// <param name="offset">Specifies the offset component of the address.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of child symbols retrieved.</param>
        [PreserveSig]
        HResult findChildrenExByAddr(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] NameSearchOptions compareFlags,
            [In] uint isect,
            [In] uint offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves the children of a specified parent identifier that are valid at a specified virtual address.
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent. If this parent symbol is a function, module, or block, then its lexical children are returned in ppResult. If the parent symbol is a type, then its class children are returned. If this parameter is <c>null</c>, then symtag must be set to <see cref="SymTagEnum.Exe"/> or <see cref="SymTagEnum.Null"/>, which returns the global scope (.exe file).</param>
        /// <param name="symTag">Specifies the symbol tag of the children to be retrieved. Values are taken from the <see cref="SymTagEnum"/> enumeration. Set to <see cref="SymTagEnum.Null"/> to retrieve all children.</param>
        /// <param name="name">Specifies the name of the children to be retrieved. Set to <c>null</c> for all children to be retrieved.</param>
        /// <param name="compareFlags">Specifies the comparison options applied to name matching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="va">Specifies the virtual address. </param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of child symbols retrieved.</param>
        [PreserveSig]
        HResult findChildrenExByVA(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] NameSearchOptions compareFlags,
            [In] ulong va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves the children of a specified parent identifier that are valid at a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent. If this parent symbol is a function, module, or block, then its lexical children are returned in ppResult. If the parent symbol is a type, then its class children are returned. If this parameter is <c>null</c>, then symtag must be set to <see cref="SymTagEnum.Exe"/> or <see cref="SymTagEnum.Null"/>, which returns the global scope (.exe file).</param>
        /// <param name="symTag">Specifies the symbol tag of the children to be retrieved. Values are taken from the <see cref="SymTagEnum"/> enumeration. Set to <see cref="SymTagEnum.Null"/> to retrieve all children.</param>
        /// <param name="name">Specifies the name of the children to be retrieved. Set to <c>null</c> for all children to be retrieved.</param>
        /// <param name="compareFlags">Specifies the comparison options applied to name matching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="rva">Specifies the RVA.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of child symbols retrieved.</param>
        [PreserveSig]
        HResult findChildrenExByRVA(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] NameSearchOptions compareFlags,
            [In] uint rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified address.
        /// </summary>
        /// <param name="isect">Specifies the section component of the address.</param>
        /// <param name="offset">Specifies the offset component of the address.</param>
        /// <param name="symTag">Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        [PreserveSig]
        HResult findSymbolByAddr(
            [In] uint isect,
            [In] uint offset,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppResult);

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">Specifies the RVA.</param>
        /// <param name="symTag">Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        [PreserveSig]
        HResult findSymbolByRVA(
            [In] uint rva,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppResult);

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified virtual address.
        /// </summary>
        /// <param name="va">Specifies the virtual address.</param>
        /// <param name="symTag">Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        [PreserveSig]
        HResult findSymbolByVA(
            [In] ulong va,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppResult);

        /// <summary>
        /// Retrieves the symbol that contains a specified metadata token.
        /// </summary>
        /// <param name="token">Specifies the token.</param>
        /// <param name="symTag">Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        [PreserveSig]
        HResult findSymbolByToken(
            [In] uint token,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppResult);

        /// <summary>
        /// Checks to see if two symbols are equivalent.
        /// </summary>
        /// <param name="symbolA">The first <see cref="IDiaSymbol"/> object used in the comparison. </param>
        /// <param name="symbolB">The second <see cref="IDiaSymbol"/> object used in the comparison.</param>
        /// <returns>If the symbols are equivalent, returns <see cref="HResult.S_OK"/>; otherwise, returns <see cref="HResult.S_FALSE"/>, the symbols are not equivalent. Otherwise, return an error code.</returns>
        [PreserveSig]
        HResult symsAreEquiv(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol symbolA,
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol symbolB);

        /// <summary>
        /// Retrieves a symbol by its unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        [PreserveSig]
        HResult symbolById(
            [In] uint id,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppResult);

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified relative virtual address (RVA) and offset.
        /// </summary>
        /// <param name="rva">Specifies the RVA.</param>
        /// <param name="symTag">Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbol">Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <param name="displacement">Returns a value specifying an offset from the relative virtual address specified in rva.</param>
        [PreserveSig]
        HResult findSymbolByRVAEx(
            [In] uint rva,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol,
            [Out] out int displacement);

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified virtual address (VA) and offset.
        /// </summary>
        /// <param name="va">Specifies the VA.</param>
        /// <param name="symTag">Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbol">Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <param name="displacement">Returns a value specifying an offset from the relative virtual address specified in rva.</param>
        [PreserveSig]
        HResult findSymbolByVAEx(
            [In] ulong va,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol,
            [Out] out int displacement);

        /// <summary>
        /// Retrieves source files by compiland and name.
        /// </summary>
        /// <param name="pCompiland">An <see cref="IDiaSymbol"/> object representing the compiland to be used as a context for the search. Set this parameter to <c>null</c> to find source files in all compilands.</param>
        /// <param name="name">Specifies the name of the source file to be retrieved. Set this parameter to <c>null</c> for all source files to be retrieved.</param>
        /// <param name="compareFlags">Specifies the comparison options applied to name searching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumSourceFiles"/> object that contains a list of the source files retrieved.</param>
        [PreserveSig]
        HResult findFile(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol pCompiland,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSourceFiles ppResult);

        /// <summary>
        /// Retrieves a source file by source file identifier.
        /// </summary>
        /// <param name="uniqueId">Specifies the source file identifier.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaSourceFile"/> object that represents the source file retrieved.</param>
        [PreserveSig]
        HResult findFileById(
            [In] uint uniqueId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSourceFile ppResult);

        /// <summary>
        /// Retrieves line numbers within specified compiland and source file identifiers.
        /// </summary>
        /// <param name="compiland">An <see cref="IDiaSymbol"/> object representing the compiland. Use this interface as a context in which to search for the line numbers.</param>
        /// <param name="file">An <see cref="IDiaSourceFile"/> object representing the source file in which to search for the line numbers.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers retrieved.</param>
        [PreserveSig]
        HResult findLines(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol compiland,
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSourceFile file,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves the lines in a specified compiland that contain a specified address.
        /// </summary>
        /// <param name="seg">Specifies the section component of the specific address.</param>
        /// <param name="offset">Specifies the offset component of the specific address.</param>
        /// <param name="length">Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        [PreserveSig]
        HResult findLinesByAddr(
            [In] uint seg,
            [In] uint offset,
            [In] uint length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves the lines in a specified compiland that contain a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">Specifies the address as an RVA.</param>
        /// <param name="length">Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        [PreserveSig]
        HResult findLinesByRVA(
            [In] uint rva,
            [In] uint length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves the line number information for lines contained in a specified virtual address (VA) range.
        /// </summary>
        /// <param name="va">Specifies the address as a VA.</param>
        /// <param name="length">Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        [PreserveSig]
        HResult findLinesByVA(
            [In] ulong va,
            [In] uint length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Determines the line numbers of the compiland that the specified line number in a source file lies within or near.
        /// </summary>
        /// <param name="compiland">An <see cref="IDiaSymbol"/> object that represents the compiland in which to search for the line numbers. This parameter cannot be <c>null</c>.</param>
        /// <param name="file">An <see cref="IDiaSourceFile"/> object that represents the source file to search in. This parameter cannot be <c>null</c>.</param>
        /// <param name="linenum">Specifies a one-based line number.</param>
        /// <param name="column">Specifies the column number. Use zero to specify all columns. A column is a byte offset into a line.</param>
        /// <returns>Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers retrieved.</returns>
        [PreserveSig]
        HResult findLinesByLinenum(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol compiland,
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSourceFile file,
            [In] uint linenum,
            [In] uint column,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves a list of sources that has been placed into the symbol store by attribute providers or other components of the compilation process.
        /// </summary>
        /// <param name="srcFile">Name of the source file for which to search.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumInjectedSources"/> object that contains a list of all of the injected sources.</param>
        [PreserveSig]
        HResult findInjectedSource(
            [In, MarshalAs(UnmanagedType.LPWStr)] string srcFile,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumInjectedSources ppResult);

        /// <summary>
        /// Retrieves an enumerated sequence of debug data streams.
        /// </summary>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumDebugStreams"/> object that contains a list of debug streams.</param>
        [PreserveSig]
        HResult getEnumDebugStreams(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumDebugStreams ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a given address.
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent.</param>
        /// <param name="isect">Specifies the section component of the address.</param>
        /// <param name="offset">Specifies the offset component of the address.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of frames that are retrieved.</param>
        [PreserveSig]
        HResult findInlineFramesByAddr(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] uint isect,
            [In] uint offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent.</param>
        /// <param name="rva">Specifies the address as an RVA.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of frames that are retrieved.</param>
        [PreserveSig]
        HResult findInlineFramesByRVA(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] uint rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified virtual address (VA).
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent.</param>
        /// <param name="va">Specifies the address as a VA.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of frames that are retrieved.</param>
        [PreserveSig]
        HResult findInlineFramesByVA(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] ulong va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol.
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains the list of line numbers that are retrieved.</param>
        [PreserveSig]
        HResult findInlineeLines(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified address range.
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent.</param>
        /// <param name="isect">Specifies the section component of the address.</param>
        /// <param name="offset">Specifies the offset component of the address.</param>
        /// <param name="length">Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains the list of line numbers that are retrieved.</param>
        [PreserveSig]
        HResult findInlineeLinesByAddr(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] uint isect,
            [In] uint offset,
            [In] uint length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified relative virtual address (RVA).
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent.</param>
        /// <param name="rva">Specifies the address as an RVA.</param>
        /// <param name="length">Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains the list of line numbers that are retrieved.</param>
        [PreserveSig]
        HResult findInlineeLinesByRVA(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] uint rva,
            [In] uint length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified virtual address (VA).
        /// </summary>
        /// <param name="parent">An <see cref="IDiaSymbol"/> object representing the parent.</param>
        /// <param name="va">Specifies the address as a VA.</param>
        /// <param name="length">Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains the list of line numbers that are retrieved.</param>
        [PreserveSig]
        HResult findInlineeLinesByVA(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol parent,
            [In] ulong va,
            [In] uint length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in the specified source file and line number.
        /// </summary>
        /// <param name="compiland">An <see cref="IDiaSymbol"/> object that represents the compiland in which to search for the line numbers. This parameter cannot be <c>null</c>.</param>
        /// <param name="file">An <see cref="IDiaSourceFile"/> object that represents the source file to search in. This parameter cannot be <c>null</c>.</param>
        /// <param name="linenum">Specifies a one-based line number.</param>
        /// <param name="column">Specifies the column number. Use zero to specify all columns. A column is a byte offset into a line.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers that were retrieved.</param>
        [PreserveSig]
        HResult findInlineeLinesByLinenum(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol compiland,
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSourceFile file,
            [In] uint linenum,
            [In] uint column,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all inlined functions that match a specified name.
        /// </summary>
        /// <param name="name">Specifies the name to use for comparison.</param>
        /// <param name="option">Specifies the comparison options applied to name searching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers that were retrieved.</param>
        [PreserveSig]
        HResult findInlineesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] NameSearchOptions option,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="va">Specifies the virtual address of the address to obtain.</param>
        /// <param name="pISect">Returns the section component of the address.</param>
        /// <param name="pOffset">Returns the offset component of the address.</param>
        /// <returns>If successful, returns <see cref="HResult.S_OK"/>; otherwise, returns an error code.</returns>
        [PreserveSig]
        HResult addressForVA(
            [In] ulong va,
            [Out] out uint pISect,
            [Out] out uint pOffset);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="rva">Specifies the relative virtual address of the address to obtain.</param>
        /// <param name="pISect">Returns the section component of the address.</param>
        /// <param name="pOffset">Returns the offset component of the address.</param>
        /// <returns>If successful, returns <see cref="HResult.S_OK"/>; otherwise, returns an error code.</returns>
        [PreserveSig]
        HResult addressForRVA(
            [In] uint rva,
            [Out] out uint pISect,
            [Out] out uint pOffset);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="isect">Specifies the section component of the address.</param>
        /// <param name="offset">Specifies the offset component of the address.</param>
        /// <param name="length">Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        [PreserveSig]
        HResult findILOffsetsByAddr(
            [In] uint isect,
            [In] uint offset,
            [In] uint length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="rva">Specifies the address as an RVA.</param>
        /// <param name="length">Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        [PreserveSig]
        HResult findILOffsetsByRVA(
            [In] uint rva,
            [In] uint length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="va">Specifies the address as an VA.</param>
        /// <param name="length">Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResult">Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        [PreserveSig]
        HResult findILOffsetsByVA(
            [In] ulong va,
            [In] uint length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult findInputAssemblyFiles(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumInputAssemblyFiles ppResult);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult findInputAssembly(
            [In] uint index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult findInputAssemblyById(
            [In] uint uniqueId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult getFuncMDTokenMapSize(
            [Out] out uint mapSize);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult getFuncMDTokenMap(
            [In] uint cb,
            [Out] out uint pcb,
            [Out] out byte pb);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult getTypeMDTokenMapSize(
            [Out] out uint mapSize);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult getTypeMDTokenMap(
            [In] uint cb,
            [Out] out uint pcb,
            [Out] out byte pb);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult getNumberOfFunctionFragments_VA(
            [In] ulong vaFunc,
            [In] uint cbFunc,
            [Out] out uint count);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult getNumberOfFunctionFragments_RVA(
            [In] uint rvaFunc,
            [In] uint cbFunc,
            [Out] out uint count);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult getFunctionFragments_VA(
            [In] ulong vaFunc,
            [In] uint cbFunc,
            [In] uint cFragments,
            [Out] out ulong pVaFragment,
            [Out] out uint pLenFragment);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult getFunctionFragments_RVA(
            [In] uint rvaFunc,
            [In] uint cbFunc,
            [In] uint cFragments,
            [Out] out uint pRvaFragment,
            [Out] out uint pLenFragment);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult getExports(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult getHeapAllocationSites(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        [PreserveSig]
        HResult findInputAssemblyFile(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaSymbol pSymbol,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);
    }
}
