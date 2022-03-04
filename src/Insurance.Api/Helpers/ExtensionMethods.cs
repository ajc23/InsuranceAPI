using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Insurance.Api.Helpers
{
    public static class ExtensionMethods
    {
        public static HttpResponseMessage AsHttpResponseMessage<T>(this T model, HttpStatusCode statusCode)
        {
            return new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
            };
        }

        public static HttpResponseMessage AsHttpResponseMessage(this ValidationResult validator)
        {
            return new HttpResponseMessage
            {
                StatusCode = (HttpStatusCode)422,
                Content = new StringContent(JsonConvert.SerializeObject(validator.Errors.Select(x => x.ErrorMessage)), Encoding.UTF8, "application/json")
            };
        }

        public static bool IsNullEmptyOrWhiteSpace(this string value)
        {
            return String.IsNullOrEmpty(value) || value.Trim().Length == 0;
        }
    }
}