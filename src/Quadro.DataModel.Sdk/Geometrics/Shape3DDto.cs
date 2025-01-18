using CPBase.Geo.Media;
using CPBase.Geo.Media.ThreeD;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Shape3DDto : StorableGuid
    {
        public Point3DDto StartPoint { get; set; } = null!;
        public Point3DDto EndPoint { get; set; } = null!;
        public bool IsArc { get; set; }

        public Point3DDto? CenterPoint { get; set; }
        public Vector3DDto? Normal { get; set; }
        public double? Radius { get; set; }
        public bool? IsCcw { get; set; }
        public bool? IsLargeArc { get; set; }

        public static Shape3DDto FromShape3D(Shape3D shape)
        {
            
            if (shape is Arc3D arc)
            {
                var result = new Shape3DDto()
                {
                    StartPoint = Point3DDto.FromPoint3D(arc.StartPoint),
                    EndPoint = Point3DDto.FromPoint3D(arc.EndPoint),
                    CenterPoint = Point3DDto.FromPoint3D(arc.CenterPoint),
                    Normal = Vector3DDto.FromVector3D(arc.Normal),
                    Radius = arc.Radius,
                    IsCcw = arc.IsCcw,
                    IsLargeArc = arc.IsLargeArc,
                    IsArc = true,
                };
                return result;
            }
            else if (shape is Line3D line)
            {
                var result = new Shape3DDto()
                {
                    StartPoint = Point3DDto.FromPoint3D(line.StartPoint),
                    EndPoint = Point3DDto.FromPoint3D(line.EndPoint),
                    IsArc = false,
                };
                return result;
            }
            throw new NotImplementedException();
        }

        public Shape3D ToShape3D()
        {
            if (IsArc)
            {
                var result = new Arc3D(StartPoint.ToPoint3D(), EndPoint.ToPoint3D(), CenterPoint!.ToPoint3D(), IsCcw == true, Normal!.ToVector3D());
                return result;
            }
            else
            {
                var result = new Line3D(StartPoint.ToPoint3D(), EndPoint.ToPoint3D());
                return result;
            }
        }
    }


}
