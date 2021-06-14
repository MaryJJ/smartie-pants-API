using Newtonsoft.Json.Linq;
using SmartiePants.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartiePants.Core.Helpers
{
    public class TargetJsonConverter : JsonCreationConverter<TargetDto>
    {
        protected override TargetDto Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("JObject");
            if (!string.IsNullOrEmpty(jObject["countryCodes"].ToString()))
            {
                return new EcpmTargetDto();
            }
            else
            {
                if (!string.IsNullOrEmpty(jObject["global"].ToString()))
                {
                    return new GlobalTargetDto();
                }
                else
                {
                    return new TargetDto();
                }
            }
        }
    }
}