using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Visual
{
    public interface IColor
    {
        byte A { get; }
        byte R { get; }
        byte G { get; }
        byte B { get; }
        string Name { get; }
    }

    public class UniversalColor : IColor
    {
        public UniversalColor(string name)
        {
            this.Name = name;
        }

        public UniversalColor(byte a, byte r, byte g, byte b, string name)
        {
            A = a;
            R = r;
            G = g;
            B = b;
            Name = name;
        }

        public byte A { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public string Name { get; set; }

        public static UniversalColor FromKnownColor(System.Drawing.Color color)
        {
            return new UniversalColor(color.Name) { A = color.A, R = color.R, G = color.G, B = color.B };
        }
    }
}
