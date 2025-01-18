namespace CPBase.Geo.Media.ThreeD
{

    public class Arc3D:Shape3D
    {

        private Point3D startpoint;
        private Point3D endpoint;
        private Point3D centerpoint;
        private double radius;
        private bool isCcw;
        private bool islargearc;
        private double anglediff;
        private Vector3D planenormal;
        private bool invalid;

        public override Point3D StartPoint => startpoint;

        public override Point3D EndPoint => endpoint;

        public Point3D CenterPoint => centerpoint;

        public double Radius => radius;

        public bool IsCcw => isCcw;

        public bool IsLargeArc => islargearc;

        public double SweepAngle
        {
            get
            {
                if (invalid)
                {
                    return 0.0;
                }

                double sweepangle = Math.Abs(anglediff);

                if (islargearc)
                {
                    sweepangle = 360.0 - sweepangle;
                }

                return sweepangle;
            }
        }

        public double ArcLength
        {
            get
            {
                if (invalid)
                {
                    return 0.0;
                }

                double arclength = Math.Abs(Math.PI * (anglediff / 180.0)) * radius;

                if (islargearc)
                {
                    arclength = (2 * Math.PI * radius) - arclength;
                }

                return arclength;
            }
        }

        public bool Invalid => invalid;

        public Vector3D Normal => planenormal;

        private void UpdateSweep()
        {

            //Vectors to center
            Vector3D v_c_s = Point3D.Subtract(startpoint, centerpoint);
            Vector3D v_c_e = Point3D.Subtract(endpoint, centerpoint);

            //Calculate angle and check if valid
            anglediff = Vector3D.AngleBetween(v_c_s, v_c_e);
            if (double.IsNaN(anglediff))
            {
                invalid = true;
            }

        }



        private void UpdateFromCenterPoint()
        {
            //Vectors to center
            Vector3D v_c_s = Point3D.Subtract(startpoint, centerpoint);
            Vector3D v_c_e = Point3D.Subtract(endpoint, centerpoint);

            //Radius
            radius = v_c_s.Length;


            //Calculate normal
            Vector3D v_c_s_n = v_c_s;
            v_c_s_n.Normalize();
            Vector3D v_c_e_n = v_c_e;
            v_c_e_n.Normalize();
            Vector3D v_normal = Vector3D.CrossProduct(v_c_s_n, v_c_e_n);
            v_normal.Normalize();

            //Rescue v_normal if not valid
            if (double.IsNaN(v_normal.Length))
            {
                v_normal = planenormal;
            }

            islargearc = !Math3D.VectorDirectionOpposite(planenormal, v_normal);

            if (isCcw)
            {
                islargearc = !islargearc;
            }


            UpdateSweep();

        }

        private void UpdateFromRadiusAndLargeArc()
        {

            //Make sure plane normal is normalized
            planenormal.Normalize();

            //Get vector from start to end
            Vector3D v_se = Point3D.Subtract(endpoint, startpoint);
            Vector3D v_se_half = Vector3D.Divide(v_se, 2.0);

            //Get midpoint between start and end (mid from straight line)
            Point3D p_mid_straight = Point3D.Add(startpoint, v_se_half);

            //Get vector between midpoint and center of circle, this is a 90 degree turn of v_se around the plane normal
            Vector3D v_mid_center = Math3D.RotateVector(v_se, planenormal, 90.0);
            v_mid_center.Normalize();

            //Get length between midpoint and center
            double d_mid_center = Math.Sqrt((Math.Pow(radius, 2.0) - v_se_half.LengthSquared));

            if (!double.IsNaN(d_mid_center))
            {
                //Turn around vector with XOR of direction and islargearc of this arc. Both options would turn this around
                if (!isCcw ^ islargearc)
                {
                    v_mid_center.Negate();
                }

                //Give v_mid_center the length of mid to center
                v_mid_center = Vector3D.Multiply(d_mid_center, v_mid_center);

                //Add to midpoint and find the center
                centerpoint = Point3D.Add(p_mid_straight, v_mid_center);
            }
            else
            {
                invalid = true;
            }

            UpdateSweep();
        }


        public Arc3D GetOffsetArc(double radiusoffset)
        {
            var startdir = startpoint - centerpoint;
            var enddir = endpoint - centerpoint;
            startdir.Normalize();
            enddir.Normalize();
            var newstart = centerpoint + (startdir * (radius + radiusoffset));
            var newend = centerpoint + (enddir * (radius + radiusoffset));
            return new Arc3D(newstart, newend, centerpoint, isCcw, planenormal);
        }

        public Arc3D GetTranslatedArc(Vector3D translation)
        {
            var result = new Arc3D();
            result.startpoint = this.startpoint + translation;
            result.endpoint = this.endpoint + translation;
            result.centerpoint = this.centerpoint + translation;
            result.radius = this.radius;
            result.isCcw = this.isCcw;
            result.islargearc = this.islargearc;
            result.anglediff = this.anglediff;
            result.planenormal = this.planenormal;
            result.invalid = this.invalid;
            return result;
        }

        public Arc3D GetTransformedArc(Matrix3D transform)
        {
            var result = new Arc3D();
            result.startpoint = transform.Transform(this.startpoint);
            result.endpoint = transform.Transform(this.endpoint);
            result.centerpoint = transform.Transform(this.centerpoint);
            result.radius = this.radius;
            result.isCcw = this.isCcw;
            result.islargearc = this.islargearc;
            result.anglediff = this.anglediff;
            result.planenormal = transform.Transform(this.planenormal);
            result.invalid = this.invalid;
            return result;
        }

        public IList<Point3D> GetDecomposedPoints(double precisionangle = 10.0)
        {
            var result = new List<Point3D>() { startpoint };

            var vstart = startpoint - centerpoint;
            var vend = endpoint - centerpoint;
            var angle = Math.Abs(Vector3D.AngleBetween(vstart, vend));
            if (islargearc)
                angle += 180.0;

            var nrofpoints = Math.Ceiling(angle / precisionangle);
            var anglestep = angle / nrofpoints;
            for (int i = 1; i <= nrofpoints; i++)
            {
                var rotation = i * anglestep;
                var vinsert = Math3D.RotateVector(vstart, planenormal, rotation * (isCcw ? 1:-1));
                result.Add(centerpoint + vinsert);
            }
            return result;
        }

        public override void Translate(Vector3D vector)
        {
            this.startpoint = this.startpoint + vector;
            this.endpoint = this.endpoint + vector;
            this.centerpoint = this.centerpoint + vector;
        }

        public override void Transform(Matrix3D matrix)
        {
            this.startpoint = matrix.Transform(this.startpoint);
            this.endpoint = matrix.Transform(this.endpoint);
            this.centerpoint = matrix.Transform(this.centerpoint);
            this.planenormal = matrix.Transform(this.planenormal);
        }

        private Arc3D()
        {

        }

        public Arc3D(Point3D startpoint, Point3D endpoint, Point3D centerpoint, bool isCcw, Vector3D planenormal)
        {

            //Initialize data
            this.startpoint = startpoint;
            this.endpoint = endpoint;
            this.centerpoint = centerpoint;
            this.isCcw = isCcw;
            this.planenormal = planenormal;

            //Calculate all other data
            UpdateFromCenterPoint();
        }


        public Arc3D(Point3D startpoint, Point3D endpoint, Double radius, bool isCcw, Boolean islargearc, Vector3D planenormal)
        {

            //Initialize data
            this.startpoint = startpoint;
            this.endpoint = endpoint;
            this.radius = radius;
            this.isCcw = isCcw;
            this.planenormal = planenormal;
            this.islargearc = islargearc;

            //Calculate all other data
            UpdateFromRadiusAndLargeArc();

        }

    }
}