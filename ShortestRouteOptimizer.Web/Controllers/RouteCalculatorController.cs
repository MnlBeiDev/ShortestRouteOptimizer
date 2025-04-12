using ShortestRouteOptimizer.Core.Interfaces;
using ShortestRouteOptimizer.Data;
using ShortestRouteOptimizer.Web.ViewModels;
using System.Web.Mvc;

public class RouteCalculatorController : Controller
{
    private readonly IRouteCalculatorService _routeCalculatorService;

    public RouteCalculatorController(IRouteCalculatorService routeCalculatorService)
    {
        _routeCalculatorService = routeCalculatorService;
        //_pathCalculator = ;
    }
    public ActionResult Index() 
    {
        ViewBag.Title = "Shortest Route Optimizer";

        return View(new RouteInputViewModel());   
    }

    [HttpPost]
    public ActionResult CalculateRouteDistance(RouteInputViewModel model)
    {
        if (!ModelState.IsValid)
        {
            //ModelState.AddModelError("", "Invalid input. Please check your data.");
            return View("Index", model);
        }
        var graph = SampleGraphData.GetNodes(); // Predefined list of nodes
        var result = _routeCalculatorService.GetShortestPath(model.From, model.To, graph);

        model.ResultPath = string.Join(", ", result.NodeNames);
        model.TotalDistance = result.Distance;

        return View("Index", model);
    }
}
