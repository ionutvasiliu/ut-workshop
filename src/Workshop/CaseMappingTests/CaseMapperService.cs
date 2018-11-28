using System.Linq;

namespace CaseMappingTests
{
    public class CaseMapperService
    {
        public CaseModel CreateMapping(Case inputCase)
        {
            if (string.IsNullOrWhiteSpace(inputCase.Reference) ||
                string.IsNullOrWhiteSpace(inputCase.Person.Name) ||
                inputCase.Financials == null ||
                !inputCase.Financials.Any())
            {
                return null;
            }

            var caseModel = new CaseModel();
            caseModel.Reference = $"AP-{inputCase.Reference}";

            return caseModel;
        }
    }
}