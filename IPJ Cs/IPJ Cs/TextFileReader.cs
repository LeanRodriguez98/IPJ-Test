using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class TextFileReader
{
	public static List<string> ReadTextFile(string filePath) 
	{
		List<string> outputs = new List<string>();
		outputs.AddRange(File.ReadAllLines(filePath));
		return outputs;
	}
}
