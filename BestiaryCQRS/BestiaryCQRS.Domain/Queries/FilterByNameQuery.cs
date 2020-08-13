using BestiaryCQRS.Domain.Core.Commands;

namespace BestiaryCQRS.Domain.Queries
{
    public class FilterByNameQuery : Command
    {
        public string Name { get; set; }

        public FilterByNameQuery(string name)
        {
            Name = name;

            Validate(this, new FilterByNameQueryValidator());
        }
    }
}