using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Model
{
    public class CurrentYear
    {
        [Key]
        public int Id 
        { get;
           set;
        }
        public string? Employee_name
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        
        public DateTime Intime
        {
            get;
                set;
        } 
        public DateTime Outtime
        {
            get;
            set;
        }
        public string? Status
        {
            get; set;
        }
        public  DateTime Hourly
        {
            get;
                set;
        }
       
    }
}
