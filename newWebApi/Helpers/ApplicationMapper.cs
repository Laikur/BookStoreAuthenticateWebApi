using AutoMapper;
using newWebApi.Data;
using newWebApi.Model;

namespace newWebApi.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books,BookModel>().ReverseMap();
        }
    }
}
