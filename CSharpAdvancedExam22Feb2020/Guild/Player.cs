namespace Guild
{
    using System.Text;
    public class Player
    {
        public Player(string name, string inputClass)
        {
            Name = name;
            Class = inputClass;
            Rank = "Trial";
            Description = "n/a";
        }

        public string Name { get; private set; }
        public string Class { get; private set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.Append($"Description: {Description}");

            return sb.ToString();
        }
    }
}
