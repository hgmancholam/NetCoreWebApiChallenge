
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Movie.CreateMovie
{
    public interface ICreateMovie
    {
        Task CreateAsync(Domain.Movie model);
    }
}
