using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(BookStoreDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = context;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(author => author.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Invalid Id because Author is not found");
            }

            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);
            return vm;
        }
    }
}
