using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestRouteOptimizer.Core.DTOs;
using ShortestRouteOptimizer.Core.Interfaces;
using ShortestRouteOptimizer.Data;
using ShortestRouteOptimizer.Services;
using System.Collections.Generic;

namespace ShortestRouteTests
{
    [TestClass]
    public class RouteCalculatorTest
    {
        private Autofac.IContainer _container;
        private List<Node> graph = new List<Node>();

        [TestInitialize]
        public void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RouteCalculatorService>().As<IRouteCalculatorService>();
            _container = builder.Build();

            graph = SampleGraphData.GetNodes();
        }


        [TestMethod]
        public void ShortestPath_From_A_To_D_Returns_Correct_Path()
        {
            var calculator = _container.Resolve<IRouteCalculatorService>();
            var result = calculator.GetShortestPath("A", "D", graph);

            CollectionAssert.AreEqual(new List<string> { "A", "C", "D" }, result.NodeNames);
            Assert.AreEqual(14, result.Distance);
        }

        [TestMethod]
        public void ShortestPath_From_A_To_B_Returns_Correct_Path()
        {
            var calculator = _container.Resolve<IRouteCalculatorService>();
            var result = calculator.GetShortestPath("A", "B", graph);

            CollectionAssert.AreEqual(new List<string> { "A", "B" }, result.NodeNames);
            Assert.AreEqual(4, result.Distance);
        }

        [TestMethod]
        public void ShortestPath_From_A_To_F_Returns_Correct_Path()
        {
            var graph = SampleGraphData.GetNodes();
            var calculator = _container.Resolve<IRouteCalculatorService>();
            var result = calculator.GetShortestPath("A", "F", graph);

            CollectionAssert.AreEqual(new List<string> { "A", "B","F" }, result.NodeNames);
            Assert.AreEqual(6, result.Distance);
        }
    }
}
