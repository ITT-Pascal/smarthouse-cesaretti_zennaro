using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Door.ValueObjects
{
    public sealed record Password
    {
        public string Value { get; init; }
        private Password(string password)
        {
            Value = password;
        }
        public static Password CreateNew(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty or whitespace");
            return new Password(password);
        }

        public static bool operator ==(Password password, string value)
        {
            return password.Value == value;

        }
        public static bool operator !=(Password password, string value)
        {
            return password.Value != value;
        }
    }
}
