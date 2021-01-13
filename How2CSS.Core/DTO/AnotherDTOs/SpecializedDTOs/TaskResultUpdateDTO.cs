using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.DTO.AnotherDTOs.SpecializedDTOs
{
    public class TaskResultUpdateDTO
    {
        public int Id { get; set; }
        public long Duration { get; set; }
        public string UserAnswer { get; set; }
        public int Score { get; set; }
    }
}
