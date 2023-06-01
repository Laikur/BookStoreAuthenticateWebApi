using System.ComponentModel.DataAnnotations;

namespace newWebApi.Data
{
    public class Books
    {
        public int Id { get; set; }
       
        public string Title { get; set; }    
        public string Description { get; set; }
    }

}

