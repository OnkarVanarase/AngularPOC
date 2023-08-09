namespace NestedExpansionPOC
{
    internal class AcronymExpansion
    {
        public long AcronymId { get; set; }

        public string Acronym { get; set; }

        public string Expansion { get; set; }

        public string NestedExpansion { get; set; }

        public DateTimeOffset LastUpdatedTime { get; set; }

        public long UserId { get; set; }
    }
}
