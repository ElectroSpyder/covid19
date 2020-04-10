namespace Covid19.Web.Data
{
    using Covid19.Web.Data.Entities;

    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DataContext context) : base(context) { }
    }
}
