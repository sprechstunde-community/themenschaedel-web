using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Themenschaedel.Web.Shared
{
    public partial class NavbarBase : ComponentBase
    {
        private readonly ILogger<NavbarBase> _logger;

        public NavbarBase(ILogger<NavbarBase> logger)
        {
            _logger = logger;
        }
        
        public void OnSentryClick()
        {
            _logger.LogDebug("LEBUTTON!!!");
        }
    }
}