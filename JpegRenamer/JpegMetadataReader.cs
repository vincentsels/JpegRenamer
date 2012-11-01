using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace FileRenamer
{
	public static class JpegMetadataReader
	{
		public static string BuildFilenameFromMetadata(FileInfo file, string format, bool replaceSpaces, string replaceSpacesWith, bool lowerCase)
		{
			if (file == null) return "";
			if (!file.Exists) return "";
			if (string.IsNullOrEmpty(format)) return "";

			Dictionary<string, string> jpegProperties;
			try
			{
				jpegProperties = Exif.ExifReader.Read(file.FullName);
			}
			catch (ArgumentException)
			{
				// In case the supplied file is not a valid jpeg, create an empty dictionary
				// with all possible properties but all empty values
				jpegProperties = new Exif.ExifProperties().ToDictionary(k => k.Key.ToString(), v => v.Value);
			}
			var fileProperties = new FileProperties(file);

			string originalFileName = file.Name;
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

			if (lowerCase)
				newFileName = newFileName.ToLower();
			if (replaceSpaces && replaceSpacesWith != null)
				newFileName = newFileName.Replace(" ", replaceSpacesWith);

			// Remove all invalid Windows filename characters
			newFileName = Regex.Replace(newFileName, @"[/?*:;{}""<>|\\]", "");

			return newFileName;
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
			Add(FILENAME, fi.Name.Substring(0, fi.Name.LastIndexOf(fi.Extension)));
			Add(CREATION_DATE, fi.CreationTime.ToShortDateString() + " " + fi.CreationTime.ToShortTimeString());
			Add(MODFICIATION_DATE, fi.LastWriteTime.ToShortDateString() + " " + fi.LastWriteTime.ToShortTimeString());
		}
	}
}
