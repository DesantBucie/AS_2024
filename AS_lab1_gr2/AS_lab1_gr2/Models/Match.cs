﻿namespace AS_lab1_gr2.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; } = string.Empty;
        // 0..1 *
        public virtual ICollection<Article>? Articles { get; set; }
        // 1 *
        public virtual ICollection<MatchEvent>? MatchEvents { get; set; }
        // 1 *
        public virtual ICollection<MatchPlayer>? MatchPlayers { get; set; }
        
    }
}