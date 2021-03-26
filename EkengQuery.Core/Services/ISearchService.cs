using System.Collections.Generic;

namespace EkengQuery.Core
{
    public interface ISearchService
    {
        List<ApplicantModel> GetResultWithOutPassport(string firstName, string lastName);
        List<ApplicantModel> GetResultWithPassport(string firstName, string lastName, string passport);
    }
}
