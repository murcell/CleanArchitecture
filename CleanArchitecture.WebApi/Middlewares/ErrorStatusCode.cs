using Newtonsoft.Json;


namespace CleanArchitecture.WebApi.Middlewares;

public  class ErrorStatusCode
{
    public int StatusCode { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }

}

