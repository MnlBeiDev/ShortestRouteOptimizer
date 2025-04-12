using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShortestRouteOptimizer.Web.ViewModels
{
    public class RouteInputViewModel
    {
        [Required(ErrorMessage = "From node is required")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "From node must contain only letters")]
        public string From { get; set; }

        [Required(ErrorMessage = "To node is required")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "To node must contain only letters")]
        public string To { get; set; }

        public string ResultPath { get; set; }
        public int TotalDistance { get; set; }
    }
}