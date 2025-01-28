using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

public class Valyuta
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Ccy { get; set; }
    public string CcyNm_RU { get; set; }
    public string CcyNm_UZ { get; set; }
    public string CcyNm_UZC { get; set; }
    public string CcyNm_EN { get; set; }
    //public string Nominal { get; set; } // Changed from int to string
    public decimal Rate { get; set; }
    public decimal Diff { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"{Ccy} ({CcyNm_EN}) - Rate: {Rate}, Diff: {Diff}, Date: {Date:dd.MM.yyyy}";
    }
}
//"id": 69,
//    "Code": "840",
//    "Ccy": "USD",
//    "CcyNm_RU": "Доллар США",
//    "CcyNm_UZ": "AQSH dollari",
//    "CcyNm_UZC": "АҚШ доллари",
//    "CcyNm_EN": "US Dollar",
//    "Nominal": "1",
//    "Rate": "12990.00",
//    "Diff": "5.56",
//    "Date": "23.01.2025"