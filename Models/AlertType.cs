using System;
using System.ComponentModel.DataAnnotations;
using SiteSafe4.Models;

namespace SiteSafe4.Models
{
    public enum AlertType
    {
        PPEViolation = 1,
        FatigueDetected = 2,
        CameraOffline = 3
    }
}
