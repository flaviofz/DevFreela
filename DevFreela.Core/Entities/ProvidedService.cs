using DevFreela.Core.Enums;
using System;

namespace DevFreela.Core.Entities
{
    public class ProvidedService : BaseEntity
    {
        public ProvidedService(
            string title, 
            string description, 
            int idClient, 
            int idFreelancer,
            decimal totalCost
        )
        {
            Title = title;
            Description = description;            
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
            CreatedAt = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int IdClient { get; private set; }        
        public int IdFreelancer { get; private set; }        
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }

        public EStatusProvidedService Status { get; private set; }
        public User Freelancer { get; set; }
        public User Client { get; set; }

    }
}
