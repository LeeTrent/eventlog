using System;
using lmsextreg.Data;
using lmsextreg.Models;
using lmsextreg.Repositories;

namespace lmsextreg.Services
{
    public class EventLogService : IEventLogService
    {
        private readonly IEventLogRepository _eventLogRepository;

        public EventLogService(IEventLogRepository eventLogRepo)
        {
            _eventLogRepository = eventLogRepo;
        }

        public void LogEvent(string eventTypeCode, ApplicationUser appUser)
        {
            var eventLog = new EventLog
            {
                EventTypeCode   = eventTypeCode,
                UserCreatedID   = appUser.Id,
                UserCreatedName = appUser.UserName,
                DataValues = "user=" + appUser.ToString(),
                DateTimeCreated = DateTime.Now
            };

            _eventLogRepository.Add(eventLog);
        }
    }
}