namespace VineSharp.Models
{
    /// <summary>
    /// Object to represent an on the vine network, this includes HashTags
    /// It appears like the twitter guys have got a hold of this.
    /// </summary>
    public class VineEntity
    {
        public string Link { get; set; }
        public int[] Range { get; set; }
        public string Type { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
