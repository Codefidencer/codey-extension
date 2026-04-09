namespace Codey.Extension.Models
{
    public class Exercise
    {
        public string   Title          { get; set; }
        public string   Description    { get; set; }
        public string   Level          { get; set; }
        public string   Concept        { get; set; }
        public string   StarterCode    { get; set; }
        public string   ExpectedOutput { get; set; }
        public string   Solution       { get; set; }
        public string[] Hints          { get; set; }
    }
}
