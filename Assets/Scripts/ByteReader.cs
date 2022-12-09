using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ByteReader
{
	byte[] mBuffer;
	int mOffset = 0;


	static string ReadLine(byte[] buffer, int start, int count)
	{
		return Encoding.UTF8.GetString(buffer, start, count);
	}
	public string ReadLine() { return ReadLine(true); }

    private string ReadLine(bool skipEmptyLines)
    {
		int max = mBuffer.Length;

		// Skip empty characters
		if (skipEmptyLines)
		{
			while (mOffset < max && mBuffer[mOffset] < 32) ++mOffset;
		}

		int end = mOffset;

		if (end < max)
		{
			for (; ; )
			{
				if (end < max)
				{
					int ch = mBuffer[end++];
					if (ch != '\n' && ch != '\r') continue;
				}
				else ++end;

				string line = ReadLine(mBuffer, mOffset, end - mOffset - 1);
				mOffset = end;
				return line;
			}
		}
		mOffset = max;
		return null;
	}

    public bool canRead { get { return (mBuffer != null && mOffset < mBuffer.Length); } }

	public ByteReader(byte[] bytes) { mBuffer = bytes; }
	public ByteReader(TextAsset asset) { mBuffer = asset.bytes; }

	public Dictionary<string,string> ReadDictionary()
    {
		Dictionary<string, string> dict = new Dictionary<string, string>();
		char[] separator = new char[] { '=' };

		while (canRead)
		{
			string line = ReadLine();
			if (line == null) break;
			if (line.StartsWith("//")) continue;

#if UNITY_FLASH
			string[] split = line.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
#else
			string[] split = line.Split(separator, 2, System.StringSplitOptions.RemoveEmptyEntries);
#endif

			if (split.Length == 2)
			{
				string key = split[0].Trim();
				string val = split[1].Trim().Replace("\\n", "\n");
				dict[key] = val;
			}
		}
		return dict;

	}
}
