using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Exif
{
	public static class ExifReader
	{
		#region Public Methods
		public static Dictionary<string, string> Read(string filePath)
		{
			var propertyItems = new List<PropertyItem>();
			var exifProperties = new ExifProperties();
			var jpegProperties = new Dictionary<string, string>();

			foreach (string exifProperty in exifProperties.Values)
				jpegProperties.Add(exifProperty, string.Empty);

			using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			{
				Image image = System.Drawing.Image.FromStream(stream, true, false);
				propertyItems.AddRange(image.PropertyItems);
			}

			foreach (var property in propertyItems)
			{
				if (!exifProperties.ContainsKey(property.Id)) continue;

				string propertyName = exifProperties[property.Id];
				string propertyValue = string.Empty;

				if (property.Type == 0x1)
				{
					propertyValue = property.Value[0].ToString().TrimEnd('\0');
				}
				else if (property.Type == 0x2)
				{
					// 2 = ASCII
					// An 8-bit byte containing one 7-bit ASCII code. The final byte is terminated with null.
					propertyValue = Encoding.ASCII.GetString(property.Value).TrimEnd('\0');
				}
				else if (property.Type == 0x3)
				{
					// 3 = unsigned short
					switch (property.Id)
					{
						case 0x8827: // ISO
							propertyValue = "ISO-" + ConvertToUInt16(property.Value).ToString();
							break;
						case 0xA217: // sensing method
							{
								switch (ConvertToUInt16(property.Value))
								{
									case 1: propertyValue = "Not defined"; break;
									case 2: propertyValue = "One-chip color area sensor"; break;
									case 3: propertyValue = "Two-chip color area sensor"; break;
									case 4: propertyValue = "Three-chip color area sensor"; break;
									case 5: propertyValue = "Color sequential area sensor"; break;
									case 7: propertyValue = "Trilinear sensor"; break;
									case 8: propertyValue = "Color sequential linear sensor"; break;
									default: propertyValue = " reserved"; break;
								}
							}
							break;
						case 0x8822: // aperture 
							switch (ConvertToUInt16(property.Value))
							{
								case 0: propertyValue = "Not defined"; break;
								case 1: propertyValue = "Manual"; break;
								case 2: propertyValue = "Normal program"; break;
								case 3: propertyValue = "Aperture priority"; break;
								case 4: propertyValue = "Shutter priority"; break;
								case 5: propertyValue = "Creative program (biased toward depth of field)"; break;
								case 6: propertyValue = "Action program (biased toward fast shutter speed)"; break;
								case 7: propertyValue = "Portrait mode (for closeup photos with the background out of focus)"; break;
								case 8: propertyValue = "Landscape mode (for landscape photos with the background in focus)"; break;
								default: propertyValue = "reserved"; break;
							}
							break;
						case 0x9207: // metering mode
							switch (ConvertToUInt16(property.Value))
							{
								case 0: propertyValue = "unknown"; break;
								case 1: propertyValue = "Average"; break;
								case 2: propertyValue = "CenterWeightedAverage"; break;
								case 3: propertyValue = "Spot"; break;
								case 4: propertyValue = "MultiSpot"; break;
								case 5: propertyValue = "Pattern"; break;
								case 6: propertyValue = "Partial"; break;
								case 255: propertyValue = "Other"; break;
								default: propertyValue = "reserved"; break;
							}
							break;
						case 0x9208: // light source
							{
								switch (ConvertToUInt16(property.Value))
								{
									case 0: propertyValue = "unknown"; break;
									case 1: propertyValue = "Daylight"; break;
									case 2: propertyValue = "Fluorescent"; break;
									case 3: propertyValue = "Tungsten"; break;
									case 17: propertyValue = "Standard light A"; break;
									case 18: propertyValue = "Standard light B"; break;
									case 19: propertyValue = "Standard light C"; break;
									case 20: propertyValue = "D55"; break;
									case 21: propertyValue = "D65"; break;
									case 22: propertyValue = "D75"; break;
									case 255: propertyValue = "other"; break;
									default: propertyValue = "reserved"; break;
								}
							}
							break;
						case 0x9209:
							{
								switch (ConvertToUInt16(property.Value))
								{
									case 0: propertyValue = "Flash did not fire"; break;
									case 1: propertyValue = "Flash fired"; break;
									case 5: propertyValue = "Strobe return light not detected"; break;
									case 7: propertyValue = "Strobe return light detected"; break;
									default: propertyValue = "reserved"; break;
								}
							}
							break;
						default:
							propertyValue = ConvertToUInt16(property.Value).ToString();
							break;
					}
				}
				else if (property.Type == 0x4)
				{
					// 4 = unsigned int
					propertyValue = ConvertToUInt32(property.Value).ToString();
				}
				else if (property.Type == 0x5)
				{
					// 5 = rational of two unsigned ints
					byte[] n = new byte[property.Len / 2];
					byte[] d = new byte[property.Len / 2];
					Array.Copy(property.Value, 0, n, 0, property.Len / 2);
					Array.Copy(property.Value, property.Len / 2, d, 0, property.Len / 2);
					uint a = ConvertToUInt32(n);
					uint b = ConvertToUInt32(d);
					Rational r = new Rational(a, b);

					switch (property.Id)
					{
						case 0x9202: // aperture
							propertyValue = "F/" + Math.Round(Math.Pow(Math.Sqrt(2), r.ToDouble()), 2).ToString();
							break;
						case 0x920A:
							propertyValue = r.ToDouble().ToString();
							break;
						case 0x829A:
							propertyValue = r.ToDouble().ToString();
							break;
						case 0x829D: // F-number
							propertyValue = "F/" + r.ToDouble().ToString();
							break;
						default:
							propertyValue = r.ToString("/");
							break;
					}

				}
				else if (property.Type == 0x7)
				{
					// 7 = undefined 
					// A byte that can take any value depending on the field
					switch (property.Id)
					{
						case 0xA300:
							{
								if (property.Value[0] == 3)
								{
									propertyValue = "DSC";
								}
								else
								{
									propertyValue = "reserved";
								}
								break;
							}
						case 0xA301:
							if (property.Value[0] == 1)
								propertyValue = "A directly photographed image";
							else
								propertyValue = "Not a directly photographed image";
							break;
						default:
							propertyValue = "-";
							break;
					}
				}
				else if (property.Type == 0x9)
				{
					// 9 = signed int
					propertyValue = ConvertToInt32(property.Value).ToString();
				}
				else if (property.Type == 0xA)
				{
					// 10 = rational of two signed ints
					byte[] n = new byte[property.Len / 2];
					byte[] d = new byte[property.Len / 2];
					Array.Copy(property.Value, 0, n, 0, property.Len / 2);
					Array.Copy(property.Value, property.Len / 2, d, 0, property.Len / 2);
					int a = ConvertToInt32(n);
					int b = ConvertToInt32(d);
					Rational r = new Rational(a, b);

					switch (property.Id)
					{
						case 0x9201: // shutter speed
							propertyValue = "1/" + Math.Round(Math.Pow(2, r.ToDouble()), 2).ToString();
							break;
						case 0x9203:
							propertyValue = Math.Round(r.ToDouble(), 4).ToString();
							break;
						default:
							propertyValue = r.ToString("/");
							break;
					}
				}

				jpegProperties[propertyName] = propertyValue;
			}

			return jpegProperties;
		}
		#endregion

		#region Private Methods
		private static int ConvertToInt32(byte [] arr)
		{
			if(arr.Length != 4 )
				return 0;
			else
				return arr[3] << 24 | arr[2] << 16 | arr[1] << 8 | arr[0];
		}

		private static uint ConvertToUInt32(byte [] arr)
		{
			if(arr.Length != 4 )
				return 0;
			else
				return Convert.ToUInt32(arr[3] << 24 | arr[2] << 16 | arr[1] << 8 | arr[0]);
		}

		private static uint ConvertToUInt16(byte [] arr)
		{
			if(arr.Length != 2 )
				return 0;
			else
				return Convert.ToUInt16(arr[1] << 8 | arr[0]);
		}
		#endregion

		internal class Rational
		{
			private int n;
			private int d;

			public Rational(int n, int d)
			{
				this.n = n;
				this.d = d;
				simplify(ref this.n, ref this.d);
			}

			public Rational(uint n, uint d)
			{
				this.n = Convert.ToInt32(n);
				this.d = Convert.ToInt32(d);

				simplify(ref this.n, ref this.d);
			}

			public Rational()
			{
				this.n = this.d = 0;
			}

			public string ToString(string sp)
			{
				if (sp == null) sp = "/";
				return n.ToString() + sp + d.ToString();
			}

			public double ToDouble()
			{
				if (d == 0)
					return 0.0;

				return Math.Round(Convert.ToDouble(n) / Convert.ToDouble(d), 2);
			}

			private void simplify(ref int a, ref int b)
			{
				if (a == 0 || b == 0)
					return;

				int gcd = euclid(a, b);
				a /= gcd;
				b /= gcd;
			}

			private int euclid(int a, int b)
			{
				if (b == 0)
					return a;
				else
					return euclid(b, a % b);
			}
		}
	}
}
