﻿namespace LoginAPI.Models
{
    public class BaseResponse
    {
        public byte Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
