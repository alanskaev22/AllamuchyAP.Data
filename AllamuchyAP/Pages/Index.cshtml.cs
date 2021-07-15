using AllamuchyAP.DataAccess.Models;
using AllamuchyAP.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AllamuchyAP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IVehicleRepository _repository;

        public IndexModel(ILogger<IndexModel> logger, IVehicleRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
           

        }
    }
}
