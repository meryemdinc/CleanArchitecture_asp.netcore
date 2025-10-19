//Result Pattern Implementation

using System.Net;

namespace App.Services
{
    public class ServiceResult<T>//<T> ALICAK BAŞARILI OLDUĞUNDA <T> DÖNÜCEK
    {

        public T? Data { get; set; }//başarılı olursa data dönecek,başarısız olursa null dönecek
        //birden fazla hata olabileceği için liste kullandık,bir hata olsaydı sadece string yazardık
        public List<string>? ErrorMessage { get; set; }//başarılı olursa null döneceği için ?nullable,
                                                       //başarısız olursa bu kısım dolacak
        [JsonIgnore]
        public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;

        [JsonIgnore]
        public bool IsFailed => !IsSuccess;//ileride fail durumları için !isSuccess kullanmaktansa şimdi IsFailed oluşturalım

        [JsonIgnore]
        public HttpStatusCode Status { get; set; }
        //static factory method
       
        public static ServiceResult<T> Success(T data,HttpStatusCode status=HttpStatusCode.OK)
        {
            return new ServiceResult<T> { Data = data, Status=status };
        }
        //birden fazla hata varsa kullanmak için
       
        public static ServiceResult<T> Fail(List<string> errorMessage,HttpStatusCode status=HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T> { ErrorMessage = errorMessage , Status= status };
        }

        //tek bir hata mesajı olduğunda kolaylık sağlaması için overload yapalım
        public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T> { ErrorMessage = [errorMessage], Status=status };
        }

    }
    //ProdutService'deki update delete gibi durumlarda geriye data dönmeyeceğimiz için bunu yazıyoruz
    public class ServiceResult
    {
        public List<string>? ErrorMessage { get; set; }//başarılı olursa null döneceği için ?nullable,
        [JsonIgnore]                                            //başarısız olursa bu kısım dolacak
        public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;

        [JsonIgnore]
        public bool IsFailed => !IsSuccess;//ileride fail durumları için !isSuccess kullanmaktansa şimdi IsFailed oluşturalım

        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        //static factory method
        public static ServiceResult Success( HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult { Status = status };
        }
        //birden fazla hata varsa kullanmak için
        public static ServiceResult Fail(List<string> errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult{ ErrorMessage = errorMessage, Status = status };
        }

        //tek bir hata mesajı olduğunda kolaylık sağlaması için overload yapalım
        public static ServiceResult Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult { ErrorMessage = [errorMessage], Status = status };
        }

    }
}
//çalıştırıldığında response body'de sadece data veya errorMessage olacak,status kodu headerda olacak