using System;
using System.Collections.Generic;
using System.Text;

namespace PomiaryRzeszow
{
        public class So2IndexLevel
        {
            public int id { get; set; }
            public string indexLevelName { get; set; }
        }

        public class CoIndexLevel
        {
            public int id { get; set; }
            public string indexLevelName { get; set; }
        }

        public class Pm10IndexLevel
        {
            public int id { get; set; }
            public string indexLevelName { get; set; }
        }

        public class O3IndexLevel
        {
            public int id { get; set; }
            public string indexLevelName { get; set; }
        }


        public class ApiResponse
        {
            public int id { get; set; }
            public object so2CalcDate { get; set; }
            public So2IndexLevel so2IndexLevel { get; set; }
            public string so2SourceDataDate { get; set; }
            public string coCalcDate { get; set; }
            public CoIndexLevel coIndexLevel { get; set; }
            public string coSourceDataDate { get; set; }
            public string pm10CalcDate { get; set; }
            public Pm10IndexLevel pm10IndexLevel { get; set; }
            public string pm10SourceDataDate { get; set; }   
            public string o3CalcDate { get; set; }
            public O3IndexLevel o3IndexLevel { get; set; }
            public string o3SourceDataDate { get; set; }         
            public bool stIndexStatus { get; set; }
            public string stIndexCrParam { get; set; }
        }
    }
