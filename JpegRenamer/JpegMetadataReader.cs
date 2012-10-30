using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.ComponentModel;

namespace FileRenamer
{
	public static class JpegMetadataReader
	{
		public static string BuildFilenameFromMetadata(string filePath, string format, bool lowerCase)
		{
			if (string.IsNullOrEmpty(filePath)) return "";
			if (string.IsNullOrEmpty(format)) return "";
			
			var fileInfo = new FileInfo(filePath);
			if (!fileInfo.Exists) return "";

			var jpegProperties = Exif.ExifReader.Read(filePath);
			var fileProperties = new FileProperties(fileInfo);

			string originalFileName = fileInfo.Name;
			string newFileName = string.Empty;

			var formatSplit = format.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (string chunk in formatSplit)
			{
				if (jpegProperties.ContainsKey(chunk))
					newFileName += jpegProperties[chunk];
				else if (fileProperties.ContainsKey(chunk))
					newFileName += fileProperties[chunk];
				else
					newFileName += chunk;
			}

			// Check whether the file already ends with jpeg
			if (!newFileName.ToLower().EndsWith(".jpeg") && !newFileName.EndsWith(".jpg"))
				newFileName += originalFileName.ToLower().Substring(
					originalFileName.ToLower().LastIndexOf(".jp"), originalFileName.Length - originalFileName.ToLower().LastIndexOf(".jp"));

			return lowerCase ? newFileName.ToLower() : newFileName;
		}
	}

	/// <summary>
	/// A couple of file properties
	/// </summary>
	public class FileProperties : Dictionary<string, string>
	{
		public const string FILENAME = "Filename";
		public const string CREATION_DATE = "Creation date";
		public const string MODFICIATION_DATE = "Modification date";

		public FileProperties(FileInfo fi)
		{
			Add(FILENAME, fi.Name);
			Add(CREATION_DATE, fi.CreationTime.ToShortDateString() + " " + fi.CreationTime.ToShortTimeString());
			Add(MODFICIATION_DATE, fi.LastWriteTime.ToLongDateString() + " " + fi.LastWriteTime.ToShortTimeString());
		}
	}
}
