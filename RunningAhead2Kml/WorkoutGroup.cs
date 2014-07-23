using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAhead2Kml
{
    public class WorkoutGroup
    {
        public string name { get; set; }
        public int lineWeight { get; set; }
        public Color lineColor { get; set; }
        public int opacityPercent { get; set; }
        public bool exportGroup { get; set; }

        public WorkoutGroup()
        {

        }

        public WorkoutGroup(string name, int lineWeight, Color lineColor, int opacityPercent, bool export)
        {
            this.name = name;
            this.lineWeight = lineWeight;
            this.lineColor = lineColor;
            this.opacityPercent = opacityPercent;
            this.exportGroup = export;
        }
    }
}
