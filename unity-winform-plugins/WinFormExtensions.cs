using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

/// <summary>
/// WinForm扩展方法
/// .net3.5框架才支持这种扩展方法
/// </summary>
public static class WinFormExtensions
{
	public static void AppendNewLine(this TextBox textBox, string text,params object[] args)
	{
		string newText = args == null || args.Length < 1 ? text : string.Format(text, args);
		if (!string.IsNullOrEmpty(textBox.Text))
			textBox.AppendText(string.Concat("\r\n",newText));
		else
			textBox.AppendText(newText);
	}

}

