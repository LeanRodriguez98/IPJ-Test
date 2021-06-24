using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

interface ISaveLoad
{
	public BinaryWriter Save(BinaryWriter bw);
	public BinaryReader Load(BinaryReader br);
}

