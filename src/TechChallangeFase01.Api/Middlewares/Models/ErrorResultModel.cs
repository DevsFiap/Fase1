﻿using Newtonsoft.Json;

namespace TechChallangeFase01.Api.Middlewares.Models;

public class ErrorResultModel
{
    public int? StatusCode { get; set; }
    public string? Message { get; set; }

    public override string ToString() 
        => JsonConvert.SerializeObject(this);
}