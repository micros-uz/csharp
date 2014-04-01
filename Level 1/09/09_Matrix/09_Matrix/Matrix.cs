namespace _09_Matrix
{
    internal class Matrix
    {
        public int A { get; set; }
        public int A1 { get; set; }
        public int B { get; set; }
        public int B1 { get; set; }

        public override string ToString()
        {
            return string.Format("Matrix: {0} {1} {2} {3}", A, A1, B, B1);
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return new Matrix
            {
                A = m1.A + m2.A,
                A1 = m1.A1 + m2.A1,
                B = m1.B + m2.B,
                B1 = m1.B1 + m2.B1
            };
        }

        public static Matrix operator++ (Matrix m1)
        {
            m1.A++;
            m1.A1++;
            m1.B++;
            m1.B1++;

            return m1;
            //return new Matrix
            //{
            //    A = m1.A++,
            //    A1 = m1.A1++,
            //    B = m1.B++,
            //    B1 = m1.B1++
            //};
        }

        public static implicit operator int(Matrix m)
        {
            return m.A + m.A1 + m.B + m.B1;
        }

        public static explicit operator Matrix(int n)
        {
            return new Matrix { A = n };
        }

        public static Matrix operator == (Matrix m1, Matrix m2)
        {
            return m1;
        }

        public static Matrix operator !=(Matrix m1, Matrix m2)
        {
            return m1;
        }
    }
}
