namespace DIA
{
    public enum MachineType
    {
        Unknown = 0,

        /// <summary>
        /// Useful for indicating we want to interact with the host and not a WoW guest.
        /// </summary>
        Host = 0x0001,

        /// <summary>
        /// Intel 386.
        /// </summary>
        I386 = 0x014c,

        /// <summary>
        /// MIPS little-endian, 0x160 big-endian
        /// </summary>
        R3000 = 0x0162,

        /// <summary>
        /// MIPS little-endian
        /// </summary>
        R4000 = 0x0166,

        /// <summary>
        /// MIPS little-endian
        /// </summary>
        R10000 = 0x0168,

        /// <summary>
        /// MIPS little-endian WCE v2
        /// </summary>
        WCEMIPSV2 = 0x0169,

        /// <summary>
        /// Alpha_AXP
        /// </summary>
        Alpha = 0x0184,

        /// <summary>
        /// SH3 little-endian
        /// </summary>
        Sh3 = 0x01a2,

        Sh3Dsp = 0x01a3,

        /// <summary>
        /// SH3E little-endian
        /// </summary>
        Sh3e = 0x01a4,

        /// <summary>
        /// SH4 little-endian
        /// </summary>
        Sh4 = 0x01a6,

        /// <summary>
        /// SH5
        /// </summary>
        Sh5 = 0x01a8,

        /// <summary>
        /// ARM Little-Endian
        /// </summary>
        Arm = 0x01c0,

        /// <summary>
        /// ARM Thumb/Thumb-2 Little-Endian
        /// </summary>
        Thumb = 0x01c2,

        /// <summary>
        /// ARM Thumb-2 Little-Endian
        /// </summary>
        ArmNt = 0x01c4,

        Am33 = 0x01d3,

        /// <summary>
        /// IBM PowerPC Little-Endian
        /// </summary>
        PowerPc = 0x01F0,

        PowerPcFp = 0x01f1,

        /// <summary>
        /// Intel 64
        /// </summary>
        Ia64 = 0x0200,

        /// <summary>
        /// MIPS
        /// </summary>
        Mips16 = 0x0266,

        /// <summary>
        /// ALPHA64
        /// </summary>
        Alpha64 = 0x0284,

        /// <summary>
        /// MIPS
        /// </summary>
        MipsFpu = 0x0366,

        /// <summary>
        /// MIPS
        /// </summary>
        MipsFpu16 = 0x0466,

        Axp64 = Alpha64,

        /// <summary>
        /// Infineon
        /// </summary>
        TriCode = 0x0520,

        Cef = 0x0CEF,

        /// <summary>
        /// EFI Byte Code
        /// </summary>
        Ebc = 0x0EBC,

        /// <summary>
        /// AMD64 (K8)
        /// </summary>
        Amd64 = 0x8664,

        /// <summary>
        /// M32R little-endian
        /// </summary>
        M32R = 0x9041,

        /// <summary>
        /// ARM64 Little-Endian
        /// </summary>
        Arm64 = 0xAA64,

        Cee = 0xC0EE,
    }
}
