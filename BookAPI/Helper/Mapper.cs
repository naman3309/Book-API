using AutoMapper;
using BookAPI.Data;
using BookAPI.Models;

namespace BookAPI.Helper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Books,BookModel>().ReverseMap();
        }

    }
}
