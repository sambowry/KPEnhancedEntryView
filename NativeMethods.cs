﻿using System;
using System.Runtime.InteropServices;

namespace KPEnhancedEntryView
{
	internal static class NativeMethods
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct SHFILEINFO
		{
			public IntPtr hIcon;
			public int iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		};

		[Flags]
		public enum SHGFI : uint
		{
			/// <summary>get icon</summary>
			Icon = 0x000000100,
			/// <summary>get display name</summary>
			DisplayName = 0x000000200,
			/// <summary>get type name</summary>
			TypeName = 0x000000400,
			/// <summary>get attributes</summary>
			Attributes = 0x000000800,
			/// <summary>get icon location</summary>
			IconLocation = 0x000001000,
			/// <summary>return exe type</summary>
			ExeType = 0x000002000,
			/// <summary>get system icon index</summary>
			SysIconIndex = 0x000004000,
			/// <summary>put a link overlay on icon</summary>
			LinkOverlay = 0x000008000,
			/// <summary>show icon in selected state</summary>
			Selected = 0x000010000,
			/// <summary>get only specified attributes</summary>
			Attr_Specified = 0x000020000,
			/// <summary>get large icon</summary>
			LargeIcon = 0x000000000,
			/// <summary>get small icon</summary>
			SmallIcon = 0x000000001,
			/// <summary>get open icon</summary>
			OpenIcon = 0x000000002,
			/// <summary>get shell size icon</summary>
			ShellIconSize = 0x000000004,
			/// <summary>pszPath is a pidl</summary>
			PIDL = 0x000000008,
			/// <summary>use passed dwFileAttribute</summary>
			UseFileAttributes = 0x000000010,
			/// <summary>apply the appropriate overlays</summary>
			AddOverlays = 0x000000020,
			/// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
			OverlayIndex = 0x000000040,
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CHARFORMAT2
		{
			public UInt32 cbSize;
			public UInt32 dwMask;
			public UInt32 dwEffects;
			public Int32 yHeight;
			public Int32 yOffset;
			public UInt32 crTextColor;
			public Byte bCharSet;
			public Byte bPitchAndFamily;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string szFaceName;

			public UInt16 wWeight;
			public UInt16 sSpacing;
			public Int32 crBackColor;
			public Int32 lcid;
			public UInt32 dwReserved;
			public Int16 sStyle;
			public Int16 wKerning;
			public Byte bUnderlineType;
			public Byte bAnimation;
			public Byte bRevAuthor;
			public Byte bReserved1;
		}

		public const int FILE_ATTRIBUTE_NORMAL = 0x80;

		public const int WM_USER = 0x400;  
		public const int EM_GETSCROLLPOS = WM_USER + 221;
		public const int EM_SETSCROLLPOS = WM_USER + 222;
		public const int EM_GETCHARFORMAT = WM_USER + 58;
		public const int EM_SETCHARFORMAT = WM_USER + 68;

		public const int SCF_SELECTION = 0x0001;

		public const uint CFM_LINK = 0x20;
		public const uint CFE_LINK = 0x20;

		[DllImport("shell32.dll")]
		public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, SHGFI uFlags);

		[DllImport("User32.dll")]
		public static extern int DestroyIcon(IntPtr hIcon);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, ref System.Drawing.Point lParam);

		[DllImport("User32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int nMsg, IntPtr wParam, IntPtr lParam);

	}
}
