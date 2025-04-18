using Quadro.Documents.Attributes;
using Quadro.Interface.Images;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Entities.Images
{
	public class ImageDto : StorableGuid, IImageEntity
	{
		public string Name { get; set; } = string.Empty;
		public string OriginalFileName { get; set; } = string.Empty;
        public ImageType Type { get; set; }

		[Image]
		public string Data { get; set; } = string.Empty;
		public int Width { get; set; }
		public int Height { get; set; }
	}
}
