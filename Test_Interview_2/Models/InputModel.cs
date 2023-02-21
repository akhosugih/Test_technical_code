using System.ComponentModel.DataAnnotations;

namespace Test_Interview_2.Models
{
    public class InputModel
    {
        [Range(0, long.MaxValue)]
        public long Input { get; set; }
    }
}
