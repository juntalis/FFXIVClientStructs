﻿using System;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe struct Hate
{
    [FieldOffset(0x00)] public fixed byte HateArray[0x08 * 32];
    [FieldOffset(0x100)] public int HateArrayLength;
    [FieldOffset(0x104)] public uint HateTargetId;

    public ReadOnlySpan<HateInfo> HateSpan
    {
        get
        {
            fixed (byte* ptr = HateArray)
            {
                return new ReadOnlySpan<HateInfo>(ptr, HateArrayLength);
            }
        }
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct HateInfo
{
    [FieldOffset(0x00)] public uint ObjectId;
    [FieldOffset(0x04)] public int Enmity;
}