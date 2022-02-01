using System;
using static System.String;

namespace TestNinja.Fundamentals
{
    public class PhoneNumber
    {
        private string Area { get; }
        private string Major { get; }
        private string Minor { get; }

        private PhoneNumber(string area, string major, string minor)
        {
            Area = area;
            Major = major;
            Minor = minor;
        }
        
        public static PhoneNumber Parse(string number)
        {
            if (IsNullOrWhiteSpace(number))
                throw new ArgumentException("Phone number cannot be blank.");
            
            if (number.Length != 10)
                throw new ArgumentException("Phone number should be 10 digits long.");

            string area = number.Substring(0, 3);
            string major = number.Substring(3, 3);
            string minor = number.Substring(6);
            return new PhoneNumber(area, major, minor);
        }

        public override string ToString()
        {
            return Format($"({Area}){Major}-{Minor}");
        }
    }
}