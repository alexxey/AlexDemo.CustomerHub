﻿namespace AlexDemo.CustomerHub.Core.Application.Responses
{
    public class BaseCommandResponse
    {
        public bool IsSuccessful { get; set; } = true;

        public string Message { get; set; }

        public List<ResponseMessageModel> Data {get; set;}
    }

    public class BaseCreateCommandResponse<T> : BaseCommandResponse
    {
        public T Id { get; set; }
    }
}
