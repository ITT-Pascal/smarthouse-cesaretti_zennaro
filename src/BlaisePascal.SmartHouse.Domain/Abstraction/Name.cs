namespace BlaisePascal.SmartHouse.Domain.Abstraction
{
    public sealed record Name
    {
        public string value { get; init; }

        private Name(string name)
        {
            this.value = name;
        }

        public static Name CreateNew(string name)
        {
            NameValidator.Validator(name);
            return new Name(name);
        }

        public static bool operator ==(Name name, string value)
        {
            return name.value == value;
        }

        public static bool operator !=(Name name, string value)
        {
            return name.value != value;
        }
    }
}
