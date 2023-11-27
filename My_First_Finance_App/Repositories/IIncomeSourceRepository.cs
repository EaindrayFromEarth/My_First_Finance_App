using My_First_Finance_App.Models;

namespace My_First_Finance_App.Repositories
{
    public interface IIncomeSourceRepository
    {
        void AddIncomeSource(IncomeSource incomeSource);
        void DeleteIncomeSource(int incomeSourceId);
        IEnumerable<IncomeSource> GetAllIncomeSources();
        IncomeSource GetIncomeSourceById(int incomeSourceId);
        void UpdateIncomeSource(IncomeSource incomeSource);
    }
}