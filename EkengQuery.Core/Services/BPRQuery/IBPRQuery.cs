using System.Threading.Tasks;

namespace EkengQuery.Core
{
    public interface IBPRQuery
    {
        Task<PassportWebServiceResponse> GetCitizenByPassport(string passportNumber);
        Task<SSNWebServiceResponse> GetCitizenBySSN(string ssn);
    }
}
