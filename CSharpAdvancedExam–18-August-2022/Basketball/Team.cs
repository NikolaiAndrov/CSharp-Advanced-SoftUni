using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new Dictionary<string, Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public Dictionary<string, Player> Players { get; set; }
        public int Count
        {
            get { return Players.Count; }
        }

        public string AddPlayer(Player player)
        {
            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Name == null || player.Name == string.Empty
                || player.Position == null || player.Position == string.Empty)
            {
                return "Invalid player's information.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            if (!Players.ContainsKey(player.Name))
            {
                Players.Add(player.Name, player);
                OpenPositions--;
            }
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            if (Players.ContainsKey(name))
            {
                Players.Remove(name);
                OpenPositions++;
                return true;
            }
            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = 0;

            foreach (var player in Players)
            {
                if (player.Value.Position == position)
                {
                    OpenPositions++;
                    count++;
                    Players.Remove(player.Key);
                }
            }

            return count;
        }

        public Player RetirePlayer(string name)
        {
            if (Players.ContainsKey(name))
            {
                Players[name].Retired = true;
                return Players[name];
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> list = new List<Player>();

            foreach (var player in Players)
            {
                if (player.Value.Games >= games)
                {
                    list.Add(Players[player.Key]);
                }
            }

            return list;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in Players)
            {
                if (!player.Value.Retired)
                {
                    sb.AppendLine(Players[player.Key].ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
