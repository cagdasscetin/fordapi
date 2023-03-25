﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FordApi.Dto;

public class TokenResponse
{
    [Display(Name = "Expire Time")]
    public DateTime ExpireTime { get; set; }

    [Display(Name = "Access Token")]
    public string AccessToken { get; set; }

    public string Role { get; set; }
    public string UserName { get; set; }
}
