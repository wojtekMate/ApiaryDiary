﻿namespace ApiaryDiary.Shared.Infrastructure.Email;

public class EmailServiceOptions
{
    public string Account { get; set; }
    public string Password { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public bool UseDefaultCredentials { get; set; }
    public bool EnableSsl { get; set; }
    public string ActivationLink { get; set; }
}