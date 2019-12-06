using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models.ViewModels
{
    public class RouteMachineView
    {

        public Route RouteRMV { get; set; }
        public Machine_Train MachineTrainRMV { get; set; }

    }
}