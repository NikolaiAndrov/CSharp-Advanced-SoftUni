namespace Guild
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public int Count
        {
            get
            {
                return roster.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                roster.Remove(player);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    player.Rank = "Member";
                    break;
                }
            }
        }

        public void DemotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    player.Rank = "Trial";
                    break;
                }
            }
        }

        public Player[] KickPlayersByClass(string inputClass)
        {
            List<Player> list = new List<Player>();

            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Class == inputClass)
                {
                    list.Add(roster[i]);
                    roster.RemoveAt(i);
                    i--;
                }
            }

            return list.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (Player player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
