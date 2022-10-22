using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ViewModelsDemo.Models;

namespace ViewModelsDemo.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }

        public List<SelectListItem> SpeakerEmails { get; set; }
        public string Speaker { get; set; }
        public string EventDate { get; set; }
    }
}
