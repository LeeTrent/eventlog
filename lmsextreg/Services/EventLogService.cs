using System;
using System.Text;
using lmsextreg.Data;
using lmsextreg.Models;
using lmsextreg.Repositories;

namespace lmsextreg.Services
{
    public class EventLogService : IEventLogService
    {
        private readonly IEventLogRepository _eventLogRepository;
        private readonly IProgramEnrollmentRepository _programEnrollmentRepository;

        public EventLogService
        (
            IEventLogRepository eventLogRepo,
            IProgramEnrollmentRepository programEnrollmentRepo
        )
        {
            _eventLogRepository             = eventLogRepo;
            _programEnrollmentRepository    = programEnrollmentRepo;
        }

        public void LogEvent(string eventTypeCode, ApplicationUser appUser)
        {
            var eventLog = new EventLog
            {
                EventTypeCode   = eventTypeCode,
                UserCreatedID   = appUser.Id,
                UserCreatedName = appUser.UserName,
                DataValues = "User=" + appUser.ToString(),
                DateTimeCreated = DateTime.Now
            };

            _eventLogRepository.Add(eventLog);
        }

        public void LogEvent(string eventTypeCode, ApplicationUser appUser, ProgramEnrollment enrollment)
        {
            var sb = new StringBuilder();
            sb.Append("User=");
            sb.Append(appUser.ToString());
            sb.Append("; ");
            sb.Append(enrollment.ToString());

            var eventLog = new EventLog
            {
                EventTypeCode   = eventTypeCode,
                UserCreatedID   = appUser.Id,
                UserCreatedName = appUser.UserName,
                DataValues = sb.ToString(),
                DateTimeCreated = DateTime.Now
            };

            _eventLogRepository.Add(eventLog);
        } 

        public void LogEvent(string eventTypeCode, ApplicationUser appUser, int programEnrollmentID)
        {
            var programEnrollment = _programEnrollmentRepository.Retrieve(programEnrollmentID);

            var sb = new StringBuilder();
            sb.Append("User=");
            sb.Append(appUser);
            sb.Append("; ");
            sb.Append(programEnrollment);

            var eventLog = new EventLog
            {
                EventTypeCode   = eventTypeCode,
                UserCreatedID   = appUser.Id,
                UserCreatedName = appUser.UserName,
                DataValues = sb.ToString(),
                DateTimeCreated = DateTime.Now
            };

            _eventLogRepository.Add(eventLog);
        }                
    }
}