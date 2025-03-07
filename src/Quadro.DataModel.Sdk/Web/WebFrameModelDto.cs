﻿using Quadro.DataModel.Model;
using Quadro.Documents.UnitOfWork;


namespace Quadro.DataModel.Entities.Web
{
    public class WebFrameModelDto
	{
		public string? Description { get; set; }
		public List<FrameMessageDto> Messages { get; set; } = new List<FrameMessageDto>();
		public double PriceExVat { get; set; }
		public string Svg { get; set; } = null!;
        public UnitOfWork UnitOfWork { get; set; } = null!;
	}
}
