using Client.Models;

namespace Api.ServiceModels
{
    public class NewTaskForm
    {
        public string AircraftId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Staus { get; set; }
    }
}