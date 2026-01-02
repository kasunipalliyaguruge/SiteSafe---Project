using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteSafe4.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteSafe4.Services
{
    public interface IAlertService
    {
        Task CreateAlertAsync(Alert alert);
    }

}

