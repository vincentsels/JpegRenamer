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
		public static Dictionary<string, string> GetMetadataForJpeg(string filePath)
		{
			return Exif.ExifReader.Read(filePath);
		}

		public static string BuildFilenameFromMetadata(string originalFileName, string format, 
			Dictionary<string, string> jpegProperties, bool lowerCase)
		{
			if (string.IsNullOrEmpty(format)) return "";
			if (jpegProperties == null || jpegProperties.Count == 0) return "";

			var splitFormat = format.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
			string newFileName = string.Empty;
			foreach (string chunk in splitFormat)
				newFileName += (jpegProperties.ContainsKey(chunk) ? jpegProperties[chunk] : chunk);

			// Check whether the file already ends with jpeg
			if (!newFileName.ToLower().EndsWith(".jpeg") && !newFileName.EndsWith(".jpg") &&
				!string.IsNullOrEmpty(originalFileName))
				newFileName += originalFileName.ToLower().Substring(
					originalFileName.ToLower().LastIndexOf(".jp"), originalFileName.Length - originalFileName.ToLower().LastIndexOf(".jp"));

			return lowerCase ? newFileName.ToLower() : newFileName;
		}
	}
}
