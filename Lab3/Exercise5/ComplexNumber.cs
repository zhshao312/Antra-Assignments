using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class ComplexNumber
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }

        ComplexNumber number1;
        public ComplexNumber(int real, int imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public void SetImaginary(int imaginary)
        {
            this.Imaginary = imaginary;
        }

        public void SetReal(int real)
        {
            this.Real = real;
        }

        public int GetImaginary()
        {
            return this.Imaginary;
        }

        public int GetReal()
        {
            return this.Real;
        }

        public new string ToString()
        {
           return $"({Real},{Imaginary})";
        }

        public int GetMagnitude() {

            return Convert.ToInt32(Math.Sqrt(Real * Real + Imaginary * Imaginary));
        }

        public void Add(ComplexNumber number)
        {
            Real = Real + number.Real;
            Imaginary = Imaginary + number.Imaginary;
        }
    }
}
