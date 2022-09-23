using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GetReportsFromBase
{
    internal class Report
    {
        public string ServerName { get { return _ServerName; } set { _ServerName = value; } }
        public string DbName { get { return _DbName; } set { _DbName = value; } }
        public string UserId { get { return _UserId; } set { _UserId = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public List<string> BaseList { get { return _BaseList; } set { _BaseList = value; } }

        public Report()
        {
        }
        public void GetReportData()
        {
            /*
            SELECT
	            rc.ctx_id,
	            rr.rpt_id,
	            rr.rpt_nazwa,
	            rs.szl_id,
	            rs.szl_nazwa--,
	            --rss.szl_stx_id,
	            --rss.szl_idpb, 
	            --rss.szl_syntax
            FROM 
	            rap_ctx rc
	            INNER JOIN rap_rpt rr on rr.ctx_id = rc.ctx_id --AND rr.rpt_nazwa = t.nazwa_rodzaju
	            INNER JOIN rap_szl rs on rs.rpt_id = rr.rpt_id --AND rs.szl_nazwa = t.nazwa_raportu
	            --INNER JOIN rap_szl_syntax rss on rss.szl_id = rs.szl_id
            ORDER BY rc.ctx_id, rr.rpt_id
            */
        }
    }
}
