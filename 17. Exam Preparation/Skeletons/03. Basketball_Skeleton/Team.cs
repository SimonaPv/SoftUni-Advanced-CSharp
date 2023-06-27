using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
        }

        public List<Player> Players { get; set; } = new List<Player>();
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get { return this.Players.Count; } }

        public string AddPlayer(Player player)
        {
            if (this.OpenPositions > 0)
            {
                if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
                {
                    return "Invalid player's information.";
                }
                else if (player.Rating < 80)
                {
                    return "Invalid player's rating.";
                }
                else
                {
                    Players.Add(player);
                    this.OpenPositions--;
                    return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
                }
            }
            else
            {
                return "There are no more open positions.";
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = Players.FirstOrDefault(x => x.Name == name);
            if (player == null) { return false; }
            else
            {
                this.OpenPositions++;
                Players.Remove(player);
                return true;
            }
        }

        public int RemovePlayerByPosition(string position)
        {
            int c = Players.RemoveAll(x => x.Position == position);
            this.OpenPositions += c;

            if (c == 0)
            {
                return 0;
            }
            else
            {
                return c;
            }
        }

        public Player RetirePlayer(string name)
        {
            Player player = Players.FirstOrDefault(x => x.Name == name);
            if (player == null) { return null; }
            else
            {
                player.Retired = true;
                return player;
            }
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> list = Players.FindAll(x => x.Games >= games);
            return list;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach (var item in Players.Where(x => x.Retired == false))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
