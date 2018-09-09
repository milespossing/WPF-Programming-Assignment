namespace ProgrammingAssignment.Models
{
    /// <summary>
    /// Drug Model
    /// <discusion>
    /// I thought about including the amount of the drug here, but decided against it
    /// In the future it could be necessary to add even more information to the drug which
    /// would then require bringing a lot of info out of the table. So for now I'll leave
    /// Drug as a simple class with the only Property given in case we decide to add to it later
    /// </discusion>
    /// </summary>
    public class Drug
    {
        public string Name { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public Drug()
        {

        }

        /// <summary>
        /// this is the method
        /// </summary>
        /// <param name="name">this is the name</param>
        public Drug(string name)
        {
            Name = name;
        }
    }
}