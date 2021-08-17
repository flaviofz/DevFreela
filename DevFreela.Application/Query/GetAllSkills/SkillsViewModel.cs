namespace DevFreela.Application.Query.GetAllSkills
{
    public class SkillsViewModel
    {
        public SkillsViewModel(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
