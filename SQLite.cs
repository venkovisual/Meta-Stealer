using System;
using System.Linq;
using System.Text;

// Token: 0x0200000C RID: 12
public class SQLite
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x0600003C RID: 60 RVA: 0x0000869B File Offset: 0x0000689B
	public int RowLength
	{
		get
		{
			return this.Count();
		}
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00014A50 File Offset: 0x00012C50
	public SQLite(byte[] fileName)
	{
		this.object_0 = (from x in "0123468800"
		select Convert.ToByte((int)(x - '0'))).ToArray<byte>();
		this.object_1 = fileName;
		this.ulong_1 = this.method_2(16U, 2U);
		this.ulong_0 = this.method_2(56U, 4U);
		this.method_0(100L);
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00014ACC File Offset: 0x00012CCC
	public string GatherValue(int rowIndex, string fieldName)
	{
		string result;
		try
		{
			int num = -1;
			int num2 = this.Fields.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (this.Fields[i].ToLower().Trim().CompareTo(fieldName.ToLower().Trim()) == 0)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				result = this.ReadContextValue(rowIndex, num);
			}
			else
			{
				result = null;
			}
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00014B44 File Offset: 0x00012D44
	private void method_0(long offset)
	{
		try
		{
			byte b = this.object_1[(int)(checked((IntPtr)offset))];
			if (b != 5)
			{
				if (b == 13)
				{
					ulong num = this.method_2((uint)((int)offset + 3), 2U) - 1UL;
					int num2 = 0;
					if (this.object_2 != null)
					{
						num2 = this.object_2.Length;
						this.object_2 = SQLite.ChangeSize<SME>(this.object_2, this.object_2.Length + (int)num + 1);
					}
					else
					{
						this.object_2 = new SME[num + 1UL];
					}
					for (ulong num3 = 0UL; num3 <= num; num3 += 1UL)
					{
						ulong num4 = this.method_2((uint)((int)offset + 8 + (int)num3 * 2), 2U);
						if (offset != 100L)
						{
							num4 += (ulong)offset;
						}
						int num5 = (int)this.method_3((uint)((int)num4));
						this.a((uint)((int)num4), (uint)num5);
						int num6 = (int)this.method_3((uint)((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL)));
						this.a((uint)((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL)), (uint)num6);
						ulong num7 = num4 + (ulong)((long)num6 - (long)num4 + 1L);
						int num8 = (int)this.method_3((uint)((int)num7));
						int num9 = num8;
						long num10 = this.a((uint)((int)num7), (uint)num8);
						long[] array = new long[5];
						for (int i = 0; i <= 4; i++)
						{
							int startIdx = num9 + 1;
							num9 = (int)this.method_3((uint)startIdx);
							array[i] = this.a((uint)startIdx, (uint)num9);
							array[i] = (long)((array[i] <= 9L) ? this.object_0[(int)(checked((IntPtr)array[i]))] : ((ulong)((SQLite.b(array[i]) == 0U) ? ((array[i] - 12L) / 2L) : ((array[i] - 13L) / 2L))));
						}
						if (this.ulong_0 == 1UL || this.ulong_0 == 2UL)
						{
							if (this.ulong_0 != 1UL)
							{
								if (this.ulong_0 == 2UL)
								{
									this.object_2[num2 + (int)num3].ItemName = Encoding.Unicode.GetString(this.object_1, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
								}
								else if (this.ulong_0 == 3UL)
								{
									this.object_2[num2 + (int)num3].ItemName = Encoding.BigEndianUnicode.GetString(this.object_1, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
								}
							}
							else
							{
								this.object_2[num2 + (int)num3].ItemName = Encoding.GetEncoding("wiArrayndows-12Array51".Replace("Array", string.Empty)).GetString(this.object_1, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
							}
						}
						this.object_2[num2 + (int)num3].RootNum = (long)this.method_2((uint)((int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2])), (uint)((int)array[3]));
						if (this.ulong_0 == 1UL)
						{
							this.object_2[num2 + (int)num3].SqlStatement = Encoding.GetEncoding("wiArrayndows-12Array51".Replace("Array", string.Empty)).GetString(this.object_1, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
						}
						else if (this.ulong_0 == 2UL)
						{
							this.object_2[num2 + (int)num3].SqlStatement = Encoding.Unicode.GetString(this.object_1, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
						}
						else if (this.ulong_0 == 3UL)
						{
							this.object_2[num2 + (int)num3].SqlStatement = Encoding.BigEndianUnicode.GetString(this.object_1, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
						}
					}
				}
			}
			else
			{
				uint num11 = (uint)(this.method_2((uint)((int)offset + 3), 2U) - 1UL);
				for (int j = 0; j <= (int)num11; j++)
				{
					uint num12 = (uint)this.method_2((uint)((int)offset + 12 + j * 2), 2U);
					if (offset != 100L)
					{
						this.method_0((long)((this.method_2((uint)((int)(offset + (long)((ulong)num12))), 4U) - 1UL) * this.ulong_1));
					}
					else
					{
						this.method_0((long)((this.method_2(num12, 4U) - 1UL) * this.ulong_1));
					}
				}
				this.method_0((long)((this.method_2((uint)((int)offset + 8), 4U) - 1UL) * this.ulong_1));
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000040 RID: 64 RVA: 0x0001507C File Offset: 0x0001327C
	public bool ReadContextTable(string tableName)
	{
		bool result;
		try
		{
			int num = -1;
			int i = 0;
			while (i <= this.object_2.Length)
			{
				if (string.Compare(this.object_2[i].ItemName.ToLower(), tableName.ToLower(), StringComparison.Ordinal) != 0)
				{
					i++;
				}
				else
				{
					num = i;
					IL_3D:
					if (num != -1)
					{
						string[] array = this.object_2[num].SqlStatement.Substring(this.object_2[num].SqlStatement.IndexOf('(') + 1).Split(new char[]
						{
							','
						});
						for (int j = 0; j <= array.Length - 1; j++)
						{
							array[j] = array[j].TrimStart(Array.Empty<char>());
							int num2 = array[j].IndexOf(' ');
							if (num2 > 0)
							{
								array[j] = array[j].Substring(0, num2);
							}
							if (array[j].IndexOf("UNIQUE", StringComparison.Ordinal) != 0)
							{
								this.Fields = SQLite.ChangeSize<string>(this.Fields, j + 1);
								this.Fields[j] = array[j];
							}
						}
						return this.method_1((ulong)((this.object_2[num].RootNum - 1L) * (long)this.ulong_1)) != 0U;
					}
					return false;
				}
			}
			goto IL_3D;
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000041 RID: 65 RVA: 0x000151D4 File Offset: 0x000133D4
	private uint method_1(ulong offset)
	{
		bool result;
		try
		{
			if (this.object_1[(int)(checked((IntPtr)offset))] == 13)
			{
				uint num = (uint)(this.method_2((uint)((int)offset + 3), 2U) - 1UL);
				if (num == 4294967295U)
				{
					return 0U;
				}
				int num2 = 0;
				if (this.object_3 != null)
				{
					num2 = this.object_3.Length;
					this.object_3 = SQLite.ChangeSize<GStruct0>(this.object_3, this.object_3.Length + (int)num + 1);
				}
				else
				{
					this.object_3 = new GStruct0[num + 1U];
				}
				for (uint num3 = 0U; num3 <= num; num3 += 1U)
				{
					ulong num4 = this.method_2((uint)((int)offset + 8 + (int)(num3 * 2U)), 2U);
					if (offset != 100UL)
					{
						num4 += offset;
					}
					int num5 = (int)this.method_3((uint)((int)num4));
					this.a((uint)((int)num4), (uint)num5);
					int num6 = (int)this.method_3((uint)((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL)));
					this.a((uint)((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL)), (uint)num6);
					ulong num7 = num4 + (ulong)((long)num6 - (long)num4 + 1L);
					int num8 = (int)this.method_3((uint)((int)num7));
					int num9 = num8;
					long num10 = this.a((uint)((int)num7), (uint)num8);
					RecordHeaderField[] array = null;
					long num11 = (long)(num7 - (ulong)((long)num8) + 1UL);
					int num12 = 0;
					while (num11 < num10)
					{
						array = SQLite.ChangeSize<RecordHeaderField>(array, num12 + 1);
						int num13 = num9 + 1;
						num9 = (int)this.method_3((uint)num13);
						array[num12].Type = this.a((uint)num13, (uint)num9);
						array[num12].Size = (long)((array[num12].Type <= 9L) ? this.object_0[(int)(checked((IntPtr)array[num12].Type))] : ((ulong)((SQLite.b(array[num12].Type) == 0U) ? ((array[num12].Type - 12L) / 2L) : ((array[num12].Type - 13L) / 2L))));
						num11 = num11 + (long)(num9 - num13) + 1L;
						num12++;
					}
					if (array != null)
					{
						this.object_3[num2 + (int)num3].Content = new string[array.Length];
						int num14 = 0;
						for (int i = 0; i <= array.Length - 1; i++)
						{
							if (array[i].Type > 9L)
							{
								if (SQLite.b(array[i].Type) != 0U)
								{
									this.object_3[num2 + (int)num3].Content[i] = Encoding.GetEncoding("wiArrayndows-12Array51".Replace("Array", string.Empty)).GetString(this.object_1, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].Size);
								}
								else if (this.ulong_0 == 1UL)
								{
									this.object_3[num2 + (int)num3].Content[i] = Encoding.GetEncoding("wiArrayndows-12Array51".Replace("Array", string.Empty)).GetString(this.object_1, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].Size);
								}
								else if (this.ulong_0 == 2UL)
								{
									this.object_3[num2 + (int)num3].Content[i] = Encoding.Unicode.GetString(this.object_1, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].Size);
								}
								else if (this.ulong_0 == 3UL)
								{
									this.object_3[num2 + (int)num3].Content[i] = Encoding.BigEndianUnicode.GetString(this.object_1, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].Size);
								}
							}
							else
							{
								this.object_3[num2 + (int)num3].Content[i] = Convert.ToString(this.method_2((uint)((int)(num7 + (ulong)num10 + (ulong)((long)num14))), (uint)((int)array[i].Size)));
							}
							num14 += (int)array[i].Size;
						}
					}
				}
			}
			else if (this.object_1[(int)(checked((IntPtr)offset))] == 5)
			{
				uint num15 = (uint)(this.method_2((uint)((int)(offset + 3UL)), 2U) - 1UL);
				for (uint num16 = 0U; num16 <= num15; num16 += 1U)
				{
					uint num17 = (uint)this.method_2((uint)((int)offset + 12 + (int)(num16 * 2U)), 2U);
					this.method_1((this.method_2((uint)((int)(offset + (ulong)num17)), 4U) - 1UL) * this.ulong_1);
				}
				this.method_1((this.method_2((uint)((int)(offset + 8UL)), 4U) - 1UL) * this.ulong_1);
			}
			result = true;
		}
		catch
		{
			result = false;
		}
		return result ? 1U : 0U;
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00015718 File Offset: 0x00013918
	public string ReadContextValue(int rowNum, int field)
	{
		string result;
		try
		{
			if (rowNum >= this.object_3.Length)
			{
				result = null;
			}
			else
			{
				result = ((field >= this.object_3[rowNum].Content.Length) ? null : this.object_3[rowNum].Content[field]);
			}
		}
		catch
		{
			result = "";
		}
		return result;
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00015780 File Offset: 0x00013980
	private ulong method_2(uint startIndex, uint size)
	{
		ulong result;
		try
		{
			if (size > 8U | size == 0U)
			{
				result = 0UL;
			}
			else
			{
				ulong num = 0UL;
				for (int i = 0; i <= (int)(size - 1U); i++)
				{
					num = (num << 8 | this.object_1[(int)(startIndex + (uint)i)]);
				}
				result = num;
			}
		}
		catch
		{
			result = 0UL;
		}
		return result;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x000086A3 File Offset: 0x000068A3
	public int Count()
	{
		return this.object_3.Length;
	}

	// Token: 0x06000045 RID: 69 RVA: 0x000157F0 File Offset: 0x000139F0
	private uint method_3(uint startIdx)
	{
		int result;
		try
		{
			if (startIdx > (uint)this.object_1.Length)
			{
				result = 0;
			}
			else
			{
				for (int i = (int)startIdx; i <= (int)(startIdx + 8U); i++)
				{
					if (i > this.object_1.Length - 1)
					{
						return 0U;
					}
					if ((this.object_1[i] & 128) != 128)
					{
						return (uint)i;
					}
				}
				result = (int)(startIdx + 8U);
			}
		}
		catch
		{
			result = 0;
		}
		return (uint)result;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00015864 File Offset: 0x00013A64
	private long a(uint startIdx, uint endIdx)
	{
		long result;
		try
		{
			endIdx += 1U;
			byte[] array = new byte[8];
			int num = (int)(endIdx - startIdx);
			bool flag = false;
			if (!(num == 0 | num > 9))
			{
				if (num != 1)
				{
					if (num == 9)
					{
						flag = true;
					}
					int num2 = 1;
					int num3 = 7;
					int num4 = 0;
					if (flag)
					{
						array[0] = this.object_1[(int)(endIdx - 1U)];
						endIdx -= 1U;
						num4 = 1;
					}
					for (int i = (int)(endIdx - 1U); i >= (int)startIdx; i += -1)
					{
						if (i - 1 >= (int)startIdx)
						{
							array[num4] = (byte)((this.object_1[i] >> (num2 - 1 & 31) & 255 >> num2) | this.object_1[i - 1] << (num3 & 31));
							num2++;
							num4++;
							num3--;
						}
						else if (!flag)
						{
							array[num4] = (byte)(this.object_1[i] >> (num2 - 1 & 31) & 255 >> num2);
						}
					}
					result = BitConverter.ToInt64(array, 0);
				}
				else
				{
					array[0] = (byte)(this.object_1[(int)startIdx] & 127);
					result = BitConverter.ToInt64(array, 0);
				}
			}
			else
			{
				result = 0L;
			}
		}
		catch
		{
			result = 0L;
		}
		return result;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x000086AD File Offset: 0x000068AD
	private static uint b(long value)
	{
		return ((value & 1L) == 1L) ? 1U : 0U;
	}

	// Token: 0x06000048 RID: 72 RVA: 0x000159A4 File Offset: 0x00013BA4
	public static T[] ChangeSize<T>(T[] oldArray, int newSize)
	{
		T[] result = oldArray;
		Array.Resize<T>(ref result, newSize);
		return result;
	}

	// Token: 0x0400002C RID: 44
	private readonly object object_0;

	// Token: 0x0400002D RID: 45
	private readonly ulong ulong_0;

	// Token: 0x0400002E RID: 46
	private readonly object object_1;

	// Token: 0x0400002F RID: 47
	private readonly ulong ulong_1;

	// Token: 0x04000030 RID: 48
	public string[] Fields;

	// Token: 0x04000031 RID: 49
	private object object_2;

	// Token: 0x04000032 RID: 50
	private object object_3;
}
