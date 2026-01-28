namespace BlaisePascal.SmartHouse.Domain.Abstraction
{
    public sealed record Name
    {
        public string name { get; init; }

        public Name(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name cannot be null, empty or with empty spaces");

            this.name = name;
        }

        public static Name CreateNew(string name)
        {
            return new Name(name);
        }
    }
}
