using Newtonsoft.Json;
using SmartiePants.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartiePants.Core.Resources
{
    [JsonConverter(typeof(TargetJsonConverter))]
    public class TargetDto
    {
        public int Value { get; set; }
    }
}