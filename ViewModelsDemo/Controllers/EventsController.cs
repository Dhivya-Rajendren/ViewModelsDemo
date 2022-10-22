using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ViewModelsDemo.Models;
using ViewModelsDemo.ViewModels;

namespace ViewModelsDemo.Controllers
{
    public class EventsController : Controller
    {
        static List<Speaker> speakerList = new List<Speaker>()
        {
            new Speaker(){SpeakerId=1,SpeakerName="Aabha",Rating=4.7F,Email="Aabha@cloudKampus.com"},
            new Speaker(){SpeakerId=2,SpeakerName="Dhivya",Rating=4.5F,Email="Dhivya@cloudKampus.com"}
        };
        static List<Event> events = new List<Event>()
        {
            new Event(){EventId=1,EventName="Webniar on .Net Core MVC",EventType="Webniar",Location="Chennai",SpeakerId=1},
            new Event(){EventId=2,EventName="Seminar on Front-end Frameworks",EventType="Seminar",Location="Bangalore",SpeakerId=2}
        };

        public IActionResult Index()
        {
            List<EventViewModel> viewModels = new List<EventViewModel>();
            foreach (var item in events)
            {
                EventViewModel viewModel = new EventViewModel();
                viewModel.Speaker = speakerList.Find(e => e.SpeakerId == item.SpeakerId).SpeakerName;
                viewModel.Event = item;
                viewModel.EventDate = "24-10-2022";
                viewModels.Add(viewModel);


            }


            return View(viewModels);
        }

        List<SelectListItem> SpeakerEmail = new List<SelectListItem>();
    public IActionResult Create()
        {
            EventViewModel viewModel = new EventViewModel();
            foreach (var item in speakerList)
            {

                SpeakerEmail.Add(new SelectListItem() { Text = item.Email, Value = item.Email });
            }
            viewModel.SpeakerEmails = SpeakerEmail;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(EventViewModel viewModel)
        {
            string s = viewModel.Speaker;
            Speaker speaker = speakerList.Find(r => r.Email.Equals(s, System.StringComparison.OrdinalIgnoreCase)); ;
            Event e = viewModel.Event;
         e.SpeakerId = speaker.SpeakerId;
            events.Add(e);
            return RedirectToAction("Index");
        }
    
    }
}
