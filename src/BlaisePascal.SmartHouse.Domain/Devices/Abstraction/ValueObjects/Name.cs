namespace BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects
{
    public sealed record Name
    {
        public string Value { get; init; }

        private Name(string name)
        {
            Value = name;
        }

        public static Name CreateNew(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace");

            return new Name(name);
        }

        public static bool operator ==(Name name, string value)
        {
            return name.Value == value;
        }

        public static bool operator !=(Name name, string value)
        {
            return name.Value != value;
        }
    }
}
