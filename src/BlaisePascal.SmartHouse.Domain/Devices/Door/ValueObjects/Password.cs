using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Door.ValueObjects
{
    public sealed record Password
    {
        public string value { get; init; }
        private Password(string password)
        {
            value = password;
        }
        public static Password CreateNew(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty or whitespace");
            return new Password(password);
        }

        public static bool operator ==(Password password, string value)
        {
            return password.value == value;

        }
        public static bool operator !=(Password password, string value)
        {
            return password.value != value;
        }
    }
}
