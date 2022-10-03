﻿namespace GetSplashUpData.Models.Response
{
    public class Response<TData>
    {
        public TData Data { get; set; }

        public Response(TData data)
        {
            Data = data;
        }
    }
}
