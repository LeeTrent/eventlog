using lmsextreg.Data;
using lmsextreg.Models;
using lmsextreg.Constants;

namespace lmsextreg.Services
{
    public interface IEventLogService
    {
        void LogEvent(string eventTypeCode, ApplicationUser appUser);
    }
}