using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mscoree
{
	// Token: 0x020002EC RID: 748
	[TypeIdentifier]
	[Guid("CB2F6722-AB3A-11D2-9C40-00C04FA30A3E")]
	[CompilerGenerated]
	[InterfaceType(1)]
	[ComImport]
	public interface ICorRuntimeHost
	{
		// Token: 0x06001364 RID: 4964
		void _VtblGap1_11();

		// Token: 0x06001365 RID: 4965
		[MethodImpl(MethodImplOptions.InternalCall)]
		void EnumDomains(out IntPtr hEnum);

		// Token: 0x06001366 RID: 4966
		[MethodImpl(MethodImplOptions.InternalCall)]
		void NextDomain([In] IntPtr hEnum, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);

		// Token: 0x06001367 RID: 4967
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CloseEnum([In] IntPtr hEnum);
	}
}
